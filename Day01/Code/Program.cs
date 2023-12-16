﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
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
            int answer2 = SolutionPart2(input);
            Console.WriteLine($"Solution part 2: {answer2}");
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

        public static int SolutionPart2(List<string> input)
        {
            var digits = new Dictionary<string, int>()
            {
                {"one" , 1 },
                {"two" , 2 },
                {"three" , 3 },
                {"four" , 4 },
                {"five" , 5 },
                {"six" , 6 },
                {"seven" , 7 },
                {"eight" , 8 },
                {"nine" , 9 },
            };

            var digitsReverse = new Dictionary<string, int>()
            {
                {"eno" , 1 },
                {"owt" , 2 },
                {"eerht" , 3 },
                {"ruof" , 4 },
                {"evif" , 5 },
                {"xis" , 6 },
                {"neves" , 7 },
                {"thgie" , 8 },
                {"enin" , 9 },
            };

            int result = 0;
            foreach(var line in input)
            {
                var leftChopped = line;
                var charArrayRight = line.ToCharArray();
                Array.Reverse(charArrayRight);
                var rightChopped = new string(charArrayRight);

                var leftNoFound = false;
                var rightNoFound = false;

                foreach (var ch in line)
                {
                    if (leftNoFound)
                    {
                        break;
                    }
                    if (Int16.TryParse(ch.ToString(), out short leftNo))
                    {
                        result += leftNo * 10;
                        leftNoFound = true;
                        break;
                    }
                    else
                    {
                        foreach (var pair in digits)
                        {
                            if (leftChopped.StartsWith(pair.Key))
                            {
                                result += pair.Value * 10;
                                leftNoFound = true;
                                break;
                            }
                        }
                        leftChopped = leftChopped.Remove(0,1);
                    }
                }

                foreach (var ch in line.Reverse())
                {
                    if (rightNoFound)
                    {
                        break;
                    }
                    if (Int16.TryParse(ch.ToString(), out short rightNo))
                    {
                        result += rightNo;
                        rightNoFound = true;
                        break;
                    }
                    else
                    {
                        foreach (var pair in digitsReverse)
                        {
                            if (rightChopped.StartsWith(pair.Key))
                            {
                                result += pair.Value;
                                rightNoFound = true;
                                break;
                            }
                        }
                        rightChopped = rightChopped.Remove(0,1);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Unfortunatley not working, since the input can have overlapping
        /// spelling of numbers like 'eightwothree'.
        /// By first mapping all numbers in accending numerical order to the
        /// input string, one gets the incorrect result '2' for the left digit.
        /// Since one needs to find the first match in the string, the correct
        /// answer is '8' for a match from the left.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int SolutionPart2_FirstApproach(List<string> input)
        {
            var digitDictionary = new Dictionary<string, string>()
            {
                {"one" , "1" },
                {"two" , "2" },
                {"three" , "3" },
                {"four" , "4" },
                {"five" , "5" },
                {"six" , "6" },
                {"seven" , "7" },
                {"eight" , "8" },
                {"nine" , "9" },
            };

            List<string> cleanedInput = new List<string>();
            foreach(var line in input)
            {
                var cleanedLine = line;
                foreach (var pair in digitDictionary)
                {
                    cleanedLine = Regex.Replace(cleanedLine, pair.Key, pair.Value);
                }
                cleanedInput.Add(cleanedLine);
            }
            return SolutionPart1(cleanedInput);
        }
    }
}
