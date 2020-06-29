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
            
            var seeds = new List<Seed>()
            {
                new Seed(2,1),
                new Seed(3,2),
                new Seed(1,3),
                new Seed(2,3),
                new Seed(3,3),
            };

            god.AddSeeds(world, seeds);
            output.PrintWorld(world);
            for (int i = 0; i < 30; i++)
            {
                god.FindNextTickLiveCities(world);
                god.ApplyLifeRules(world);
                god.AddSeeds(world, god.NextTickSeeds);
                output.PrintWorld(world);
            }
        }
    }
}
