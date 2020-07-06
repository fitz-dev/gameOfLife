using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace GameOfLife
{
    public class CellManager
    {

        public Cell CreateCell(int columnIndex, int rowIndex)
        {
            return new Cell(new Coordinates(columnIndex, rowIndex));
        }

        public void AssignNeighbourProperties(Cell cell, World world, List<Coordinates> state)
        {
            cell.Neighbours = FindNeighbours(cell, world);
            cell.LiveNeighbours = SetNumberOfLiveNeighbours(state, cell);
        }

        public Dictionary<string, Coordinates> FindNeighbours(Cell cell, World world)
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
        
        private int SetNumberOfLiveNeighbours(List<Coordinates> previousState, Cell cell)
        {
            cell.LiveNeighbours = 0;
            return cell.Neighbours.Count(neighbour => previousState.Any(city => neighbour.Value.X == city.X && neighbour.Value.Y == city.Y));
        }
        
        private Coordinates CheckForEdgeNeighbours(Coordinates coordinates, World world)
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

        private int CheckForIndexSmallerThanWorld(int coordinate, int axisSize)
        {
            return coordinate < 0 ? axisSize : coordinate;
        }
        private int CheckForIndexLargerThanWorld(int coordinate, int axisSize)
        {
            return coordinate > axisSize ? 0 : coordinate;
        }
        private Coordinates SetTopLeft(Cell cell)
        {
            var neighbourX = cell.Position.X - 1;
            var neighbourY = cell.Position.Y - 1;
            return new Coordinates(neighbourX, neighbourY);
        } 
        
        private Coordinates SetLeft(Cell cell)
        {
            var neighbourX = cell.Position.X - 1;
            var neighbourY = cell.Position.Y;
            return new Coordinates(neighbourX, neighbourY);
        }
        
        private Coordinates SetBottomLeft(Cell cell)
        {
            var neighbourX = cell.Position.X - 1;
            var neighbourY = cell.Position.Y + 1;
            return new Coordinates(neighbourX, neighbourY);
        }
        
        private Coordinates SetTop(Cell cell)
        {
            var neighbourX = cell.Position.X;
            var neighbourY = cell.Position.Y - 1;
            return new Coordinates(neighbourX, neighbourY);
        } 
        
        private Coordinates SetBottom(Cell cell)
        {
            var neighbourX = cell.Position.X;
            var neighbourY = cell.Position.Y + 1;
            return new Coordinates(neighbourX, neighbourY);
        }
        
        private Coordinates SetTopRight(Cell cell)
        {
            var neighbourX = cell.Position.X + 1;
            var neighbourY = cell.Position.Y - 1;
            return new Coordinates(neighbourX, neighbourY);
        }
        
        private Coordinates SetRight(Cell cell)
        {
            var neighbourX = cell.Position.X + 1;
            var neighbourY = cell.Position.Y;
            return new Coordinates(neighbourX, neighbourY);
        }
        
        private Coordinates SetBottomRight(Cell cell)
        {
            var neighbourX = cell.Position.X + 1;
            var neighbourY = cell.Position.Y + 1;
            return new Coordinates(neighbourX, neighbourY);
        }
    }
}