using System;
using System.Data;

namespace GameOfLife
{
    public class World
    {
        public static City[,] CreateWorld(int rows, int columns)
        {
            var world = new City[rows, columns];
            
            int rowLength = world.GetLength(0);
            int columnLength = world.GetLength(1);

            for (int xIndex = 0; xIndex < rowLength; xIndex++)
            {
                for (int yIndex = 0; yIndex < columnLength; yIndex++)
                {
                    world[xIndex,yIndex] = new City(xIndex, yIndex);
                }
            }
            return world;
        }
    }
}