namespace GameOfLife.Models
{
    public class World
    {
        public int[,] Grid { get; }
        // todo: 2D array is useless at this point? any other way to do the same thing? 

        public World(int columns, int rows)
        {
            // todo: check this isn't an issue
            Grid = new int[rows, columns];
        }
    }
}