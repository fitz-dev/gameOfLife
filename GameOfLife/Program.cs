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
            
            var seeds = new List<Cell>()
            {
                new Cell(new Coordinates(4,2)),
                new Cell(new Coordinates(5,2)),
                new Cell(new Coordinates(6,2)),
                new Cell(new Coordinates(10,2)),
                new Cell(new Coordinates(11,2)),
                new Cell(new Coordinates(12,2)),
                new Cell(new Coordinates(2,4)),
                new Cell(new Coordinates(7,4)),
                new Cell(new Coordinates(9,4)),
                new Cell(new Coordinates(14,4)),
                new Cell(new Coordinates(2,5)),
                new Cell(new Coordinates(7,5)),
                new Cell(new Coordinates(9,5)),
                new Cell(new Coordinates(14,5)),
                new Cell(new Coordinates(2,6)),
                new Cell(new Coordinates(7,6)),
                new Cell(new Coordinates(9,6)),
                new Cell(new Coordinates(14,6)),
                new Cell(new Coordinates(4,7)),
                new Cell(new Coordinates(5,7)),
                new Cell(new Coordinates(6,7)),
                new Cell(new Coordinates(10,7)),
                new Cell(new Coordinates(11,7)),
                new Cell(new Coordinates(12,7)),
                new Cell(new Coordinates(4,9)),
                new Cell(new Coordinates(5,9)),
                new Cell(new Coordinates(6,9)),
                new Cell(new Coordinates(10,9)),
                new Cell(new Coordinates(11,9)),
                new Cell(new Coordinates(12,9)),
                new Cell(new Coordinates(2,10)),
                new Cell(new Coordinates(7,10)),
                new Cell(new Coordinates(9,10)),
                new Cell(new Coordinates(14,10)),
                new Cell(new Coordinates(2,11)),
                new Cell(new Coordinates(7,11)),
                new Cell(new Coordinates(9,11)),
                new Cell(new Coordinates(14,11)),
                new Cell(new Coordinates(2,12)),
                new Cell(new Coordinates(7,12)),
                new Cell(new Coordinates(9,12)),
                new Cell(new Coordinates(14,12)),
                new Cell(new Coordinates(4,14)),
                new Cell(new Coordinates(5,14)),
                new Cell(new Coordinates(6,14)),
                new Cell(new Coordinates(10,14)),
                new Cell(new Coordinates(11,14)),
                new Cell(new Coordinates(12,14)),
            };

            RunVisuals(10, world, seeds, stateManager);
            
        }

        private static void RunVisuals(int number, World world, List<Cell> seeds, StateManager stateManager)
        {
            var output = new Output();
            
            stateManager.ConstructInitialStateFor(stateManager.CurrentState, world);
            stateManager.ConstructInitialStateFor(stateManager.NextState, world);
            
            stateManager.AddCoordinatesForNextState(seeds);
            
            for (int i = 0; i <= number; i++)
            {
                output.PrintWorld(world, stateManager);
                stateManager.RefreshStatesForNextTick();
                stateManager.FindLiveNeighboursForAllCells();
                stateManager.DetermineCellsToLiveInNextState();
            }
        }
    }
}
