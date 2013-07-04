using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class FirstBiggerThanNeighboursTest
{
    [TestMethod]
    public void TestMethod1()
    {
        int[] numbers = { 1, 5, 1 };

        int actual = FirstBiggerThanNeighbours.FindFirstBiggerThanNeighbours(numbers);
        int expected = 1;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestMethod2()
    {
        int[] numbers = { 5, 1, 1 };

        int actual = FirstBiggerThanNeighbours.FindFirstBiggerThanNeighbours(numbers);
        int expected = 0;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestMethod3()
    {
        int[] numbers = { 1, 1, 5 };

        int actual = FirstBiggerThanNeighbours.FindFirstBiggerThanNeighbours(numbers);
        int expected = 2;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestMethod4()
    {
        int[] numbers = { 1, 1, 1 };

        int actual = FirstBiggerThanNeighbours.FindFirstBiggerThanNeighbours(numbers);
        int expected = -1;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestMethod5()
    {
        int[] numbers = { 1, 2, 3 };

        int actual = FirstBiggerThanNeighbours.FindFirstBiggerThanNeighbours(numbers);
        int expected = 2;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestMethod6()
    {
        int[] numbers = { 1, 2, 2, 3, 2 };

        int actual = FirstBiggerThanNeighbours.FindFirstBiggerThanNeighbours(numbers);
        int expected = 3;

        Assert.AreEqual(expected, actual);
    }
}