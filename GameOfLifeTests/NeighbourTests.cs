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
            var testCell = CreateTestCell(3, 1);
            var expectedLeftNeighbour = CreateTestCell(2,1);

            testCell.Neighbours = Neighbours.SetNeighbours(testCell, world);
            
            testCell.Neighbours.Should().ContainEquivalentOf(expectedLeftNeighbour);
        }
        
        [Fact]
        public void Given_CellWithNeighbourOnTheRight_When_SetNeighboursIsCalled_Then_ExpectedCellCoordinatesAreFound()
        {
            var world = new World(5, 5);
            var testCell = CreateTestCell(2, 2);
            var expectedRightNeighbour = CreateTestCell(3,2);
                        
            testCell.Neighbours = Neighbours.SetNeighbours(testCell, world);
            
            testCell.Neighbours.Should().ContainEquivalentOf(expectedRightNeighbour);
        }
        
        [Fact]
        public void Given_CellWithNeighbourOnTheTopFringe_When_SetNeighboursIsCalled_Then_ExpectedCellCoordinatesAreFound()
        {
            var world = new World(5, 5);
            var testCell = CreateTestCell(2, 0);
            var expectedTopNeighbour = CreateTestCell(2,4);
                           
            testCell.Neighbours = Neighbours.SetNeighbours(testCell, world);
        
            testCell.Neighbours.Should().ContainEquivalentOf(expectedTopNeighbour);
        }
        
        [Fact]
        public void Given_CellWithNeighbourOnTheBottomFringe_When_SetNeighboursIsCalled_Then_ExpectedCellCoordinatesAreFound()
        {
            var world = new World(5, 5);
            var testCell = CreateTestCell(2, 4);
            var expectedBottomNeighbour = CreateTestCell(2,0);                   
            testCell.Neighbours = Neighbours.SetNeighbours(testCell, world);
                        
            testCell.Neighbours.Should().ContainEquivalentOf(expectedBottomNeighbour);
        }
        
        
        [Fact]
        public void Given_CellWithNeighbourOnTheRightFringe_When_SetNeighboursIsCalled_Then_ExpectedCellCoordinatesAreFound()
        {
            var world = new World(5, 5);
            var testCell = CreateTestCell(4, 2);
            var expectedRightNeighbour = CreateTestCell(0,2);
            
            testCell.Neighbours = Neighbours.SetNeighbours(testCell, world);
        
            testCell.Neighbours.Should().ContainEquivalentOf(expectedRightNeighbour);
        }
        
        [Fact]
        public void Given_CellWithNeighbourOnTheTopRightFringe_When_SetNeighboursIsCalled_Then_ExpectedCellCoordinatesAreFound()
        {
            var world = new World(5, 5);
            var testCell = CreateTestCell(3, 0);
            var expectedTopRightNeighbour = CreateTestCell(4,4);
                        
            testCell.Neighbours = Neighbours.SetNeighbours(testCell, world);
        
            testCell.Neighbours.Should().ContainEquivalentOf(expectedTopRightNeighbour);

        }
        
        private Cell CreateTestCell(int xIndex, int yIndex)
        {
            return new Cell(new Coordinates(xIndex, yIndex));
        }
    }
}