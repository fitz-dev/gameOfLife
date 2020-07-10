using GameOfLife.Models;

namespace GameOfLife
{
    public interface IOutput
    {
        public void PrintWorld(World world, Generations generations);
    }
}