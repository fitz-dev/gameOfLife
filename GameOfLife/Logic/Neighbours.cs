using System.Collections.Generic;
using System.Linq;
using GameOfLife.Models;

namespace GameOfLife.Logic
{
    public static class Neighbours
    {
        public static int SetNumberOfLiveNeighbours(List<Cell> currentGeneration, Cell cell)
        {
            var liveCells = currentGeneration.Where(currentCell => currentCell.Live);
            
            return liveCells
                .Sum(liveCell => cell.Neighbours
                .Count(neighbour => neighbour.Position.X == liveCell.Position.X && neighbour.Position.Y == liveCell.Position.Y));
        }
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
            return new Coordinates(cell.Position.X - 1, cell.Position.Y - 1);
        } 
        
        private static Coordinates SetLeft(Cell cell)
        {
            return new Coordinates(cell.Position.X - 1, cell.Position.Y);
        }
        
        private static Coordinates SetBottomLeft(Cell cell)
        {
            return new Coordinates(cell.Position.X - 1, cell.Position.Y + 1);
        }
        
        private static Coordinates SetTop(Cell cell)
        {
            return new Coordinates(cell.Position.X, cell.Position.Y - 1);
        } 
        
        private static Coordinates SetBottom(Cell cell)
        {
            return new Coordinates(cell.Position.X, cell.Position.Y + 1);
        }
        
        private static Coordinates SetTopRight(Cell cell)
        {
            return new Coordinates(cell.Position.X + 1, cell.Position.Y - 1);
        }
        
        private static Coordinates SetRight(Cell cell)
        {
            return new Coordinates(cell.Position.X + 1, cell.Position.Y);
        }
        
        private static Coordinates SetBottomRight(Cell cell)
        {
            return new Coordinates(cell.Position.X + 1, cell.Position.Y + 1);
        }
    }
}