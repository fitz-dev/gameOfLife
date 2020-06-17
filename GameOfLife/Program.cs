using System;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var world = World.CreateWorld(10,10);
            var god = new God();
            god.AddSeeds(world, 3, 2);
            god.AddSeeds(world, 6, 9);
            god.AddSeeds(world, 2, 5);

            PrintWorld(world);
            Console.WriteLine(world.Length);
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