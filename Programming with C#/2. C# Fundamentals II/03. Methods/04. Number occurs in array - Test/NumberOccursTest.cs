using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class NumberOccursTest
{
    [TestMethod]
    public void SuccessfulTest1()
    {
        int[] numbers = { 1, 1, 1, 1, 1 };
        int actual = NumberOccursInArray.GetNumberOfOccurs(numbers, searchedNumber: 1);
        int expected = 5;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void SuccessfulTest2()
    {
        int[] numbers = { 1, 2, 2, 3, 3, 3, 4, 4, 4, 4 };
        int actual = NumberOccursInArray.GetNumberOfOccurs(numbers, searchedNumber: 3);
        int expected = 3;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void FailTest1()
    {
        int[] numbers = { 2, 2, 2, 2, 2 };
        int actual = NumberOccursInArray.GetNumberOfOccurs(numbers, searchedNumber: 2);
        int expected = 4;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void FailTest2()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };
        int actual = NumberOccursInArray.GetNumberOfOccurs(numbers, searchedNumber: 5);
        int expected = 2;

        Assert.AreEqual(expected, actual);
    }
}