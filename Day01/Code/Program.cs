﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Code
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's solve Day 01");
            var input = File.ReadAllLines("input.txt")
                .ToList();
            int answer1 = SolutionPart1(input);
            Console.WriteLine($"Solution part 1: {answer1}");
        }

        public static int SolutionPart1(List<string> input)
        {
            int result = 0;
            foreach(var line in input)
            {
                Regex leftRegex = new Regex(@"\d");
                Regex rightRegex = new Regex(@"\d", RegexOptions.RightToLeft);
                var leftMatches = leftRegex.Match(line);
                var rightMatches = rightRegex.Match(line);
                var leftNo = leftMatches.Value[0].ToString();
                var rightNo = rightMatches.Value[0].ToString();
                result += int.Parse(leftNo + rightNo);
            }
            return result;
        }
    }
}
