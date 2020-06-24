using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;

namespace GameOfLife
{
    public class Input
    {
       
        public int ProcessInput(string input)
        {
            var outputMessage = new Output.Messages();
            
            input = ValidateFormat(input, outputMessage);
            input = ValidateValues(input, outputMessage);
            
            return Convert.ToInt32(input);
        }

        private string ValidateValues(string input, Output.Messages outputMessage)
        {
            while (IsInvalidNumber(input))
            {
                Console.WriteLine(outputMessage.InputTooHighOrLow);
                input = Console.ReadLine();
            }

            return input;
        }

        private bool IsInvalidNumber(string input)
        {
            var convertedInput = Convert.ToInt32(input);
            return convertedInput < 1 || convertedInput > 100;
        }

        private string ValidateFormat(string input, Output.Messages outputMessage)
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