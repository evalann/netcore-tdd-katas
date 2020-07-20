using NUnit.Framework;

namespace StringCalculatorKataTests
{
    public class StringCalculatorTests
    {
        [Test]
        public void Add_GivenBlankString_ShouldReturn0()
        {
            var sut = new StringCalculator();

            int act = sut.Add("");

            Assert.That(act, Is.EqualTo(0));
        }

        [TestCase("69", 69)]
        [TestCase("1", 1)]
        [TestCase("2", 2)]
        [TestCase("2147483647", int.MaxValue)]
        public void Add_GivenSingleNumberShouldReturnThatNumber(string input, int expected)
        {
            var sut = new StringCalculator();

            int act = sut.Add(input);

            Assert.That(act, Is.EqualTo(expected));
        }

        [TestCase("23,19", 42)]
        [TestCase("1,2", 3)]
        [TestCase("42,27", 69)]
        public void Add_GivenNumberCommaNumber_ShouldReturnSumOfBoth(string input, int expected)
        {
            var sut = new StringCalculator();

            int act = sut.Add(input);

            Assert.That(act, Is.EqualTo(expected));
        }
    }
}