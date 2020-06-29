using System;
using System.Collections.Generic;
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
            var world = new World(god, 10, 10);
            var seeds = new List<Seed>()
            {
                new Seed(3,4),
                new Seed(1,5)
            };
            var numberOfLiveCities = 0;

           god.AddSeeds(world, seeds);

            for (int xIndex = 0; xIndex < world.RowLength; xIndex++)
            {
                for (int yIndex = 0; yIndex < world.ColumnLength; yIndex++)
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
            var god = new God();
            var world = new World(god, 10, 10);
            var chosenCity = god.FetchCity(world, 2, 5);
            var seeds = new List<Seed>()
            {
                new Seed(2,4),
            };
            
            god.AddSeeds(world,seeds);
            god.FindNextTickLiveCities(world);
            god.ApplyLifeRules(world);
        
            Assert.False(chosenCity.Live);
        }
        
        
        [Fact]
        public void Given_ALiveCityWithMoreThanLiveThreeNeighbours_When_LifeRulesAreApplied_Then_CityDies()
        {
            var god = new God();
            var world = new World(god, 10, 10);
            var chosenCity = god.FetchCity(world, 2, 5);
            var seeds = new List<Seed>()
            {
                new Seed(2,4),
                new Seed(2,6),
                new Seed(1,5),
                new Seed(1,6)
            };
            
            god.AddSeeds(world,seeds);
            god.FindNextTickLiveCities(world);
            god.ApplyLifeRules(world);
            
            Assert.False(chosenCity.Live);
        }
        
        
        [Fact]
        public void Given_ALiveCityWithTwoLiveNeighbours_When_LifeRulesAreApplied_Then_CityLives()
        {
            var god = new God();
            var world = new World(god, 10, 10);
            var chosenCity = god.FetchCity(world, 2, 5);
            var seeds = new List<Seed>()
            {
                new Seed(2,4),
                new Seed(2,5),
                new Seed(2,6),
            };

            god.AddSeeds(world,seeds);
            god.FindNextTickLiveCities(world);
            god.ApplyLifeRules(world);
            // god.AddOriginalSeeds(world, 2, 5);
            // god.AddOriginalSeeds(world, 2, 4);
            // god.AddOriginalSeeds(world, 2, 6);
            //
            // var chosenCity = god.FetchCity(world, 2, 5);
            // chosenCity.GetNumberOfLiveNeighbours(world);
            // god.CompareNumberOfLiveNeighbours(chosenCity);
        
            Assert.True(chosenCity.Live);
        }
        
        [Fact]
        public void Given_ALiveCityWithThreeLiveNeighbours_When_LifeRulesAreApplied_Then_CityLives()
        {
            var god = new God();
            var world = new World(god, 10, 10);
            var seeds = new List<Seed>()
            {
                new Seed(2,4),
                new Seed(2,6),
                new Seed(1,5),
            };
            
            var chosenCity = god.FetchCity(world, 2, 5);
     
            god.AddSeeds(world, seeds);
            god.FindNextTickLiveCities(world);
            god.ApplyLifeRules(world);
            
            Assert.Equal(3, chosenCity.LiveNeighbours);
            Assert.True(chosenCity.Live);
        }
        
        
        [Fact]
        public void Given_ADeadCityWithExactlyThreeLiveNeighbours_When_LifeRulesAreApplied_Then_CityLives()
        {
            var god = new God();
            var world = new World(god, 7, 7);
            var seeds = new List<Seed>()
            {
                new Seed(2,4),
                new Seed(2,6),
                new Seed(1,5),
            };
            var chosenCity = god.FetchCity(world, 2, 5);
            
            god.AddSeeds(world, seeds);
            god.FindNextTickLiveCities(world);
            god.ApplyLifeRules(world);
            
            Assert.Equal(3, chosenCity.LiveNeighbours);
            Assert.True(chosenCity.Live);
        }
        
        [Fact]
        public void Given_ADeadCityWithNoLiveNeighbours_When_LifeRulesAreApplied_Then_CityIsDead()
        {
            var god = new God();
            var world = new World(god, 10, 10);
            var seeds = new List<Seed>();
            var chosenCity = god.FetchCity(world, 7, 5);
            
            god.AddSeeds(world,seeds);
            god.FindNextTickLiveCities(world);
            god.ApplyLifeRules(world);
            
            Assert.Equal(0, chosenCity.LiveNeighbours);
            Assert.False(chosenCity.Live);
        }
    }
}