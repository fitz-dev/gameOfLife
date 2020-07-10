using System;
using GameOfLife.Models;

namespace GameOfLife
{
    public class Input
    {
        public int ProcessWorldInput(string input)
        {
            var outputMessage = new Output.Messages();
            
            input = ValidateInputFormat(input, outputMessage);
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

        private string ValidateInputFormat(string input, Output.Messages outputMessage)
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
        
        // public int ProcessSeedInput(string input)
        // {
        //     var outputMessage = new Output.Messages();
        //     
        //     input = ValidateSeedInput(input);
        //     input = ValidateValues(input, outputMessage);
        //     
        //     return Convert.ToInt32(input);
        // }
        
        public int ValidateSeedInput(string input)
        {
            var outputMessage = new Output.Messages();
            var splitInput = input.Split(",");

            for (int i = 0; i < splitInput.Length; i++)
            {
                input += ValidateInputFormat(input, outputMessage);
            }
            return Convert.ToInt32(input);
        }
        
        private string ValidateSeedValues(string input, World world, Output.Messages outputMessage)
        {
            while (IsInvalidSeedLength(input, world) || IsInvalidSeedHeight(input, world))
            {
                Console.WriteLine(outputMessage.InputTooHighOrLow);
                input = Console.ReadLine();
            }
            return input;
        }

        private bool IsInvalidSeedLength(string input, World world)
        {
            var convertedInput = Convert.ToInt32(input);
            return convertedInput > world.Length;
        }

        private bool IsInvalidSeedHeight(string input, World world)
        {
            var convertedInput = Convert.ToInt32(input);
            return convertedInput > world.Height;
        }
    }
}