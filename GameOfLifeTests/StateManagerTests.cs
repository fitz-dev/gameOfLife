using System.Collections.Generic;
using FluentAssertions;
using GameOfLife;
using GameOfLife.Managers;
using Xunit;

namespace GameOfLifeTests
{
    public class StateManagerTests
    {
        [Fact]
       public void Given_APreviouslyLiveCellWithLessThanTwoLiveNeighbours_When_TheStateIsProcessed_Then_CellIsNotInCurrentState()
       {
           var stateManager = new StateManager();
           var world = new World(10, 10);
           var seeds = new List<Cell>()
           {
               new Cell(new Coordinates(2,5)),
               new Cell(new Coordinates(4,6))
           };
           var testCoordinate = new Cell(new Coordinates(2,5));
           
           stateManager.CurrentState = seeds;
           stateManager.RefreshStates();
           stateManager.ProcessWorldForCurrentState(world);
           
           foreach (var coordinate in stateManager.CurrentState)
           {
               coordinate.Should().NotBeEquivalentTo(testCoordinate);
           }
       }
       
        
        [Fact]
        public void Given_APreviouslyLiveCellWithMoreThanLiveThreeNeighbours_When_TheStateIsProcessed_Then_CellIsNotInCurrentState()
        {
            var stateManager = new StateManager();
            var world = new World(10, 10);
            var seeds = new List<Cell>()
            {
                new Cell(new Coordinates(2,4)),
                new Cell(new Coordinates(2,5)),
                new Cell(new Coordinates(2,6)),
                new Cell(new Coordinates(1,5)),
                new Cell(new Coordinates(1,6))
            };
            
            var testCoordinate = new Cell(new Coordinates(2, 5));
       
            stateManager.CurrentState = seeds;
            stateManager.RefreshStates();
            stateManager.ProcessWorldForCurrentState(world);
       
            foreach (var coordinate in stateManager.CurrentState)
            {
                coordinate.Should().NotBeEquivalentTo(testCoordinate);
            }
        }
        
        
        [Fact]
        public void Given_APreviouslyLiveCellWithTwoLiveNeighbours_When_TheStateIsProcessed_Then_CellIsInCurrentState()
        {
            var stateManager = new StateManager();
            var world = new World(10, 10);
            var seeds = new List<Cell>()
            {
                new Cell(new Coordinates(2,4)),
                new Cell(new Coordinates(2,5)),
                new Cell(new Coordinates(2,6)),
            };
       
            var testCoordinate = new Cell(new Coordinates(2, 5));
       
            stateManager.CurrentState = seeds;
            stateManager.ProcessWorldForCurrentState(world);
       
            stateManager.CurrentState.Should().ContainEquivalentOf(testCoordinate);
        }
        
        [Fact]
        public void Given_APreviouslyLiveCellWithThreeLiveNeighbours_When_TheStateIsProcessed_Then_CellIsInCurrentState()
        {
            var stateManager = new StateManager();
            var world = new World(10, 10);
            var seeds = new List<Cell>()
            {
                new Cell(new Coordinates(2,4)),
                new Cell(new Coordinates(2,5)),
                new Cell(new Coordinates(2,6)),
                new Cell(new Coordinates(1,5)),
            };
            
            var testCoordinate = new Cell(new Coordinates(2, 5));
       
            stateManager.CurrentState = seeds;
            stateManager.ProcessWorldForCurrentState(world);
       
            stateManager.CurrentState.Should().ContainEquivalentOf(testCoordinate);
        }
       
       [Fact]
        public void Given_APreviouslyDeadCellWithExactlyThreeLiveNeighbours_When_TheStateIsProcessed_Then_CellIsInCurrentState()
        {
            var stateManager = new StateManager();
            var cellManager = new CellManager();
            var world = new World(7, 7);
            var seeds = new List<Cell>()
            {
                new Cell(new Coordinates(2,4)),
                new Cell(new Coordinates(2,6)),
                new Cell(new Coordinates(1,5)),
            };
            
            var testCoordinate = new Cell(new Coordinates(2,5));
            stateManager.CurrentState = seeds;
            cellManager.AssignNeighbourProperties(testCoordinate, world, stateManager.CurrentState);
            stateManager.RefreshStates();
            stateManager.ProcessWorldForCurrentState(world);
       
            stateManager.CurrentState.Should().ContainEquivalentOf(testCoordinate);
        }
        
        [Fact]
        public void Given_APreviouslyDeadCellWithNoLiveNeighbours_When_TheStateIsProcessed_Then_CellIsNotInCurrentState()
        {
            var stateManager = new StateManager();
            var world = new World(10, 10);
            var seeds = new List<Cell>();
            
            var testCoordinate = new Cell(new Coordinates(7,5));
            stateManager.CurrentState = seeds;
            stateManager.RefreshStates();
            stateManager.ProcessWorldForCurrentState(world);
       
            stateManager.CurrentState.Should().NotContain(testCoordinate);
        }
        
        
    }
}