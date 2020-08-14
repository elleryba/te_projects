# Testing Doubles Tutorial

In this tutorial, you'll continue working on the hotels application. This time, you've been assigned to a new team. There is a new project that does statistical analysis on the hotel data.

## Project Overview

If you look in your `student-tutorial/HotelStats` project, you should have the starting code for this tutorial. This is a simple console application that contains the following classes:

- `Program.cs`: The main entry point for the application.
- `HotelStats.cs`: The main class that performs the statistical analysis of the data.
- `Dao/IStatsDao.cs`: The Statistics DAO Interface.
- `Dao/SqlStatsDao.cs`: A DAO that can retrieve statistics from a database.

### Testing Project

If you look in `student-tutorial/HotelStats.Test`, you should see the following dependencies declared in `HotelStats.Test.csproj`:

```
<ItemGroup>
  <PackageReference Include="Microsoft.NET.Test.Sdk" Version="15.9.0" />
  <PackageReference Include="Moq" Version="4.13.1" />
  <PackageReference Include="MSTest.TestAdapter" Version="1.3.2" />
  <PackageReference Include="MSTest.TestFramework" Version="1.3.2" />
</ItemGroup>
```

The mocking framework Moq is already included, so you won't need to install it.

## Creating and Writing Unit Tests

If you look in `HotelStats.Test`, you'll notice there are currently no tests. The first thing to do is create a new class called `HotelStatsTest`. This is done by convention and includes the class you're testing against along with the suffix `Test`. You'll use the attribute `[TestClass]` to mark this class as a test class.

```csharp
namespace HotelStats.Tests
{
    [TestClass]
    public class HotelStatsTest
    {

    }
}
```

Next, set up the variables that you'll need to write your tests:

```csharp
namespace HotelStats.Tests
{
    [TestClass]
    public class HotelStatsTest
    {

        private HotelStats _stats;
        private Mock<IStatsDao> _mock;

    }
}
```

You'll want to create an instance of the `HotelStats` object once before any of the tests run. To do this, use MSTest's `[TestInitialize]` lifecycle method, as shown below:

```csharp
namespace HotelStats.Tests
{
    [TestClass]
    public class HotelStatsTest
    {

        private HotelStats _stats;
        private Mock<IStatsDao> _mock;

        [TestInitialize]
        public void BeforeTest()
        {
            // ...
        }
    }
}
```

There is one thing to consider when creating an instance of the `HotelStats` class. The constructor for `HotelStats` takes in an argument of type `IStatsDao`. You know from the project overview that there is an implementation of that interface called `SqlStatsDao`. You could create an instance of that class:

```csharp
private HotelStats _stats;
private Mock<IStatsDao> _mock;

[TestInitialize]
public void BeforeTest()
{
    IStatsDao = new SqlStatsDao();
    _stats = new HotelStats()
}
```

However, if you do this, you'll have some problems. First, this violates the idea of a unit test, which is designed to test a single "unit" of functionality. Secondly, unit tests are supposed to be fast, and if you introduce a database that is a dependency, your tests may slow down. If you create a new instance of `SqlStatsDao`, you're now testing that along with your `HotelStats` class, and this isn't what you want to do.

Instead, you can mock the `IStatsDao` using `Moq` and pass that mocked object into your `HotelStats` constructor. Now, you have control over that mocked object, and when methods are called, you can provide your own data.

```csharp
namespace HotelStats.Tests
{
    [TestClass]
    public class HotelStatsTest
    {

        private HotelStats _stats;
        private Mock<IStatsDao> _mock;

        [TestInitialize]
        public void BeforeTest()
        {
            _mock = new Mock<IStatsDao>();
            _stats = new HotelStats(_mock.Object);
        }
    }
}
```

With all of the setup completed, you can now write your individual tests.

### Mean Rating Tests

The first method in your `HotelStats` class that you need to write tests for is `GetRatingMean()`. Mean is the average, so what you'll do here is add all of the hotel ratings (1-5) and divide that by the number of ratings.

```csharp
public double GetRatingMean()
{
    int[] stars = _statsDao.GetAllRatings();
    double total = 0.0;
    double mean = 0.0;

    if (stars.Length > 0)
    {
        for (int i = 0; i < stars.Length; i++)
        {
            total += stars[i];
        }

        mean = total / (double)stars.Length;
    }

    return mean;
}
```

In your tests, you'll want to test for the following scenarios:

- When the data set is empty
- When the data set contains all of the same number, it should return that number
- When the data set contains different numbers, it should return the correct mean

To write your first test, start with the `[TestMethod]` attribute followed by a `public` method that doesn't return anything. The name of the test method should be descriptive, and by convention, starts with the word `Test`.

```csharp
[TestMethod]
public void TestRatingMeanIsZeroWithEmptyDataSet()
{

}
```

Tests can be divided up into three sections: `Arrange`, `Act`, and `Assert`. It's good practice to start with this structure.

```csharp
[TestMethod]
public void TestRatingMeanIsZeroWithEmptyDataSet()
{
    // Arrange

    // Act

    // Assert
}
```

With the `IStatsDao` class mocked out, you can provide your own data when a method is called. When `GetAllRatings()` is called in your first test, you'll want to have an empty data set. To do so, set that up in the `Arrange` section:

```csharp
[TestMethod]
public void TestRatingMeanIsZeroWithEmptyDataSet()
{
    // Arrange
    int[] dataSet = new int[] { };

    // Act

    // Assert
}
```

In `Act`, you can use `Moq`s `Setup().Returns()` to provide your own return data when that method is called.

```csharp
[TestMethod]
public void TestRatingMeanIsZeroWithEmptyDataSet()
{
    // Arrange
    int[] dataSet = new int[] { };

    // Act
    _mock.Setup(dao => dao.GetAllRatings()).Returns(dataSet);

    // Assert
}
```

Finally, you want to `Assert` that the expected result is `0.00` when `_stats.GetRatingMean()` is called with an empty data set:

```csharp
[TestMethod]
public void TestRatingMeanIsZeroWithEmptyDataSet()
{
    // Arrange
    int[] dataSet = new int[] { };

    // Act
    _mock.Setup(dao => dao.GetAllRatings()).Returns(dataSet);

    // Assert
    Assert.AreEqual(0.00, _stats.GetRatingMean());
}
```

That is the first of the three methods you need to write for this method. The other two are:

When the data set contains all of the same number, it should return that number
  - Name: TestRatingMeanIsCorrectWithAllTheSameNumbers
  - Use the data set {2,2,2,2,2}
  - Expect the Mean to be 2.0

When the data set contains different numbers, it should return the correct mean
  - Name: TestRatingMeanIsCorrectWhenDataSetContainsDifferentNumbers
  - Use the data set {1,2,2,3,5,3,4,4,2,1}
  - Expect the Mean to be 2.7

Before looking at the solutions, try to do these on your own:

```csharp
[TestMethod]
public void TestRatingMeanIsCorrectWithAllTheSameNumbers()
{
    // Arrange
    int[] dataSet = new int[] { 2, 2, 2, 2, 2 };

    // Act
    _mock.Setup(dao => dao.GetAllRatings()).Returns(dataSet);

    // Assert
    Assert.AreEqual(2.00, _stats.GetRatingMean());
}

[TestMethod]
public void TestRatingMeanIsCorrectWhenDataSetContainsDifferentNumbers()
{
    // Arrange
    int[] dataSet = new int[] { 1, 2, 2, 3, 5, 3, 4, 4, 2, 1 };

    // Act
    _mock.Setup(dao => dao.GetAllRatings()).Returns(dataSet);

    // Assert
    Assert.AreEqual(2.7, _stats.GetRatingMean());
}
```

### Median Price Tests

In statistics, the median value is the number in the middle of the data set. Here's how you can calculate it:

> "If there is an odd amount of numbers, the median value is the number that is in the middle, with the same amount of numbers below and above. If there is an even amount of numbers in the list, the middle pair must be determined, added together, and divided by two to find the median value" (Ganti, 2019).

If you look in `HotelStats`, you'll see the method that calculates the `Median` Hotel Price:

```csharp
public double GetHotelPriceMedian()
{
    double[] prices = _statsDao.GetAllPrices();
    double median = 0.0;

    if (prices.Length > 0)
    {
        Array.Sort(prices);

        if (prices.Length % 2 != 0)
        {
            median = prices[prices.Length / 2];
        }
        else
        {
            median = (prices[prices.Length / 2] + prices[(prices.Length / 2) - 1]) / 2.0;
        }
    }

    return median;
}
```

There are three tests that you need to write here:

When the data set is empty
  - Name: TestPriceMedianIsZeroWithEmptyDataSet
  - The data set should be an empty `double[]`
  - You should expect the result to be 0.00

When the data set contains an odd number of values
  - When the data set has an odd number of values, it should be the middle of the sorted data set
  - Name: TestPriceMedianWithDataSetLengthOdd
  - Use the data set double[] {99.99,149.99,89.99,129.99,199.99}
  - Expect the Median to be 129.99

When the data set contains an even number of values
  - When the data set has an even number, the median is the sum of the middle 2 / 2.0
  - Name: TestPriceMedianWithDataSetLengthEven
  - Use the data set double[] {99.99,149.99,89.99,129.99,199.99, 179.99}
  - Expect the Median to be 139.99

Try to write these tests before looking at the solutions below:


```csharp
[TestMethod]
public void TestPriceMedianIsZeroWithEmptyDataSet()
{
    // Arrange
    double[] dataSet = new double[] { };

    // Act
    _mock.Setup(dao => dao.GetAllPrices()).Returns(dataSet);

    // Assert
    Assert.AreEqual(0.00, _stats.GetHotelPriceMedian());
}

[TestMethod]
public void TestPriceMedianWithDataSetLengthOdd()
{
    // Arrange
    double[] dataSet = new double[] { 99.99, 149.99, 89.99, 129.99, 199.99 };

    // Act
    _mock.Setup(dao => dao.GetAllPrices()).Returns(dataSet);

    // Assert
    Assert.AreEqual(129.99, _stats.GetHotelPriceMedian());
}

[TestMethod]
public void TestPriceMedianWithDataSetLengthEven()
{
    // Arrange
    double[] dataSet =
            new double[] { 99.99, 149.99, 89.99, 129.99, 199.99, 179.99 };

    // Act
    _mock.Setup(dao => dao.GetAllPrices()).Returns(dataSet);

    // Assert
    Assert.AreEqual(139.99, _stats.GetHotelPriceMedian());
}
```


### Sources

Ganti, Akhilesh. *Median*. Retrieved from https://www.investopedia.com/terms/m/median.asp.
