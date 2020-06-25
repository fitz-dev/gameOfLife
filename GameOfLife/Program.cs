﻿using System;
using System.Collections.Generic;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new Input();
            var output = new Output();
            var outputMessages = new Output.Messages();
            // outputmessages in their own methods? 
            output.PrintOutput(outputMessages.Welcome);
            
            Console.WriteLine(outputMessages.AskLength);
            var columnInt = input.ProcessWorldInput(Console.ReadLine());
            Console.WriteLine(outputMessages.AskHeight);
            var rowInt = input.ProcessWorldInput(Console.ReadLine());
            
            var world = new World(columnInt,rowInt);
            
            // seeds as input? make a city or create seed from input? 
            var allSeeds = new List<(Seeds)>()
            {
                (2,4),
                (3,4),
                (5,6),
                (7,8)
            };

            var columnIndex = 0;
            var rowIndex = 0;
            var god = new God();

            Console.WriteLine(outputMessages.SeedXEntry);
            columnIndex = input.ProcessSeedInput(world, Console.ReadLine());
            Console.WriteLine(outputMessages.SeedYEntry);
            columnIndex = input.ProcessSeedInput(world, Console.ReadLine());
            // allSeeds.Add(seed.x = columnIndex, seed.y = rowIndex);
            
            
            god.AddSeeds(world, columnIndex, rowIndex);

            Console.WriteLine(outputMessages.SeedXEntry);

            
            Console.WriteLine("=Initial=============================");
            output.PrintWorld(world);
       
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