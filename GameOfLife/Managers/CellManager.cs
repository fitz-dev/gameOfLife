using System.Collections.Generic;
using System.Linq;
using GameOfLife.Logic;
using GameOfLife.Models;

namespace GameOfLife.Managers
{
    public class CellManager
    {

        public Cell CreateCell(int columnIndex, int rowIndex)
        {
            return new Cell(new Coordinates(columnIndex, rowIndex));
        }

        public void AssignNeighbourProperties(Cell cell, World world, List<Cell> state)
        {
            cell.Neighbours = Neighbours.SetNeighbours(cell, world);
            // cell.NumLiveNeighbours = SetNumberOfLiveNeighbours(state, cell);
        }
        
        private int SetNumberOfLiveNeighbours(List<Cell> previousState, Cell cell)
        {
            cell.NumLiveNeighbours = 0;
            return cell.Neighbours.Count(neighbour => previousState.Any(cell => neighbour.Position.X == cell.Position.X && neighbour.Position.Y == cell.Position.Y));
        }
        
        // private int SetNumberOfLiveNeighbours(List<Cell> previousState, Cell cell)
        // {
        //     cell.NumLiveNeighbours = 0;
        //     return cell.Neighbours.Count(neighbour => previousState.Any(cell => neighbour.Position.X == cell.Position.X && neighbour.Position.Y == cell.Position.Y));
        // }
    }
}