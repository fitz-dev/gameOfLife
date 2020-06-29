﻿﻿using System;
using System.Collections.Generic;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var god = new God();
            var input = new Input();
            var output = new Output();
            var outputMessages = new Output.Messages();
            // outputmessages in their own methods? 
            output.PrintOutput(outputMessages.Welcome);
            
            Console.WriteLine(outputMessages.AskLength);
            var columnInt = input.ProcessWorldInput(Console.ReadLine());
            Console.WriteLine(outputMessages.AskHeight);
            var rowInt = input.ProcessWorldInput(Console.ReadLine());
            
            var world = new World(god, columnInt,rowInt);
            
            // seeds as input? make a city or create seed from input? 
            var allSeeds = new List<(int, int)>()
            {
                (2,4),
                (2,6),
                (3,5),
                (4,4),
                (4,6)
            };

        }
    }
}
