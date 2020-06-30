using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using GameOfLife;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace GameOfLifeTests
{
    public class CellManagerTests
    {
        [Fact]
        public void Given_ALiveCellWithLessThanTwoLiveNeighbours_When_LifeRulesAreApplied_Then_CellDies()
        {
            var cellManager = new CellManager();
            var world = new World(10, 10);
            var seeds = new List<Coordinates>()
            {
                new Coordinates(2,5),
            };
            
            var testCoordinate = new Coordinates(2,5);
            cellManager.AddSeeds(seeds);
            cellManager.CheckEachCellForLife(world);
            
            foreach (var coordinate in cellManager.CurrentState)
            {
                coordinate.Should().NotBeEquivalentTo(testCoordinate);
            }
        }
        
        
        [Fact]
        public void Given_ALiveCellWithMoreThanLiveThreeNeighbours_When_LifeRulesAreApplied_Then_CellDies()
        {
            var cellManager = new CellManager();
            var world = new World(10, 10);
            var seeds = new List<Coordinates>()
            {
                new Coordinates(2,4),
                new Coordinates(2,5),
                new Coordinates(2,6),
                new Coordinates(1,5),
                new Coordinates(1,6)
            };
            
            var testCoordinate = new Coordinates(2, 5);
     
            cellManager.AddSeeds(seeds);
            cellManager.CheckEachCellForLife(world);

            foreach (var coordinate in cellManager.CurrentState)
            {
                coordinate.Should().NotBeEquivalentTo(testCoordinate);
            }
        }
        
        
        [Fact]
        public void Given_ALiveCellWithTwoLiveNeighbours_When_LifeRulesAreApplied_Then_CellLives()
        {
            var cellManager = new CellManager();
            var world = new World(10, 10);
            var seeds = new List<Coordinates>()
            {
                new Coordinates(2,4),
                new Coordinates(2,5),
                new Coordinates(2,6),
            };

            var testCoordinate = new Coordinates(2, 5);
     
            cellManager.AddSeeds(seeds);
            cellManager.CheckEachCellForLife(world);

            cellManager.CurrentState.Should().ContainEquivalentOf(testCoordinate);
            // Assert.True(CoordinatesAreInCurrentLiveState(cellManager, testCoordinate));
        }
        
        [Fact]
        public void Given_ALiveCellWithThreeLiveNeighbours_When_LifeRulesAreApplied_Then_CellLives()
        {
            var cellManager = new CellManager();
            var world = new World(10, 10);
            var seeds = new List<Coordinates>()
            {
                new Coordinates(2,4),
                new Coordinates(2,5),
                new Coordinates(2,6),
                new Coordinates(1,5),
            };
            
            var testCoordinate = new Coordinates(2, 5);
     
            cellManager.AddSeeds(seeds);
            cellManager.CheckEachCellForLife(world);

            cellManager.CurrentState.Should().ContainEquivalentOf(testCoordinate);
            // Assert.True(CoordinatesAreInCurrentLiveState(cellManager, testCoordinate));
        }

       [Fact]
        public void Given_ADeadCellWithExactlyThreeLiveNeighbours_When_LifeRulesAreApplied_Then_CellLives()
        {
            var cellManager = new CellManager();
            var world = new World(7, 7);
            var seeds = new List<Coordinates>()
            {
                new Coordinates(2,4),
                new Coordinates(2,6),
                new Coordinates(1,5),
            };
            
            var testCoordinate = new Coordinates(2,5);
            cellManager.AddSeeds(seeds);
            cellManager.CheckEachCellForLife(world);

            cellManager.CurrentState.Should().ContainEquivalentOf(testCoordinate);
                        
            // Assert.True(CoordinatesAreInCurrentLiveState(cellManager, testCoordinate));
        }
        
        [Fact]
        public void Given_ADeadCellWithNoLiveNeighbours_When_LifeRulesAreApplied_Then_CellIsDead()
        {
            var cellManager = new CellManager();
            var world = new World(10, 10);
            var seeds = new List<Coordinates>();
            
            var testCoordinate = new Coordinates(7,5);
            cellManager.AddSeeds(seeds);
            cellManager.CheckEachCellForLife(world);

            cellManager.CurrentState.Should().NotContain(testCoordinate);
            // Assert.False(CoordinatesAreInCurrentLiveState(cellManager, testCoordinate));
        }
        
        private static bool CoordinatesAreInCurrentLiveState(CellManager cellManager, Coordinates coordinate)
        {
            return cellManager.CurrentState.Any(seed => seed.X == coordinate.X && seed.Y == coordinate.Y);
        }
    }
}