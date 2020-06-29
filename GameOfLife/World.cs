using System;
using System.Data;

namespace GameOfLife
{
    public class World
    {
        public int ColumnLength { get; set; }
        public int RowLength { get; set; }
        public Cell[,] Grid { get; set; }
        // public int[,] grid { get; }

        public World(CellManager cellManager, int columns, int rows)
        {
            ColumnLength = columns;
            RowLength = rows;
            Grid = cellManager.CreateWorld(columns, rows);
            // Grid = new Cell[rows, columns];
        }
    }
}