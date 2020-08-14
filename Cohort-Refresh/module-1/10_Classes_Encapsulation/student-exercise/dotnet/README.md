# Encapsulation

In this exercise, you'll create the classes specified in the [requirements section](#Evaluation-Criteria-&-Functional-Requirements) of this document. The unit tests you run verify that you've defined the classes correctly.

## Learning objectives

After completing this exercise, you'll understand how to:

* Write code that's [loosely coupled][loose-coupling].
* Write code that appropriately hides the internal details of classes.
* Create readonly properties.
* Limit access to properties through the use of [access modifiers][dot-net-access-modifiers].
* Write [derived properties][derived-properties].

## Getting started

* Open the `oop-with-encapsulation-exercises.sln` solution in Visual Studio.
* Click on the **Test -> Run All Tests** menu option.
* Click on the **Test Explorer** tab to see the results of your tests and which ones passed/failed.

## Tips and tricks

* As you work on creating the classes, be sure to run the tests, and then provide enough code to pass the test. For instance, if you're working on the `HomeworkAssignment` class, provide enough code to get one of the `HomeworkAssignment` tests passing. 
* Focusing on getting a single test to pass at a time saves time, as this forces you to only focus on what's important for the test you're currently working on. This is commonly called **[Test Driven Development][introduction-to-test-driven-development]**, or **TDD**.
* Be mindful of your [access modifiers][dot-net-access-modifiers].
* Keep in mind that a **loosely coupled** system is one in which each of its components has, or makes use of, little or no knowledge of the definitions of other separate components. One of your goals as a developer should be to write code that's loosely coupled.

> Note: If you find yourself stuck on a problem for longer than fifteen minutes, move onto the next, and try again later.

## Evaluation criteria and functional requirements

* The project must not have any build errors.
* All unit tests pass as expected.
* Appropriate variable names and data types are used.
* Code is presented in a clean, organized format.
* Code is appropriately encapsulated.
* The code meets the specifications defined below.

**Notes for all classes**

- X in the set column indicates it **must have a `set` accessor**.
- Nothing in the set column indicates the property is a [derived property][derived-properties].
- Readonly properties don't require a `set` accessor. They're set from the class's constructor.
- Private setters require the property to have `private set`.

### Step One: Create `HomeworkAssignment.cs`

#### Properties

| Property      | Data Type | Get | Set      | Description                                                                          |
| ------------- | --------- | --- | -------- | -------------------------------------------------------------------------------------|
| EarnedMarks   | int       | X   | X        | Gets or sets the total number of correct marks submitter received on the assignment. |
| PossibleMarks | int       | X   | readonly | Gets the number of possible marks on the assignment.                                 |
| SubmitterName | string    | X   | readonly | Gets or sets the submitter's name for the assignment.                                |
| LetterGrade   | string    | X   |          | Gets the letter grade for the assignment.                                            |

**Notes**

- `LetterGrade` is a derived property that's calculated using EarnedMarks and PossibleMarks.
  - For 90% or greater return "A"
  - 80-89% return "B"
  - 70-79% return "C"
  - 60-69% return "D"
  - otherwise return "F"
  - _hint_: PossibleMarks and EarnedMarks are `int`s. What happens when a smaller integer is divided by a larger integer?

#### Constructor

Create a constructor for this class that accepts two parameters: `int possibleMarks` and `string submitterName`. Use these parameters to set the `readonly` properties.

### Step Two: Create `FruitTree.cs`

#### Properties

| Property          | Data Type | Get | Set      | Description                                            |
| ----------------- | --------- | --- | -------- | ------------------------------------------------------ |
| TypeOfFruit       | string    | X   | readonly | Gets the type of fruit on the tree.                    |
| PiecesOfFruitLeft | int       | X   | private  | Gets the number of remaining fruit pieces on the tree. |

#### Constructor

Create a constructor for this class that accepts two parameters: `string typeOfFruit` and `int startingPiecesOfFruit`. Use these parameters to set the properties of the class.

#### Methods

Create a method called `PickFruit` that accepts an `int` called `numberOfPiecesToRemove` and returns a `bool`:
- If there are enough pieces left on the tree, "pick" the fruit and update `PiecesOfFruitLeft` by subtracting `numberOfPiecesToRemove` from it.
- Return `true` if there were enough pieces left to pick. Return `false` if no fruit was picked—that is, `PiecesOfFruitLeft` was less than `numberOfPiecesToRemove`.

### Step Three: Create `Employee.cs`

#### Properties

| Property     | Data Type | Get | Set      | Description                             |
| ------------ | --------- | --- | -------- | --------------------------------------- |
| EmployeeId   | int       | X   | readonly | Gets the employee id.                   |
| FirstName    | string    | X   | readonly | Gets the employee's first name.         |
| LastName     | string    | X   | X        | Gets or sets the employee's last name.  |
| FullName     | string    | X   |          | Gets the employee's full name.          |
| Department   | string    | X   | X        | Gets or sets the employee's department. |
| AnnualSalary | double    | X   | private  | Gets the employee's annual salary.      |

**Notes**

- `FullName` is a derived property that returns `LastName, FirstName`.

#### Constructor

Create a constructor for this class that accepts four parameters: `int employeeId`, `string firstName`, `string lastName`, and `double salary`. Use these parameters to set the properties of the class.

#### Methods

Create a method called `RaiseSalary` that accepts a `double` called `percent` and returns `void`. The method increases the current annual salary by the percentage provided. For example, 5.5 represents 5.5%.

### Step Four: Create `Airplane.cs`

#### Properties

| Property                 | Data Type | Get | Set      | Description                                         |
| ------------------------ | --------- | --- | -------- | --------------------------------------------------- |
| PlaneNumber              | string    | X   | readonly | Gets the six-character plane number.                |
| TotalFirstClassSeats     | int       | X   | readonly | Gets the number of total first class seats.         |
| BookedFirstClassSeats    | int       | X   | private  | Gets the number of already booked first class seats |
| AvailableFirstClassSeats | int       | X   |          | Gets the number of available first class seats.     |
| TotalCoachSeats          | int       | X   | readonly | Gets the number of total coach seats.               |
| BookedCoachSeats         | int       | X   | private  | Gets the number of already booked coach seats       |
| AvailableCoachSeats      | int       | X   |          | Gets the number of available coach seats.           |

**Notes**

- `AvailableFirstClassSeats` is a derived property calculated by subtracting `BookedFirstClassSeats` from `TotalFirstClassSeats`.
- `AvailableCoachSeats` is a derived property calculated by subtracting `BookedCoachSeats` from `TotalCoachSeats`.

#### Constructors

Create a constructor for this class that accepts three parameters: `string planeNumber`, `int totalFirstClassSeats`, and `int totalCoachSeats`. Use these parameters to set the `readonly` of the class:

- `planeNumber` is the assigned plane number to the airplane.
- `totalFirstClassSeats` is the initial number of total first class seats.
- `totalCoachSeats` is the initial number of total coach seats.

#### Methods

Create a method called `ReserveSeats` that returns a `bool` and accepts two parameters: a `bool` called `forFirstClass` and an `int` called `totalNumberOfSeats`.

- If `forFirstClass` is `true`, add `totalNumberOfSeats` to the value for `BookedFirstClassSeats`.
- If `forFirstClass` is `false`, add `totalNumberOfSeats` to the value for `BookedCoachSeats`.
- Return `true` if there were enough seats to make the reservation, otherwise `false`.

###  Step Five: Create `Television.cs`

#### Properties

| Property       | Data Type | Get | Set     | Description                                                                 |
| -------------- | --------- | --- | ------- | --------------------------------------------------------------------------- |
| IsOn           | bool      | X   | private | Gets whether or not the TV is turned on.                                    |
| CurrentChannel | int       | X   | private | Gets the value for the current channel. Channel levels go between 3 and 18. |
| CurrentVolume  | int       | X   | private | Gets the current volume level.                                              |

#### Constructors

The `Television` class doesn't need a constructor. However, the properties need default values: a new TV is off by default. The channel is set to three and the volume level to two.

#### Methods

Create methods based on the following signatures:

```
    void TurnOff()
    void TurnOn()
    void ChangeChannel(int newChannel)
    void ChannelUp()
    void ChannelDown()
    void RaiseVolume()
    void LowerVolume()
```

**Notes**

- `TurnOff()` turns off the tv.
- `TurnOn()` turns the tv on and also resets the channel to three and the volume level to two.
- `ChangeChannel(int newChannel)` changes the current channel—only if it's on—to the value of `newChannel` as long as it's between 3 and 18.
- `ChannelUp()` increases the current channel by one, only if it's on. If the value goes past 18, then the current channel should be set to three.
- `ChannelDown()` decreases the current channel by one, only if it's on. If the value goes below three, then the current channel should be set to 18.
- `RaiseVolume()` increases the volume by one, only if it's on. The limit is 10.
- `LowerVolume()` decreases the volume by one, only if it's on. The limit is 0.

###  Step Six: Create `Elevator.cs`

#### Properties

| Property       | Data Type | Get | Set      | Description                                          |
| -------------- | --------- | --- | -------- | ---------------------------------------------------- |
| CurrentLevel   | int       | X   | private  | Gets the current floor that the elevator is on.      |
| NumberOfLevels | int       | X   | readonly | Gets the number of levels available to the elevator. |
| DoorIsOpen     | bool      | X   | private  | Gets if the elevator door is open or not.            |

#### Constructor

The `Elevator` class has a single constructor that accepts one parameter, `int numberOfLevels`, which indicates how many floors are available to the elevator.

Either provide a default value or set it in the constructor so new elevators start on floor one.

#### Methods

Create methods based on the following signatures:

```
    void OpenDoor()
    void CloseDoor()
    void GoUp(int desiredFloor)
    void GoDown(int desiredFloor)
```

**Notes**

- `OpenDoor()` opens the elevator door.
- `CloseDoor()` closes the elevator door.
- `GoUp(int desiredFloor)` sends the elevator upward to the desired floor as long as the door isn't open. Can't go past top floor.
- `GoDown(int desiredFloor)` sends the elevator downward to the desired floor as long as the door isn't open. Can't go past floor one.


---

[derived-properties]: https://www.uml-diagrams.org/derived-property.html
[dot-net-access-modifiers]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/access-modifiers
[introduction-to-test-driven-development]: http://agiledata.org/essays/tdd.html
[loose-coupling]: http://wiki.c2.com/?CouplingAndCohesion# Encapsulation

In this exercise, you'll create the classes specified in the [requirements section](#Evaluation-Criteria-&-Functional-Requirements) of this document. The unit tests you run verify that you've defined the classes correctly.

## Learning objectives

After completing this exercise, you'll understand how to:

* Write code that's [loosely coupled][loose-coupling].
* Write code that appropriately hides the internal details of classes.
* Create readonly properties.
* Limit access to properties through the use of [access modifiers][dot-net-access-modifiers].
* Write [derived properties][derived-properties].

## Getting started

* Open the `oop-with-encapsulation-exercises.sln` solution in Visual Studio.
* Click on the **Test -> Run All Tests** menu option.
* Click on the **Test Explorer** tab to see the results of your tests and which ones passed/failed.

## Tips and tricks

* As you work on creating the classes, be sure to run the tests, and then provide enough code to pass the test. For instance, if you're working on the `HomeworkAssignment` class, provide enough code to get one of the `HomeworkAssignment` tests passing. 
* Focusing on getting a single test to pass at a time saves time, as this forces you to only focus on what's important for the test you're currently working on. This is commonly called **[Test Driven Development][introduction-to-test-driven-development]**, or **TDD**.
* Be mindful of your [access modifiers][dot-net-access-modifiers].
* Keep in mind that a **loosely coupled** system is one in which each of its components has, or makes use of, little or no knowledge of the definitions of other separate components. One of your goals as a developer should be to write code that's loosely coupled.

> Note: If you find yourself stuck on a problem for longer than fifteen minutes, move onto the next, and try again later.

## Evaluation criteria and functional requirements

* The project must not have any build errors.
* All unit tests pass as expected.
* Appropriate variable names and data types are used.
* Code is presented in a clean, organized format.
* Code is appropriately encapsulated.
* The code meets the specifications defined below.

**Notes for all classes**

- X in the set column indicates it **must have a `set` accessor**.
- Nothing in the set column indicates the property is a [derived property][derived-properties].
- Readonly properties don't require a `set` accessor. They're set from the class's constructor.
- Private setters require the property to have `private set`.

### Step One: Create `HomeworkAssignment.cs`

#### Properties

| Property      | Data Type | Get | Set      | Description                                                                          |
| ------------- | --------- | --- | -------- | -------------------------------------------------------------------------------------|
| EarnedMarks   | int       | X   | X        | Gets or sets the total number of correct marks submitter received on the assignment. |
| PossibleMarks | int       | X   | readonly | Gets the number of possible marks on the assignment.                                 |
| SubmitterName | string    | X   | readonly | Gets or sets the submitter's name for the assignment.                                |
| LetterGrade   | string    | X   |          | Gets the letter grade for the assignment.                                            |

**Notes**

- `LetterGrade` is a derived property that's calculated using EarnedMarks and PossibleMarks.
  - For 90% or greater return "A"
  - 80-89% return "B"
  - 70-79% return "C"
  - 60-69% return "D"
  - otherwise return "F"
  - _hint_: PossibleMarks and EarnedMarks are `int`s. What happens when a smaller integer is divided by a larger integer?

#### Constructor

Create a constructor for this class that accepts two parameters: `int possibleMarks` and `string submitterName`. Use these parameters to set the `readonly` properties.

### Step Two: Create `FruitTree.cs`

#### Properties

| Property          | Data Type | Get | Set      | Description                                            |
| ----------------- | --------- | --- | -------- | ------------------------------------------------------ |
| TypeOfFruit       | string    | X   | readonly | Gets the type of fruit on the tree.                    |
| PiecesOfFruitLeft | int       | X   | private  | Gets the number of remaining fruit pieces on the tree. |

#### Constructor

Create a constructor for this class that accepts two parameters: `string typeOfFruit` and `int startingPiecesOfFruit`. Use these parameters to set the properties of the class.

#### Methods

Create a method called `PickFruit` that accepts an `int` called `numberOfPiecesToRemove` and returns a `bool`:
- If there are enough pieces left on the tree, "pick" the fruit and update `PiecesOfFruitLeft` by subtracting `numberOfPiecesToRemove` from it.
- Return `true` if there were enough pieces left to pick. Return `false` if no fruit was picked—that is, `PiecesOfFruitLeft` was less than `numberOfPiecesToRemove`.

### Step Three: Create `Employee.cs`

#### Properties

| Property     | Data Type | Get | Set      | Description                             |
| ------------ | --------- | --- | -------- | --------------------------------------- |
| EmployeeId   | int       | X   | readonly | Gets the employee id.                   |
| FirstName    | string    | X   | readonly | Gets the employee's first name.         |
| LastName     | string    | X   | X        | Gets or sets the employee's last name.  |
| FullName     | string    | X   |          | Gets the employee's full name.          |
| Department   | string    | X   | X        | Gets or sets the employee's department. |
| AnnualSalary | double    | X   | private  | Gets the employee's annual salary.      |

**Notes**

- `FullName` is a derived property that returns `LastName, FirstName`.

#### Constructor

Create a constructor for this class that accepts four parameters: `int employeeId`, `string firstName`, `string lastName`, and `double salary`. Use these parameters to set the properties of the class.

#### Methods

Create a method called `RaiseSalary` that accepts a `double` called `percent` and returns `void`. The method increases the current annual salary by the percentage provided. For example, 5.5 represents 5.5%.

### Step Four: Create `Airplane.cs`

#### Properties

| Property                 | Data Type | Get | Set      | Description                                         |
| ------------------------ | --------- | --- | -------- | --------------------------------------------------- |
| PlaneNumber              | string    | X   | readonly | Gets the six-character plane number.                |
| TotalFirstClassSeats     | int       | X   | readonly | Gets the number of total first class seats.         |
| BookedFirstClassSeats    | int       | X   | private  | Gets the number of already booked first class seats |
| AvailableFirstClassSeats | int       | X   |          | Gets the number of available first class seats.     |
| TotalCoachSeats          | int       | X   | readonly | Gets the number of total coach seats.               |
| BookedCoachSeats         | int       | X   | private  | Gets the number of already booked coach seats       |
| AvailableCoachSeats      | int       | X   |          | Gets the number of available coach seats.           |

**Notes**

- `AvailableFirstClassSeats` is a derived property calculated by subtracting `BookedFirstClassSeats` from `TotalFirstClassSeats`.
- `AvailableCoachSeats` is a derived property calculated by subtracting `BookedCoachSeats` from `TotalCoachSeats`.

#### Constructors

Create a constructor for this class that accepts three parameters: `string planeNumber`, `int totalFirstClassSeats`, and `int totalCoachSeats`. Use these parameters to set the `readonly` of the class:

- `planeNumber` is the assigned plane number to the airplane.
- `totalFirstClassSeats` is the initial number of total first class seats.
- `totalCoachSeats` is the initial number of total coach seats.

#### Methods

Create a method called `ReserveSeats` that returns a `bool` and accepts two parameters: a `bool` called `forFirstClass` and an `int` called `totalNumberOfSeats`.

- If `forFirstClass` is `true`, add `totalNumberOfSeats` to the value for `BookedFirstClassSeats`.
- If `forFirstClass` is `false`, add `totalNumberOfSeats` to the value for `BookedCoachSeats`.
- Return `true` if there were enough seats to make the reservation, otherwise `false`.

###  Step Five: Create `Television.cs`

#### Properties

| Property       | Data Type | Get | Set     | Description                                                                 |
| -------------- | --------- | --- | ------- | --------------------------------------------------------------------------- |
| IsOn           | bool      | X   | private | Gets whether or not the TV is turned on.                                    |
| CurrentChannel | int       | X   | private | Gets the value for the current channel. Channel levels go between 3 and 18. |
| CurrentVolume  | int       | X   | private | Gets the current volume level.                                              |

#### Constructors

The `Television` class doesn't need a constructor. However, the properties need default values: a new TV is off by default. The channel is set to three and the volume level to two.

#### Methods

Create methods based on the following signatures:

```
    void TurnOff()
    void TurnOn()
    void ChangeChannel(int newChannel)
    void ChannelUp()
    void ChannelDown()
    void RaiseVolume()
    void LowerVolume()
```

**Notes**

- `TurnOff()` turns off the tv.
- `TurnOn()` turns the tv on and also resets the channel to three and the volume level to two.
- `ChangeChannel(int newChannel)` changes the current channel—only if it's on—to the value of `newChannel` as long as it's between 3 and 18.
- `ChannelUp()` increases the current channel by one, only if it's on. If the value goes past 18, then the current channel should be set to three.
- `ChannelDown()` decreases the current channel by one, only if it's on. If the value goes below three, then the current channel should be set to 18.
- `RaiseVolume()` increases the volume by one, only if it's on. The limit is 10.
- `LowerVolume()` decreases the volume by one, only if it's on. The limit is 0.

###  Step Six: Create `Elevator.cs`

#### Properties

| Property       | Data Type | Get | Set      | Description                                          |
| -------------- | --------- | --- | -------- | ---------------------------------------------------- |
| CurrentLevel   | int       | X   | private  | Gets the current floor that the elevator is on.      |
| NumberOfLevels | int       | X   | readonly | Gets the number of levels available to the elevator. |
| DoorIsOpen     | bool      | X   | private  | Gets if the elevator door is open or not.            |

#### Constructor

The `Elevator` class has a single constructor that accepts one parameter, `int numberOfLevels`, which indicates how many floors are available to the elevator.

Either provide a default value or set it in the constructor so new elevators start on floor one.

#### Methods

Create methods based on the following signatures:

```
    void OpenDoor()
    void CloseDoor()
    void GoUp(int desiredFloor)
    void GoDown(int desiredFloor)
```

**Notes**

- `OpenDoor()` opens the elevator door.
- `CloseDoor()` closes the elevator door.
- `GoUp(int desiredFloor)` sends the elevator upward to the desired floor as long as the door isn't open. Can't go past top floor.
- `GoDown(int desiredFloor)` sends the elevator downward to the desired floor as long as the door isn't open. Can't go past floor one.


---

[derived-properties]: https://www.uml-diagrams.org/derived-property.html
[dot-net-access-modifiers]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/access-modifiers
[introduction-to-test-driven-development]: http://agiledata.org/essays/tdd.html
[loose-coupling]: http://wiki.c2.com/?CouplingAndCohesion