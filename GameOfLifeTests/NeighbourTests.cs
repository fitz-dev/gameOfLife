using System.Collections.Generic;
using FluentAssertions;
using GameOfLife.Logic;
using GameOfLife.Models;
using Xunit;

namespace GameOfLifeTests
{
    public class NeighbourTests
    {
        [Fact]
        public void Given_CellWithNeighbourOnTheLeft_When_SetNeighboursIsCalled_Then_ExpectedCellCoordinatesAreFound()
        {
            var world = new World(5, 5);
            var cell = CreateTestCell(3, 1);
            var expectedLeftNeighbour = CreateTestCell(2,1);

            cell.Neighbours = Neighbours.SetNeighbours(cell, world);
            
            cell.Neighbours.Should().ContainEquivalentOf(expectedLeftNeighbour);
        }
        
        [Fact]
        public void Given_CellWithNeighbourOnTheRight_When_SetNeighboursIsCalled_Then_ExpectedCellCoordinatesAreFound()
        {
            var world = new World(5, 5);
            var cell = CreateTestCell(2, 2);
            var expectedRightNeighbour = CreateTestCell(3,2);
                        
            cell.Neighbours = Neighbours.SetNeighbours(cell, world);
            
            cell.Neighbours.Should().ContainEquivalentOf(expectedRightNeighbour);
        }
        
        [Fact]
        public void Given_CellWithNeighbourOnTheTopFringe_When_SetNeighboursIsCalled_Then_ExpectedCellCoordinatesAreFound()
        {
            var world = new World(5, 5);
            var cell = CreateTestCell(2, 0);
            var expectedTopNeighbour = CreateTestCell(2,4);
                           
            cell.Neighbours = Neighbours.SetNeighbours(cell, world);
        
            cell.Neighbours.Should().ContainEquivalentOf(expectedTopNeighbour);
        }
        
        [Fact]
        public void Given_CellWithNeighbourOnTheBottomFringe_When_SetNeighboursIsCalled_Then_ExpectedCellCoordinatesAreFound()
        {
            var world = new World(5, 5);
            var cell = CreateTestCell(2, 4);
            var expectedBottomNeighbour = CreateTestCell(2,0);                   
            cell.Neighbours = Neighbours.SetNeighbours(cell, world);
                        
            cell.Neighbours.Should().ContainEquivalentOf(expectedBottomNeighbour);
        }
        
        
        [Fact]
        public void Given_CellWithNeighbourOnTheRightFringe_When_SetNeighboursIsCalled_Then_ExpectedCellCoordinatesAreFound()
        {
            var world = new World(5, 5);
            var cell = CreateTestCell(4, 2);
            var expectedRightNeighbour = CreateTestCell(0,2);
            cell.Neighbours = Neighbours.SetNeighbours(cell, world);
        
            cell.Neighbours.Should().ContainEquivalentOf(expectedRightNeighbour);
        }
        
        [Fact]
        public void Given_CellWithNeighbourOnTheTopRightFringe_When_SetNeighboursIsCalled_Then_ExpectedCellCoordinatesAreFound()
        {
            var world = new World(5, 5);
            var cell = CreateTestCell(3, 0);
            var expectedTopRightNeighbour = CreateTestCell(4,4);
            cell.Neighbours = Neighbours.SetNeighbours(cell, world);
        
            cell.Neighbours.Should().ContainEquivalentOf(expectedTopRightNeighbour);

        }
        
        [Fact]
        public void Given_ACellThatHasTwoLiveNeighbours_When_FetchingNumberOfLiveNeighbours_Then_IntegerIsReturned()
        {
            var world = new World(10, 10);
            var seeds = new List<Cell>()
            {
                new Cell(new Coordinates(0,4))
                {
                    Live = true, 
                    Neighbours = {}, 
                    Position = {}, 
                    NumLiveNeighbours = 0
                },
                new Cell(new Coordinates(0,6))
                {
                    Live = true, 
                    Neighbours = {}, 
                    Position = {}, 
                    NumLiveNeighbours = 0
                },
            };
            var cell = CreateTestCell(0, 5);
            
            cell.Neighbours = Neighbours.SetNeighbours(cell, world);
            cell.NumLiveNeighbours = Neighbours.SetNumberOfLiveNeighbours(seeds, cell);
            
            Assert.Equal(2, cell.NumLiveNeighbours);
        }
          
        [Fact]
        public void Given_ACellThatHasNoLiveNeighbours_When_FetchingNumberOfLiveNeighbours_Then_IntegerIsReturned()
        {
            var world = new World(10, 10);
            var seeds = new List<Cell>();
                       
            var cell = CreateTestCell(0, 5);
            cell.Neighbours = Neighbours.SetNeighbours(cell, world);
            cell.NumLiveNeighbours = Neighbours.SetNumberOfLiveNeighbours(seeds, cell);

            Assert.Equal(0, cell.NumLiveNeighbours);
        }
        
        private Cell CreateTestCell(int xIndex, int yIndex)
        {
            return new Cell(new Coordinates(xIndex, yIndex));
        }
    }
}