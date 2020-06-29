using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class SeedTests
    {
        [Fact]
        public void Given_StillLifeStartingSeeds_When_NextTickLiveCitiesAreFound_Then_ExpectedSeedCoordinatedAreReturned()
        {
            var cellManager = new CellManager();
            var world = new World(cellManager, 6, 6);
            var seeds = new List<Seed>()
            {
                new Seed(2,1),
                new Seed(3,1),
                new Seed(1,2),
                new Seed(4,2),
                new Seed(2,3),
                new Seed(3,3),
            };
            
            cellManager.AddSeeds(world, seeds);
            
            cellManager.FindNextTickLiveCities(world);
        
            cellManager.NextTickSeeds.Should().BeEquivalentTo(seeds);
        }
        
        [Fact]
        public void Given_OscillatorToadStartingSeeds_When_NextTickLiveCitiesAreFound_Then_ExpectedSeedCoordinatedAreReturned()
        {
            var cellManager = new CellManager();
            var world = new World(cellManager, 6, 6);
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
            
            cellManager.AddSeeds(world, seeds);
            
            cellManager.FindNextTickLiveCities(world);
        
            cellManager.NextTickSeeds.Should().BeEquivalentTo(expectedSeedCoordinates);
        }
        
        [Fact]
        public void Given_OscillatorBeaconStartingSeeds_When_NextTickLiveCitiesAreFound_Then_ExpectedSeedCoordinatedAreReturned()
        {
            var cellManager = new CellManager();
            var world = new World(cellManager, 6, 6);
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
            
            cellManager.AddSeeds(world, seeds);
            cellManager.FindNextTickLiveCities(world);
        
            cellManager.NextTickSeeds.Should().BeEquivalentTo(expectedSeedCoordinates);
        }

        [Fact]
        public void Given_OscillatorBeaconStartingSeeds_When_TwoTicksHaveElapsed_Then_ExpectedSeedCoordinatedAreReturned()
        {
            var cellManager = new CellManager();
            var world = new World(cellManager, 6, 6);
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
            
            cellManager.AddSeeds(world, seeds);
            
            cellManager.FindNextTickLiveCities(world);
            cellManager.ApplyLifeRules(world);
            
            cellManager.AddSeeds(world, cellManager.NextTickSeeds);
            
            cellManager.FindNextTickLiveCities(world);
            cellManager.ApplyLifeRules(world);

            cellManager.NextTickSeeds.Should().BeEquivalentTo(seeds);
        }
        
        [Fact]
        public void Given_OscillatorPulsarStartingSeeds_When_ThreeTicksHaveElapsed_Then_ExpectedSeedCoordinatedAreReturned()
        {
            var cellManager = new CellManager();
            var world = new World(cellManager, 20, 20);
            var seeds = new List<Seed>()
            {
                new Seed(4,2),
                new Seed(5,2),
                new Seed(6,2),
                new Seed(10,2),
                new Seed(11,2),
                new Seed(12,2),
                new Seed(2,4),
                new Seed(7,4),
                new Seed(9,4),
                new Seed(14,4),
                new Seed(2,5),
                new Seed(7,5),
                new Seed(9,5),
                new Seed(14,5),
                new Seed(2,6),
                new Seed(7,6),
                new Seed(9,6),
                new Seed(14,6),
                new Seed(4,7),
                new Seed(5,7),
                new Seed(6,7),
                new Seed(10,7),
                new Seed(11,7),
                new Seed(12,7),
                new Seed(4,9),
                new Seed(5,9),
                new Seed(6,9),
                new Seed(10,9),
                new Seed(11,9),
                new Seed(12,9),
                new Seed(2,10),
                new Seed(7,10),
                new Seed(9,10),
                new Seed(14,10),
                new Seed(2,11),
                new Seed(7,11),
                new Seed(9,11),
                new Seed(14,11),
                new Seed(2,12),
                new Seed(7,12),
                new Seed(9,12),
                new Seed(14,12),
                new Seed(4,14),
                new Seed(5,14),
                new Seed(6,14),
                new Seed(10,14),
                new Seed(11,14),
                new Seed(12,14),
            };
            
            cellManager.AddSeeds(world, seeds);
            
            for (int i = 0; i < 3; i++)
            {
                cellManager.FindNextTickLiveCities(world);
                cellManager.ApplyLifeRules(world);
                cellManager.AddSeeds(world, cellManager.NextTickSeeds);
            }
            cellManager.NextTickSeeds.Should().BeEquivalentTo(seeds);
        }
    }
}