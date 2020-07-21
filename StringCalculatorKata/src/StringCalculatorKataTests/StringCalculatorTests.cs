using System;
using NUnit.Framework;

namespace StringCalculatorKataTests
{
    public class StringCalculatorTests
    {
        [Test]
        public void Add_GivenBlankString_ShouldReturn0()
        {
            var sut = CreateSut();

            int act = sut.Add("");

            Assert.That(act, Is.EqualTo(0));
        }

        [TestCase("69", 69)]
        [TestCase("1", 1)]
        [TestCase("2", 2)]
        [TestCase("2147483647", int.MaxValue)]
        public void Add_GivenSingleNumberShouldReturnThatNumber(string input, int expected)
        {
            var sut = CreateSut();

            int act = sut.Add(input);

            Assert.That(act, Is.EqualTo(expected));
        }

        [TestCase("23,19", 42)]
        [TestCase("1,2", 3)]
        [TestCase("42,27", 69)]
        public void Add_GivenNumberCommaNumber_ShouldReturnSumOfBoth(string input, int expected)
        {
            var sut = CreateSut();

            int act = sut.Add(input);

            Assert.That(act, Is.EqualTo(expected));
        }

        [TestCase("1,2,3,4", 10)]
        [TestCase("100,302,693", 1095)]
        [TestCase("40,25,1,2,1", 69)]
        public void Add_GivenManyNumbers_ShouldReturnSum(string input, int expected)
        {
            var sut = CreateSut();

            int act = sut.Add(input);

            Assert.That(act, Is.EqualTo(expected));
        }

        [TestCase("1,2\n3,4", 10)]
        [TestCase("1\n2", 3)]
        [TestCase("100\n302\n693", 1095)]
        [TestCase("40\n25,1,2\n1", 69)]
        public void Add_GivenNewLineDelimiterAsWell_ShouldReturnSum(string input, int expected)
        {
            var sut = CreateSut();

            int act = sut.Add(input);

            Assert.That(act, Is.EqualTo(expected));
        }

        [TestCase("//;\n1;2", 3)]
        [TestCase("//bar\n11bar32", 43)]
        [TestCase("//^\n1^2^3", 6)]
        public void Add_GivenDelimiterSpecified_ShouldReturnSum(string input, int expected)
        {
            var sut = CreateSut();

            int act = sut.Add(input);

            Assert.That(act, Is.EqualTo(expected));
        }

        [Test]
        public void Add_GivenNegativeNumber_ShouldThrowIndexOutOfRangeExceptionWithNegativeInMessage()
        {
            var sut = CreateSut();

            var ex = Assert.Throws<IndexOutOfRangeException>(() => sut.Add("-1,2"));

            Assert.That(ex.Message, Is.EqualTo("negatives not allowed (-1)"));
        }

        [Test]
        public void Add_GivenMultipleNegativeNumbers_ShouldThrowIndexOutOfRangeExceptionWithNegativesInMessage()
        {
            var sut = CreateSut();

            var ex = Assert.Throws<IndexOutOfRangeException>(() => sut.Add("-1,-2"));

            Assert.That(ex.Message, Is.EqualTo("negatives not allowed (-1,-2)"));
        }

        private static StringCalculator CreateSut()
        {
            return new StringCalculator();
        }
    }
}