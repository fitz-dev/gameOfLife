using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;

namespace GameOfLife
{
    public class Cell
    {
        public Dictionary<string, Seed> Neighbours;
        public Seed Coordinates;
        public bool Live;
        public int LiveNeighbours;
        
        public Cell(Seed seed)
        {
            Coordinates = seed;
        }

        public void SetNumberOfLiveNeighbours(List<Seed> liveCities)
        {
            LiveNeighbours = 0;
            LiveNeighbours = Neighbours.Count(neighbour => liveCities.Any(city => neighbour.Value.X == city.X && neighbour.Value.Y == city.Y));
        }

        public Dictionary<string, Seed> FindNeighbours(int worldLength, int worldHeight)
        {
            var neighbours = new Dictionary<string, Seed>
            {
                {"topLeft", CheckForEdgeNeighbours(SetTopLeft(), worldLength, worldHeight)},
                {"left", CheckForEdgeNeighbours(SetLeft(), worldLength, worldHeight)},
                {"bottomLeft", CheckForEdgeNeighbours(SetBottomLeft(), worldLength, worldHeight)},
                {"top", CheckForEdgeNeighbours(SetTop(), worldLength, worldHeight)},
                {"bottom", CheckForEdgeNeighbours(SetBottom(), worldLength, worldHeight)},
                {"topRight", CheckForEdgeNeighbours(SetTopRight(), worldLength, worldHeight)},
                {"right", CheckForEdgeNeighbours(SetRight(), worldLength, worldHeight)},
                {"bottomRight", CheckForEdgeNeighbours(SetBottomRight(), worldLength, worldHeight)}
            };
            return neighbours;
        }
        
        private Seed CheckForEdgeNeighbours(Seed coordinates, int worldLength, int worldHeight)
        {
            var columnIndex = coordinates.Y;
            var rowIndex = coordinates.X;
            
            columnIndex = CheckForIndexSmallerThanWorld(columnIndex, worldHeight - 1);
            columnIndex = CheckForIndexLargerThanWorld(columnIndex, worldLength - 1);

            rowIndex = CheckForIndexSmallerThanWorld(rowIndex, worldHeight - 1);
            rowIndex = CheckForIndexLargerThanWorld(rowIndex, worldLength - 1);
      
            return new Seed(rowIndex, columnIndex);
        }

        private int CheckForIndexSmallerThanWorld(int coordinate, int axisSize)
        {
            return coordinate < 0 ? axisSize : coordinate;
        }
        private int CheckForIndexLargerThanWorld(int coordinate, int axisSize)
        {
            return coordinate > axisSize ? 0 : coordinate;
        }

        private Seed SetTopLeft()
        {
            var neighbourX = Coordinates.X - 1;
            var neighbourY = Coordinates.Y - 1;
            return new Seed(neighbourX, neighbourY);
        } 
        
        private Seed SetLeft()
        {
            var neighbourX = Coordinates.X - 1;
            var neighbourY = Coordinates.Y;
            return new Seed(neighbourX, neighbourY);
        }
        
        private Seed SetBottomLeft()
        {
            var neighbourX = Coordinates.X - 1;
            var neighbourY = Coordinates.Y + 1;
            return new Seed(neighbourX, neighbourY);
        }
        
        private Seed SetTop()
        {
            var neighbourX = Coordinates.X;
            var neighbourY = Coordinates.Y - 1;
            return new Seed(neighbourX, neighbourY);
        } 
        
        private Seed SetBottom()
        {
            var neighbourX = Coordinates.X;
            var neighbourY = Coordinates.Y + 1;
            return new Seed(neighbourX, neighbourY);
        }
        
        private Seed SetTopRight()
        {
            var neighbourX = Coordinates.X + 1;
            var neighbourY = Coordinates.Y - 1;
            return new Seed(neighbourX, neighbourY);
        }
        
        private Seed SetRight()
        {
            var neighbourX = Coordinates.X + 1;
            var neighbourY = Coordinates.Y;
            return new Seed(neighbourX, neighbourY);
        }
        
        private Seed SetBottomRight()
        {
            var neighbourX = Coordinates.X + 1;
            var neighbourY = Coordinates.Y + 1;
            return new Seed(neighbourX, neighbourY);
        }
    }
}

