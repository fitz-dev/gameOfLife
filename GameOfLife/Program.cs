using System;
using System.Collections.Generic;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var world = World.CreateWorld(10,10);
            int columnLength = world.GetLength(0);
            int rowLength = world.GetLength(1);
            
            var god = new God();
            god.AddSeeds(world, 2, 3);
            god.AddSeeds(world, 3, 2);
            god.AddSeeds(world, 1, 2);
            god.AddSeeds(world, 3, 1);
            god.AddSeeds(world, 5, 1);
            god.AddSeeds(world, 5, 2);
            god.AddSeeds(world, 5, 0);
            
            Console.WriteLine("=1111=============================");
            PrintWorld(world);
            
            Console.WriteLine("=2222=============================");
            for (int rowIndex = 0; rowIndex < rowLength; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < columnLength; columnIndex++)
                {
                    var city = world[columnIndex, rowIndex];
                    city.FindNeighbours(world);
                    city.GetNumberOfLiveNeighbours(world);
                    god.ApplyLifeRules(city);
                }
            }
            PrintWorld(world);

            for (int i = 3; i < 10; i++)
            {
                Console.WriteLine($"={i}{i}{i}{i}==================");
                world = World.CreateWorld(10,10);
                foreach (var city in god.NextTickLiveCities)
                {
                    god.AddSeeds(world, city.X, city.Y);
                }
                god.NextTickLiveCities = new List<City>();
                for (int rowIndex = 0; rowIndex < rowLength; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < columnLength; columnIndex++)
                    {
                        var city = world[columnIndex, rowIndex];
                        city.FindNeighbours(world);
                        city.GetNumberOfLiveNeighbours(world);
                        god.ApplyLifeRules(city);
                    }
                }
                PrintWorld(world);
            }
        }

        private static void SetAllNeighboursToLive(City[,] world, Dictionary<string, Tuple<int, int>> neighbours)
        {
            foreach (var neighbour in neighbours)
            {
                var columnIndex = neighbour.Value.Item1;
                var rowIndex = neighbour.Value.Item2;
                world[columnIndex, rowIndex].Live = true;
                world[columnIndex, rowIndex].SetLifeDisplay();
            }
        }

        private static void PrintWorld(City[,] world)
        {
            int columnLength = world.GetLength(0);
            int rowLength = world.GetLength(1);

            for (int rowIndex = 0; rowIndex < rowLength; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < columnLength; columnIndex++)
                {
                    Console.Write($"{world[columnIndex, rowIndex].Display} ");
                }
                Console.WriteLine();
            }
        }
    }
}