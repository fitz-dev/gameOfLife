using System.Collections.Generic;
using System.Threading;

namespace GameOfLife
{
    public class God
    {
        public List<City> LiveCities = new List<City>();
        public List<City> NextTickLiveCities = new List<City>();
        public List<City> DeadCities = new List<City>();
        
        
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