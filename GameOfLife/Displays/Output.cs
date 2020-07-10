using System;
using System.Linq;
using GameOfLife.Models;

namespace GameOfLife
{
    public class Output : IOutput
    {
        public class Messages
        {
            public string Welcome = "Hello there. Let's make a world...";
            public string AskLength = "Enter length of the world between 1 & 100: ";
            public string AskHeight = "Enter height of the world between 1 & 100: ";
            public string IncorrectFormat = "That's not a number, please try again.";
            public string InputTooHighOrLow = "That number is too high or too low.";
            public string SeedXEntry = "Please enter a number for your X coordinate";
            public string SeedYEntry = "Please enter a number for your Y coordinate";
            public string EnterAnotherSeed = "Enter another seed or press type 'exit' to finish.";
            public string SeedTooHighOrLow = "That seed doesn't fit on the world. Try again.";
            public string IncorrectSeedFormat = "That doesn't seem right. Try again.";
            public string IncorrectSeedCoordinateFormat = "You haven't enter the coordinate properly, it's an X & Y like this: 3,4. Try again.";
            public string Separator = "=====================";
        }

        public void PrintOutput(string message)
        {
            Console.WriteLine(message);
        }


        public void PrintWorld(World world, Generations generations)
        {
            Console.WriteLine("==================================");
            for (int xIndex = 0; xIndex < world.Length; xIndex++)
            {
                for (int yIndex = 0; yIndex < world.Height; yIndex++)
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