using System;
using System.Data;

namespace GameOfLife
{
    public class World
    {
        public static City[,] CreateWorld(int columns, int rows)
        {
            var world = new City[columns, rows];
            
            int columnLength = world.GetLength(0);
            int rowLength = world.GetLength(1);

            for (int rowIndex = 0; rowIndex < rowLength; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < columnLength; columnIndex++)
                {
                    world[columnIndex,rowIndex] = new City(columnIndex, rowIndex);
                }
            }
            // for (int columnIndex = 0; columnIndex < rowLength; columnIndex++)
            // {
            //     for (int rowIndex = 0; rowIndex < columnLength; rowIndex++)
            //     {
            //         world[columnIndex,rowIndex] = new City(columnIndex, rowIndex);
            //     }
            // }
            return world;
        }
    }
}