﻿﻿using System;
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
            Console.WriteLine("Let's solve Day 03");
            var input = File.ReadAllLines("input.txt")
                .ToList();

            int answer1 = SolutionPart1(input);
            Console.WriteLine($"Solution part 1: {answer1}");
        }

        public static int SolutionPart1(List<string> input)
        {
            int result = 0;
            var map = new List<List<char>>();
            foreach (var line in input)
            {
                var a = line.ToList();
                map.Add(a);
            }

            int lineNo = 0;
            int lineCount = input.Count() - 1;
            var notSymbol = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.' };
            foreach (var line in input)
            {
                int width = line.Length-1;
                foreach (Match match in Regex.Matches(line, @"\d+"))
                {
                    int index = match.Index;
                    int length = match.Length;
                    var symbolFound = false;

                    var rows = Enumerable.Range(lineNo - 1, 3).ToArray().Where(x => (x <= lineCount && x >= 0));
                    foreach (int row in rows)
                    {
                        if (symbolFound)
                        {
                            break;
                        }
                        var columns = Enumerable.Range(index-1, length + 2).ToArray().Where(x => (x <= width && x >= 0));
                        foreach(int column in columns)
                        {
                            if(!notSymbol.Contains(map[row][column]))
                            {
                                result += int.Parse(match.Value);
                                symbolFound = true;
                                break;
                            }
                        }
                    }
                }

                lineNo++;
            }

            return result;
        }
    }
}
