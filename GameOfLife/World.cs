using System;
using System.Data;

namespace GameOfLife
{
    public class World
    {
        public int ColumnLength { get; set; }
        public int RowLength { get; set; }
        public int[,] Grid { get; set; }
        // public int[,] grid { get; }

        public World(int columns, int rows)
        {
            ColumnLength = columns;
            RowLength = rows;
            Grid = new int[rows, columns];
            // Grid = CreateWorld(columns, rows);
        }
        // public Cell[,] CreateWorld(int columns, int rows)
        // {
        //     var world = new Cell[columns, rows];
        //         
        //     for (int rowIndex = 0; rowIndex < rows; rowIndex++)
        //     {
        //         for (int columnIndex = 0; columnIndex < columns; columnIndex++)
        //         {
        //             world[columnIndex,rowIndex] = new Cell(columnIndex, rowIndex);
        //         }
        //     }
        //     return world;
        // }
    }
}