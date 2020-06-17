using System;
using System.Collections.Generic;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var world = World.CreateWorld(10,5);
            var god = new God();
            var cityTest = world[1,4];
            cityTest.FindNeighbours(world);
            cityTest.Live = true;
            var neighbours = cityTest.Neighbours;
            
            foreach (var (item1, item2) in neighbours)
            {
                Console.WriteLine($"{item1}, {item2}");
            }
            SetAllNeighboursToLive(world, neighbours);

            Console.WriteLine("");
            PrintWorld(world);
        }

        private static void SetAllNeighboursToLive(City[,] world, Dictionary<string, Tuple<int, int>> neighbours)
        {
            int columnLength = world.GetLength(0);
            int rowLength = world.GetLength(1);

            for (int rowIndex = 0; rowIndex < rowLength; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < columnLength; columnIndex++)
                {
                    foreach (var neighbour in neighbours)
                    {
                        if (neighbour.Value.Item1 == columnIndex && neighbour.Value.Item2 == rowIndex)
                        {
                            world[columnIndex, rowIndex].Live = true;
                        }
                    }
                }
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
                    // Display
                    Console.Write($"{world[columnIndex, rowIndex].Display} ");
                    // Coordinates
                    // Console.Write($"({world[columnIndex, rowIndex].X} {world[columnIndex, rowIndex].Y}) ");
                }
                Console.WriteLine();
            }
        }
    }
}