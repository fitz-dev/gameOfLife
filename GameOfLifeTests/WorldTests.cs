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
            var god = new God();
            var world = new World(god, 8, 10);

            var worldSize = world.Grid.Length;
            
            Assert.Equal(80, worldSize);
        }
   }
}