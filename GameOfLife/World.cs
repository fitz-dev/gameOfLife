using System;
using System.Data;

namespace GameOfLife
{
    public class World
    {
        public int ColumnLength { get; set; }
        public int RowLength { get; set; }
        public int[,] Grid { get; set; }

        public World(int columns, int rows)
        {
            ColumnLength = columns;
            RowLength = rows;
            Grid = new int[rows, columns];
        }
    }
}