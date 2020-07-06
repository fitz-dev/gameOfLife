using System.Collections.Generic;

namespace GameOfLife.Managers
{
    public static class NeighbourManager
    {
        public static Dictionary<string, Coordinates> FindNeighbours(Cell cell, World world)
        {
            return new Dictionary<string, Coordinates>
            {
                {"topLeft", CheckForEdgeNeighbours(SetTopLeft(cell), world)},
                {"left", CheckForEdgeNeighbours(SetLeft(cell), world)},
                {"bottomLeft", CheckForEdgeNeighbours(SetBottomLeft(cell), world)},
                {"top", CheckForEdgeNeighbours(SetTop(cell), world)},
                {"bottom", CheckForEdgeNeighbours(SetBottom(cell), world)},
                {"topRight", CheckForEdgeNeighbours(SetTopRight(cell), world)},
                {"right", CheckForEdgeNeighbours(SetRight(cell), world)},
                {"bottomRight", CheckForEdgeNeighbours(SetBottomRight(cell), world)}
            };
        }
       
        private static Coordinates CheckForEdgeNeighbours(Coordinates coordinates, World world)
        {
            var columnIndex = coordinates.Y;
            var rowIndex = coordinates.X;
            var worldLength = world.Grid.GetLength(0) - 1;
            var worldHeight = world.Grid.GetLength(1) - 1;
            
            columnIndex = CheckForIndexSmallerThanWorld(columnIndex, worldLength);
            columnIndex = CheckForIndexLargerThanWorld(columnIndex, worldLength);

            rowIndex = CheckForIndexSmallerThanWorld(rowIndex, worldHeight);
            rowIndex = CheckForIndexLargerThanWorld(rowIndex, worldHeight);
      
            return new Coordinates(rowIndex, columnIndex);
        }

        private static int CheckForIndexSmallerThanWorld(int coordinate, int axisSize)
        {
            return coordinate < 0 ? axisSize : coordinate;
        }
        private static int CheckForIndexLargerThanWorld(int coordinate, int axisSize)
        {
            return coordinate > axisSize ? 0 : coordinate;
        }
        private static Coordinates SetTopLeft(Cell cell)
        {
            var neighbourX = cell.Position.X - 1;
            var neighbourY = cell.Position.Y - 1;
            return new Coordinates(neighbourX, neighbourY);
        } 
        
        private static Coordinates SetLeft(Cell cell)
        {
            var neighbourX = cell.Position.X - 1;
            var neighbourY = cell.Position.Y;
            return new Coordinates(neighbourX, neighbourY);
        }
        
        private static Coordinates SetBottomLeft(Cell cell)
        {
            var neighbourX = cell.Position.X - 1;
            var neighbourY = cell.Position.Y + 1;
            return new Coordinates(neighbourX, neighbourY);
        }
        
        private static Coordinates SetTop(Cell cell)
        {
            var neighbourX = cell.Position.X;
            var neighbourY = cell.Position.Y - 1;
            return new Coordinates(neighbourX, neighbourY);
        } 
        
        private static Coordinates SetBottom(Cell cell)
        {
            var neighbourX = cell.Position.X;
            var neighbourY = cell.Position.Y + 1;
            return new Coordinates(neighbourX, neighbourY);
        }
        
        private static Coordinates SetTopRight(Cell cell)
        {
            var neighbourX = cell.Position.X + 1;
            var neighbourY = cell.Position.Y - 1;
            return new Coordinates(neighbourX, neighbourY);
        }
        
        private static Coordinates SetRight(Cell cell)
        {
            var neighbourX = cell.Position.X + 1;
            var neighbourY = cell.Position.Y;
            return new Coordinates(neighbourX, neighbourY);
        }
        
        private static Coordinates SetBottomRight(Cell cell)
        {
            var neighbourX = cell.Position.X + 1;
            var neighbourY = cell.Position.Y + 1;
            return new Coordinates(neighbourX, neighbourY);
        }
    }
}