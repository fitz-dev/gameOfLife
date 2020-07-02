﻿﻿using System;
using System.Collections.Generic;

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

            RunVisuals(10, world, seeds, stateManager);
            
        }

        private static void RunVisuals(int number, World world, List<Coordinates> seeds, StateManager stateManager)
        {
            var output = new Output();
            stateManager.CurrentState = seeds;
            output.PrintWorld(world, stateManager);
            for (int i = 0; i <= number; i++)
            {
                stateManager.RefreshStates();
                stateManager.ProcessWorldForCurrentState(world);
                output.PrintWorld(world, stateManager);
            }
        }
    }
}
