using System;
using System.Linq;
using GameOfLife.Logic;
using GameOfLife.Models;

namespace GameOfLife.Displays
{
    public class Output : IOutput
    {
        public void DisplayCurrentGeneration(World world, Generations generations)
        {
            Console.WriteLine("==================================");
            for (int yIndex = 0; yIndex < world.Height; yIndex++)
            {
                for (int xIndex = 0; xIndex < world.Length; xIndex++)
                {
                    Console.Write($"{SetLifeDisplay(new Coordinates(xIndex, yIndex), generations)} ");
                }
                Console.WriteLine();
            }
        }

        private string SetLifeDisplay(Coordinates coordinates, Generations generations)
        {
            var cell = generations.CurrentGeneration.First(currentCell => currentCell.Position.X == coordinates.X && currentCell.Position.Y == coordinates.Y);
            return cell.Live ? "O" : "-";
        }
    }
}