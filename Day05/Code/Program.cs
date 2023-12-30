﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Code
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's solve Day 05");
            var input = File.ReadAllLines("input.txt")
                .ToList();
            BigInteger answer1 = SolutionPart1(input);
            Console.WriteLine($"Solution part 1: {answer1}");

            BigInteger answer2 = SolutionPart2(input);
            Console.WriteLine($"Solution part 2: {answer2}");
        }

        public static (List<BigInteger>, Dictionary<string, Dictionary<string,List<BigInteger>>>) ParseInput(List<string> input)
        {
            var seeds = new List<BigInteger>();
            var Maps = new Dictionary<string, Dictionary<string,List<BigInteger>>>();
            var mapIsOpen = false;
            var currentMapKey = "";

            foreach (var line in input)
            {
                if (line.StartsWith("seeds:"))
                {
                    var x = line.Split(':').Select(i => i.Trim()).ToList();
                    seeds = x[1].Split(' ').Select(s => BigInteger.Parse(s)).ToList();
                    continue;
                }

                if (line == "")
                {
                    mapIsOpen = false;
                    continue;
                }

                if (line.Contains(':'))
                {
                    currentMapKey = line.Trim();
                    Maps[currentMapKey] = new Dictionary<string, List<BigInteger>>() {
                        { "Destination", new List<BigInteger>() },
                        { "SourceMin", new List<BigInteger>() },
                        { "Length", new List<BigInteger>() },
                        { "SourceMax", new List<BigInteger>() },
                    };
                    mapIsOpen = true;
                    continue;
                }

                if (mapIsOpen)
                {
                    var data = line.Split(' ').Select(i => i.Trim()).ToList();
                    BigInteger dest = BigInteger.Parse(data[0]);
                    BigInteger smin = BigInteger.Parse(data[1]);
                    BigInteger length = BigInteger.Parse(data[2]);
                    BigInteger smax = smin + length;
                    Maps[currentMapKey]["Destination"].Add(dest);
                    Maps[currentMapKey]["SourceMin"].Add(smin);
                    Maps[currentMapKey]["Length"].Add(length);
                    Maps[currentMapKey]["SourceMax"].Add(smax);
                    continue;
                }
            }

            return (seeds, Maps);
        }

        public static BigInteger SolutionPart1(List<string> input)
        {
            (List<BigInteger> seeds, Dictionary<string, Dictionary<string, List<BigInteger>>> Maps) = ParseInput(input);

            var locations = new List<BigInteger>();
            List<string> mapNames = new List<string>() {
                "seed-to-soil map:",
                "soil-to-fertilizer map:",
                "fertilizer-to-water map:",
                "water-to-light map:",
                "light-to-temperature map:",
                "temperature-to-humidity map:",
                "humidity-to-location map:"
            };

            foreach (var seed in seeds)
            {
                BigInteger kernel = seed;
                foreach (var mapName in mapNames)
                {
                    var currentMap = Maps[mapName];
                    var entries = currentMap["Destination"].Count();
                    var conversionFound = false;

                    for (int i = 0; i < entries; i++)
                    {
                        if (conversionFound)
                        {
                            break;
                        }
                        if (kernel >= currentMap["SourceMin"][i] && kernel <= currentMap["SourceMax"][i])
                        {
                            conversionFound = true;
                            kernel = kernel + currentMap["Destination"][i] - currentMap["SourceMin"][i];
                        }
                    }
                }
                locations.Add(kernel);
            }

            return locations.Min();
        }
        public static BigInteger SolutionPart2(List<string> input)
        {
            (List<BigInteger> seeds, Dictionary<string, Dictionary<string, List<BigInteger>>> Maps) = ParseInput(input);

            var locations = new List<BigInteger>();
            List<string> mapNames = new List<string>() {
                "seed-to-soil map:",
                "soil-to-fertilizer map:",
                "fertilizer-to-water map:",
                "water-to-light map:",
                "light-to-temperature map:",
                "temperature-to-humidity map:",
                "humidity-to-location map:"
            };

            var seedRanges = new List<BigInteger>();

            var seedCounts = seeds.Count();
            for (int i = 0; i < seedCounts/2; i += 2)
            {
                Console.WriteLine($"Seed {i} of Ranges {seedCounts/2}");
                var kernel = seeds[i];
                var diff = seeds[i+1];
                for (int s = 0; s < diff; s++)
                {
                    kernel++;
                    if (!seedRanges.Contains(kernel))
                    {
                        seedRanges.Add(kernel);
                    }
                }
            }

            int se = 0;
            int sc = seedRanges.Count();
            foreach (var seed in seedRanges)
            {
                se++;
                Console.WriteLine($"Seed {se} of Ranges {sc}");
                BigInteger kernel = seed;
                foreach (var mapName in mapNames)
                {
                    var currentMap = Maps[mapName];
                    var entries = currentMap["Destination"].Count();
                    var conversionFound = false;

                    for (int i = 0; i < entries; i++)
                    {
                        if (conversionFound)
                        {
                            break;
                        }
                        if (kernel >= currentMap["SourceMin"][i] && kernel <= currentMap["SourceMax"][i])
                        {
                            conversionFound = true;
                            kernel = kernel + currentMap["Destination"][i] - currentMap["SourceMin"][i];
                        }
                    }
                }
                locations.Add(kernel);
            }

            return locations.Min();
        }
    }
}