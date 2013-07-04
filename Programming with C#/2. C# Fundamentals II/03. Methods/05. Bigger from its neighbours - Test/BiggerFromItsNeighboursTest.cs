using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class BiggerFromItsNeighboursTest
{
    [TestMethod]
    public void TestMethod1()
    {
        int[] numbers = { 1, 5, 1 };

        bool actual = BiggerFromItsNeighbours.IsBiggerThanItsNeighbours(numbers, index: 1);
        bool expected = true;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestMethod2()
    {
        int[] numbers = { 5, 1, 1 };

        bool actual = BiggerFromItsNeighbours.IsBiggerThanItsNeighbours(numbers, index: 0);
        bool expected = true;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestMethod3()
    {
        int[] numbers = { 1, 1, 5 };

        bool actual = BiggerFromItsNeighbours.IsBiggerThanItsNeighbours(numbers, index: 2);
        bool expected = true;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestMethod4()
    {
        int[] numbers = { 5, 1, 5 };

        bool actual = BiggerFromItsNeighbours.IsBiggerThanItsNeighbours(numbers, index: 1);
        bool expected = false;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestMethod5()
    {
        int[] numbers = { 1, 2, 3 };

        bool actual = BiggerFromItsNeighbours.IsBiggerThanItsNeighbours(numbers, index: 1);
        bool expected = false;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestMethod6()
    {
        int[] numbers = { 1, 2, 3 };

        bool actual = BiggerFromItsNeighbours.IsBiggerThanItsNeighbours(numbers, index: 0);
        bool expected = false;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestMethod7()
    {
        int[] numbers = { 1, 2, 3 };

        bool actual = BiggerFromItsNeighbours.IsBiggerThanItsNeighbours(numbers, index: 2);
        bool expected = true;

        Assert.AreEqual(expected, actual);
    }
}