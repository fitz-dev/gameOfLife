using System;
using System.Collections.Generic;
using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class CellTests
    {
        [Fact]
        public void Given_ANewWorld_When_ANewSeedIsAdded_Then_CellIsLive()
        {
            var cellManager = new CellManager();
            var world = new World(cellManager, 5, 5);
            var seeds = new List<Seed>(){new Seed(2, 2)};
            
            cellManager.AddSeeds(world, seeds);
            var chosenCell =  cellManager.FetchCell(world, 2, 2);

            Assert.True(chosenCell.Live);
        }

        [Fact]
        public void Given_NeighbourThatIsToTheLeftOfTheCell_When_FindNeighboursIsCalled_Then_ProperIndexIsFound()
        {
            var cellManager = new CellManager();
            var world = new World(cellManager, 5, 5);
            
            var chosenCell = cellManager.FetchCell(world, 2, 2);

            var leftNeighbour = new Tuple<int, int>(1,2);
            
            Assert.Equal(leftNeighbour, chosenCell.Neighbours["left"]);
        }
        
        [Fact]
        public void Given_NeighbourThatIsToTheRightOfTheCell_When_FindNeighboursIsCalled_Then_ProperIndexIsFound()
        {
            var cellManager = new CellManager();
            var world = new World(cellManager, 5, 5);
            
            var chosenCell = cellManager.FetchCell(world, 2, 2);

            var leftNeighbour = new Tuple<int, int>(3,2);
            
            Assert.Equal(leftNeighbour, chosenCell.Neighbours["right"]);
        }
        
        [Fact]
        public void Given_NeighbourThatIsOffTheTopEdgeOfTheWorld_When_FindNeighboursIsCalled_Then_ProperIndexIsFound()
        {
            var cellManager = new CellManager();
            var world = new World(cellManager, 5, 5);
               
            var chosenCell = cellManager.FetchCell(world, 2, 0);
        
            var topNeighbour = new Tuple<int, int>(2,4);
            
            Assert.Equal(topNeighbour, chosenCell.Neighbours["top"]);
        }
        
        [Fact]
        public void Given_NeighbourThatIsOffTheBottomEdgeOfTheWorld_When_FindNeighboursIsCalled_Then_ProperIndexIsFound()
        {
            var cellManager = new CellManager();
            var world = new World(cellManager, 5, 5);
            
            var chosenCell = cellManager.FetchCell(world, 2, 4);
        
            var bottomNeighbour = new Tuple<int, int>(2,0);                   
            
            Assert.Equal(bottomNeighbour, chosenCell.Neighbours["bottom"]);
        }
        
        
        [Fact]
        public void Given_NeighbourThatIsOffTheRightEdgeOfTheWorld_When_FindNeighboursIsCalled_Then_ProperIndexIsFound()
        {
            var cellManager = new CellManager();
            var world = new World(cellManager, 5, 5);
            
            var chosenCell = cellManager.FetchCell(world, 4, 2);
        
            var rightNeighbour = new Tuple<int, int>(0,2);
            
            Assert.Equal(rightNeighbour, chosenCell.Neighbours["right"]);
        }
        
        [Fact]
        public void Given_NeighbourThatIsOffTheLeftEdgeOfTheWorld_When_FindNeighboursIsCalled_Then_ProperIndexIsFound()
        {
            var cellManager = new CellManager();
            var world = new World(cellManager, 5, 5);
            
            var chosenCell = cellManager.FetchCell(world, 0, 3);
        
            var leftNeighbour = new Tuple<int, int>(4,3);
            
            Assert.Equal(leftNeighbour, chosenCell.Neighbours["left"]);
        }
        
        [Fact]
        public void Given_ACellThatHasTwoLiveNeighbours_When_FetchingNumberOfLiveNeighbours_Then_IntegerIsReturned()
        {
            var cellManager = new CellManager();
            var world = new World(cellManager, 10, 10);
            var seeds = new List<Seed>()
            {
                new Seed(0,4),
                new Seed(0,5),
                new Seed(0,6)
            };
            cellManager.AddSeeds(world, seeds);
            var chosenCell = cellManager.FetchCell(world, 0, 5);
            chosenCell.SetNumberOfLiveNeighbours(world);
        
            Assert.Equal(2, chosenCell.LiveNeighbours);
        }
          
        [Fact]
        public void Given_ACellThatHasNoLiveNeighbours_When_FetchingNumberOfLiveNeighbours_Then_IntegerIsReturned()
        {
            var cellManager = new CellManager();
            var world = new World(cellManager, 10, 10);
            
            var chosenCell = cellManager.FetchCell(world, 0, 5);
            chosenCell.SetNumberOfLiveNeighbours(world);
        
            Assert.Equal(0, chosenCell.LiveNeighbours);
        }
    }
}