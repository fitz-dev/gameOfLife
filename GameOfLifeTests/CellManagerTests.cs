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
        public void Given_ACellThatHasTwoLiveNeighbours_When_FetchingNumberOfLiveNeighbours_Then_IntegerIsReturned()
        {
            var cellManager = new CellManager();
            var world = new World(10, 10);
            var seeds = new List<Cell>()
            {
                new Cell(new Coordinates(0,4)),
                new Cell(new Coordinates(0,5)),
                new Cell(new Coordinates(0,6))
            };
            
            var testCell = CreateTestCell(0, 5);
            cellManager.AssignNeighbourProperties(testCell, world, seeds);
            
            Assert.Equal(2, testCell.NumLiveNeighbours);
        }
          
        [Fact]
        public void Given_ACellThatHasNoLiveNeighbours_When_FetchingNumberOfLiveNeighbours_Then_IntegerIsReturned()
       {
           var cellManager = new CellManager();
           var world = new World(10, 10);
           var seeds = new List<Cell>();
                       
           var testCell = CreateTestCell(0, 5);
           cellManager.AssignNeighbourProperties(testCell, world, seeds);
       
           Assert.Equal(0, testCell.NumLiveNeighbours);
       }
       
        private Cell CreateTestCell(int columnIndex, int rowIndex)
        {
            return new Cell(new Coordinates(columnIndex, rowIndex));
        }
    }
}