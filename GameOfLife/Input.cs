using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.Linq;

namespace GameOfLife
{
    public class Input
    {
        public int ProcessSeedInput(World world, string input)
        {
            var outputMessage = new Output.Messages();

            input = ValidateWorldFormat(input, outputMessage);
            // input = ValidateCoordinateValues(world, input);
            // while (!IsValidCoordinate(world, input) || !IsNumber(input))
            // {
            //     Console.WriteLine(outputMessage.SeedXEntry);
            //     input = Console.ReadLine();
            // }
            return Convert.ToInt32(input);
        }

        private bool ValidateCoordinateValues(World world, string input)
        {
            var convertedInput = Convert.ToInt32(input);
            return convertedInput > world.Grid.GetLength(0) || convertedInput > world.Grid.GetLength(1);
        }
        
        //
        // public Tuple<int, int> ProcessSeedFormat(string seed)
        // {
        //     var coordinates = seed.Split(",");
        //     return new Tuple<int, int>(Convert.ToInt32(coordinates[0]), Convert.ToInt32(coordinates[1]));
        // }
       
        public int ProcessWorldInput(string input)
        {
            var outputMessage = new Output.Messages();
            
            input = ValidateWorldFormat(input, outputMessage);
            input = ValidateValues(input, outputMessage);
            
            return Convert.ToInt32(input);
        }

        private string ValidateValues(string input, Output.Messages outputMessage)
        {
            while (IsInvalidWorldNumber(input))
            {
                Console.WriteLine(outputMessage.InputTooHighOrLow);
                input = Console.ReadLine();
            }
            return input;
        }

        private bool IsInvalidWorldNumber(string input)
        {
            var convertedInput = Convert.ToInt32(input);
            return convertedInput < 1 || convertedInput > 100;
        }

        private string ValidateWorldFormat(string input, Output.Messages outputMessage)
        {
            while (!IsNumber(input))
            {
                Console.WriteLine(outputMessage.IncorrectFormat);
                input = Console.ReadLine();
            }
            return input;
        }

        private bool IsNumber(string input)
        {
            return int.TryParse(input, out _);
        }
    }
}