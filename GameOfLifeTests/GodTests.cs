using System;
using System.Linq;
using GameOfLife;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace GameOfLifeTests
{
    public class GodTests
    {
        [Fact]
        public void Given_ANumberOfStartingSeeds_When_SeedsAreAddedToWorld_Then_SameNumberOfLiveCitiesReturnedInArray()
        {
            var god = new God();
            var world = new World(10, 10);
            var numberOfLiveCities = 0;

            god.AddSeeds(world, 3,4);
            god.AddSeeds(world, 1,5);

            int rowLength = world.RowLength;
            int columnLength = world.ColumnLength;

            for (int xIndex = 0; xIndex < rowLength; xIndex++)
            {
                for (int yIndex = 0; yIndex < columnLength; yIndex++)
                {
                    if (world.Grid[xIndex, yIndex].Live)
                    {
                        numberOfLiveCities++;
                    }
                }
            }
            Assert.Equal(2, numberOfLiveCities);
        }
        
        [Fact]
        public void Given_ALiveCityWithLessThanTwoLiveNeighbours_When_LifeRulesAreApplied_Then_CityDies()
        {
            var world = new World(10, 10);
            var god = new God();
            god.AddSeeds(world, 2, 4);
            
            var chosenCity = god.FetchCity(world, 2, 5);
            chosenCity.FindNumberOfLiveNeighbours(world);
            god.ApplyLifeRules(chosenCity);

            Assert.Equal(1, chosenCity.LiveNeighbours);
            Assert.False(chosenCity.Live);
        }
        
        
        [Fact]
        public void Given_ALiveCityWithMoreThanLiveThreeNeighbours_When_LifeRulesAreApplied_Then_CityDies()
        {
            var world = new World(10, 10);
            var god = new God();
            god.AddSeeds(world, 2, 4);
            god.AddSeeds(world, 2, 6);
            god.AddSeeds(world, 1, 5);
            god.AddSeeds(world, 1, 6);
            
            var chosenCity = god.FetchCity(world, 2, 5);
            chosenCity.FindNumberOfLiveNeighbours(world);
            god.ApplyLifeRules(chosenCity);
            
            Assert.False(chosenCity.Live);
        }
        
        
        [Fact]
        public void Given_ALiveCityWithTwoLiveNeighbours_When_LifeRulesAreApplied_Then_CityLives()
        {
            var world = new World(10, 10);
            var god = new God();
            god.AddSeeds(world, 2, 5);
            god.AddSeeds(world, 2, 4);
            god.AddSeeds(world, 2, 6);
            
            var chosenCity = god.FetchCity(world, 2, 5);
            chosenCity.FindNumberOfLiveNeighbours(world);
            god.ApplyLifeRules(chosenCity);
        
            Assert.True(chosenCity.Live);
        }
        
        [Fact]
        public void Given_ALiveCityWithThreeLiveNeighbours_When_LifeRulesAreApplied_Then_CityLives()
        {
            var world = new World(10, 10);
            var god = new God();
            god.AddSeeds(world, 2, 4);
            god.AddSeeds(world, 2, 6);
            god.AddSeeds(world, 1, 5);
            
            var chosenCity = god.FetchCity(world, 2, 5);
            chosenCity.FindNumberOfLiveNeighbours(world);
            god.ApplyLifeRules(chosenCity);
        
            Assert.True(chosenCity.Live);
        }
        
        
        [Fact]
        public void Given_ADeadCityWithExactlyThreeLiveNeighbours_When_LifeRulesAreApplied_Then_CityLives()
        {
            var world = new World(10, 10);
            var god = new God();
            god.AddSeeds(world, 2, 4);
            god.AddSeeds(world, 2, 6);
            god.AddSeeds(world, 1, 5);
            
            var chosenCity = god.FetchCity(world, 2, 5);
            chosenCity.FindNumberOfLiveNeighbours(world);
            god.ApplyLifeRules(chosenCity);
        
            Assert.Equal(3, chosenCity.LiveNeighbours);
            Assert.True(chosenCity.Live);
        }
        
        [Fact]
        public void Given_ADeadCityWithNoLiveNeighbours_When_LifeRulesAreApplied_Then_CityLives()
        {
            var world = new World(10, 10);
            var god = new God();

            var chosenCity = god.FetchCity(world, 7, 5);
            chosenCity.FindNumberOfLiveNeighbours(world);
            god.ApplyLifeRules(chosenCity);
        
            Assert.False(chosenCity.Live);
        }
    }
}