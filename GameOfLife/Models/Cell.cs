using System.Collections.Generic;

namespace GameOfLife.Models
{
    public class Cell
    {
        public bool Live;
        public Coordinates Position;
        public List<Coordinates> Neighbours;
        public int NumLiveNeighbours;
        
        public Cell(Coordinates position)
        {
            Position = position;
        }
    }
}

