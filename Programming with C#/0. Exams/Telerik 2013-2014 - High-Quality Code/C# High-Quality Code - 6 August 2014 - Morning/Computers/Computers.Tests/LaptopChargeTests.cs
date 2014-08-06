namespace Computers.Tests
{
    using System;
    using Computers.Models.Components;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LaptopChargeTests
    {
        [TestMethod]
        public void CreateBatteryInitiallyShouldReturn50Percents()
        {
            var laptopBattery = new LaptopBattery();
            var exceptedPercentage = 50;
            Assert.AreEqual(exceptedPercentage, laptopBattery.Percentage);
        }

        [TestMethod]
        public void Subtract10PercentsShouldReturn40()
        {
            var laptopBattery = new LaptopBattery();
            laptopBattery.Charge(-10);
            var exceptedPercentage = 40;
            Assert.AreEqual(exceptedPercentage, laptopBattery.Percentage);
        }

        [TestMethod]
        public void Subtract50PercentsShouldReturnZero()
        {
            var laptopBattery = new LaptopBattery();
            laptopBattery.Charge(-50);
            var exceptedPercentage = 0;
            Assert.AreEqual(exceptedPercentage, laptopBattery.Percentage);
        }

        [TestMethod]
        public void Add10PercentsShouldReturn60()
        {
            var laptopBattery = new LaptopBattery();
            laptopBattery.Charge(10);
            var exceptedPercentage = 60;
            Assert.AreEqual(exceptedPercentage, laptopBattery.Percentage);
        }

        [TestMethod]
        public void Add50PercentsShouldReturn100()
        {
            var laptopBattery = new LaptopBattery();
            laptopBattery.Charge(50);
            var exceptedPercentage = 100;
            Assert.AreEqual(exceptedPercentage, laptopBattery.Percentage);
        }

        [TestMethod]
        public void TestOnNegativeInputValueShouldReturnZero()
        {
            var laptopBattery = new LaptopBattery();
            laptopBattery.Charge(-1000);
            var exceptedPercentage = 0;
            Assert.AreEqual(exceptedPercentage, laptopBattery.Percentage);
        }

        [TestMethod]
        public void TestOnInputValueGreaterThanMaximalValueShouldReturn100()
        {
            var laptopBattery = new LaptopBattery();
            laptopBattery.Charge(10000);
            var exceptedPercentage = 100;
            Assert.AreEqual(exceptedPercentage, laptopBattery.Percentage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetNegativePercentageViaPropertyShouldThrowException()
        {
            var laptopBattery = new LaptopBattery();
            laptopBattery.Percentage = -10;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetInvalidNonNegativePercentageViaPropertyShouldThrowException()
        {
            var laptopBattery = new LaptopBattery();
            laptopBattery.Percentage = 150;
        }
    }
}