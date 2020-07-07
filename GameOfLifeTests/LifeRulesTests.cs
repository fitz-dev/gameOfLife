using System.Collections.Generic;
using FluentAssertions;
using GameOfLife.Logic;
using GameOfLife.Managers;
using GameOfLife.Models;
using Xunit;

namespace GameOfLifeTests
{
    public class LifeRulesTests
    { 
        [Fact]
       public void Given_ALiveCellWithLessThanTwoLiveNeighbours_When_CellIsChecked_Then_CellDies()
       {
           var testCoordinate = new Cell(new Coordinates(2,4))
           {
               Live = true, 
               Neighbours = new List<Cell>(),
               NumLiveNeighbours = 1,
           };

           Assert.False(LifeRules.CellShouldLive(testCoordinate));
       }
       
        
        [Fact]
        public void Given_ALiveCellWithMoreThanLiveThreeNeighbours_When_CellIsChecked_Then_CellDies()
        {
            var testCoordinate = new Cell(new Coordinates(2,4))
            {
                Live = true, 
                Neighbours = new List<Cell>(),
                NumLiveNeighbours = 4,
            };

            Assert.False(LifeRules.CellShouldLive(testCoordinate));
        }
        
        
        [Fact]
        public void Given_ALiveCellWithTwoLiveNeighbours_When_CellIsChecked_Then_CellLives()
        {
            var testCoordinate = new Cell(new Coordinates(2,4))
            {
                Live = true, 
                Neighbours = new List<Cell>(),
                NumLiveNeighbours = 2,
            };

            Assert.True(LifeRules.CellShouldLive(testCoordinate));
        }
        
        [Fact]
        public void Given_ALiveCellWithThreeLiveNeighbours_When_TheCellIsChecked_Then_CellLives()
        {
            var testCoordinate = new Cell(new Coordinates(2,4))
            {
                Live = true, 
                Neighbours = new List<Cell>(),
                NumLiveNeighbours = 3,
            };

            Assert.True(LifeRules.CellShouldLive(testCoordinate));
        }
       
       [Fact]
        public void Given_ADeadCellWithThreeLiveNeighbours_When_CellIsChecked_Then_CellLives()
        {
            var testCoordinate = new Cell(new Coordinates(2,4))
            {
                Live = false, 
                Neighbours = new List<Cell>(),
                NumLiveNeighbours = 3,
            };

            Assert.True(LifeRules.CellShouldLive(testCoordinate));
        }
        
        [Fact]
        public void Given_ADeadCellWithNoLiveNeighbours_When_CellIsChecked_Then_CellDies()
        {
            var testCoordinate = new Cell(new Coordinates(2,4))
            {
                Live = false, 
                Neighbours = new List<Cell>(),
                NumLiveNeighbours = 0,
            };

            Assert.False(LifeRules.CellShouldLive(testCoordinate));
        }
    }
}