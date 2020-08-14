# Introduction to Classes

The purpose of this exercise is to provide you the opportunity to define and use classes. The names of the classes, methods, and properties are specified in the Evaluation Criteria & Functional Requirements section.

## Learning Objectives

After completing this exercise, students will understand:

- How to create classes.
- How to create properties.
- How to manage the state of an object.
- How to limit access to properties through the use of [access modifiers][dot-net-access-modifiers].

## Evaluation Criteria & Functional Requirements

- The project must not have any build errors.
- Unit tests pass as expected.
- Appropriate variable names and data types are used.
- Code is presented in a clean, organized format.
- If a property does not have set marked, then it should be considered `private set`.
- The code meets the specifications defined below.

### Difficulty - Easy

#### Company

##### Constructors

| Signature | Description          |
| --------- | -------------------- |
| Company() | Default constructor. |

##### Class Properties

| Property Name     | Data Type | Get | Set | Description                             |
| ----------------- | --------- | --- | --- | --------------------------------------- |
| Name              | string    | X   | X   | The company name.                       |
| NumberOfEmployees | int       | X   | X   | The number of employees at the company. |
| Revenue           | decimal   | X   | X   | The annual revenue of the company.      |
| Expenses          | decimal   | X   | X   | The annual expenses of the company.     |

##### Methods

| Method Name      | Return Type | Description                                                                                                               |
| ---------------- | ----------- | ------------------------------------------------------------------------------------------------------------------------- |
| GetCompanySize() | string      | Returns "small" if less than 50 employees, "medium" if between 50 and 250 employees, "large" if greater than 250 employees. |
| GetProfit()      | decimal     | Returns the result of revenue - expenses.                                                                                 |

#### Person

##### Constructors

| Signature | Description          |
| --------- | -------------------- |
| Person()  | Default constructor. |

##### Class Properties

| Property Name | Data Type | Get | Set | Description                   |
| ------------- | --------- | --- | --- | ----------------------------- |
| FirstName     | string    | X   | X   | The first name of the person. |
| LastName      | string    | X   | X   | The last name of the person.  |
| Age           | int       | X   | X   | The age of the person.        |

##### Methods

| Method Name   | Return Type | Description                                                                                      |
| ------------- | ----------- | ------------------------------------------------------------------------------------------------ |
| GetFullName() | string      | Returns the first and last name of the person separated by a space. For instance, "Sonny Koufax". |
| IsAdult()     | bool        | Returns `true` if the person is 18 or older.                                                     |

#### Product

##### Constructors

| Signature | Description          |
| --------- | -------------------- |
| Product() | Default constructor. |

##### Class Properties

| Property Name  | Data Type | Get | Set | Description                            |
| -------------- | --------- | --- | --- | -------------------------------------- |
| Name           | string    | X   | X   | The name of the product.               |
| Price          | decimal   | X   | X   | The price of the product.              |
| WeightInOunces | double    | X   | X   | The weight (in ounces) of the product. |

### Difficulty - Medium

#### Dog

##### Constructors

| Signature | Description                                                 |
| --------- | ----------------------------------------------------------- |
| Dog()     | Default constructor. **All new dogs are awake by default.** |

##### Class Properties

| Property Name | Data Type | Get | Set | Description                                                                         |
| ------------- | --------- | --- | --- | ----------------------------------------------------------------------------------- |
| IsSleeping    | bool      | X   |     | `true` if the dog is asleep, `false` if not. **All new dogs are awake by default.** |

##### Methods

| Method Name | Return Type | Description                                                                       |
| ----------- | ----------- | --------------------------------------------------------------------------------- |
| MakeSound() | string      | Returns `"Zzzzz..."` if the dog is asleep. Returns `"Woof!"` if the dog is awake. |
| Sleep()     | void        | Sets `IsSleeping` to `true`.                                                      |
| WakeUp()    | void        | Sets `IsSleeping` to `false`.                                                     |

#### Shopping Cart

##### Constructors

| Signature      | Description          |
| -------------- | -------------------- |
| ShoppingCart() | Default constructor. |

##### Class Properties

| Property Name      | Data Type | Get | Set | Description                                                                              |
| ------------------ | --------- | --- | --- | ---------------------------------------------------------------------------------------- |
| TotalNumberOfItems | int       | X   |     | The number of items in the shopping cart. **All shopping carts have 0 items by default** |
| TotalAmountOwed    | decimal   | X   |     | The total for the shopping cart. **All shopping carts have 0.0 owed by default**         |

##### Methods

| Method Name                                       | Return Type | Description                                                                                      |
| ------------------------------------------------- | ----------- | ------------------------------------------------------------------------------------------------ |
| GetAveragePricePerItem()                          | decimal     | Returns the result of `TotalAmountOwed / TotalNumberOfItems`.                                    |
| AddItems(int numberOfItems, decimal pricePerItem) | void        | Updates `TotalNumberOfItems` and increases `TotalAmountOwed` by `(pricePerItem * numberOfItems)` |
| Empty()                                           | void        | Resets `TotalNumberOfItems` and `TotalAmountOwed` to 0.                                          |

### Difficulty - Difficult

#### Calculator

##### Constructors

| Signature    | Description                                                        |
| ------------ | ------------------------------------------------------------------ |
| Calculator() | Default constructor. All calculators have 0 for Result by default. |

##### Class Properties

| Property Name | Data Type | Get | Set | Description                   |
| ------------- | --------- | --- | --- | ----------------------------- |
| Result        | int       | X   |     | The current calculated value. |

##### Methods

| Method Name              | Return Type | Description                                                                                                                     |
| ------------------------ | ----------- | ------------------------------------------------------------------------------------------------------------------------------- |
| Add(int addend)          | int         | Adds `addend` to `Result` and returns the current value of `Result`.                                                            |
| Multiply(int multiplier) | int         | Multiplies current result by `multiplier` and returns the current value of `Result`.                                            |
| Power(int exponent)      | int         | Raises `Result` to power of `exponent`. Negative exponents should use the absolute value. Returns the current value of `Result` |
| Reset()                  | void        | Resets `Result` to 0.                                                                                                           |
| Subtract(int subtrahend) | int         | Subtracts `subtrahend` from the current value of `Result` and returns the current value of `Result`.                            |

## Getting Started

- Open the introduction-to-classes-exercise.sln solution in Visual Studio.
- Click on the **Test -> Run -> All Tests** Menu.
- Click on the **Test Explorer** tab to see the results of your tests and which passed/failed.
- Provide enough code to get a test passing.
- Repeat until all tests are passing.

## Tips and Tricks

- **Note: If you find yourself stuck on a problem for longer than fifteen minutes, move onto the next, and try again later.**
- In this exercise, you'll be provided with a series of specification for classes you need to create. Each class comes with its own challenge and nuance, and you may find that some of these classes are more challenging than others to implement.
- In this exercise, create the classes specified in the requirements section of this document. The unit tests you run verify if you have defined the classes correctly. As you work on creating the classes, be sure to run the tests, and then provide enough code to pass the test. For instance, if you are working on the `Product` class, provide enough code to get one of the Product tests passing. Focusing on getting a single test to pass at a time saves a lot of time, as this forces you to only focus on what is important for the test you're currently working on. This is commonly referred to as **[Test Driven Development][introduction-to-test-driven-development]**, or **TDD**.
- What happens if you don't define any [constructors][dot-net-constructors] in a class? Does your code still work as expected? Why or why not?
- When you provide an explicit constructor with arguments in a class, what happens to the default constructor (a constructor with no arguments)?
- While making the tests pass and adhering to the specification is all that is technically required for this exercise, you may also choose to gain additional practice by writing code in the Program.cs files for each of the projects. For example, you could instantiate an instance of your Calculator class in the CalculatorExercise/Program.cs file, and execute methods, printing out the results to the console.
- Be mindful of your [access modifiers][dot-net-access-modifiers].

---

[dot-net-access-modifiers]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/access-modifiers
[dot-net-constructors]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/constructors
[introduction-to-test-driven-development]: http://agiledata.org/essays/tdd.html
