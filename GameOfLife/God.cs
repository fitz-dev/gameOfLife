using System.Collections.Generic;
using System.Threading;

namespace GameOfLife
{
    public class God
    {
        public List<City> LiveCities = new List<City>();
        public List<City> NextTickLiveCities = new List<City>();
        
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

        public void ApplyLifeRules(World world)
        {
            for (int rowIndex = 0; rowIndex < world.RowLength; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < world.ColumnLength; columnIndex++)
                {
                    var city = world.Grid[columnIndex, rowIndex];
                    if (NextTickLiveCities.Contains(city))
                    {
                        city.Live = true;
                    }
                    else
                    {
                        city.Live = false;
                    }
                }
            }
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
        
        public void FindNextTickLiveCities(World world)
        {
            NextTickLiveCities.Clear();
            for (int rowIndex = 0; rowIndex < world.RowLength; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < world.ColumnLength; columnIndex++)
                {
                    var city = world.Grid[columnIndex, rowIndex];
                    city.LiveNeighbours = 0;
                    city.GetNumberOfLiveNeighbours(world);
                    CompareNumberOfLiveNeighbours(city);
                }
            }
        }
        
        // change to live cities? 
        public void CompareNumberOfLiveNeighbours(City city)
        {
            if ((city.Live && city.LiveNeighbours == 2) || (city.Live && city.LiveNeighbours == 3) ||
                (!city.Live && city.LiveNeighbours == 3))
            {
                NextTickLiveCities.Add(city);
            }
        }
    }
}