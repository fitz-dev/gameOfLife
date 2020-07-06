using System.Collections.Generic;
using System.Linq;

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
            cell.Neighbours = NeighbourManager.FindNeighbours(cell, world);
            cell.NumLiveNeighbours = SetNumberOfLiveNeighbours(state, cell);
        }
        
        private int SetNumberOfLiveNeighbours(List<Cell> previousState, Cell cell)
        {
            cell.NumLiveNeighbours = 0;
            return cell.Neighbours.Count(neighbour => previousState.Any(cell => neighbour.Value.X == cell.Position.X && neighbour.Value.Y == cell.Position.Y));
        }
    }
}