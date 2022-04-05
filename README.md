# Homework #9

Topics : Design Patterns, TDD, SOLID, generic host.
Prepared by: Maier Illia
## General requirements
### Application localization
User interaction **English only** and no transliteration.
Comments in the code forbidden.
When checking assignments, spelling will not be assessed.
## Tasks
### Task value
Task 1 - 80 points.
Task 2 - 20 points.
### Task 1\. Project development according to TDD.
It is necessary to finalize the project to a working state.
The project is being developed following the approach TDD (Test-Driven Development).
The task imitates the situation when the unit tests are already written, and the programmer needs to implement the software components.
A job is considered complete when all unit tests pass.
### Task 2\. Generic host for worker service.
Configure host to run hosted service as worker instance.
Add logging in json format(one log = one line).
Add service configuration from eviroment values, json file and command line arguments - in this priority.
Configure logging from json file(or other configuration source).
Add hosted service runnig.

## Project structure
At this stage, the project structure looks like:
- DesignPatterns - project with custom implementation of some patterns
	- Builder - folder with StringBuilder implementation
		- CustomStringBuilder - string builder implementation
		- ICustomStringBuilder - string builder interface. Allows you to build strings based on a chain of string elements.
	- ChainOfResponsibility - folder with string mutation classes.
		- InvertMutator - A string mutator that reverses the character order.
		- IStringMutator - string mutator interface. Allows you to build a pipeline (chain) of mutators.
		- RemoveNumbersMutator - A string mutator that removes numbers from a string.
		- ToUpperMutator - A string mutator that converts a string to uppercase.
		- TrimMutator - A string mutator that removes leading and trailing spaces in a string.
	- IoC - folder with IoC-container
		- IServiceCollection - service provider builder interface.
		- IServiceProvider - service provider (IoC container).
		- ServiceCollection - service provider builder. Does not contain references to specific class implementations.
		- ServiceProvider - implementation of a service provider (IoC-container). Does not contain references to specific class implementations.
		- SomeSecondTransient - demo service with lifetime Transient. **Cannot be changed!**
		- SomeSingleton- demo service with lifetime Singleton. **Cannot be changed!**
		- SomeTransient- demo service with lifetime Transient. **Cannot be changed!**
- DesignPatterns.UnitTests
	- CustomStringBuilderTests - String Builder tests.
	- IoCContainerTests - IoC container tests.
	- StringMutatorTests -string mutator tests.

**You cannot change the location of existing files.**

## Check list
Project checklist:
- [ ] Project should start as a worker service and run Worker hosted service
- [ ] ALL unit tests pass successfully in DesignPatterns.UnitTests
	- [ ] Passing tests successfully CustomStringBuilderTests
	- [ ] Passing tests successfully IoCContainerTests
	- [ ] Passing tests successfully StringMutatorTests
