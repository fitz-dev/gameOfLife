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
        
        public int SetNumberOfLiveNeighbours(List<Cell> previousState, Cell cell)
        {
            var liveCells = previousState.Where(cell1 => cell1.Live);
            return liveCells.Sum(liveCell => cell.Neighbours.Count(neighbour => neighbour.Position.X == liveCell.Position.X && neighbour.Position.Y == liveCell.Position.Y));
        }
    }
}