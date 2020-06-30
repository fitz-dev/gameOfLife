using System;
using System.Collections.Generic;
using FluentAssertions;
using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class CellTests
    {
        // [Fact]
        // public void Given_ANewWorld_When_ANewSeedIsAdded_Then_CellIsLive()
        // {
        //     var cellManager = new CellManager();
        //     var seeds = new List<Seed>(){new Seed(2, 2)};
        //     
        //     cellManager.AddSeeds(seeds);
        //     
        //     var chosenCell = cellManager.FetchCell(2, 2);
        //
        //     Assert.True(chosenCell.Live);
        // }

        [Fact]
        public void Given_NeighbourThatIsToTheLeftOfTheCell_When_FindNeighboursIsCalled_Then_ProperIndexIsFound()
        {
            var cellManager = new CellManager();
            var world = new World(5, 5);

            var length = world.Grid.GetLength(0);
            var height = world.Grid.GetLength(1);
            
            var chosenCell = cellManager.FetchCell(3, 1);
            chosenCell.Neighbours = cellManager.FindNeighbours(chosenCell, world);

            var leftNeighbour = new Coordinates(2,1);
            
            leftNeighbour.Should().BeEquivalentTo(chosenCell.Neighbours["left"]);
        }
        
        [Fact]
        public void Given_NeighbourThatIsToTheRightOfTheCell_When_FindNeighboursIsCalled_Then_ProperIndexIsFound()
        {
            var cellManager = new CellManager();
            var world = new World(5, 5);
            var length = world.Grid.GetLength(0);
            var height = world.Grid.GetLength(1);
            
            var chosenCell = cellManager.FetchCell(2, 2);
            chosenCell.Neighbours = cellManager.FindNeighbours(chosenCell, world);

            var rightNeighbour = new Coordinates(3,2);
            
            rightNeighbour.Should().BeEquivalentTo(chosenCell.Neighbours["right"]);
        }
        
        [Fact]
        public void Given_NeighbourThatIsOffTheTopEdgeOfTheWorld_When_FindNeighboursIsCalled_Then_ProperIndexIsFound()
        {
            var cellManager = new CellManager();
            var world = new World(5, 5);
            var length = world.Grid.GetLength(0);
            var height = world.Grid.GetLength(1);
               
            var chosenCell = cellManager.FetchCell(2, 0);
            chosenCell.Neighbours = cellManager.FindNeighbours(chosenCell, world);
        
            var topNeighbour = new Coordinates(2,4);
            
            topNeighbour.Should().BeEquivalentTo(chosenCell.Neighbours["top"]);
        }
        
        [Fact]
        public void Given_NeighbourThatIsOffTheBottomEdgeOfTheWorld_When_FindNeighboursIsCalled_Then_ProperIndexIsFound()
        {
            var cellManager = new CellManager();
            var world = new World(5, 5);
            var length = world.Grid.GetLength(0);
            var height = world.Grid.GetLength(1);
            
            var chosenCell = cellManager.FetchCell(2, 4);
            chosenCell.Neighbours = cellManager.FindNeighbours(chosenCell, world);
        
            var bottomNeighbour = new Coordinates(2,0);                   
            
            bottomNeighbour.Should().BeEquivalentTo(chosenCell.Neighbours["bottom"]);
        }
        
        
        [Fact]
        public void Given_NeighbourThatIsOffTheRightEdgeOfTheWorld_When_FindNeighboursIsCalled_Then_ProperIndexIsFound()
        {
            var cellManager = new CellManager();
            var world = new World(5, 5);
            var length = world.Grid.GetLength(0);
            var height = world.Grid.GetLength(1);
            
            var chosenCell = cellManager.FetchCell(4, 2);
            chosenCell.Neighbours = cellManager.FindNeighbours(chosenCell, world);
        
            var rightNeighbour = new Coordinates(0,2);
            
            rightNeighbour.Should().BeEquivalentTo(chosenCell.Neighbours["right"]);
        }
        
        [Fact]
        public void Given_NeighbourThatIsOffTheLeftEdgeOfTheWorld_When_FindNeighboursIsCalled_Then_ProperIndexIsFound()
        {
            var cellManager = new CellManager();
            var world = new World(5, 5);
            var length = world.Grid.GetLength(0);
            var height = world.Grid.GetLength(1);
            
            var chosenCell = cellManager.FetchCell(0, 3);
            chosenCell.Neighbours = cellManager.FindNeighbours(chosenCell, world);
        
            var leftNeighbour = new Coordinates(4,3);
            
            leftNeighbour.Should().BeEquivalentTo(chosenCell.Neighbours["left"]);
        }
        
        [Fact]
        public void Given_ACellThatHasTwoLiveNeighbours_When_FetchingNumberOfLiveNeighbours_Then_IntegerIsReturned()
        {
            var cellManager = new CellManager();
            var world = new World(10, 10);
            var length = world.Grid.GetLength(0);
            var height = world.Grid.GetLength(1);
            var seeds = new List<Coordinates>()
            {
                new Coordinates(0,4),
                new Coordinates(0,5),
                new Coordinates(0,6)
            };
            
            cellManager.AddSeeds(seeds);
            var chosenCell = cellManager.FetchCell(0, 5);
            chosenCell.Neighbours = cellManager.FindNeighbours(chosenCell, world);
            cellManager.SetNumberOfLiveNeighbours(cellManager.PreviousState, chosenCell);
        
            Assert.Equal(2, chosenCell.LiveNeighbours);
        }
          
        [Fact]
        public void Given_ACellThatHasNoLiveNeighbours_When_FetchingNumberOfLiveNeighbours_Then_IntegerIsReturned()
        {
            var cellManager = new CellManager();
            var world = new World(10, 10);
            var length = world.Grid.GetLength(0);
            var height = world.Grid.GetLength(1);
            
            var chosenCell = cellManager.FetchCell(0, 5);
            chosenCell.Neighbours = cellManager.FindNeighbours(chosenCell, world);
            cellManager.SetNumberOfLiveNeighbours(cellManager.PreviousState, chosenCell);
        
            Assert.Equal(0, chosenCell.LiveNeighbours);
        }
    }
}