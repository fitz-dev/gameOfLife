using System;
using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class CityTests
    {
        
        [Fact]
        public void Given_NeighbourThatIsToTheLeftEdgeOfTheCity_When_FindNeighboursIsCalled_Then_ProperIndexIsFound()
        {
            var world = World.CreateWorld(5, 5);
            var god = new God();
            
            var chosenCity = god.FetchCity(world, 2, 2);
            chosenCity.FindNeighbours(world);

            var leftNeighbour = new Tuple<int, int>(1,2);
            
            Assert.Equal(leftNeighbour, chosenCity.Neighbours["left"]);
        }
        
        [Fact]
        public void Given_NeighbourThatIsToTheRightOfTheCity_When_FindNeighboursIsCalled_Then_ProperIndexIsFound()
        {
            var world = World.CreateWorld(5, 5);
            var god = new God();
            
            var chosenCity = god.FetchCity(world, 2, 2);
            chosenCity.FindNeighbours(world);

            var leftNeighbour = new Tuple<int, int>(3,2);
            
            Assert.Equal(leftNeighbour, chosenCity.Neighbours["right"]);
        }
        
        [Fact]
        public void Given_NeighbourThatIsOffTheTopEdgeOfTheWorld_When_FindNeighboursIsCalled_Then_ProperIndexIsFound()
        {
            var world = World.CreateWorld(5, 5);
            var god = new God();
               
            var chosenCity = god.FetchCity(world, 2, 0);
            chosenCity.FindNeighbours(world);
        
            var topNeighbour = new Tuple<int, int>(2,4);
            
            Assert.Equal(topNeighbour, chosenCity.Neighbours["top"]);
        }
        
        [Fact]
        public void Given_NeighbourThatIsOffTheBottomEdgeOfTheWorld_When_FindNeighboursIsCalled_Then_ProperIndexIsFound()
        {
            var world = World.CreateWorld(5, 5);
            var god = new God();
            
            var chosenCity = god.FetchCity(world, 2, 4);
            chosenCity.FindNeighbours(world);
        
            var bottomNeighbour = new Tuple<int, int>(2,0);                   
            
            Assert.Equal(bottomNeighbour, chosenCity.Neighbours["bottom"]);
        }
        
        
        [Fact]
        public void Given_NeighbourThatIsOffTheRightEdgeOfTheWorld_When_FindNeighboursIsCalled_Then_ProperIndexIsFound()
        {
            var world = World.CreateWorld(5, 5);
            var god = new God();
            
            var chosenCity = god.FetchCity(world, 4, 2);
            chosenCity.FindNeighbours(world);
        
            var rightNeighbour = new Tuple<int, int>(0,2);
            
            Assert.Equal(rightNeighbour, chosenCity.Neighbours["right"]);
        }
        
        
        
        [Fact]
        public void Given_NeighbourThatIsOffTheLeftEdgeOfTheWorld_When_FindNeighboursIsCalled_Then_ProperIndexIsFound()
        {
            var world = World.CreateWorld(5, 5);
            var god = new God();
            
            var chosenCity = god.FetchCity(world, 0, 3);
            chosenCity.FindNeighbours(world);
        
            var leftNeighbour = new Tuple<int, int>(4,3);
            
            Assert.Equal(leftNeighbour, chosenCity.Neighbours["left"]);
        }
    }
}