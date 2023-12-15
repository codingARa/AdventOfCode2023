using NUnit.Framework;
using System.Collections.Generic;

namespace DayXXTest
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            List<string> inputList = new() {};
            var answer = DayXXCode.Program.SolutionPart1(inputList);
            Assert.That(answer, Is.EqualTo(0));
        }
    }
}