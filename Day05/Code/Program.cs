﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Code
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's solve Day 05");
            var input = File.ReadAllLines("input.txt")
                .ToList();
            int answer1 = SolutionPart1(input);
            Console.WriteLine($"Solution part 1: {answer1}");
        }

        public static int SolutionPart1(List<string> input)
        {
            return 0;
        }
    }
}