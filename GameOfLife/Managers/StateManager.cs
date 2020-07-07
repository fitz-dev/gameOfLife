using System.Collections.Generic;
using System.Linq;
using GameOfLife.Logic;
using GameOfLife.Models;

namespace GameOfLife.Managers
{
    public class StateManager
    {
        private List<Cell> _previousState = new List<Cell>();

        public List<Cell> CurrentState = new List<Cell>();

        public void UpdateStatesForNextTick()
        {
            SetCurrentStateToPreviousState();
            ClearCurrentState();
        }
        
        private void SetCurrentStateToPreviousState()
        {
            _previousState.Clear();
            _previousState.AddRange(CurrentState);
        }

        private void ClearCurrentState()
        {
            foreach (var cell in CurrentState)
            {
                cell.Live = false;
            }
        }

        //todo: go through and add seeds to initial / previous state. need to then update current state depending on the previous state. 
        public void ConstructInitialState(World world)
        {
            var cellManager = new CellManager();
            for (int rowIndex = 0; rowIndex < world.Grid.GetLength(1); rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < world.Grid.GetLength(0); columnIndex++)
                {
                    var cell = cellManager.CreateCell(columnIndex, rowIndex);
                    cell.Neighbours = Neighbours.SetNeighbours(cell, world);
                    CurrentState.Add(cell);
                }
            }
        }

        public void AddCoordinates(List<Coordinates> coordinates)
        {
            foreach (var coordinate in coordinates)
            {
                CurrentState.First(cell => cell.Position.X == coordinate.X && cell.Position.Y == coordinate.Y).Live = true;
            }
        }
        
        
        
        private bool CellWasLiveIn(List<Cell> previousState, Cell cell)
        {
            return previousState.Any(seed => 
                seed.Position.X == cell.Position.X && 
                seed.Position.Y == cell.Position.Y);
        }

        private void ApplyCellLifeRules(Cell cell)
        {
            if (!LifeRules.CellWillLive(cell)) return;
            CurrentState.Add(cell);
        }

    }
}