using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PrintNameTest
{
    [TestMethod]
    public void SuccessfulTest1()
    {
        string actual = PrintName.RegardsUser("Ivan");
        string expected = "Hello, Ivan!";

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void SuccessfulTest2()
    {
        string actual = PrintName.RegardsUser("Peter");
        string expected = "Hello, Peter!";

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void FailTest1()
    {
        string actual = PrintName.RegardsUser("Ivan!");
        string expected = "Peter is not Ivan!";

        Assert.AreEqual(expected, actual);
    }
}