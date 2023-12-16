using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Code
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's solve Day 02");
            var input = File.ReadAllLines("input.txt").ToList();

            int answer1 = SolutionPart1(input, 12, 13, 14);
            Console.WriteLine($"Solution part 1: {answer1}");

            int answer2 = SolutionPart2(input);
            Console.WriteLine($"Solution part 2: {answer2}");
        }

        public static int SolutionPart1(List<string> input, int rmax, int gmax, int bmax)
        {
            int result = 0;

            foreach (var game in input)
            {
                var gameIsValid = true;
                var record = game.Split(':');
                int gameId = int.Parse(record[0].Replace("Game ", ""));
                foreach (var round in record[1].Split(';'))
                {
                    if (!gameIsValid)
                    {
                        break;
                    }
                    var colors = round.Split(',');
                    foreach (var color in colors)
                    {
                        if (color.ToString().EndsWith("red"))
                        {
                            int r = int.Parse(color.Trim().Split(' ')[0]);
                            if (r > rmax)
                            {
                                gameIsValid = false;
                                break;
                            }
                        }
                        else if (color.ToString().EndsWith("green"))
                        {
                            int g = int.Parse(color.Trim().Split(' ')[0]);
                            if (g > gmax)
                            {
                                gameIsValid = false;
                                break;
                            }
                        }
                        else if (color.ToString().EndsWith("blue"))
                        {
                            int b = int.Parse(color.Trim().Split(' ')[0]);
                            if (b > bmax)
                            {
                                gameIsValid = false;
                                break;
                            }
                        }
                    }
                }
                if (gameIsValid)
                {
                    result += gameId;
                }
            }

            return result;
        }
        public static int SolutionPart2(List<string> input)
        {
            var powerList = new List<int>();

            foreach (var game in input)
            {
                int rmax = 0;
                int gmax = 0;
                int bmax = 0;
                var record = game.Split(':');
                int gameId = int.Parse(record[0].Replace("Game ", ""));
                foreach (var round in record[1].Split(';'))
                {
                    var colors = round.Split(',');
                    foreach (var color in colors)
                    {
                        if (color.ToString().EndsWith("red"))
                        {
                            int r = int.Parse(color.Trim().Split(' ')[0]);
                            if (r > rmax)
                            {
                                rmax = r;
                            }
                        }
                        else if (color.ToString().EndsWith("green"))
                        {
                            int g = int.Parse(color.Trim().Split(' ')[0]);
                            if (g > gmax)
                            {
                                gmax = g;
                            }
                        }
                        else if (color.ToString().EndsWith("blue"))
                        {
                            int b = int.Parse(color.Trim().Split(' ')[0]);
                            if (b > bmax)
                            {
                                bmax = b;
                            }
                        }
                    }
                }
                var power = rmax * gmax * bmax;
                powerList.Add(power);
            }

            return powerList.Sum();
        }
    }
}
