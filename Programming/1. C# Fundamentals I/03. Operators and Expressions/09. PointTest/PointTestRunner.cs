using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PointInsideCircleOutOfRectangle;

[TestClass]
public class PointTestRunner
{
    [TestMethod]
    public void BothInside1()
    {
        Program.Point point = new Program.Point();
        point.x = 1;
        point.y = 1;
        Assert.AreEqual(Program.InsideCircle(point), true);
        Assert.AreEqual(Program.InsideRectangle(point), true);
    }

    [TestMethod]
    public void BothInside2()
    {
        Program.Point point = new Program.Point();
        point.x = 3.5;
        point.y = 0;
        Assert.AreEqual(Program.InsideCircle(point), true);
        Assert.AreEqual(Program.InsideRectangle(point), true);
    }

    [TestMethod]
    public void BothInside3()
    {
        Program.Point point = new Program.Point();
        point.x = -1;
        point.y = -1;
        Assert.AreEqual(Program.InsideCircle(point), true);
        Assert.AreEqual(Program.InsideRectangle(point), true);
    }

    [TestMethod]
    public void BothOutside1()
    {
        Program.Point point = new Program.Point();
        point.x = 5.1;
        point.y = 2;
        Assert.AreEqual(Program.InsideCircle(point), false);
        Assert.AreEqual(Program.InsideRectangle(point), false);
    }

    [TestMethod]
    public void BothOutside2()
    {
        Program.Point point = new Program.Point();
        point.x = -1.25;
        point.y = 3;
        Assert.AreEqual(Program.InsideCircle(point), false);
        Assert.AreEqual(Program.InsideRectangle(point), false);
    }

    [TestMethod]
    public void BothOutside3()
    {
        Program.Point point = new Program.Point();
        point.x = 3.8;
        point.y = -1.1;
        Assert.AreEqual(Program.InsideCircle(point), false);
        Assert.AreEqual(Program.InsideRectangle(point), false);
    }

    [TestMethod]
    public void InSideCircleOutOfRectangle1()
    {
        Program.Point point = new Program.Point();
        point.x = 1;
        point.y = 3.5;
        Assert.AreEqual(Program.InsideCircle(point), true); 
        Assert.AreEqual(Program.InsideRectangle(point), false);
    }

    [TestMethod]
    public void InSideCircleOutOfRectangle2()
    {
        Program.Point point = new Program.Point();
        point.x = 1;
        point.y = 3.5;
        Assert.AreEqual(Program.InsideCircle(point), true);
        Assert.AreEqual(Program.InsideRectangle(point), false); 
    }

    [TestMethod]
    public void InSideCircleOutOfRectangle3()
    {
        Program.Point point = new Program.Point();
        point.x = 1;
        point.y = 3.5;
        Assert.AreEqual(Program.InsideCircle(point), true);
        Assert.AreEqual(Program.InsideRectangle(point), false);
    }

    [TestMethod]
    public void OutOfCircleInSideRectangle1()
    {
        Program.Point point = new Program.Point();
        point.x = 4.9;
        point.y = -.05;
        Assert.AreEqual(Program.InsideCircle(point), false);
        Assert.AreEqual(Program.InsideRectangle(point), true);
    }

    [TestMethod]
    public void OutOfCircleInSideRectangle2()
    {
        Program.Point point = new Program.Point();
        point.x = 5;
        point.y = -1;
        Assert.AreEqual(Program.InsideCircle(point), false);
        Assert.AreEqual(Program.InsideRectangle(point), true);
    }

    [TestMethod]
    public void OutOfCircleInSideRectangle3()
    {
        Program.Point point = new Program.Point();
        point.x = 4.5;
        point.y = 0.5;
        Assert.AreEqual(Program.InsideCircle(point), false);
        Assert.AreEqual(Program.InsideRectangle(point), true);
    }
}