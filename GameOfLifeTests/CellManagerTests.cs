using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using GameOfLife;
using GameOfLife.Logic;
using GameOfLife.Managers;
using GameOfLife.Models;
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
            testCell.NumLiveNeighbours = cellManager.SetNumberOfLiveNeighbours(seeds, testCell);
            
            Assert.Equal(2, testCell.NumLiveNeighbours);
        }
          
        [Fact]
        public void Given_ACellThatHasNoLiveNeighbours_When_FetchingNumberOfLiveNeighbours_Then_IntegerIsReturned()
       {
           var cellManager = new CellManager();
           var world = new World(10, 10);
           var seeds = new List<Cell>();
                       
           var testCell = new Cell(new Coordinates(0, 5));
           testCell.Neighbours = Neighbours.SetNeighbours(testCell, world);
            
           cellManager.SetNumberOfLiveNeighbours(seeds, testCell);

           Assert.Equal(0, testCell.NumLiveNeighbours);
       }
    }
}