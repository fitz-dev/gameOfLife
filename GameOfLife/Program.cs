﻿﻿using System;
using System.Collections.Generic;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var cellManager = new CellManager();
            var input = new Input();
            var output = new Output();
            var outputMessages = new Output.Messages();
            // outputmessages in their own methods? 
            // output.PrintOutput(outputMessages.Welcome);
            //
            // Console.WriteLine(outputMessages.AskLength);
            // var columnInt = input.ProcessWorldInput(Console.ReadLine());
            // Console.WriteLine(outputMessages.AskHeight);
            // var rowInt = input.ProcessWorldInput(Console.ReadLine());
            
            var world = new World(20,20);
            
            var seeds = new List<Coordinates>()
            {
                new Coordinates(1,1),
                new Coordinates(2,1),
                new Coordinates(1,2),
                new Coordinates(2,2),
                new Coordinates(3,3),
                new Coordinates(4,3),
                new Coordinates(3,4),
                new Coordinates(4,4),
            };

            ProgressTicks(10, world, seeds, cellManager);
            
        }

        private static void ProgressTicks(int number, World world, List<Coordinates> seeds, CellManager cellManager)
        {
            var output = new Output();
            cellManager.CurrentState = seeds;
            for (int i = 0; i <= number; i++)
            {
                cellManager.PreviousState.Clear();
                cellManager.PreviousState.AddRange(cellManager.CurrentState);
                cellManager.CurrentState.Clear();
                cellManager.CheckEachCellForLife(world);
                output.PrintWorld(world, cellManager);
            }
        }
    }
}
