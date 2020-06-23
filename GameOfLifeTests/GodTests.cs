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
            var world = World.CreateWorld(8, 10);
            var numberOfLiveCities = 0;

            god.AddSeeds(world, 3,4);
            god.AddSeeds(world, 7,8);

            int rowLength = world.GetLength(0);
            int columnLength = world.GetLength(1);

            for (int xIndex = 0; xIndex < rowLength; xIndex++)
            {
                for (int yIndex = 0; yIndex < columnLength; yIndex++)
                {
                    if (world[xIndex, yIndex].Live)
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
            var world = World.CreateWorld(10, 10);
            var god = new God();
            god.AddSeeds(world, 2, 4);
            
            var chosenCity = god.FetchCity(world, 2, 5);
            chosenCity.FindNeighbours(world);
            god.ApplyLifeRules(chosenCity);
        
            Assert.False(chosenCity.Live);
        }
        
        
        [Fact]
        public void Given_ALiveCityWithMoreThanLiveThreeNeighbours_When_LifeRulesAreApplied_Then_CityDies()
        {
            var world = World.CreateWorld(10, 10);
            var god = new God();
            god.AddSeeds(world, 2, 4);
            god.AddSeeds(world, 2, 6);
            god.AddSeeds(world, 1, 5);
            god.AddSeeds(world, 1, 6);
            
            var chosenCity = god.FetchCity(world, 2, 5);
            chosenCity.FindNeighbours(world);
            chosenCity.FindNumberOfLiveNeighbours(world);
            god.ApplyLifeRules(chosenCity);
            
            Assert.False(chosenCity.Live);
        }
        
        
        [Fact]
        public void Given_ALiveCityWithTwoLiveNeighbours_When_LifeRulesAreApplied_Then_CityLives()
        {
            var world = World.CreateWorld(10, 10);
            var god = new God();
            god.AddSeeds(world, 2, 5);
            god.AddSeeds(world, 2, 4);
            god.AddSeeds(world, 2, 6);
            
            var chosenCity = god.FetchCity(world, 2, 5);
            chosenCity.FindNeighbours(world);
            chosenCity.FindNumberOfLiveNeighbours(world);
            god.ApplyLifeRules(chosenCity);

            Assert.True(chosenCity.Live);
        }
        
        [Fact]
        public void Given_ALiveCityWithThreeLiveNeighbours_When_LifeRulesAreApplied_Then_CityLives()
        {
            var world = World.CreateWorld(10, 10);
            var god = new God();
            god.AddSeeds(world, 2, 4);
            god.AddSeeds(world, 2, 6);
            god.AddSeeds(world, 1, 5);
            
            var chosenCity = god.FetchCity(world, 2, 5);
            chosenCity.FindNeighbours(world);
            chosenCity.FindNumberOfLiveNeighbours(world);
            god.ApplyLifeRules(chosenCity);

            Assert.True(chosenCity.Live);
        }
        
        
        [Fact]
        public void Given_ADeadCityWithExactlyThreeLiveNeighbours_When_LifeRulesAreApplied_Then_CityLives()
        {
            var world = World.CreateWorld(10, 10);
            var god = new God();
            god.AddSeeds(world, 2, 4);
            god.AddSeeds(world, 2, 6);
            god.AddSeeds(world, 1, 5);
            
            var chosenCity = god.FetchCity(world, 2, 5);
            chosenCity.FindNeighbours(world);
            chosenCity.FindNumberOfLiveNeighbours(world);
            god.ApplyLifeRules(chosenCity);

            Assert.Equal(3, chosenCity.LiveNeighbours);
            Assert.True(chosenCity.Live);
        }
        
        [Fact]
        public void Given_ADeadCityWithNoLiveNeighbours_When_LifeRulesAreApplied_Then_CityLives()
        {
            var world = World.CreateWorld(10, 10);
            var god = new God();
            god.AddSeeds(world, 2, 4);
            god.AddSeeds(world, 2, 6);
            god.AddSeeds(world, 1, 5);
            
            var chosenCity = god.FetchCity(world, 5, 5);
            chosenCity.FindNeighbours(world);
            chosenCity.FindNumberOfLiveNeighbours(world);
            god.ApplyLifeRules(chosenCity);

            Assert.False(chosenCity.Live);
        }
    }
}