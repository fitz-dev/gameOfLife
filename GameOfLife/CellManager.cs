using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace GameOfLife
{
    public class CellManager
    {
        private List<Seed> _liveCities = new List<Seed>();
        public List<Seed> NextTickSeeds = new List<Seed>();
        
        public Cell[,] CreateWorld(int columns, int rows)
        {
            var world = new Cell[columns, rows];
                
            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < columns; columnIndex++)
                {
                    world[columnIndex,rowIndex] = new Cell(world, columnIndex, rowIndex);
                }
            }
            return world;
        }

        public void AddSeeds(World world, IEnumerable<Seed> seeds)
        {
            _liveCities.Clear();
            foreach (var seed in seeds)
            {
                var cell = world.Grid[seed.X, seed.Y];
                cell.Live = true;
                _liveCities.Add(seed);
            }
        }
        
        public void FindNextTickLiveCities(World world)
        {
            NextTickSeeds.Clear();
            for (int rowIndex = 0; rowIndex < world.RowLength; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < world.ColumnLength; columnIndex++)
                {
                    var cell = world.Grid[columnIndex, rowIndex];
                    cell.SetNumberOfLiveNeighbours(world);
                    CheckLiveNeighboursAgainstLifeRules(cell);
                }
            }
        }
        public void ApplyLifeRules(World world)
        {
            for (int rowIndex = 0; rowIndex < world.RowLength; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < world.ColumnLength; columnIndex++)
                {
                    var cell = world.Grid[columnIndex, rowIndex];
                    cell.Live = NextTickSeeds.Any(seed => seed.X == cell.Column && seed.Y == cell.Row);
                }
            }
        }
        private void CheckLiveNeighboursAgainstLifeRules(Cell cell)
        {
            if ((cell.Live && cell.LiveNeighbours == 2) || (cell.Live && cell.LiveNeighbours == 3) ||
                (!cell.Live && cell.LiveNeighbours == 3))
            {
                NextTickSeeds.Add(new Seed(cell.Column, cell.Row));
            }
        }
        public Cell FetchCell(World world, int columnIndex, int rowIndex)
        {
            return world.Grid[columnIndex, rowIndex];
        }
    }
}