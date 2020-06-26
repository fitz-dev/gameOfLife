using System;
using System.Data;

namespace GameOfLife
{
    public class World
    {
        public int ColumnLength { get; set; }
        public int RowLength { get; set; }
        public City[,] Grid { get; set; }

        public World(God god, int columns, int rows)
        {
            ColumnLength = columns;
            RowLength = rows;
            Grid = god.CreateWorld(columns, rows);
        }
    }
}