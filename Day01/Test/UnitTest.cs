using NUnit.Framework;
using System.Collections.Generic;

namespace Test
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            List<string> inputList = new() {
                "1abc2",
                "pqr3stu8vwx",
                "a1b2c3d4e5f",
                "treb7uchet"
            };
            var answer = Code.Program.SolutionPart1(inputList);
            Assert.That(answer, Is.EqualTo(142));
        }

        [Test]
        public void Test2()
        {
            List<string> inputList = new() {
                "two1nine",
                "eightwothree",
                "abcone2threexyz",
                "xtwone3four",
                "4nineeightseven2",
                "zoneight234",
                "7pqrstsixteen"
            };
            var answer = Code.Program.SolutionPart2(inputList);
            Assert.That(answer, Is.EqualTo(281));
        }
    }
}