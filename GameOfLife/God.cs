namespace GameOfLife
{
    public class God
    {
        public void AddSeeds(City[,] world, int xIndex, int yIndex)
        {
            world[xIndex, yIndex].Live = true;
        }
    }
}