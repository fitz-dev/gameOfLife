namespace GameOfLife
{
    public interface IOutput
    {
        public string GetSeedPlacement();
        public void PrintWorld(World world);
    }
}