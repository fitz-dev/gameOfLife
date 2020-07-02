using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class StateManager
    {
        private List<Coordinates> _previousState = new List<Coordinates>();
        public List<Coordinates> CurrentState = new List<Coordinates>();

        public void RefreshStates()
        {
            _previousState.Clear();
            _previousState.AddRange(CurrentState);
            CurrentState.Clear();
        }

        public void ProcessWorldForCurrentState(World world)
        {
            var cellManager = new CellManager();
            for (int rowIndex = 0; rowIndex < world.RowLength; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < world.ColumnLength; columnIndex++)
                {
                    var cell = cellManager.CreateCell(columnIndex, rowIndex);
                    cellManager.AssignNeighbourProperties(cell, world, _previousState);
                    DetermineIfCellShouldLive(cell);
                }
            }
        }

        private void DetermineIfCellShouldLive(Cell cell)
        {
            cell.Live = CellWasLiveIn(_previousState, cell);
            if (!CellMeetsConditionsForLife(cell, cell.Live)) return;
            CurrentState.Add(new Coordinates(cell.Position.X, cell.Position.Y));
        }

        private bool CellWasLiveIn(List<Coordinates> previousState, Cell cell)
        {
            return previousState.Any(seed => 
                seed.X == cell.Position.X && 
                seed.Y == cell.Position.Y);
        }
        private bool CellMeetsConditionsForLife(Cell cell, bool cellWasLive)
        {
            return ((cellWasLive && cell.LiveNeighbours == 2) || 
                    (cellWasLive && cell.LiveNeighbours == 3) || 
                    (!cellWasLive && cell.LiveNeighbours == 3));
        }
    }
}