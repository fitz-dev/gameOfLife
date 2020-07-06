using FluentAssertions;
using GameOfLife;
using GameOfLife.Logic;
using GameOfLife.Managers;
using GameOfLife.Models;
using Xunit;

namespace GameOfLifeTests
{
    public class NeighbourTests
    {
        [Fact]
        public void Given_CellWithNeighbourOnTheLeft_When_FindNeighboursIsCalled_Then_ProperIndexIsFound()
        {
            var world = new World(5, 5);

            var testCell = CreateTestCell(3, 1);
            testCell.Neighbours = Neighbours.FindNeighbours(testCell, world);

            var leftNeighbour = new Coordinates(2,1);
            
            testCell.Neighbours.Should().ContainEquivalentOf(leftNeighbour);
        }
        
        [Fact]
        public void Given_CellWithNeighbourOnTheRight_When_FindNeighboursIsCalled_Then_ProperIndexIsFound()
        {
            var world = new World(5, 5);
                        
            var testCell = CreateTestCell(2, 2);
            testCell.Neighbours = Neighbours.FindNeighbours(testCell, world);

            var rightNeighbour = new Coordinates(3,2);
            
            testCell.Neighbours.Should().ContainEquivalentOf(rightNeighbour);
        }
        
        [Fact]
        public void Given_CellWithNeighbourOnTheTopFringe_When_FindNeighboursIsCalled_Then_ProperIndexIsFound()
        {
            var world = new World(5, 5);
                           
            var testCell = CreateTestCell(2, 0);
            testCell.Neighbours = Neighbours.FindNeighbours(testCell, world);
        
            var topNeighbour = new Coordinates(2,4);
            
            testCell.Neighbours.Should().ContainEquivalentOf(topNeighbour);
        }
        
        [Fact]
        public void Given_CellWithNeighbourOnTheBottomFringe_When_FindNeighboursIsCalled_Then_ProperIndexIsFound()
        {
            var world = new World(5, 5);
                        
            var testCell = CreateTestCell(2, 4);
            testCell.Neighbours = Neighbours.FindNeighbours(testCell, world);
        
            var bottomNeighbour = new Coordinates(2,0);                   
            
            testCell.Neighbours.Should().ContainEquivalentOf(bottomNeighbour);
        }
        
        
        [Fact]
        public void Given_CellWithNeighbourOnTheRightFringe_When_FindNeighboursIsCalled_Then_ProperIndexIsFound()
        {
            var world = new World(5, 5);
                        
            var testCell = CreateTestCell(4, 2);
            testCell.Neighbours = Neighbours.FindNeighbours(testCell, world);
        
            var rightNeighbour = new Coordinates(0,2);
            
            testCell.Neighbours.Should().ContainEquivalentOf(rightNeighbour);
        }
        
        [Fact]
        public void Given_CellWithNeighbourOnTheTopRightFringe_When_FindNeighboursIsCalled_Then_ProperIndexIsFound()
        {
            var world = new World(5, 5);
                        
            var testCell = CreateTestCell(3, 0);
            testCell.Neighbours = Neighbours.FindNeighbours(testCell, world);
        
            var toprightNeighbour = new Coordinates(4,4);

            testCell.Neighbours.Should().ContainEquivalentOf(toprightNeighbour);
        }
        
        private Cell CreateTestCell(int columnIndex, int rowIndex)
        {
            return new Cell(new Coordinates(columnIndex, rowIndex));
        }
    }
}