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
            var (xCoord, yCoord) = coordinates;
            var columns = world.GetLength(0);
            var rows = world.GetLength(1);
            
            if (xCoord < 0)
            {
                xCoord = rows - 1;
            }
            
            if (xCoord > rows - 1)
            {
                xCoord = 0;
            }
            
            if (yCoord < 0)
            {
                yCoord = columns - 1;
            }
            
            if (yCoord > columns - 1)
            {
                yCoord = 0;
            }
            // var checkedXLower = xCoord < 0 ? (rows - 1) : xCoord;
            // var checkedYLower = yCoord < 0 ? (columns - 1) : yCoord;
            return new Tuple<int, int>(xCoord, yCoord);
        }
    }
}