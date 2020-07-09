using System.Collections.Generic;
using System.Linq;
using GameOfLife.Logic;
using GameOfLife.Models;

namespace GameOfLife.Managers
{
    public class CellManager
    {

        public Cell CreateCell(int xIndex, int yIndex)
        {
            return new Cell(new Coordinates(xIndex, yIndex));
        }
        
        public int SetNumberOfLiveNeighbours(List<Cell> currentState, Cell cell)
        {
            var liveCells = currentState.Where(currentCell => currentCell.Live);
            
            return liveCells
                .Sum(liveCell => cell.Neighbours
                .Count(neighbour => neighbour.Position.X == liveCell.Position.X && neighbour.Position.Y == liveCell.Position.Y));
        }
    }
}