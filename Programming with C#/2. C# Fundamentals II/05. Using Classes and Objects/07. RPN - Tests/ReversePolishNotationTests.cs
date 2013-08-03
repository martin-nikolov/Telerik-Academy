using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPN;

namespace RPN
{
    [TestClass]
    public class ReversePolishNotationTests
    {
        [TestMethod]
        public void Pow_Of_Two_Doubles()
        {
            double expected = Math.Pow(3.14, 2) + Math.Pow(3.14, 2);
            string actual = ReversePolishNotation.Parse(ReversePolishNotation.Tokenize("3.14 ^ 2 + pow(3.14, 2)"));

            Assert.AreEqual(expected.ToString(), actual);
        }

        [TestMethod]
        public void Two_Nested_Pow_Expressions()
        {
            double expected = Math.Pow(Math.Pow(3, 2), 2) + Math.Pow(Math.Pow(Math.Pow(Math.Pow(2, 2), 2), 2), 2);
            string actual = ReversePolishNotation.Parse(ReversePolishNotation.Tokenize("pow(pow(3, 2), 2) + pow(pow(pow(pow(2, 2), 2), 2), 2)"));

            Assert.AreEqual(expected.ToString(), actual);
        }

        [TestMethod]
        public void Nested_Pow_And_Sqrt_Expressions()
        {
            double expected = Math.Pow(Math.Sqrt(16), Math.Pow(Math.Sqrt(16), 3)) + Math.Sqrt(Math.Sqrt(Math.Sqrt(Math.Pow(121, 4))));
            string actual = ReversePolishNotation.Parse(ReversePolishNotation.Tokenize("Pow(Sqrt(16), Pow(Sqrt(16), 3)) + Sqrt(Sqrt(Sqrt(Pow(121, 4))))"));

            Assert.AreEqual(expected.ToString(), actual);
        }

        [TestMethod]
        public void SomeExpression01()
        {
            double expected = (3 + 5.3) * 2.7 - Math.Log(22, Math.E) / Math.Pow(2.2, -1.7);
            string actual = ReversePolishNotation.Parse(ReversePolishNotation.Tokenize("(3 + 5.3) * 2.7 - ln(22) / 2.2 ^ -1.7"));

            Assert.AreEqual(expected.ToString(), actual);
        }

        [TestMethod]
        public void SomeExpression02()
        {
            double expected = Math.Pow(2, 3.14) * (3 - (3 * Math.Sqrt(2) - 3.2) + 1.5 * 0.3);
            string actual = ReversePolishNotation.Parse(ReversePolishNotation.Tokenize("pow(2, 3.14) * (3 - (3 * sqrt(2) - 3.2) + 1.5 * 0.3)"));

            Assert.AreEqual(expected.ToString(), actual);
        }

        [TestMethod]
        public void SomeExpression03()
        {
            double expected = (1 - -1) * Math.Pow(Math.Pow(1 + 1, Math.Pow(Math.Log(2.71, Math.E), 1 - 1)), 10);
            string actual = ReversePolishNotation.Parse(ReversePolishNotation.Tokenize("(1 - -1) * pow(pow(1 + 1, pow(ln(2.71), 1 - 1)), 10)"));

            Assert.AreEqual(expected.ToString(), actual);
        }

        [TestMethod]
        public void SomeExpression04()
        {
            double expected = -(-1 + -2);
            string actual = ReversePolishNotation.Parse(ReversePolishNotation.Tokenize("-(-1 + -2)"));

            Assert.AreEqual(expected.ToString(), actual);
        }

        [TestMethod]
        public void Nested_Logs()
        {
            double expected = Math.Log(Math.Log(Math.Log(21.213, Math.E), Math.E), Math.E);
            string actual = ReversePolishNotation.Parse(ReversePolishNotation.Tokenize("ln(ln(ln(21.213)))"));

            Assert.AreEqual(expected.ToString(), actual);
        }

        [TestMethod]
        public void Two_Nested_Pow_Expressions_Using_Arrow()
        {
            double expected = Math.Pow(Math.Pow(3, 2), 2) + Math.Pow(Math.Pow(Math.Pow(Math.Pow(2, 2), 2), 2), 2);
            string actual = ReversePolishNotation.Parse(ReversePolishNotation.Tokenize("3 ^ 2 ^ 2 + 2 ^ 2 ^ 2 ^ 2 ^ 2"));

            Assert.AreEqual(expected.ToString(), actual);
        }

        [TestMethod]
        public void Addition_Of_Integers()
        {
            double expected = 1 + 2 + 3 + 4 + 5 + 6 + 7;
            string actual = ReversePolishNotation.Parse(ReversePolishNotation.Tokenize("1 + 2 + 3 + 4 + 5 + 6 + 7"));

            Assert.AreEqual(expected.ToString(), actual);
        }

        [TestMethod]
        public void Addition_Of_Doubles()
        {
            double expected = 1.1 + 2.2 + 3.3 + 4.4 + 5.5 + 6.6;
            string actual = ReversePolishNotation.Parse(ReversePolishNotation.Tokenize("1.1 + 2.2 + 3.3 + 4.4 + 5.5 + 6.6"));

            Assert.AreEqual(expected.ToString(), actual);
        }

        [TestMethod]
        public void Pow_Subtraction_Multiplication_Addition_Division()
        {
            double expected = Math.Pow(3.14, 2) - 15 / 3 + 2 * 3 - (15 + 3);
            string actual = ReversePolishNotation.Parse(ReversePolishNotation.Tokenize("pow(3.14, 2) - 15 / 3 + 2 * 3 - (15 + 3)"));

            Assert.AreEqual(expected.ToString(), actual);
        }

        [TestMethod]
        public void Addition_Of_Pow_Division_Subtraction_And_Multiplication()
        {
            double expected = 15.5 / 5 + Math.Pow(0.123, 2) - (3.2 * 5);
            string actual = ReversePolishNotation.Parse(ReversePolishNotation.Tokenize("15.5 / 5 + pow(0.123, 2) - (3.2 * 5)"));

            Assert.AreEqual(expected.ToString(), actual);
        }

        [TestMethod]
        public void Multiplication_Division()
        {
            double expected = 1111 * 1111 / 1111;
            string actual = ReversePolishNotation.Parse(ReversePolishNotation.Tokenize("1111 * 1111 / 1111"));

            Assert.AreEqual(expected.ToString(), actual);
        }

        [TestMethod]
        public void Addition_Multiplication_Division_Subtraction()
        {
            double expected = 1111 + 1111 * 1111 / 1111 - 1111;
            string actual = ReversePolishNotation.Parse(ReversePolishNotation.Tokenize("1111 + 1111 * 1111 / 1111 - 1111"));

            Assert.AreEqual(expected.ToString(), actual);
        }

        [TestMethod]
        public void Pow_Division_Subtraction_Addition_Doubles()
        {
            double expected = 0.1 + 1.1 / 2.2 + 3.3 * 4.4 + Math.Pow(5.5, 6.6) - 7.7;
            string actual = ReversePolishNotation.Parse(ReversePolishNotation.Tokenize("0.1 + 1.1 / 2.2 + 3.3 * 4.4 + pow(5.5, 6.6) - 7.7"));

            Assert.AreEqual(expected.ToString(), actual);
        }

        [TestMethod]
        public void Natural_Log_Integer()
        {
            double expected = Math.Log(20, Math.E);
            string actual = ReversePolishNotation.Parse(ReversePolishNotation.Tokenize("ln(20)"));

            Assert.AreEqual(expected.ToString(), actual);
        }

        [TestMethod]
        public void Natural_Log_Double()
        {
            double expected = Math.Log(12.1234, Math.E);
            string actual = ReversePolishNotation.Parse(ReversePolishNotation.Tokenize("ln(12.1234)"));

            Assert.AreEqual(expected.ToString(), actual);
        }

        [TestMethod]
        public void Sqrt_Еxactly_Root_Integer()
        {
            double expected = Math.Sqrt(121);
            string actual = ReversePolishNotation.Parse(ReversePolishNotation.Tokenize("sqrt(121)"));

            Assert.AreEqual(expected.ToString(), actual);
        }

        [TestMethod]
        public void Sqrt_Long_Integer()
        {
            double expected = Math.Sqrt(1231311);
            string actual = ReversePolishNotation.Parse(ReversePolishNotation.Tokenize("sqrt(1231311)"));

            Assert.AreEqual(expected.ToString(), actual);
        }

        [TestMethod]
        public void Addition_Of_Two_Sqrts()
        {
            double expected = Math.Sqrt(123.12) + Math.Sqrt(123);
            string actual = ReversePolishNotation.Parse(ReversePolishNotation.Tokenize("sqrt(123.12) + sqrt(123)"));

            Assert.AreEqual(expected.ToString(), actual);
        }

        [TestMethod]
        public void Addition_Of_Logs_And_Sqrts()
        {
            double expected = Math.Log(43.123, Math.E) + Math.Sqrt(121.121) + Math.Log(123, Math.E) + Math.Sqrt(1000000);
            string actual = ReversePolishNotation.Parse(ReversePolishNotation.Tokenize("ln(43.123) + sqrt(121.121) + ln(123) + sqrt(1000000)"));

            Assert.AreEqual(expected.ToString(), actual);
        }

        [TestMethod]
        public void Sin_Integer()
        {
            double expected = Math.Sin(20);
            string actual = ReversePolishNotation.Parse(ReversePolishNotation.Tokenize("sin(20)"));

            Assert.AreEqual(expected.ToString(), actual);
        }

        [TestMethod]
        public void Sin_Double()
        {
            double expected = Math.Sin(123.12);
            string actual = ReversePolishNotation.Parse(ReversePolishNotation.Tokenize("sin(123.12)"));

            Assert.AreEqual(expected.ToString(), actual);
        }

        [TestMethod]
        public void Cos_Integer()
        {
            double expected = Math.Cos(20);
            string actual = ReversePolishNotation.Parse(ReversePolishNotation.Tokenize("Cos(20)"));

            Assert.AreEqual(expected.ToString(), actual);
        }

        [TestMethod]
        public void Cos_Double()
        {
            double expected = Math.Cos(123.12);
            string actual = ReversePolishNotation.Parse(ReversePolishNotation.Tokenize("cos(123.12)"));

            Assert.AreEqual(expected.ToString(), actual);
        }

        [TestMethod]
        public void Tan_Integer()
        {
            double expected = Math.Tan(20);
            string actual = ReversePolishNotation.Parse(ReversePolishNotation.Tokenize("tg(20)"));

            Assert.AreEqual(expected.ToString(), actual);
        }

        [TestMethod]
        public void Tan_Double()
        {
            double expected = Math.Tan(123.12);
            string actual = ReversePolishNotation.Parse(ReversePolishNotation.Tokenize("tan(123.12)"));

            Assert.AreEqual(expected.ToString(), actual);
        }

        [TestMethod]
        public void Addition_Of_Sin_Cos_Tan()
        {
            double expected = Math.Tan(123.12) + Math.Cos(20) + Math.Sin(30) + Math.Cos(12.21) + Math.Sin(21.21) + Math.Tan(20);
            string actual = ReversePolishNotation.Parse(ReversePolishNotation.Tokenize("Tan(123.12) + Cos(20) + Sin(30) + Cos(12.21) + Sin(21.21) + Tan(20)"));

            Assert.AreEqual(expected.ToString(), actual);
        }

        [TestMethod]
        public void Division_And_Multiplication_Of_Sin_Cos_Tan_ln_Sqrt_Pow()
        {
            double expected = Math.Tan(123.12) / Math.Cos(20) / Math.Sin(30) / Math.Cos(12.21) * Math.Sin(21.21)
                * Math.Tan(20) * Math.Sqrt(121) / Math.Pow(12.12, 2) * Math.Log(12.2, Math.E);
            string actual = ReversePolishNotation.Parse(ReversePolishNotation.Tokenize("Tan(123.12) / Cos(20) / Sin(30) / Cos(12.21) * Sin(21.21) * Tan(20) * Sqrt(121) / Pow(12.12, 2) * ln(12.2, E)"));

            Assert.AreEqual(expected.ToString(), actual);
        }
    }
}
