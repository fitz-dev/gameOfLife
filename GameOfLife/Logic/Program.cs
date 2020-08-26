using System;
using System.Collections.Generic;
using System.Linq;
using GameOfLife.Displays;
using GameOfLife.Models;

namespace GameOfLife.Logic
{
    class Program
    {
        static void Main(string[] args)
        {
            var world = CreateWorld();
            var seeds = CreateSeeds();
            RunGame(world, seeds);
        }

        private static World CreateWorld()
        {
            var input = new ConsoleInput();
            Console.WriteLine("Hello there. Let's make a world...");
            Console.WriteLine("Enter length of the world between 1 & 100: ");
            var length = input.ProcessWorldInput(Console.ReadLine());
            Console.WriteLine("Enter height of the world between 1 & 100: ");
            var height = input.ProcessWorldInput(Console.ReadLine());
            return new World(length, height);
        }
        
        private static List<Cell> CreateSeeds()
        {
            var seeds = new List<Cell>();
            var seedInput = "";
            Console.WriteLine("Enter seed X and Y separated by a comma like this: 3,4. Press 'x' to quit.");
            while (seedInput != "x")
            {
                seedInput = Console.ReadLine();
                var splitInput = seedInput.Split(",");
                if (splitInput.Length > 1)
                {
                    seeds.Add(new Cell(new Coordinates(Convert.ToInt32(splitInput[0]), Convert.ToInt32(splitInput[1]))));
                }
            }
            return seeds;
        }

        private static void RunGame(World world, List<Cell> seeds)
        {
            var output = new ConsoleOutput();
            var generations = new Generations();

            generations.ConstructGenerations(world);
            generations.AddSeedsForNextGeneration(seeds);
            output.DisplayCurrentGeneration(world, generations);

            while (ThereAreLiveCells(generations))
            {
                generations.FindLiveNeighboursForAllCells();
                generations.UpdateGenerationsForNextTick();
                generations.DetermineIfCellsWillLiveInNextGeneration();
                System.Threading.Thread.Sleep(1000);
                output.DisplayCurrentGeneration(world, generations);
            }

            Console.WriteLine("=========Everyone's dead===========");
        }

        private static bool ThereAreLiveCells(Generations generations)
        {
            return generations.NextGeneration.Count(cell => cell.Live) > 0;
        }
        
        
    }
}
