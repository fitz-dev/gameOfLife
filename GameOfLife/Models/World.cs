using System;
using System.Data;

namespace GameOfLife
{
    public class World
    {
        public int[,] Grid { get; set; }

        public World(int columns, int rows)
        {
            Grid = new int[rows, columns];
        }
    }
}