using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class City
    {
        public int Column;
        public int Row;
        public bool Live;
        public int LiveNeighbours;
        public Dictionary<string, Tuple<int, int>> Neighbours;
        
        public City(City[,] world, int column, int row)
        {
            Column = column;
            Row = row;
            Neighbours = FindNeighbours(world);
        }

        public void GetNumberOfLiveNeighbours(World world)
        {
            LiveNeighbours = 0;
            foreach (var (_, (columnIndex, rowIndex)) in Neighbours)
            {
                if (world.Grid[columnIndex, rowIndex].Live)
                {
                    LiveNeighbours++;
                }
            }
        }

        private Dictionary<string, Tuple<int, int>> FindNeighbours(City[,] world)
        {
            var neighbours = new Dictionary<string, Tuple<int, int>>
            {
                {"topLeft", CheckForEdgeNeighbours(SetTopLeft(), world)},
                {"left", CheckForEdgeNeighbours(SetLeft(), world)},
                {"bottomLeft", CheckForEdgeNeighbours(SetBottomLeft(), world)},
                {"top", CheckForEdgeNeighbours(SetTop(), world)},
                {"bottom", CheckForEdgeNeighbours(SetBottom(), world)},
                {"topRight", CheckForEdgeNeighbours(SetTopRight(), world)},
                {"right", CheckForEdgeNeighbours(SetRight(), world)},
                {"bottomRight", CheckForEdgeNeighbours(SetBottomRight(), world)}
            };
            return neighbours;
        }
        
        private Tuple<int, int> CheckForEdgeNeighbours(Tuple<int, int> coordinates, City[,] world)
        {
            var worldLength = world.GetLength(0) - 1;
            var worldHeight = world.GetLength(1) - 1;
            var (rowIndex, columnIndex) = coordinates;
            
            columnIndex = CheckForIndexSmallerThanWorld(columnIndex, worldHeight);
            columnIndex = CheckForIndexLargerThanWorld(columnIndex, worldLength);

            rowIndex = CheckForIndexSmallerThanWorld(rowIndex, worldHeight);
            rowIndex = CheckForIndexLargerThanWorld(rowIndex, worldLength);
      
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
            var neighbourX = Column - 1;
            var neighbourY = Row - 1;
            return new Tuple<int, int>(neighbourX, neighbourY);
        } 
        
        private Tuple<int, int> SetLeft()
        {
            var neighbourX = Column - 1;
            var neighbourY = Row;
            return new Tuple<int, int>(neighbourX, neighbourY);
        }
        
        private Tuple<int, int> SetBottomLeft()
        {
            var neighbourX = Column - 1;
            var neighbourY = Row + 1;
            return new Tuple<int, int>(neighbourX, neighbourY);
        }
        
        private Tuple<int, int> SetTop()
        {
            var neighbourX = Column;
            var neighbourY = Row - 1;
            return new Tuple<int, int>(neighbourX, neighbourY);
        } 
        
        private Tuple<int, int> SetBottom()
        {
            var neighbourX = Column;
            var neighbourY = Row + 1;
            return new Tuple<int, int>(neighbourX, neighbourY);
        }
        
        private Tuple<int, int> SetTopRight()
        {
            var neighbourX = Column + 1;
            var neighbourY = Row - 1;
            return new Tuple<int, int>(neighbourX, neighbourY);
        }
        
        private Tuple<int, int> SetRight()
        {
            var neighbourX = Column + 1;
            var neighbourY = Row;
            return new Tuple<int, int>(neighbourX, neighbourY);
        }
        
        private Tuple<int, int> SetBottomRight()
        {
            var neighbourX = Column + 1;
            var neighbourY = Row + 1;
            return new Tuple<int, int>(neighbourX, neighbourY);
        }
    }
}

