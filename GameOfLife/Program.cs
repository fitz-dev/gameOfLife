﻿﻿using System;
using System.Collections.Generic;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var cellManager = new CellManager();
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
            
            var seeds = new List<Seed>()
            {
                new Seed(1,1),
                new Seed(2,1),
                new Seed(1,2),
                new Seed(2,2),
                new Seed(3,3),
                new Seed(4,3),
                new Seed(3,4),
                new Seed(4,4),
            };

            cellManager.AddSeeds(seeds);
            output.PrintWorld(world);
            for (int i = 0; i < 30; i++)
            {
                cellManager.FindNextTickLiveCities(world);
                cellManager.ApplyLifeRules(world);
                cellManager.AddSeeds(cellManager.NextTickSeeds);
                output.PrintWorld(world);
            }
        }
    }
}
