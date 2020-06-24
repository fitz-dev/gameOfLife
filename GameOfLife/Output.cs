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
            public string AskLength = "Enter length of the world between 1 & 100: ";
            public string AskHeight = "Enter height of the world between 1 & 100: ";
            public string IncorrectFormat = "That's not a number, please try again.";
            public string InputTooHighOrLow = "That number is too high or too low.";
            public string FirstSeedEntry = "Please enter an X & Y coordinate split by a comma for where you would like your first seed. E.g 3,4";
            public string EnterAnotherSeed = "Enter another seed or press type 'exit' to finish.";
            public string SeedTooHighOrLow = "That seed doesn't fit on the world. Try again.";
            public string IncorrectSeedFormat = "That doesn't seem right. Try again.";
            public string IncorrectSeedCoordinateFormat = "You haven't enter the coordinate properly, it's an X & Y like this: 3,4. Try again.";
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