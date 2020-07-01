using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace GameOfLife
{
    public class CellManager
    {
        public List<Coordinates> PreviousState = new List<Coordinates>();
        public List<Coordinates> CurrentState = new List<Coordinates>();
        
        public void AddSeeds(IEnumerable<Coordinates> seeds)
        {
            PreviousState.Clear();
            foreach (var seed in seeds)
            {
                PreviousState.Add(seed);
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
        
        public int SetNumberOfLiveNeighbours(List<Coordinates> previousState, Cell cell)
        {
            cell.LiveNeighbours = 0;
            return cell.Neighbours.Count(neighbour => previousState.Any(city => neighbour.Value.X == city.X && neighbour.Value.Y == city.Y));
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
        
        public void CheckEachCellForLife(World world)
        {
            // PreviousState = CurrentState;
            CurrentState.Clear();
            for (int rowIndex = 0; rowIndex < world.RowLength; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < world.ColumnLength; columnIndex++)
                {
                    var cell = new Cell(new Coordinates(columnIndex, rowIndex));
                    cell.Neighbours = FindNeighbours(cell, world);
                    cell.LiveNeighbours = SetNumberOfLiveNeighbours(PreviousState, cell);
                    var cellWasLive= CheckIfCellWasLiveInPreviousState(PreviousState, cell);
                    if(CellIsLive(cell, cellWasLive))
                    {
                        cell.Live = true;
                        CurrentState.Add(new Coordinates(cell.Position.X, cell.Position.Y));
                    };
                }
            }
        }

        private bool CheckIfCellWasLiveInPreviousState(List<Coordinates> state, Cell cell)
        {
            return state.Any(seed => seed.X == cell.Position.X && seed.Y == cell.Position.Y);
        }
        private bool CellIsLive(Cell cell, bool cellWasLive)
        {
            return ((cellWasLive && cell.LiveNeighbours == 2) || 
                    (cellWasLive && cell.LiveNeighbours == 3) || 
                    (!cellWasLive && cell.LiveNeighbours == 3));
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