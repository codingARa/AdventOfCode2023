using NUnit.Framework;
using System.Collections.Generic;

namespace Test
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            List<string> inputList = new() {};
            var answer = Code.Program.SolutionPart1(inputList);
            Assert.That(answer, Is.EqualTo(0));
        }
    }
}