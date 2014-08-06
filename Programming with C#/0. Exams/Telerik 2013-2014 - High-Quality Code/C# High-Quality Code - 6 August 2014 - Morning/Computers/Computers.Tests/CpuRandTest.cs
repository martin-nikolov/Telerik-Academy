namespace Computers.Tests
{
    using System;
    using Computers.Models.Components;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CpuRandTest
    {
        [TestMethod]
        public void TestRandomGeneratorWithCustomRandomNumberProviderThatAlwaysReturn5()
        {
            var customNumber = 5;

            // CustomRandomNumberProvider always returns customNumber
            var customRandomNumberProvider = new CustomRandomNumberProvider(customNumber);
            var cpu = new Cpu32Bits(4, null, customRandomNumberProvider);
            var generatedNumber = cpu.GenerateRandomNumber(1, 100);
            Assert.AreEqual(customNumber, generatedNumber);
        }
    }
}