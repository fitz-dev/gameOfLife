using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

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

        public void GetNumberOfLiveNeighbours(City[,] world)
        {
            foreach (var neighbour in Neighbours)
            {
                var columnIndex = neighbour.Value.Item1;
                var rowIndex = neighbour.Value.Item2;
                if (world[columnIndex, rowIndex].Live)
                {
                    LiveNeighbours++;
                }
            }
        }

        public void FindNeighbours(City[,] world)
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

        private Tuple<int, int> CheckForEdgeNeighbours(City[,] world, Tuple<int, int> coordinates)
        {
            var (rowIndex, columnIndex) = coordinates;
            var columnSize = world.GetLength(0) - 1;
            var rowsSize = world.GetLength(1) - 1;

            rowIndex = CheckForIndexSmallerThanWorld(rowIndex, rowsSize);
            rowIndex = CheckForIndexLargerThanWorld(rowIndex, rowsSize);
            
            columnIndex = CheckForIndexSmallerThanWorld(columnIndex, columnSize);
            columnIndex = CheckForIndexLargerThanWorld(columnIndex, columnSize);
      
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
    }
}

