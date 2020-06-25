using System.Collections.Generic;
using System.Threading;

namespace GameOfLife
{
    public class God
    {
        public List<City> LiveCities = new List<City>();
        public List<City> NextTickLiveCities = new List<City>();
        public List<City> DeadCities = new List<City>();
        
        public City[,] CreateWorld(int columns, int rows)
        {
            var world = new City[columns, rows];
                
            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < columns; columnIndex++)
                {
                    world[columnIndex,rowIndex] = new City(columnIndex, rowIndex);
                    world[columnIndex,rowIndex].FindNeighbours(rows, columns);
                    // TODO remove find neighbours and have the method run when a city is made
                }
            }
            return world;
        }
        
        public void AddSeed(World world, int columnIndex, int rowIndex)
        {
            var city = world.Grid[columnIndex, rowIndex];
            city.Live = true;
            LiveCities.Add(world.Grid[columnIndex, rowIndex]);
        }

        public City FetchCity(World world, int columnIndex, int rowIndex)
        {
            return world.Grid[columnIndex, rowIndex];
        }
        
        public void ApplyLifeRules(City city)
        {
            if ((city.Live && city.LiveNeighbours == 2) || (city.Live && city.LiveNeighbours == 3) ||
                (!city.Live && city.LiveNeighbours == 3))
            {
                NextTickLiveCities.Add(city);
                city.Live = true;
            }
        }
    }
}