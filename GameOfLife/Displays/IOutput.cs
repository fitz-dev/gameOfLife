using GameOfLife.Managers;

namespace GameOfLife
{
    public interface IOutput
    {
        public void PrintWorld(World world, StateManager stateManager);
    }
}