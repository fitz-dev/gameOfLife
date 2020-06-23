using System;
using System.Data;

namespace GameOfLife
{
    public class World
    {
        public static int Columns;
        public static int Rows;
        public static int ColumnLength { get; set; }
        public static int RowLength { get; set; }
        public City[,] Population { get; set; }

        public World(int columns, int rows)
        {
            Columns = columns;
            ColumnLength = columns - 1;
            Rows = rows;
            RowLength = rows - 1;
            Population = CreateWorld();
        }

        public static City[,] CreateWorld()
        {
            var world = new City[Columns, Rows];
                
            for (int rowIndex = 0; rowIndex < RowLength; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < ColumnLength; columnIndex++)
                {
                    world[columnIndex,rowIndex] = new City(columnIndex, rowIndex);
                }
            }
            return world;
        }
    }
}