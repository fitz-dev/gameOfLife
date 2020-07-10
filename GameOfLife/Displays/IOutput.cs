using GameOfLife.Logic;
using GameOfLife.Models;

namespace GameOfLife.Displays
{
    public interface IOutput
    {
        public void DisplayCurrentGeneration(World world, Generations generations);
    }
}