using System;
using System.Collections.Generic;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var world = World.CreateWorld(10,10);
            var god = new God();
            god.AddSeeds(world, 2, 5);
            var cityTest = god.FetchCity(world, 2, 5);
            cityTest.FindNeighbours(world);
            
            var neighbours = cityTest.Neighbours;
            
            foreach (var (item1, item2) in neighbours)
            {
                Console.WriteLine($"{item1}, {item2}");
            }

            Console.WriteLine("");
            
            PrintWorld(world);
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