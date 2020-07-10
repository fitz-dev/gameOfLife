using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using GameOfLife.Logic;
using GameOfLife.Models;
using Xunit;

namespace GameOfLifeTests
{
    public class PatternTests
    {
        [Fact]
        public void Given_SeedsThatResultInAUnmovingShape_When_OneTickHasPassed_Then_SameCoordinatesAreReturned()
        {
            var generations = new Generations();
            var world = new World(6, 6);
            var seeds = new List<Cell>()
            {
                new Cell(new Coordinates(2,1)),
                new Cell(new Coordinates(3,1)),
                new Cell(new Coordinates(1,2)),
                new Cell(new Coordinates(4,2)),
                new Cell(new Coordinates(2,3)),
                new Cell(new Coordinates(3,3)),
            };
            
            ProgressTicks(1, world, seeds, generations);
            var currentGenerationCoordinates = ExtractCurrentGenerationCoordinates(generations);

            currentGenerationCoordinates.Should().BeEquivalentTo(seeds);
        }
        
        [Fact]
        public void Given_SeedsForARepeatingPatternCalledToad_When_TwoTicksHavePassed_Then_ExpectedCoordinatesAreReturned()
        {
            var generations = new Generations();
            var world = new World(6, 6);
            var seeds = new List<Cell>()
            {
                new Cell(new Coordinates(2,2)),
                new Cell(new Coordinates(3,2)),
                new Cell(new Coordinates(4,2)),
                new Cell(new Coordinates(1,3)),
                new Cell(new Coordinates(2,3)),
                new Cell(new Coordinates(3,3)),
            };

            ProgressTicks(2, world, seeds, generations);
            var currentCoordinates = ExtractCurrentGenerationCoordinates(generations); 
            
            currentCoordinates.Should().BeEquivalentTo(seeds);
        }

        
        [Fact]
        public void Given_SeedsForARepeatingPatternCalledToad_When_OneTickHasPassed_Then_ExpectedCoordinatesAreReturned()
        {
            var generations = new Generations();
            var world = new World(6, 6);
            var seeds = new List<Cell>()
            {
                new Cell(new Coordinates(2,2)),
                new Cell(new Coordinates(3,2)),
                new Cell(new Coordinates(4,2)),
                new Cell(new Coordinates(1,3)),
                new Cell(new Coordinates(2,3)),
                new Cell(new Coordinates(3,3)),
            };
           
            var expectedSeedCoordinates = new List<Cell>()
            {
                new Cell(new Coordinates(3,1)),
                new Cell(new Coordinates(1,2)),
                new Cell(new Coordinates(4,2)),
                new Cell(new Coordinates(1,3)),
                new Cell(new Coordinates(4,3)),
                new Cell(new Coordinates(2,4))
            };

            ProgressTicks(1, world, seeds, generations);
        
            var currentCoordinates = ExtractCurrentGenerationCoordinates(generations); 
            
            currentCoordinates.Should().BeEquivalentTo(expectedSeedCoordinates);
        }

        [Fact]
        public void Given_SeedsForARepeatingPatternCalledBeacon_When_OneTickHasPassed_Then_ExpectedCoordinatesAreReturned()
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
            
            var expectedSeedCoordinates = new List<Cell>()
            {
                new Cell(new Coordinates(1,1)),
                new Cell(new Coordinates(2,1)),
                new Cell(new Coordinates(1,2)),
                new Cell(new Coordinates(4,3)),
                new Cell(new Coordinates(3,4)),
                new Cell(new Coordinates(4,4)),
            };
            
            ProgressTicks(1, world, seeds, generations);
            var currentCoordinates = ExtractCurrentGenerationCoordinates(generations); 
        
            currentCoordinates.Should().BeEquivalentTo(expectedSeedCoordinates);
        }

        [Fact]
        public void Given_SeedsForARepeatingPatternCalledBeacon_When_TwoTicksHavePassed_Then_ExpectedCoordinatesAreReturned()
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
            
            ProgressTicks(2, world, seeds, generations);
            var currentCoordinates = ExtractCurrentGenerationCoordinates(generations); 

            currentCoordinates.Should().BeEquivalentTo(seeds);
        }
        
        [Fact]
        public void Given_SeedsForARepeatingPatternCalledPulsar_When_ThreeTicksHavePassed_Then_ExpectedCoordinatesAreReturned()
        {
            var generations = new Generations();
            var world = new World(20, 20);
            var seeds = new List<Cell>()
            {
                new Cell(new Coordinates(4,2)),
                new Cell(new Coordinates(5,2)),
                new Cell(new Coordinates(6,2)),
                new Cell(new Coordinates(10,2)),
                new Cell(new Coordinates(11,2)),
                new Cell(new Coordinates(12,2)),
                new Cell(new Coordinates(2,4)),
                new Cell(new Coordinates(7,4)),
                new Cell(new Coordinates(9,4)),
                new Cell(new Coordinates(14,4)),
                new Cell(new Coordinates(2,5)),
                new Cell(new Coordinates(7,5)),
                new Cell(new Coordinates(9,5)),
                new Cell(new Coordinates(14,5)),
                new Cell(new Coordinates(2,6)),
                new Cell(new Coordinates(7,6)),
                new Cell(new Coordinates(9,6)),
                new Cell(new Coordinates(14,6)),
                new Cell(new Coordinates(4,7)),
                new Cell(new Coordinates(5,7)),
                new Cell(new Coordinates(6,7)),
                new Cell(new Coordinates(10,7)),
                new Cell(new Coordinates(11,7)),
                new Cell(new Coordinates(12,7)),
                new Cell(new Coordinates(4,9)),
                new Cell(new Coordinates(5,9)),
                new Cell(new Coordinates(6,9)),
                new Cell(new Coordinates(10,9)),
                new Cell(new Coordinates(11,9)),
                new Cell(new Coordinates(12,9)),
                new Cell(new Coordinates(2,10)),
                new Cell(new Coordinates(7,10)),
                new Cell(new Coordinates(9,10)),
                new Cell(new Coordinates(14,10)),
                new Cell(new Coordinates(2,11)),
                new Cell(new Coordinates(7,11)),
                new Cell(new Coordinates(9,11)),
                new Cell(new Coordinates(14,11)),
                new Cell(new Coordinates(2,12)),
                new Cell(new Coordinates(7,12)),
                new Cell(new Coordinates(9,12)),
                new Cell(new Coordinates(14,12)),
                new Cell(new Coordinates(4,14)),
                new Cell(new Coordinates(5,14)),
                new Cell(new Coordinates(6,14)),
                new Cell(new Coordinates(10,14)),
                new Cell(new Coordinates(11,14)),
                new Cell(new Coordinates(12,14)),
            };
            
            ProgressTicks(3, world, seeds, generations);
            var currentCoordinates = ExtractCurrentGenerationCoordinates(generations); 
            
            currentCoordinates.Should().BeEquivalentTo(seeds);
        }

        private void ProgressTicks(int numberOfTicks, World world, List<Cell> seeds, Generations generations)
        {
            generations.ConstructGenerations(world);
            generations.AddSeedsForNextGeneration(seeds);
            
            for (int i = 0; i <= numberOfTicks; i++)
            {
                generations.UpdateGenerationsForNextTick();
                generations.FindLiveNeighboursForAllCells();
                generations.DetermineIfCellsWillLiveInNextGeneration();
            }
        }
        
        private static List<Cell> ExtractCurrentGenerationCoordinates(Generations generations)
        {
            return generations.CurrentGeneration
                .Where(cell => cell.Live)
                .Select(cell => new Cell(cell.Position))
                .ToList();
        }
    }
}