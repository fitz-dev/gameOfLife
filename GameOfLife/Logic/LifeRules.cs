using GameOfLife.Models;

namespace GameOfLife.Logic
{
    public static class LifeRules
    {
        public static bool CellWillLive(Cell cell)
        {
            return cell.Live && cell.NumLiveNeighbours == 2 || 
                   cell.Live  && cell.NumLiveNeighbours == 3 || 
                   !cell.Live  && cell.NumLiveNeighbours == 3;
        }
    }
}