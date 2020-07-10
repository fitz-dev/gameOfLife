using System.Collections.Generic;
using System.Linq;
using GameOfLife.Models;

namespace GameOfLife.Logic
{
    public class Generations
    {
        public List<Cell> CurrentGeneration = new List<Cell>();
        public List<Cell> NextGeneration = new List<Cell>();

        public void ConstructGenerations(World world)
        {
            CreateGenerationFor(CurrentGeneration, world);
            CreateGenerationFor(NextGeneration, world);
        }
        public void AddSeedsForNextGeneration(List<Cell> seeds)
        {
            foreach (var seed in seeds)
            {
                SetMatchingCellPositionToLive(NextGeneration, seed);
            }
        }
        public void UpdateGenerationsForNextTick()
        {
            ClearAllLiveCellsIn(CurrentGeneration);
            SetNextGenerationToCurrentGeneration();
            ClearAllLiveCellsIn(NextGeneration);
        }


        public void FindLiveNeighboursForAllCells()
        {
            foreach (var currentCell in CurrentGeneration)
            {
                currentCell.NumLiveNeighbours = Neighbours.SetNumberOfLiveNeighbours(CurrentGeneration, currentCell);
            }
        }

        public void DetermineIfCellsWillLiveInNextGeneration()
        {
            foreach (var currentCell in CurrentGeneration)
            {
                if (LifeRules.CellShouldLive(currentCell))
                {
                    SetMatchingCellPositionToLive(NextGeneration, currentCell);
                }
            }
        }
        
        private void CreateGenerationFor(List<Cell> generation, World world)
        {
            for (int yIndex = 0; yIndex < world.Height; yIndex++)
            {
                for (int xIndex = 0; xIndex < world.Length; xIndex++)
                {
                    var cell = new Cell(new Coordinates(xIndex, yIndex));
                    cell.Neighbours = Neighbours.SetNeighbours(cell, world);
                    generation.Add(cell);
                }
            }
        }
        
        private void SetNextGenerationToCurrentGeneration()
        {
            foreach (var nextCell in NextGeneration.Where(nextCell => nextCell.Live))
            {
                SetMatchingCellPositionToLive(CurrentGeneration, nextCell);
            }
        }

        private void ClearAllLiveCellsIn(List<Cell> generation)
        {
            foreach (var cell in generation)
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