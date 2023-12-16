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
            Console.WriteLine("Let's solve Day XX");
            var input = File.ReadAllLines("input.txt").ToList();

            int answer1 = SolutionPart1(input, 12, 13, 14);
            Console.WriteLine($"Solution part 1: {answer1}");
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
    }
}
