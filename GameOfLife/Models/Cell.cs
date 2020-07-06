using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class Cell
    {
        public bool Live;
        public Coordinates Position;
        public Dictionary<string, Coordinates> Neighbours;
        public int NumLiveNeighbours;
        
        public Cell(Coordinates position)
        {
            Position = position;
        }
    }
}

