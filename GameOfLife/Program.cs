﻿﻿using System;
using System.Collections.Generic;
  using GameOfLife.Managers;
  using GameOfLife.Models;

  namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var stateManager = new StateManager();
            var input = new Input();
            var output = new Output();
            var outputMessages = new Output.Messages();
            // outputmessages in their own methods? 
            output.PrintOutput(outputMessages.Welcome);
            
            Console.WriteLine(outputMessages.AskLength);
            var columnInt = input.ProcessWorldInput(Console.ReadLine());
            Console.WriteLine(outputMessages.AskHeight);
            var rowInt = input.ProcessWorldInput(Console.ReadLine());
            
            var world = new World(columnInt,rowInt);
            
            var seeds = new List<Coordinates>()
            {
                new Coordinates(2,2),
                new Coordinates(3,2),
                new Coordinates(4,2),
                new Coordinates(1,3),
                new Coordinates(2,3),
                new Coordinates(3,3),
            };

            var seedCells = AddSeeds(seeds);

            RunVisuals(10, world, seedCells, stateManager);
            
        }

        private static List<Cell> AddSeeds(List<Coordinates> seeds)
        {
            var seedCells = new List<Cell>();
            foreach (var seed in seeds)
            {
                seedCells.Add(new Cell(new Coordinates(seed.X, seed.Y)));
            }

            return seedCells;
        }

        private static void RunVisuals(int number, World world, List<Cell> seeds, StateManager stateManager)
        {
            var output = new Output();
            stateManager.CurrentState = seeds;
            output.PrintWorld(world, stateManager);
            for (int i = 0; i <= number; i++)
            {
                // stateManager.SetCurrentStateToPreviousState();
                // stateManager.ConstructInitialState(world);
                // output.PrintWorld(world, stateManager);
            }
        }
    }
}
