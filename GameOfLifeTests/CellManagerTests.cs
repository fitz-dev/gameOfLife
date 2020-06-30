using System;
using System.Collections.Generic;
using System.Linq;
using GameOfLife;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace GameOfLifeTests
{
    public class CellManagerTests
    {
        // [Fact]
        // public void Given_ANumberOfStartingSeeds_When_SeedsAreAddedToWorld_Then_SameNumberOfLiveCitiesReturnedInArray()
        // {
        //     var cellManager = new CellManager();
        //     var world = new World(10, 10);
        //     var seeds = new List<Seed>()
        //     {
        //         new Seed(3,4),
        //         new Seed(1,5)
        //     };
        //     var numberOfLiveCities = 0;
        //
        //    cellManager.AddSeeds( seeds);
        //
        //     for (int xIndex = 0; xIndex < world.RowLength; xIndex++)
        //     {
        //         for (int yIndex = 0; yIndex < world.ColumnLength; yIndex++)
        //         {
        //             if (world.Grid[xIndex, yIndex].Live)
        //             {
        //                 numberOfLiveCities++;
        //             }
        //         }
        //     }
        //     Assert.Equal(2, numberOfLiveCities);
        // }
        
        [Fact]
        public void Given_ALiveCellWithLessThanTwoLiveNeighbours_When_LifeRulesAreApplied_Then_CellDies()
        {
            var cellManager = new CellManager();
            var world = new World(10, 10);
            var chosenCell = cellManager.FetchCell(2, 5);
            var seeds = new List<Seed>()
            {
                new Seed(2,4),
            };
            
            cellManager.AddSeeds(seeds);
            cellManager.FindNextTickLiveCities(world);
            cellManager.ApplyLifeRules(world);
        
            Assert.False(chosenCell.Live);
        }
        
        
        [Fact]
        public void Given_ALiveCellWithMoreThanLiveThreeNeighbours_When_LifeRulesAreApplied_Then_CellDies()
        {
            var cellManager = new CellManager();
            var world = new World(10, 10);
            var chosenCell = cellManager.FetchCell(2, 5);
            var seeds = new List<Seed>()
            {
                new Seed(2,4),
                new Seed(2,6),
                new Seed(1,5),
                new Seed(1,6)
            };
            
            cellManager.AddSeeds(seeds);
            cellManager.FindNextTickLiveCities(world);
            cellManager.ApplyLifeRules(world);
            
            Assert.False(chosenCell.Live);
        }
        
        
        [Fact]
        public void Given_ALiveCellWithTwoLiveNeighbours_When_LifeRulesAreApplied_Then_CellLives()
        {
            var cellManager = new CellManager();
            var world = new World(10, 10);
            // var chosenCell = cellManager.FetchCell(world, 2, 5);
            var chosenCell = new Cell(new Seed(2,5));
            var seeds = new List<Seed>()
            {
                new Seed(2,4),
                new Seed(2,5),
                new Seed(2,6),
            };

            cellManager.AddSeeds(seeds);
            cellManager.FindNextTickLiveCities(world);
            cellManager.ApplyLifeRules(world);
        
            Assert.True(chosenCell.Live);
        }
        
        [Fact]
        public void Given_ALiveCellWithThreeLiveNeighbours_When_LifeRulesAreApplied_Then_CellLives()
        {
            var cellManager = new CellManager();
            var world = new World(10, 10);
            var seeds = new List<Seed>()
            {
                new Seed(2,4),
                new Seed(2,6),
                new Seed(1,5),
            };
            
            var chosenCell = cellManager.FetchCell(2, 5);
     
            cellManager.AddSeeds( seeds);
            cellManager.FindNextTickLiveCities(world);
            cellManager.ApplyLifeRules(world);
            
            Assert.Equal(3, chosenCell.LiveNeighbours);
            Assert.True(chosenCell.Live);
        }
        
        
        [Fact]
        public void Given_ADeadCellWithExactlyThreeLiveNeighbours_When_LifeRulesAreApplied_Then_CellLives()
        {
            var cellManager = new CellManager();
            var world = new World(7, 7);
            var seeds = new List<Seed>()
            {
                new Seed(2,4),
                new Seed(2,6),
                new Seed(1,5),
            };
            var chosenCell = cellManager.FetchCell(2, 5);
            
            cellManager.AddSeeds( seeds);
            cellManager.FindNextTickLiveCities(world);
            cellManager.ApplyLifeRules(world);
            
            Assert.Equal(3, chosenCell.LiveNeighbours);
            Assert.True(chosenCell.Live);
        }
        
        [Fact]
        public void Given_ADeadCellWithNoLiveNeighbours_When_LifeRulesAreApplied_Then_CellIsDead()
        {
            var cellManager = new CellManager();
            var world = new World(10, 10);
            var seeds = new List<Seed>();
            var chosenCell = cellManager.FetchCell(7, 5);
            
            cellManager.AddSeeds(seeds);
            cellManager.FindNextTickLiveCities(world);
            cellManager.ApplyLifeRules(world);
            
            Assert.Equal(0, chosenCell.LiveNeighbours);
            Assert.False(chosenCell.Live);
        }
    }
}