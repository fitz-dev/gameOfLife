using System;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var world = new World().CreateWorld(10,10);

            AddSeed(world, 5, 5);
            AddSeed(world, 3, 2);

            PrintWorld(world);
        }

        private static void AddSeed(City[,] world, int xIndex, int yIndex)
        {
            world[xIndex, yIndex].Live = true;
        }

        private static void PrintWorld(City[,] world)
        {
            int rowLength = world.GetLength(0);
            int columnLength = world.GetLength(1);

            for (int xIndex = 0; xIndex < rowLength; xIndex++)
            {
                for (int yIndex = 0; yIndex < columnLength; yIndex++)
                {
                    world[xIndex, yIndex].SetLifeDisplay();
                    Console.Write($"{world[xIndex, yIndex].Display} ");
                }
                Console.WriteLine();
            }
        }
    }
}