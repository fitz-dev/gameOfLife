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
            
            cellManager.PreviousState = seeds;
            var testCell = CreateTestCell(0, 5);
            testCell.Neighbours = cellManager.FindNeighbours(testCell, world);
            testCell.LiveNeighbours = cellManager.SetNumberOfLiveNeighbours(cellManager.PreviousState, testCell);
        
            Assert.Equal(2, testCell.LiveNeighbours);
        }
          
        [Fact]
        public void Given_ACellThatHasNoLiveNeighbours_When_FetchingNumberOfLiveNeighbours_Then_IntegerIsReturned()
        {
            var cellManager = new CellManager();
            var world = new World(10, 10);
                        
            var testCell = CreateTestCell(0, 5);
            testCell.Neighbours = cellManager.FindNeighbours(testCell, world);
            cellManager.SetNumberOfLiveNeighbours(cellManager.PreviousState, testCell);
        
            Assert.Equal(0, testCell.LiveNeighbours);
        }
        
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
            cellManager.PreviousState = seeds;
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

            cellManager.PreviousState = seeds;
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

            cellManager.PreviousState = seeds;
            cellManager.CheckEachCellForLife(world);

            cellManager.CurrentState.Should().ContainEquivalentOf(testCoordinate);
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
     
            cellManager.PreviousState = seeds;
            cellManager.CheckEachCellForLife(world);

            cellManager.CurrentState.Should().ContainEquivalentOf(testCoordinate);
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
            cellManager.PreviousState = seeds;
            cellManager.CheckEachCellForLife(world);

            cellManager.CurrentState.Should().ContainEquivalentOf(testCoordinate);
        }
        
        [Fact]
        public void Given_ADeadCellWithNoLiveNeighbours_When_LifeRulesAreApplied_Then_CellIsDead()
        {
            var cellManager = new CellManager();
            var world = new World(10, 10);
            var seeds = new List<Coordinates>();
            
            var testCoordinate = new Coordinates(7,5);
            cellManager.PreviousState = seeds;
            cellManager.CheckEachCellForLife(world);

            cellManager.CurrentState.Should().NotContain(testCoordinate);
        }
        
        
        private Cell CreateTestCell(int columnIndex, int rowIndex)
        {
            return new Cell(new Coordinates(columnIndex, rowIndex));
        }
    }
}