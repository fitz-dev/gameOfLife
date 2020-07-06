using System.Collections.Generic;
using FluentAssertions;
using GameOfLife;
using GameOfLife.Managers;
using GameOfLife.Models;
using Xunit;

namespace GameOfLifeTests
{
    public class StateManagerTests
    {
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