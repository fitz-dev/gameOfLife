using System.Collections.Generic;
using System.Threading;

namespace GameOfLife
{
    public class God
    {
        public List<City> LiveCities = new List<City>();
        public List<City> NextTickLiveCities = new List<City>();
        public List<City> DeadCities = new List<City>();
        
        
        public void AddSeeds(City[,] world, int columnIndex, int rowIndex)
        {
            var city = world[columnIndex, rowIndex];
            city.Live = true;
            city.Display = "X";
            LiveCities.Add(world[columnIndex, rowIndex]);
        }

        public City FetchCity(City[,] world, int columnIndex, int rowIndex)
        {
            return world[columnIndex, rowIndex];
        }
        
        public void ApplyLifeRules(City city)
        {
            if ((city.Live && city.LiveNeighbours == 2) || (city.Live && city.LiveNeighbours == 3) ||
                (!city.Live && city.LiveNeighbours == 3))
            {
                NextTickLiveCities.Add(city);
                city.Live = true;
                city.Display = "X";
            }
            else
            {
                city.Display = "-";
            }
        }
    }
}