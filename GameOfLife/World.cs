using System;
using System.Data;

namespace GameOfLife
{
    public class World
    {
        public int ColumnLength { get; set; }
        public int RowLength { get; set; }
        public City[,] Grid { get; set; }

        public World(int columns, int rows)
        {
            ColumnLength = columns - 1;
            RowLength = rows - 1;
            Grid = CreateWorld(columns, rows);
        }
        public City[,] CreateWorld(int columns, int rows)
        {
            var world = new City[columns, rows];
                
            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < columns; columnIndex++)
                {
                    world[columnIndex,rowIndex] = new City(columnIndex, rowIndex);
                }
            }
            return world;
        }

    }
}