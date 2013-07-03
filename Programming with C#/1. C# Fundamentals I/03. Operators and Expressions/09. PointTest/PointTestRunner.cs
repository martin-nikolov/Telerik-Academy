using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PointInsideCircleOutOfRectangle;

[TestClass]
public class PointTestRunner
{
    [TestMethod]
    public void BothInside1()
    {
        PointInsideCircleOutsideRectangle.Point point = new PointInsideCircleOutsideRectangle.Point();
        point.x = 1;
        point.y = 1;
        Assert.AreEqual(PointInsideCircleOutsideRectangle.InsideCircle(point), true);
        Assert.AreEqual(PointInsideCircleOutsideRectangle.InsideRectangle(point), true);
    }

    [TestMethod]
    public void BothInside2()
    {
        PointInsideCircleOutsideRectangle.Point point = new PointInsideCircleOutsideRectangle.Point();
        point.x = 3.5;
        point.y = 0;
        Assert.AreEqual(PointInsideCircleOutsideRectangle.InsideCircle(point), true);
        Assert.AreEqual(PointInsideCircleOutsideRectangle.InsideRectangle(point), true);
    }

    [TestMethod]
    public void BothInside3()
    {
        PointInsideCircleOutsideRectangle.Point point = new PointInsideCircleOutsideRectangle.Point();
        point.x = -1;
        point.y = -1;
        Assert.AreEqual(PointInsideCircleOutsideRectangle.InsideCircle(point), true);
        Assert.AreEqual(PointInsideCircleOutsideRectangle.InsideRectangle(point), true);
    }

    [TestMethod]
    public void BothOutside1()
    {
        PointInsideCircleOutsideRectangle.Point point = new PointInsideCircleOutsideRectangle.Point();
        point.x = 5.1;
        point.y = 2;
        Assert.AreEqual(PointInsideCircleOutsideRectangle.InsideCircle(point), false);
        Assert.AreEqual(PointInsideCircleOutsideRectangle.InsideRectangle(point), false);
    }

    [TestMethod]
    public void BothOutside2()
    {
        PointInsideCircleOutsideRectangle.Point point = new PointInsideCircleOutsideRectangle.Point();
        point.x = -1.25;
        point.y = 3;
        Assert.AreEqual(PointInsideCircleOutsideRectangle.InsideCircle(point), false);
        Assert.AreEqual(PointInsideCircleOutsideRectangle.InsideRectangle(point), false);
    }

    [TestMethod]
    public void BothOutside3()
    {
        PointInsideCircleOutsideRectangle.Point point = new PointInsideCircleOutsideRectangle.Point();
        point.x = 3.8;
        point.y = -1.1;
        Assert.AreEqual(PointInsideCircleOutsideRectangle.InsideCircle(point), false);
        Assert.AreEqual(PointInsideCircleOutsideRectangle.InsideRectangle(point), false);
    }

    [TestMethod]
    public void InSideCircleOutOfRectangle1()
    {
        PointInsideCircleOutsideRectangle.Point point = new PointInsideCircleOutsideRectangle.Point();
        point.x = 1;
        point.y = 3.5;
        Assert.AreEqual(PointInsideCircleOutsideRectangle.InsideCircle(point), true); 
        Assert.AreEqual(PointInsideCircleOutsideRectangle.InsideRectangle(point), false);
    }

    [TestMethod]
    public void InSideCircleOutOfRectangle2()
    {
        PointInsideCircleOutsideRectangle.Point point = new PointInsideCircleOutsideRectangle.Point();
        point.x = 1;
        point.y = 3.5;
        Assert.AreEqual(PointInsideCircleOutsideRectangle.InsideCircle(point), true);
        Assert.AreEqual(PointInsideCircleOutsideRectangle.InsideRectangle(point), false); 
    }

    [TestMethod]
    public void InSideCircleOutOfRectangle3()
    {
        PointInsideCircleOutsideRectangle.Point point = new PointInsideCircleOutsideRectangle.Point();
        point.x = 1;
        point.y = 3.5;
        Assert.AreEqual(PointInsideCircleOutsideRectangle.InsideCircle(point), true);
        Assert.AreEqual(PointInsideCircleOutsideRectangle.InsideRectangle(point), false);
    }

    [TestMethod]
    public void OutOfCircleInSideRectangle1()
    {
        PointInsideCircleOutsideRectangle.Point point = new PointInsideCircleOutsideRectangle.Point();
        point.x = 4.9;
        point.y = -.05;
        Assert.AreEqual(PointInsideCircleOutsideRectangle.InsideCircle(point), false);
        Assert.AreEqual(PointInsideCircleOutsideRectangle.InsideRectangle(point), true);
    }

    [TestMethod]
    public void OutOfCircleInSideRectangle2()
    {
        PointInsideCircleOutsideRectangle.Point point = new PointInsideCircleOutsideRectangle.Point();
        point.x = 5;
        point.y = -1;
        Assert.AreEqual(PointInsideCircleOutsideRectangle.InsideCircle(point), false);
        Assert.AreEqual(PointInsideCircleOutsideRectangle.InsideRectangle(point), true);
    }

    [TestMethod]
    public void OutOfCircleInSideRectangle3()
    {
        PointInsideCircleOutsideRectangle.Point point = new PointInsideCircleOutsideRectangle.Point();
        point.x = 4.5;
        point.y = 0.5;
        Assert.AreEqual(PointInsideCircleOutsideRectangle.InsideCircle(point), false);
        Assert.AreEqual(PointInsideCircleOutsideRectangle.InsideRectangle(point), true);
    }
}