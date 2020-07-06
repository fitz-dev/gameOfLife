namespace GameOfLife.Models
{
    public class World
    {
        public int[,] Grid { get; }

        public World(int columns, int rows)
        {
            Grid = new int[rows, columns];
        }
    }
}