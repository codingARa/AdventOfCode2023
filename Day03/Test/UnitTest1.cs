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
                "467..114..",
                "...*......",
                "..35..633.",
                "......#...",
                "617*......",
                ".....+.58.",
                "..592.....",
                "......755.",
                "...$.*....",
                ".664.598..",
            };
            var answer = Code.Program.SolutionPart1(inputList);
            Assert.That(answer, Is.EqualTo(4361));
        }
    }
}
