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
        public void Given_NeighbourThatIsToTheLeftOfTheCell_When_FindNeighboursIsCalled_Then_ProperIndexIsFound()
        {
            var cellManager = new CellManager();
            var world = new World(5, 5);

            var testCell = CreateTestCell(3, 1);
            testCell.Neighbours = cellManager.FindNeighbours(testCell, world);

            var leftNeighbour = new Coordinates(2,1);
            
            leftNeighbour.Should().BeEquivalentTo(testCell.Neighbours["left"]);
        }
        
        [Fact]
        public void Given_NeighbourThatIsToTheRightOfTheCell_When_FindNeighboursIsCalled_Then_ProperIndexIsFound()
        {
            var cellManager = new CellManager();
            var world = new World(5, 5);
                        
            var testCell = CreateTestCell(2, 2);
            testCell.Neighbours = cellManager.FindNeighbours(testCell, world);

            var rightNeighbour = new Coordinates(3,2);
            
            rightNeighbour.Should().BeEquivalentTo(testCell.Neighbours["right"]);
        }
        
        [Fact]
        public void Given_NeighbourThatIsOffTheTopEdgeOfTheWorld_When_FindNeighboursIsCalled_Then_ProperIndexIsFound()
        {
            var cellManager = new CellManager();
            var world = new World(5, 5);
                           
            var testCell = CreateTestCell(2, 0);
            testCell.Neighbours = cellManager.FindNeighbours(testCell, world);
        
            var topNeighbour = new Coordinates(2,4);
            
            topNeighbour.Should().BeEquivalentTo(testCell.Neighbours["top"]);
        }
        
        [Fact]
        public void Given_NeighbourThatIsOffTheBottomEdgeOfTheWorld_When_FindNeighboursIsCalled_Then_ProperIndexIsFound()
        {
            var cellManager = new CellManager();
            var world = new World(5, 5);
                        
            var testCell = CreateTestCell(2, 4);
            testCell.Neighbours = cellManager.FindNeighbours(testCell, world);
        
            var bottomNeighbour = new Coordinates(2,0);                   
            
            bottomNeighbour.Should().BeEquivalentTo(testCell.Neighbours["bottom"]);
        }
        
        
        [Fact]
        public void Given_NeighbourThatIsOffTheRightEdgeOfTheWorld_When_FindNeighboursIsCalled_Then_ProperIndexIsFound()
        {
            var cellManager = new CellManager();
            var world = new World(5, 5);
                        
            var testCell = CreateTestCell(4, 2);
            testCell.Neighbours = cellManager.FindNeighbours(testCell, world);
        
            var rightNeighbour = new Coordinates(0,2);
            
            rightNeighbour.Should().BeEquivalentTo(testCell.Neighbours["right"]);
        }
        
        [Fact]
        public void Given_NeighbourThatIsOffTheLeftEdgeOfTheWorld_When_FindNeighboursIsCalled_Then_ProperIndexIsFound()
        {
            var cellManager = new CellManager();
            var world = new World(5, 5);
                        
            var testCell = CreateTestCell(0, 3);
            testCell.Neighbours = cellManager.FindNeighbours(testCell, world);
        
            var leftNeighbour = new Coordinates(4,3);
            
            leftNeighbour.Should().BeEquivalentTo(testCell.Neighbours["left"]);
        }
        
        [Fact]
        public void Given_ACellThatHasTwoLiveNeighbours_When_FetchingNumberOfLiveNeighbours_Then_IntegerIsReturned()
        {
            var cellManager = new CellManager();
            var world = new World(10, 10);
            var seeds = new List<Coordinates>()
            {
                new Coordinates(0,4),
                new Coordinates(0,5),
                new Coordinates(0,6)
            };
            
            var testCell = CreateTestCell(0, 5);
            cellManager.AssignNeighbourProperties(testCell, world, seeds);
            
            Assert.Equal(2, testCell.LiveNeighbours);
        }
          
        [Fact]
        public void Given_ACellThatHasNoLiveNeighbours_When_FetchingNumberOfLiveNeighbours_Then_IntegerIsReturned()
       {
           var cellManager = new CellManager();
           var world = new World(10, 10);
           var seeds = new List<Coordinates>();
                       
           var testCell = CreateTestCell(0, 5);
           cellManager.AssignNeighbourProperties(testCell, world, seeds);
       
           Assert.Equal(0, testCell.LiveNeighbours);
       }
       
        private Cell CreateTestCell(int columnIndex, int rowIndex)
        {
            return new Cell(new Coordinates(columnIndex, rowIndex));
        }
    }
}