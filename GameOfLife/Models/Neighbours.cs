using System.Collections.Generic;
using GameOfLife.Models;

namespace GameOfLife.Logic
{
    public static class Neighbours
    {
        public static List<Cell> SetNeighbours(Cell cell, World world)
        {
            return new List<Cell>
            {
                {CheckForEdgeNeighbours(SetTopLeft(cell), world)},
                {CheckForEdgeNeighbours(SetLeft(cell), world)},
                {CheckForEdgeNeighbours(SetBottomLeft(cell), world)},
                {CheckForEdgeNeighbours(SetTop(cell), world)},
                {CheckForEdgeNeighbours(SetBottom(cell), world)},
                {CheckForEdgeNeighbours(SetTopRight(cell), world)},
                {CheckForEdgeNeighbours(SetRight(cell), world)},
                {CheckForEdgeNeighbours(SetBottomRight(cell), world)}
            };
        }
       
        private static Cell CheckForEdgeNeighbours(Coordinates coordinates, World world)
        {
            var xIndex = coordinates.X;
            var yIndex = coordinates.Y;
            
            xIndex = CheckForIndexSmallerThanWorld(xIndex, world.Length - 1);
            xIndex = CheckForIndexLargerThanWorld(xIndex, world.Length - 1);

            yIndex = CheckForIndexSmallerThanWorld(yIndex, world.Height - 1);
            yIndex = CheckForIndexLargerThanWorld(yIndex, world.Height - 1);
      
            return new Cell(new Coordinates(xIndex, yIndex));
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