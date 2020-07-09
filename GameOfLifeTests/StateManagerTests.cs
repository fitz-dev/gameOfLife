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
        public void Given_AnEmptyNextState_When_AddingSeedsToNextState_Then_SameNumberOfLiveCellsAreReturned()
        {
            var stateManager = new StateManager();
            var world = new World(5, 5);
            stateManager.ConstructInitialStateFor(stateManager.NextState, world);
            
            var seeds = new List<Cell>()
            {
                new Cell(new Coordinates(2,3)),
                new Cell(new Coordinates(4,2)),
                new Cell(new Coordinates(3,1)),
                new Cell(new Coordinates(2,1)),
            };

            stateManager.AddSeedsForNextState(seeds);
            var numberLiveCells = stateManager.NextState.Count(cell => cell.Live);
            
            Assert.Equal(4, numberLiveCells);
        }
        
        [Fact]
        public void Given_AnEmptyCurrentStateAndPopulatedNextState_When_StatesAreUpdated_Then_LiveCellsAreFoundInCurrentState()
        {
            var stateManager = new StateManager();
            var world = new World(5, 5);
            var seeds = new List<Cell>()
            {
                new Cell(new Coordinates(2,3)),
                new Cell(new Coordinates(4,2)),
                new Cell(new Coordinates(3,1)),
                new Cell(new Coordinates(2,1)),
            };

            stateManager.ConstructInitialStateFor(stateManager.CurrentState, world);
            stateManager.ConstructInitialStateFor(stateManager.NextState, world);
            stateManager.AddSeedsForNextState(seeds);
            stateManager.UpdateStatesForCurrentTick();
            
            var numberLiveCells = stateManager.CurrentState.Count(cell => cell.Live);
            
            Assert.Equal(4, numberLiveCells);
        }
        
        [Fact]
        public void Given_PopulatedNextState_When_StatesAreUpdated_Then_NoLiveCellsAreFoundInNextState()
        {
            var stateManager = new StateManager();
            var world = new World(5, 5);
            var seeds = new List<Cell>()
            {
                new Cell(new Coordinates(2,3)),
                new Cell(new Coordinates(4,2)),
                new Cell(new Coordinates(3,1)),
                new Cell(new Coordinates(2,1)),
            };

            stateManager.ConstructInitialStateFor(stateManager.CurrentState, world);
            stateManager.ConstructInitialStateFor(stateManager.NextState, world);
            stateManager.AddSeedsForNextState(seeds);
            
            stateManager.UpdateStatesForCurrentTick();
            
            var numberLiveCells = stateManager.NextState.Count(cell => cell.Live);
            
            Assert.Equal(0, numberLiveCells);
        }
        
        [Fact]
        public void Given_NextStateThatHasBeenPopulated_When_StatesAreUpdated_Then_CurrentStateIsPopulated()
        {
            var stateManager = new StateManager();
            var world = new World(6, 6);
            var seeds = new List<Cell>()
            {
                new Cell(new Coordinates(1,1)),
                new Cell(new Coordinates(2,1)),
                new Cell(new Coordinates(1,2)),
                new Cell(new Coordinates(2,2)),
                new Cell(new Coordinates(3,3)),
                new Cell(new Coordinates(4,3)),
                new Cell(new Coordinates(3,4)),
                new Cell(new Coordinates(4,4)),
            };

            stateManager.ConstructInitialStateFor(stateManager.CurrentState, world);
            stateManager.ConstructInitialStateFor(stateManager.NextState, world);
            
            stateManager.AddSeedsForNextState(seeds);
            stateManager.UpdateStatesForCurrentTick();
            stateManager.FindLiveNeighboursForAllCells();
            stateManager.DetermineCellsToLiveInNextState();
            
            stateManager.UpdateStatesForCurrentTick();
            
            var numberLiveCells = stateManager.CurrentState.Count(cell => cell.Live);
            
            Assert.Equal(6, numberLiveCells);
        }
    }
}