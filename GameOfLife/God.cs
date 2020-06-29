using System.Collections.Generic;
using System.Threading;

namespace GameOfLife
{
    public class God
    {
        public List<Seed> LiveCities = new List<Seed>();
        public List<Seed> NextTickLiveCities = new List<Seed>();
        
        public City[,] CreateWorld(int columns, int rows)
        {
            var world = new City[columns, rows];
                
            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < columns; columnIndex++)
                {
                    world[columnIndex,rowIndex] = new City(world, columnIndex, rowIndex);
                }
            }
            return world;
        }

        public void AddSeeds(World world, IEnumerable<Seed> seeds)
        {
            LiveCities.Clear();
            foreach (var seed in seeds)
            {
                var city = world.Grid[seed.X, seed.Y];
                city.Live = true;
                LiveCities.Add(new Seed(city.Column, city.Row));
            }
        }
        
        public void FindNextTickLiveCities(World world)
        {
            NextTickLiveCities.Clear();
            for (int rowIndex = 0; rowIndex < world.RowLength; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < world.ColumnLength; columnIndex++)
                {
                    var city = world.Grid[columnIndex, rowIndex];
                    city.GetNumberOfLiveNeighbours(world);
                    CheckLiveNeighboursAgainstLifeRules(city);
                }
            }
        }
        public void ApplyLifeRules(World world)
        {
            for (int rowIndex = 0; rowIndex < world.RowLength; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < world.ColumnLength; columnIndex++)
                {
                    var city = world.Grid[columnIndex, rowIndex];
                    var cityCoordinates = new Seed(city.Column, city.Row);
                    city.Live = NextTickLiveCities.Contains(cityCoordinates);
                }
            }
        }
        private void CheckLiveNeighboursAgainstLifeRules(City city)
        {
            if ((city.Live && city.LiveNeighbours == 2) || (city.Live && city.LiveNeighbours == 3) ||
                (!city.Live && city.LiveNeighbours == 3))
            {
                NextTickLiveCities.Add(new Seed(city.Column, city.Row));
            }
        }
        public City FetchCity(World world, int columnIndex, int rowIndex)
        {
            return world.Grid[columnIndex, rowIndex];
        }
    }
}