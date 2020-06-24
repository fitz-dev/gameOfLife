using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class City
    {
        public int X;
        public int Y;
        public bool Live;
        public int LiveNeighbours;
        public Dictionary<string, Tuple<int, int>> Neighbours = new Dictionary<string, Tuple<int, int>>();
        
        public City(int x, int y)
        {
            X = x;
            Y = y;
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

        public void FindNeighbours(int rows, int columns)
        {
            Neighbours.Add("topLeft", CheckForEdgeNeighbours(rows, columns, SetTopLeft()));
            Neighbours.Add("left", CheckForEdgeNeighbours(rows, columns, SetLeft()));
            Neighbours.Add("bottomLeft", CheckForEdgeNeighbours(rows, columns, SetBottomLeft()));
            Neighbours.Add("top", CheckForEdgeNeighbours(rows, columns, SetTop()));
            Neighbours.Add("bottom", CheckForEdgeNeighbours(rows, columns, SetBottom()));
            Neighbours.Add("topRight", CheckForEdgeNeighbours(rows, columns, SetTopRight()));
            Neighbours.Add("right", CheckForEdgeNeighbours(rows, columns, SetRight()));
            Neighbours.Add("bottomRight", CheckForEdgeNeighbours(rows, columns, SetBottomRight()));
        }
        
        private Tuple<int, int> CheckForEdgeNeighbours(int rows, int columns, Tuple<int, int> coordinates)
        {
            var (rowIndex, columnIndex) = coordinates;

            rowIndex = CheckForIndexSmallerThanWorld(rowIndex, rows - 1);
            rowIndex = CheckForIndexLargerThanWorld(rowIndex, columns - 1);
            
            columnIndex = CheckForIndexSmallerThanWorld(columnIndex, rows - 1);
            columnIndex = CheckForIndexLargerThanWorld(columnIndex, columns - 1);
      
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

