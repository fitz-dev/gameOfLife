using System;
using System.Linq;
using GameOfLife;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace GameOfLifeTests
{
    public class GodTests
    {
        [Fact]
        public void Given_ANumberOfStartingSeeds_When_SeedsAreAddedToWorld_Then_SameNumberOfLiveCitiesReturnedInArray()
        {
            var god = new God();
            var world = World.CreateWorld(8, 10);
            var numberOfLiveCities = 0;

            god.AddSeeds(world, 3,4);
            god.AddSeeds(world, 7,8);

            int rowLength = world.GetLength(0);
            int columnLength = world.GetLength(1);

            for (int xIndex = 0; xIndex < rowLength; xIndex++)
            {
                for (int yIndex = 0; yIndex < columnLength; yIndex++)
                {
                    if (world[xIndex, yIndex].Live)
                    {
                        numberOfLiveCities++;
                    }
                }
            }
            
            Assert.Equal(2, numberOfLiveCities);
        }
    }
}