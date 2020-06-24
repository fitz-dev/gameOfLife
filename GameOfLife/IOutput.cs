namespace GameOfLife
{
    public interface IOutput
    {
        public string GetWorldSize();
        public string GetSeedPlacement();
        public void PrintWorld(World world);
    }
}