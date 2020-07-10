using System;

namespace GameOfLife.Displays
{
    public class Input
    {
        public int ProcessWorldInput(string input)
        {
            input = ValidateInputFormat(input);
            input = ValidateValues(input);
            
            return Convert.ToInt32(input);
        }

        private string ValidateValues(string input)
        {
            while (IsInvalidWorldNumber(input))
            {
                Console.WriteLine("That number is too high or too low.");
                input = Console.ReadLine();
            }
            return input;
        }

        private bool IsInvalidWorldNumber(string input)
        {
            var minWorldSize = 1;
            var maxWorldSize = 100;
            var convertedInput = Convert.ToInt32(input);
            return convertedInput < minWorldSize || convertedInput > maxWorldSize;
        }

        private string ValidateInputFormat(string input)
        {
            while (!IsNumber(input))
            {
                Console.WriteLine("That's not a number, please try again.");
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