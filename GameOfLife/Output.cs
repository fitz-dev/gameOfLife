using System;
using System.Net;
using System.Threading.Tasks.Dataflow;

namespace GameOfLife
{
    public class Output : IOutput
    {
        public class Messages
        {
            public string Welcome = "Hello God. Let's make a world...";
            public string AskLength = "Enter length of the world between 0 & 100: ";
            public string AskHeight = "Enter height of the world between 0 & 100: ";
            public string IncorrectFormat = "That's not a number, please try again.";
            public string InputTooHighOrLow = "That number is too high or too low.";
        } 
        public string GetWorldSize()
        {
            Console.WriteLine("Hello God. Let's make a world...");
            
            Console.WriteLine("Enter length of the world between 1 & 100: ");
            
            var columns = Console.ReadLine();
            Console.WriteLine("Enter height of the world between 1 & 100: ");
            var rows = Console.ReadLine();
            return "";
        }

        public string GetSeedPlacement()
        {
            throw new System.NotImplementedException();
        }

        public void PrintWorld(World world)
        {
            for (int rowIndex = 0; rowIndex < world.RowLength; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < world.ColumnLength; columnIndex++)
                {
                    Console.Write($"{SetLifeDisplay(world.Grid[columnIndex, rowIndex])} ");
                }
                Console.WriteLine();
            }
        }
        
        public string SetLifeDisplay(City city)
        {
            return city.Live ? "O" : "-";
        }
    }
}