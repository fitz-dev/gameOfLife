using System;
using System.Collections.Generic;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var world = new World(10,10);

            var god = new God();
            god.AddSeeds(world, 2, 3);
            god.AddSeeds(world, 3, 2);
            god.AddSeeds(world, 1, 2);
            god.AddSeeds(world, 3, 1);
            god.AddSeeds(world, 5, 1);
            god.AddSeeds(world, 5, 2);
            god.AddSeeds(world, 5, 0);
            
            Console.WriteLine("=Initial=============================");
            PrintWorld(world);
            
            Console.WriteLine("==============================");
            ProcessEachCell(world, god);
            PrintWorld(world);

            while (god.NextTickLiveCities.Count > 0)
            {
                Console.WriteLine($"===================");
                world = new World(10,10);
                foreach (var city in god.NextTickLiveCities)
                {
                    god.AddSeeds(world, city.X, city.Y);
                }
                god.NextTickLiveCities = new List<City>();
                ProcessEachCell(world, god);
                PrintWorld(world);
            }
        }

        private static void ProcessEachCell(World world, God god)
        {
            for (int rowIndex = 0; rowIndex < world.RowLength; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < world.ColumnLength; columnIndex++)
                {
                    var city = world.Grid[columnIndex, rowIndex];
                    city.FindNeighbours(world);
                    city.FindNumberOfLiveNeighbours(world);
                    god.ApplyLifeRules(city);
                }
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

        private static void PrintWorld(World world)
        {
            for (int rowIndex = 0; rowIndex < world.RowLength; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < world.ColumnLength; columnIndex++)
                {
                    Console.Write($"{world.Grid[columnIndex, rowIndex].Display} ");
                }
                Console.WriteLine();
            }
        }
    }
}