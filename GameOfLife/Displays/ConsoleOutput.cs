using System;
using System.Linq;
using GameOfLife.Logic;
using GameOfLife.Models;

namespace GameOfLife.Displays
{
    public class ConsoleOutput : IOutput
    {
        public void DisplayCurrentGeneration(World world, Generations generations)
        {
            Console.WriteLine("==================================");
            for (int yIndex = 0; yIndex < world.Height; yIndex++)
            {
                for (int xIndex = 0; xIndex < world.Length; xIndex++)
                {
                    Console.Write($"{SetLifeDisplay(generations, xIndex, yIndex)} ");
                }
                Console.WriteLine();
            }
        }

        private string SetLifeDisplay(Generations generations, int x, int y)
        {
            var cell = generations.CurrentGeneration.First(currentCell => currentCell.Position.X == x && currentCell.Position.Y == y);
            return cell.Live ? "O" : "-";
        }
    }
}