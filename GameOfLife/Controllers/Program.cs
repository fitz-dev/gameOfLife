using System;
using System.Collections.Generic;
using GameOfLife.Managers;
using GameOfLife.Models;

namespace GameOfLife.Controllers
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

            
            var validatedSeeds = new List<Cell>();
            Console.WriteLine("Enter seeds. Press 'x' to quit.");
            var seedInput = "";
            while (seedInput != "x")
            {
                // output.PrintOutput("Enter a seed X and Y separated by a comma like this: 3,4");
                
                seedInput = Console.ReadLine();
                if (seedInput != "x")
                {
                    var readyToSplit = seedInput;
                    var splitInput = readyToSplit.Split(",");
                    while (splitInput.Length != 2)
                    {
                        Console.WriteLine("That's not the right format. Remember it's 3,4 or 14,32");
                        var nextSeed = Console.ReadLine();
                        splitInput = readyToSplit.Split(",");
                    }

                    while (!int.TryParse(splitInput[0], out _) || !int.TryParse(splitInput[1], out _))
                    {
                        Console.WriteLine("That's not a number dingus.");
                        var nextSeed = Console.ReadLine();
                        splitInput = readyToSplit.Split(",");
                    }

                    validatedSeeds.Add(new Cell(new Coordinates(Convert.ToInt32(splitInput[0]),
                        Convert.ToInt32(splitInput[1]))));
                }
                

            }

            RunVisuals(20, world, validatedSeeds, stateManager);

        }

        private static void RunVisuals(int number, World world, List<Cell> seeds, StateManager stateManager)
        {
            var output = new Output();
            
            stateManager.ConstructInitialStateFor(stateManager.CurrentState, world);
            stateManager.ConstructInitialStateFor(stateManager.NextState, world);
            stateManager.AddSeedsForNextState(seeds);
            
            for (int i = 0; i <= number; i++)
            {
                output.PrintWorld(world, stateManager);
                stateManager.UpdateStatesForCurrentTick();
                stateManager.FindLiveNeighboursForAllCells();
                stateManager.DetermineCellsToLiveInNextState();
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
