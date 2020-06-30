using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace GameOfLife
{
    public class CellManager
    {
        public List<Coordinates> LiveCities = new List<Coordinates>();
        public List<Coordinates> NextTickSeeds = new List<Coordinates>();
        
        public void AddSeeds(IEnumerable<Coordinates> seeds)
        {
            LiveCities.Clear();
            foreach (var seed in seeds)
            {
                LiveCities.Add(seed);
            }
        }
        
        public Dictionary<string, Coordinates> FindNeighbours(Cell cell, World world)
        {
            var neighbours = new Dictionary<string, Coordinates>
            {
                {"topLeft", CheckForEdgeNeighbours(SetTopLeft(cell), world)},
                {"left", CheckForEdgeNeighbours(SetLeft(cell), world)},
                {"bottomLeft", CheckForEdgeNeighbours(SetBottomLeft(cell), world)},
                {"top", CheckForEdgeNeighbours(SetTop(cell), world)},
                {"bottom", CheckForEdgeNeighbours(SetBottom(cell), world)},
                {"topRight", CheckForEdgeNeighbours(SetTopRight(cell), world)},
                {"right", CheckForEdgeNeighbours(SetRight(cell), world)},
                {"bottomRight", CheckForEdgeNeighbours(SetBottomRight(cell), world)}
            };
            return neighbours;
        }
        
        public void SetNumberOfLiveNeighbours(List<Coordinates> liveCities, Cell cell)
        {
            cell.LiveNeighbours = 0;
            cell.LiveNeighbours = cell.Neighbours.Count(neighbour => liveCities.Any(city => neighbour.Value.X == city.X && neighbour.Value.Y == city.Y));
        }
        
        private Coordinates CheckForEdgeNeighbours(Coordinates coordinates, World world)
        {
            var columnIndex = coordinates.Y;
            var rowIndex = coordinates.X;
            
            columnIndex = CheckForIndexSmallerThanWorld(columnIndex, world.ColumnLength - 1);
            columnIndex = CheckForIndexLargerThanWorld(columnIndex, world.ColumnLength - 1);

            rowIndex = CheckForIndexSmallerThanWorld(rowIndex, world.RowLength -1);
            rowIndex = CheckForIndexLargerThanWorld(rowIndex, world.RowLength -1);
      
            return new Coordinates(rowIndex, columnIndex);
        }

        private int CheckForIndexSmallerThanWorld(int coordinate, int axisSize)
        {
            return coordinate < 0 ? axisSize : coordinate;
        }
        private int CheckForIndexLargerThanWorld(int coordinate, int axisSize)
        {
            return coordinate > axisSize ? 0 : coordinate;
        }
        
        public void FindNextTickLiveCities(World world)
        {
            NextTickSeeds.Clear();
            for (int rowIndex = 0; rowIndex < world.RowLength; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < world.ColumnLength; columnIndex++)
                {
                    var cell = new Cell(new Coordinates(columnIndex, rowIndex));
                    cell.Neighbours = FindNeighbours(cell, world);
                    SetNumberOfLiveNeighbours(LiveCities, cell);
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
                    var cell = new Cell(new Coordinates(columnIndex, rowIndex));
                    cell.Live = NextTickSeeds.Any(seed => seed.X == cell.Position.X && seed.Y == cell.Position.Y);
                }
            }
        }
        private void CheckLiveNeighboursAgainstLifeRules(Cell cell)
        {
            if ((cell.Live && cell.LiveNeighbours == 2) || (cell.Live && cell.LiveNeighbours == 3) ||
                (!cell.Live && cell.LiveNeighbours == 3))
            {
                NextTickSeeds.Add(new Coordinates(cell.Position.X, cell.Position.Y));
            }
        }
        public Cell FetchCell(int columnIndex, int rowIndex)
        {
            return new Cell(new Coordinates(columnIndex, rowIndex)){Live = true};
        }
        
        
        private Coordinates SetTopLeft(Cell cell)
        {
            var neighbourX = cell.Position.X - 1;
            var neighbourY = cell.Position.Y - 1;
            return new Coordinates(neighbourX, neighbourY);
        } 
        
        private Coordinates SetLeft(Cell cell)
        {
            var neighbourX = cell.Position.X - 1;
            var neighbourY = cell.Position.Y;
            return new Coordinates(neighbourX, neighbourY);
        }
        
        private Coordinates SetBottomLeft(Cell cell)
        {
            var neighbourX = cell.Position.X - 1;
            var neighbourY = cell.Position.Y + 1;
            return new Coordinates(neighbourX, neighbourY);
        }
        
        private Coordinates SetTop(Cell cell)
        {
            var neighbourX = cell.Position.X;
            var neighbourY = cell.Position.Y - 1;
            return new Coordinates(neighbourX, neighbourY);
        } 
        
        private Coordinates SetBottom(Cell cell)
        {
            var neighbourX = cell.Position.X;
            var neighbourY = cell.Position.Y + 1;
            return new Coordinates(neighbourX, neighbourY);
        }
        
        private Coordinates SetTopRight(Cell cell)
        {
            var neighbourX = cell.Position.X + 1;
            var neighbourY = cell.Position.Y - 1;
            return new Coordinates(neighbourX, neighbourY);
        }
        
        private Coordinates SetRight(Cell cell)
        {
            var neighbourX = cell.Position.X + 1;
            var neighbourY = cell.Position.Y;
            return new Coordinates(neighbourX, neighbourY);
        }
        
        private Coordinates SetBottomRight(Cell cell)
        {
            var neighbourX = cell.Position.X + 1;
            var neighbourY = cell.Position.Y + 1;
            return new Coordinates(neighbourX, neighbourY);
        }
    }
}