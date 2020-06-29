using System;
using System.Collections.Generic;
using System.Linq;
using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class SeedTests
    {
        [Fact]
        public void Given_StillLifeStartingSeeds_When_NextTickLiveCitiesAreFound_Then_ExpectedSeedCoordinatedAreReturned()
        {
            var god = new God();
            var world = new World(god, 6, 6);
            var seeds = new List<Seed>()
            {
                new Seed(2,1),
                new Seed(3,1),
                new Seed(1,2),
                new Seed(4,2),
                new Seed(2,3),
                new Seed(3,3),
            };
            
            god.AddSeeds(world, seeds);
            
            god.FindNextTickLiveCities(world);
        
            Assert.Equal(ConvertFormat(seeds), ConvertFormat(god.NextTickSeeds));
        }
        
        [Fact]
        public void Given_OscillatorToadStartingSeeds_When_NextTickLiveCitiesAreFound_Then_ExpectedSeedCoordinatedAreReturned()
        {
            var god = new God();
            var world = new World(god, 6, 6);
            var seeds = new List<Seed>()
            {
                new Seed(2,2),
                new Seed(3,2),
                new Seed(4,2),
                new Seed(1,3),
                new Seed(2,3),
                new Seed(3,3),
            };
            
            var expectedSeedCoordinates = new List<Seed>()
            {
                new Seed(3,1),
                new Seed(1,2),
                new Seed(4,2),
                new Seed(1,3),
                new Seed(4,3),
                new Seed(2,4)
            };
            
            god.AddSeeds(world, seeds);
            
            god.FindNextTickLiveCities(world);
        
            Assert.Equal(ConvertFormat(expectedSeedCoordinates), ConvertFormat(god.NextTickSeeds));
        }
        
        [Fact]
        public void Given_OscillatorBeaconStartingSeeds_When_NextTickLiveCitiesAreFound_Then_ExpectedSeedCoordinatedAreReturned()
        {
            var god = new God();
            var world = new World(god, 6, 6);
            var seeds = new List<Seed>()
            {
                new Seed(1,1),
                new Seed(2,1),
                new Seed(1,2),
                new Seed(2,2),
                new Seed(3,3),
                new Seed(4,3),
                new Seed(3,4),
                new Seed(4,4),
            };
            
            var expectedSeedCoordinates = new List<Seed>()
            {
                new Seed(1,1),
                new Seed(2,1),
                new Seed(1,2),
                new Seed(4,3),
                new Seed(3,4),
                new Seed(4,4),
            };
            
            god.AddSeeds(world, seeds);
            god.FindNextTickLiveCities(world);
        
            Assert.Equal(ConvertFormat(expectedSeedCoordinates), ConvertFormat(god.NextTickSeeds));
        }

        [Fact]
        public void Given_OscillatorBeaconStartingSeeds_When_TwoTicksHaveElapsed_Then_ExpectedSeedCoordinatedAreReturned()
        {
            var god = new God();
            var world = new World(god, 6, 6);
            var seeds = new List<Seed>()
            {
                new Seed(1,1),
                new Seed(2,1),
                new Seed(1,2),
                new Seed(2,2),
                new Seed(3,3),
                new Seed(4,3),
                new Seed(3,4),
                new Seed(4,4),
            };
            
            god.AddSeeds(world, seeds);
            
            god.FindNextTickLiveCities(world);
            god.ApplyLifeRules(world);
            
            god.AddSeeds(world, god.NextTickSeeds);
            
            god.FindNextTickLiveCities(world);
            god.ApplyLifeRules(world);

            Assert.Equal(ConvertFormat(seeds), ConvertFormat(god.NextTickSeeds));
        }

        private List<Tuple<int, int>> ConvertFormat(List<Seed> seedsToConvert)
        {
            var output = new List<Tuple<int, int>>();
            foreach (var seed in seedsToConvert)
            {
                output.Add(Tuple.Create(seedsToConvert[0].X, seedsToConvert[1].Y));
            }
            return output;
        }
    }
}