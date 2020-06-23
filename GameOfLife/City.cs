using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class City
    {
        public int X;
        public int Y;
        public bool Live;
        public string Display = "-";
        public int LiveNeighbours;
        
        public City(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        public Dictionary<string, Tuple<int, int>> Neighbours = new Dictionary<string, Tuple<int, int>>();

        public void SetLifeDisplay()
        {
            Display = Live ? "0" : "-";
        }

        public void FindNumberOfLiveNeighbours(World world)
        {
            foreach (var neighbour in Neighbours)
            {
                var columnIndex = neighbour.Value.Item1;
                var rowIndex = neighbour.Value.Item2;
                if (world.Grid[columnIndex, rowIndex].Live)
                {
                    LiveNeighbours++;
                }
            }
        }

        public void FindNeighbours(World world)
        {
            Neighbours.Add("topLeft", CheckForEdgeNeighbours(world, SetTopLeft()));
            Neighbours.Add("left", CheckForEdgeNeighbours(world, SetLeft()));
            Neighbours.Add("bottomLeft", CheckForEdgeNeighbours(world, SetBottomLeft()));
            Neighbours.Add("top", CheckForEdgeNeighbours(world, SetTop()));
            Neighbours.Add("bottom", CheckForEdgeNeighbours(world, SetBottom()));
            Neighbours.Add("topRight", CheckForEdgeNeighbours(world, SetTopRight()));
            Neighbours.Add("right", CheckForEdgeNeighbours(world, SetRight()));
            Neighbours.Add("bottomRight", CheckForEdgeNeighbours(world, SetBottomRight()));
        }
        
        private Tuple<int, int> CheckForEdgeNeighbours(World world, Tuple<int, int> coordinates)
        {
            var (rowIndex, columnIndex) = coordinates;

            rowIndex = CheckForIndexSmallerThanWorld(rowIndex, world.RowLength);
            rowIndex = CheckForIndexLargerThanWorld(rowIndex, world.ColumnLength);
            
            columnIndex = CheckForIndexSmallerThanWorld(columnIndex, world.RowLength);
            columnIndex = CheckForIndexLargerThanWorld(columnIndex, world.ColumnLength);
      
            return new Tuple<int, int>(rowIndex, columnIndex);
        }

        private int CheckForIndexSmallerThanWorld(int coordinate, int axisSize)
        {
            return coordinate < 0 ? axisSize : coordinate;
        }
        private int CheckForIndexLargerThanWorld(int coordinate, int axisSize)
        {
            return coordinate > axisSize ? 0 : coordinate;
        }

        private Tuple<int, int> SetTopLeft()
        {
            var neighbourX = X - 1;
            var neighbourY = Y - 1;
            return new Tuple<int, int>(neighbourX, neighbourY);
        } 
        
        private Tuple<int, int> SetLeft()
        {
            var neighbourX = X - 1;
            var neighbourY = Y;
            return new Tuple<int, int>(neighbourX, neighbourY);
        }
        
        private Tuple<int, int> SetBottomLeft()
        {
            var neighbourX = X - 1;
            var neighbourY = Y + 1;
            return new Tuple<int, int>(neighbourX, neighbourY);
        }
        
        private Tuple<int, int> SetTop()
        {
            var neighbourX = X;
            var neighbourY = Y - 1;
            return new Tuple<int, int>(neighbourX, neighbourY);
        } 
        
        private Tuple<int, int> SetBottom()
        {
            var neighbourX = X;
            var neighbourY = Y + 1;
            return new Tuple<int, int>(neighbourX, neighbourY);
        }
        
        private Tuple<int, int> SetTopRight()
        {
            var neighbourX = X + 1;
            var neighbourY = Y - 1;
            return new Tuple<int, int>(neighbourX, neighbourY);
        }
        
        private Tuple<int, int> SetRight()
        {
            var neighbourX = X + 1;
            var neighbourY = Y;
            return new Tuple<int, int>(neighbourX, neighbourY);
        }
        
        private Tuple<int, int> SetBottomRight()
        {
            var neighbourX = X + 1;
            var neighbourY = Y + 1;
            return new Tuple<int, int>(neighbourX, neighbourY);
        }
    }
}

