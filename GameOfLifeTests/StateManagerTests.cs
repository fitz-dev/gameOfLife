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
        public void Given_AnEmptyWorld_When_CurrentStateIsConstructed_Then_NoLiveCellsAreReturned()
        {
            var stateManager = new StateManager();
            var world = new World(5, 5);
            
            stateManager.ConstructInitialStateFor(stateManager.CurrentState, world);
            var numberLiveCells = stateManager.CurrentState.Count(cell => cell.Live);
            
            Assert.Equal(0, numberLiveCells);
        }
        
        [Fact]
        public void Given_StateThatHasBeenConstructed_When_AddingSeeds_Then_SameNumberOfLiveCellsReturned()
        {
            var stateManager = new StateManager();
            var world = new World(5, 5);
            stateManager.ConstructInitialStateFor(stateManager.NextState, world);
            
            var seeds = new List<Coordinates>()
            {
                new Coordinates(2,3),
                new Coordinates(4,2),
                new Coordinates(3,1),
                new Coordinates(2,1),
            };

            stateManager.AddCoordinatesForNextState(seeds);
            var numberLiveCells = stateManager.NextState.Count(cell => cell.Live);
            
            Assert.Equal(4, numberLiveCells);
        }
        
        [Fact]
        public void Given_EmptyCurrentState_When_NextStateIsAdded_Then_LiveCellsAreFound()
        {
            var stateManager = new StateManager();
            var world = new World(5, 5);
            var seeds = new List<Coordinates>()
            {
                new Coordinates(2,3),
                new Coordinates(4,2),
                new Coordinates(3,1),
                new Coordinates(2,1),
            };

            stateManager.ConstructInitialStateFor(stateManager.CurrentState, world);
            stateManager.ConstructInitialStateFor(stateManager.NextState, world);
            
            stateManager.AddCoordinatesForNextState(seeds);
            
            stateManager.RefreshStatesForNextTick();
            
            var numberLiveCells = stateManager.CurrentState.Count(cell => cell.Live);
            
            Assert.Equal(4, numberLiveCells);
        }
        
        [Fact]
        public void Given_PopulatedNextState_When_StatesAreReset_Then_NoLiveCellsAreFound()
        {
            var stateManager = new StateManager();
            var world = new World(5, 5);
            var seeds = new List<Coordinates>()
            {
                new Coordinates(2,3),
                new Coordinates(4,2),
                new Coordinates(3,1),
                new Coordinates(2,1),
            };

            stateManager.ConstructInitialStateFor(stateManager.CurrentState, world);
            stateManager.ConstructInitialStateFor(stateManager.NextState, world);
            stateManager.AddCoordinatesForNextState(seeds);
            
            stateManager.RefreshStatesForNextTick();
            
            var numberLiveCells = stateManager.NextState.Count(cell => cell.Live);
            
            Assert.Equal(0, numberLiveCells);
        }
        
        [Fact]
        public void Given_PopulatedCurrentState_When_LiveNeighboursAreSetForWholeState_Then_LifeRulesAreApplied()
        {
            var stateManager = new StateManager();
            var world = new World(5, 5);
            var seeds = new List<Coordinates>()
            {
                new Coordinates(1,1),
                new Coordinates(1,2),
                new Coordinates(2,2),
                new Coordinates(2,2),
                new Coordinates(3,3),
                new Coordinates(3,4),
                new Coordinates(4,3),
                new Coordinates(4,4),
            };

            stateManager.ConstructInitialStateFor(stateManager.CurrentState, world);
            stateManager.ConstructInitialStateFor(stateManager.NextState, world);
            stateManager.AddCoordinatesForNextState(seeds);
            
            stateManager.RefreshStatesForNextTick();
            stateManager.FindLiveNeighboursForAllCells();
            
            stateManager.DetermineCellsToLiveInNextState();
            
            //todo: nextState is pulling in live cells when it should have been reset, so returning the wrong number of expected LiveCells. 
            
            var numberLiveCells = stateManager.NextState.Count(cell => cell.Live);
            
            Assert.Equal(6, numberLiveCells);
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