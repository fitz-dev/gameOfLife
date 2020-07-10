using System.Collections.Generic;
using System.Linq;
using GameOfLife.Logic;
using GameOfLife.Models;
using Xunit;

namespace GameOfLifeTests
{
    public class GameTests
    {
        [Fact]
        public void Given_ACellThatHasTwoLiveNeighbours_When_FetchingNumberOfLiveNeighbours_Then_IntegerIsReturned()
        {
            var world = new World(10, 10);
            var seeds = new List<Cell>()
            {
                new Cell(new Coordinates(0,4))
                {
                    Live = true, 
                    Neighbours = {}, 
                    Position = {}, 
                    NumLiveNeighbours = 0
                },
                new Cell(new Coordinates(0,6))
                {
                    Live = true, 
                    Neighbours = {}, 
                    Position = {}, 
                    NumLiveNeighbours = 0
                },
            };
            var testCell = new Cell(new Coordinates(0, 5));
            
            testCell.Neighbours = Neighbours.SetNeighbours(testCell, world);
            testCell.NumLiveNeighbours = Neighbours.SetNumberOfLiveNeighbours(seeds, testCell);
            
            Assert.Equal(2, testCell.NumLiveNeighbours);
        }
          
        [Fact]
        public void Given_ACellThatHasNoLiveNeighbours_When_FetchingNumberOfLiveNeighbours_Then_IntegerIsReturned()
        {
            var world = new World(10, 10);
            var seeds = new List<Cell>();
                       
            var testCell = new Cell(new Coordinates(0, 5));
            testCell.Neighbours = Neighbours.SetNeighbours(testCell, world);
            testCell.NumLiveNeighbours = Neighbours.SetNumberOfLiveNeighbours(seeds, testCell);

            Assert.Equal(0, testCell.NumLiveNeighbours);
        }
        [Fact]
        public void Given_AnEmptyWorld_When_CurrentGenerationIsConstructed_Then_NoLiveCellsAreReturned()
        {
            var generations = new Generations();
            var world = new World(5, 5);
            
            generations.ConstructGenerations(world);
            var numberLiveCells = generations.CurrentGeneration.Count(cell => cell.Live);
            
            Assert.Equal(0, numberLiveCells);
        }
        
        [Fact]
        public void Given_AnEmptyNextGeneration_When_AddingSeedsToNextGeneration_Then_SameNumberOfLiveCellsAreReturned()
        {
            var generations = new Generations();
            var world = new World(5, 5);
            generations.ConstructGenerations(world);
            
            var seeds = new List<Cell>()
            {
                new Cell(new Coordinates(2,3)),
                new Cell(new Coordinates(4,2)),
                new Cell(new Coordinates(3,1)),
                new Cell(new Coordinates(2,1)),
            };

            generations.AddSeedsForNextGeneration(seeds);
            var numberLiveCells = generations.NextGeneration.Count(cell => cell.Live);
            
            Assert.Equal(4, numberLiveCells);
        }
        
        [Fact]
        public void Given_AnEmptyCurrentGenerationAndPopulatedNextGeneration_When_GenerationsAreUpdated_Then_LiveCellsAreFoundInCurrentGeneration()
        {
            var generations = new Generations();
            var world = new World(5, 5);
            var seeds = new List<Cell>()
            {
                new Cell(new Coordinates(2,3)),
                new Cell(new Coordinates(4,2)),
                new Cell(new Coordinates(3,1)),
                new Cell(new Coordinates(2,1)),
            };

            generations.ConstructGenerations(world);
            generations.AddSeedsForNextGeneration(seeds);
            generations.UpdateGenerations();
            
            var numberLiveCells = generations.CurrentGeneration.Count(cell => cell.Live);
            
            Assert.Equal(4, numberLiveCells);
        }
        
        [Fact]
        public void Given_PopulatedNextGeneration_When_GenerationsAreUpdated_Then_NoLiveCellsAreFoundInNextGeneration()
        {
            var generations = new Generations();
            var world = new World(5, 5);
            var seeds = new List<Cell>()
            {
                new Cell(new Coordinates(2,3)),
                new Cell(new Coordinates(4,2)),
                new Cell(new Coordinates(3,1)),
                new Cell(new Coordinates(2,1)),
            };

            generations.ConstructGenerations(world);
            generations.AddSeedsForNextGeneration(seeds);
            
            generations.UpdateGenerations();
            
            var numberLiveCells = generations.NextGeneration.Count(cell => cell.Live);
            
            Assert.Equal(0, numberLiveCells);
        }
        
        [Fact]
        public void Given_NextGenerationThatHasBeenPopulated_When_GenerationsAreUpdated_Then_CurrentGenerationIsPopulated()
        {
            var generations = new Generations();
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

            generations.ConstructGenerations(world);
            
            generations.AddSeedsForNextGeneration(seeds);
            generations.UpdateGenerations();
            generations.FindLiveNeighboursForAllCells();
            generations.DetermineIfCellsWillLiveInNextGeneration();
            generations.UpdateGenerations();
            
            var numberLiveCells = generations.CurrentGeneration.Count(cell => cell.Live);
            
            Assert.Equal(6, numberLiveCells);
        }
    }
}