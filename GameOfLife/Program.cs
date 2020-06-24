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
            var columnInt = input.ProcessWorldInput(Console.ReadLine());
            Console.WriteLine(outputMessages.AskHeight);
            var rowInt = input.ProcessWorldInput(Console.ReadLine());
            
            var world = new World(columnInt,rowInt);
            
            var seeds = new List<Tuple<int, int>>();
            
            Console.WriteLine(outputMessages.FirstSeedEntry);
            var seed = Console.ReadLine();
            
            input.ValidateSeed(world, seed);
            seeds.Add(input.ProcessSeedFormat(seed));
            
            Console.WriteLine(outputMessages.EnterAnotherSeed);
            var additionalSeeds = "";
            
            while (additionalSeeds != "exit")
            {
                additionalSeeds = Console.ReadLine();
                if (additionalSeeds != "exit")
                {
                    input.ValidateSeed(world, additionalSeeds);
                    seeds.Add(input.ProcessSeedFormat(additionalSeeds)); 
                    Console.WriteLine(outputMessages.EnterAnotherSeed);
                }
            }
            
            

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