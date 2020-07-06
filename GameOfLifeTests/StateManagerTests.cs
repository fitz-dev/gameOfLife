using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using GameOfLife;
using GameOfLife.Managers;
using GameOfLife.Models;
using Xunit;

namespace GameOfLifeTests
{
    public class StateManagerTests
    {
        [Fact]
        public void Given_StartingSeeds_When_WorldIsProcessed_SameNumberOfLiveCellsReturned()
        {
            var stateManager = new StateManager();
            var world = new World(5, 5);
            
            var seeds = new List<Cell>()
            {
                new Cell(new Coordinates(2,5)),
                new Cell(new Coordinates(4,5)),
                new Cell(new Coordinates(3,1)),
                new Cell(new Coordinates(2,1)),
            };

            stateManager.ConstructInitialState(world);

            
            var numberLiveCells = stateManager.CurrentState.Count(cell => cell.Live);
            
            Assert.Equal(4, numberLiveCells);
        }
        
        // [Fact]
        // public void Given_APreviousState_When_WorldIsProcessed_CurrentStateIsReturned()
        // {
        //     var stateManager = new StateManager();
        //     var world = new World(10, 10);
        //     
        //     var previousState = new List<Cell>()
        //     {
        //         new Cell(new Coordinates(2,5)),
        //         new Cell(new Coordinates(4,6))
        //     };
        //
        //     var testCoordinate = new Coordinates(2,5);
        //    
        //     stateManager.CurrentState = seeds;
        //     stateManager.RefreshStates();
        //     stateManager.ProcessWorldForCurrentState(world);
        //    
        //     foreach (var coordinate in stateManager.CurrentState)
        //     {
        //         coordinate.Should().NotBeEquivalentTo(testCoordinate);
        //     }
        // }
    }
}