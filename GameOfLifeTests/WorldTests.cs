using System;
using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class WorldTests
    {
        [Fact]
        public void Given_ANumberOfRowsAndColumns_When_WorldIsCreated_Then_CorrectArrayIsReturned()
        {
            var cellManager = new CellManager();
            var world = new World(8, 10);

            var worldSize = world.Grid.Length;
            
            Assert.Equal(80, worldSize);
        }
   }
}