using System.Collections.Generic;
using System.Linq;
using GameOfLife.Logic;
using GameOfLife.Managers;

namespace GameOfLife.Models
{
    public class StateManager
    {
        // todo: worldstate, grid state. 
        public List<Cell> CurrentState = new List<Cell>();
        public List<Cell> NextState = new List<Cell>();

        public void ConstructInitialStateFor(List<Cell> state, World world)
        {
            var cellManager = new CellManager();
            for (int rowIndex = 0; rowIndex < world.Grid.GetLength(1); rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < world.Grid.GetLength(0); columnIndex++)
                {
                    // todo: change column and rows to X / Y?
                    var cell = cellManager.CreateCell(columnIndex, rowIndex);
                    cell.Neighbours = Neighbours.SetNeighbours(cell, world);
                    state.Add(cell);
                }
            }
        }
        
            
        public void UpdateStatesForCurrentTick()
        {
            ClearAllLiveCellsIn(CurrentState);
            SetNextStateToCurrentState();
            ClearAllLiveCellsIn(NextState);
        }

        public void AddSeedsForNextState(List<Cell> coordinates)
        {
            foreach (var coordinate in coordinates)
            {
                SetMatchingCellPositionToLive(NextState, coordinate);
            }
        }
    
        private void SetNextStateToCurrentState()
        {
            foreach (var nextCell in NextState.Where(nextCell => nextCell.Live))
            {
                SetMatchingCellPositionToLive(CurrentState, nextCell);
            }
        }

        public void FindLiveNeighboursForAllCells()
        {
            // todo: get rid of cell manager? add find neighbours to state manager
            var cellManager = new CellManager();
            foreach (var currentCell in CurrentState)
            {
                currentCell.NumLiveNeighbours = cellManager.SetNumberOfLiveNeighbours(CurrentState, currentCell);
            }
        }

        public void DetermineCellsToLiveInNextState()
        {
            foreach (var currentCell in CurrentState)
            {
                if (LifeRules.CellShouldLive(currentCell))
                {
                    SetMatchingCellPositionToLive(NextState, currentCell);
                }
            }
        }

        private void ClearAllLiveCellsIn(List<Cell> state)
        {
            foreach (var cell in state)
            {
                cell.Live = false;
            }
        }
        
        
        private void SetMatchingCellPositionToLive(List<Cell> state, Cell nextCell)
        {
            state.First(cell => cell.Position.X == nextCell.Position.X && cell.Position.Y == nextCell.Position.Y).Live = true;
        }

    }
}