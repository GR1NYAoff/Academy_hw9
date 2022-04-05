using DesignPatterns.ChainOfResponsibility;
using Xunit;

namespace DesignPatterns.UnitTests
{
    public class StringMutatorTests
    {
        [Fact]
        public void StringMutatorsTest()
        {
            IStringMutator stringMutator1 = new ToUpperMutator();
            IStringMutator stringMutator2 = new InvertMutator();
            IStringMutator stringMutator3 = new RemoveNumbersMutator();
            IStringMutator stringMutator4 = new TrimMutator();

            _ = stringMutator1
                .SetNext(stringMutator2)
                .SetNext(stringMutator3)
                .SetNext(stringMutator4);

            var actual = stringMutator1.Mutate("    SOME 1 input 2 String 3");

            Assert.Equal("GNIRTS  TUPNI  EMOS", actual);
        }

        [Theory]
        [InlineData("123,456", ",")]
        [InlineData("123.456", ".")]
        [InlineData("some 123number", "some number")]
        [InlineData("123number", "number")]
        [InlineData("text with 01234567890 0987654321 number", "text with   number")]
        [InlineData("number123", "number")]
        public void RemoveNumbersMutatorTest(string input, string expectedResult)
        {
            IStringMutator stringMutator = new RemoveNumbersMutator();

            var actual = stringMutator.Mutate(input);

            Assert.Equal(expectedResult, actual);
        }

        [Fact]
        public void NullHandlingTest()
        {
            IStringMutator stringMutator = new ToUpperMutator();
            _ = Assert.Throws<ArgumentNullException>(() => stringMutator.Mutate(null!));

            stringMutator = new InvertMutator();
            _ = Assert.Throws<ArgumentNullException>(() => stringMutator.Mutate(null!));

            stringMutator = new RemoveNumbersMutator();
            _ = Assert.Throws<ArgumentNullException>(() => stringMutator.Mutate(null!));

            stringMutator = new TrimMutator();
            _ = Assert.Throws<ArgumentNullException>(() => stringMutator.Mutate(null!));
        }

        [Fact]
        public void SingleNextTest()
        {
            IStringMutator sut = new ToUpperMutator();
            IStringMutator stringMutator2 = new InvertMutator();
            IStringMutator stringMutator3 = new RemoveNumbersMutator();
            IStringMutator stringMutator4 = new TrimMutator();

            _ = sut.SetNext(stringMutator2);
            _ = sut.SetNext(stringMutator3);
            _ = sut.SetNext(stringMutator4);

            var actual = sut.Mutate("    some2345Text        ");

            Assert.Equal("SOME2345TEXT", actual);
        }
    }
}
