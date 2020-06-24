using System;
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
            Console.WriteLine(outputMessages.Welcome);
            Console.WriteLine(outputMessages.AskLength);
            var columnInt = input.ProcessInput(Console.ReadLine());
            Console.WriteLine(outputMessages.AskHeight);
            var rowInt = input.ProcessInput(Console.ReadLine());
            

            var world = new World(columnInt,rowInt);

            var god = new God();
            god.AddSeeds(world, 2, 3);
            god.AddSeeds(world, 3, 2);
            god.AddSeeds(world, 1, 2);
            god.AddSeeds(world, 3, 1);
            god.AddSeeds(world, 5, 1);
            god.AddSeeds(world, 5, 2);
            god.AddSeeds(world, 5, 0);
            
            Console.WriteLine("=Initial=============================");
            output.PrintWorld(world);
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
        }
    }
}