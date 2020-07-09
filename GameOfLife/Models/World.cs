namespace GameOfLife.Models
{
    public class World
    {
        public int Length { get; }
        public int Height { get; }

        public World(int length, int height)
        {
            Length = length;
            Height = height;
        }
    }
}