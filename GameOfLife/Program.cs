﻿﻿using System;
using System.Collections.Generic;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var god = new God();
            var input = new Input();
            var output = new Output();
            var outputMessages = new Output.Messages();
            // outputmessages in their own methods? 
            output.PrintOutput(outputMessages.Welcome);
            
            Console.WriteLine(outputMessages.AskLength);
            var columnInt = input.ProcessWorldInput(Console.ReadLine());
            Console.WriteLine(outputMessages.AskHeight);
            var rowInt = input.ProcessWorldInput(Console.ReadLine());
            
            var world = new World(god, columnInt,rowInt);
            
            // seeds as input? make a city or create seed from input? 
            var allSeeds = new List<(int, int)>()
            {
                (2,4),
                (2,6),
                (3,5),
                (4,4),
                (4,6)
            };

            foreach (var seed in allSeeds)
            {
                god.AddSeed(world, seed.Item1, seed.Item2);
            }

            Console.WriteLine($"live cities: {god.LiveCities.Count}");

            for (int rowIndex = 0; rowIndex < world.RowLength; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < world.ColumnLength; columnIndex++)
                {
                    var city = world.Grid[columnIndex, rowIndex];
                    city.GetNumberOfLiveNeighbours(world);
                    god.CompareNumberOfLiveNeighbours(city);
                }
            }
            
            Console.WriteLine($"new live cities: {god.NextTickLiveCities.Count}");

            foreach (var city in god.NextTickLiveCities)
            {
                Console.WriteLine($"{city.Column}, {city.Row}");
            }
            
            
            // while (god.NextTickLiveCities.Count > 0)
            // {
            //     Console.WriteLine($"===================");
            //     world = new World(10,10);
            //     foreach (var city in god.NextTickLiveCities)
            //     {
            //         god.AddSeed(world, city.Column, city.Row);
            //     }
            //     god.NextTickLiveCities = new List<City>();
            //     ProcessEachCell(world, god);
            //     PrintWorld(world);
            // }
        }
    }
}

// Console.WriteLine("==============================");
// ProcessEachCell(world, god);
// PrintWorld(world);
//
// while (god.NextTickLiveCities.Count > 0)
// {
//     Console.WriteLine($"===================");
//     world = new World(10,10);
//     foreach (var city in god.NextTickLiveCities)
//     {
//         god.AddSeeds(world, city.X, city.Y);
//     }
//     god.NextTickLiveCities = new List<City>();
//     ProcessEachCell(world, god);
//     PrintWorld(world);
// }