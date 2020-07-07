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
        public void Given_AnEmptyWorld_When_InitialStateIsConstructed_Then_NoLiveCellsAreReturned()
        {
            var stateManager = new StateManager();
            var world = new World(5, 5);
            
            stateManager.ConstructInitialState(world);
            var numberLiveCells = stateManager.CurrentState.Count(cell => cell.Live);
            
            Assert.Equal(0, numberLiveCells);
        }
        
        [Fact]
        public void Given_StateThatHasBeenConstructed_When_AddingSeeds_Then_SameNumberOfLiveCellsReturned()
        {
            var stateManager = new StateManager();
            var world = new World(5, 5);
            stateManager.ConstructInitialState(world);
            
            var seeds = new List<Coordinates>()
            {
                new Coordinates(2,3),
                new Coordinates(4,2),
                new Coordinates(3,1),
                new Coordinates(2,1),
            };

            stateManager.AddCoordinates(seeds);
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
        //         new Coordinates(2,5),
        //         new Coordinates(4,6)
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