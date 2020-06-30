using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace GameOfLife
{
    public class CellManager
    {
        public List<Seed> LiveCities = new List<Seed>();
        public List<Seed> NextTickSeeds = new List<Seed>();
        
        public void AddSeeds(IEnumerable<Seed> seeds)
        {
            LiveCities.Clear();
            foreach (var seed in seeds)
            {
                LiveCities.Add(seed);
            }
        }
        
        public void FindNextTickLiveCities(World world)
        {
            NextTickSeeds.Clear();
            for (int rowIndex = 0; rowIndex < world.RowLength; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < world.ColumnLength; columnIndex++)
                {
                    var cell = new Cell(new Seed(columnIndex, rowIndex));
                    cell.Neighbours = cell.FindNeighbours(world.RowLength, world.ColumnLength);
                    cell.SetNumberOfLiveNeighbours(LiveCities);
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
                    var cell = new Cell(new Seed(columnIndex, rowIndex));
                    cell.Live = NextTickSeeds.Any(seed => seed.X == cell.Coordinates.X && seed.Y == cell.Coordinates.Y);
                }
            }
        }
        private void CheckLiveNeighboursAgainstLifeRules(Cell cell)
        {
            if ((cell.Live && cell.LiveNeighbours == 2) || (cell.Live && cell.LiveNeighbours == 3) ||
                (!cell.Live && cell.LiveNeighbours == 3))
            {
                NextTickSeeds.Add(new Seed(cell.Coordinates.X, cell.Coordinates.Y));
            }
        }
        public Cell FetchCell(int columnIndex, int rowIndex)
        {
            return new Cell(new Seed(columnIndex, rowIndex)){Live = true};
        }
    }
}