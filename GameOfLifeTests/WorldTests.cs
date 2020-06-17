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
            var world = World.CreateWorld(8, 10);

            var worldSize = world.Length;
            
            Assert.Equal(80, worldSize);
        }
        
        [Fact]
        public void Given_ANumberOfStartingSeeds_When_SeedsAreAddedToWorld_Then_SameNumberAreReturnedInArray()
        {
            var world = World.CreateWorld(8, 10);
            
            
            var worldSize = world.Length;
            
            Assert.Equal(80, worldSize);
        }
    }
}