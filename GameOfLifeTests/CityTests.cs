// using System;
// using GameOfLife;
// using Xunit;
//
// namespace GameOfLifeTests
// {
//     public class CityTests
//     {
//         [Fact]
//         public void Given_ANewWorld_When_ANewSeedIsAdded_Then_SeedIsLive()
//         {
//             var god = new God();
//             var world = new World(god, 5, 5);
//             
//             god.AddOriginalSeeds(world, 2, 2);
//             var chosenCity =  god.FetchCity(world, 2, 2);
//
//             Assert.True(chosenCity.Live);
//         }
//
//         [Fact]
//         public void Given_NeighbourThatIsToTheLeftOfTheCity_When_FindNeighboursIsCalled_Then_ProperIndexIsFound()
//         {
//             var god = new God();
//             var world = new World(god, 5, 5);
//             
//             var chosenCity = god.FetchCity(world, 2, 2);
//
//             var leftNeighbour = new Tuple<int, int>(1,2);
//             
//             Assert.Equal(leftNeighbour, chosenCity.Neighbours["left"]);
//         }
//         
//         [Fact]
//         public void Given_NeighbourThatIsToTheRightOfTheCity_When_FindNeighboursIsCalled_Then_ProperIndexIsFound()
//         {
//             var god = new God();
//             var world = new World(god, 5, 5);
//             
//             var chosenCity = god.FetchCity(world, 2, 2);
//
//             var leftNeighbour = new Tuple<int, int>(3,2);
//             
//             Assert.Equal(leftNeighbour, chosenCity.Neighbours["right"]);
//         }
//         
//         [Fact]
//         public void Given_NeighbourThatIsOffTheTopEdgeOfTheWorld_When_FindNeighboursIsCalled_Then_ProperIndexIsFound()
//         {
//             var god = new God();
//             var world = new World(god, 5, 5);
//                
//             var chosenCity = god.FetchCity(world, 2, 0);
//         
//             var topNeighbour = new Tuple<int, int>(2,4);
//             
//             Assert.Equal(topNeighbour, chosenCity.Neighbours["top"]);
//         }
//         
//         [Fact]
//         public void Given_NeighbourThatIsOffTheBottomEdgeOfTheWorld_When_FindNeighboursIsCalled_Then_ProperIndexIsFound()
//         {
//             var god = new God();
//             var world = new World(god, 5, 5);
//             
//             var chosenCity = god.FetchCity(world, 2, 4);
//         
//             var bottomNeighbour = new Tuple<int, int>(2,0);                   
//             
//             Assert.Equal(bottomNeighbour, chosenCity.Neighbours["bottom"]);
//         }
//         
//         
//         [Fact]
//         public void Given_NeighbourThatIsOffTheRightEdgeOfTheWorld_When_FindNeighboursIsCalled_Then_ProperIndexIsFound()
//         {
//             var god = new God();
//             var world = new World(god, 5, 5);
//             
//             var chosenCity = god.FetchCity(world, 4, 2);
//         
//             var rightNeighbour = new Tuple<int, int>(0,2);
//             
//             Assert.Equal(rightNeighbour, chosenCity.Neighbours["right"]);
//         }
//         
//         [Fact]
//         public void Given_NeighbourThatIsOffTheLeftEdgeOfTheWorld_When_FindNeighboursIsCalled_Then_ProperIndexIsFound()
//         {
//             var god = new God();
//             var world = new World(god, 5, 5);
//             
//             var chosenCity = god.FetchCity(world, 0, 3);
//         
//             var leftNeighbour = new Tuple<int, int>(4,3);
//             
//             Assert.Equal(leftNeighbour, chosenCity.Neighbours["left"]);
//         }
//         
//         [Fact]
//         public void Given_ACityThatHasTwoLiveNeighbours_When_FetchingNumberOfLiveNeighbours_Then_IntegerIsReturned()
//         {
//             var god = new God();
//             var world = new World(god, 10, 10);
//             god.AddOriginalSeeds(world, 0, 4);
//             god.AddOriginalSeeds(world, 0, 5);
//             god.AddOriginalSeeds(world, 0, 6);
//             
//             var chosenCity = god.FetchCity(world, 0, 5);
//             chosenCity.GetNumberOfLiveNeighbours(world);
//         
//             Assert.Equal(2, chosenCity.LiveNeighbours);
//         }
//           
//         [Fact]
//         public void Given_ACityThatHasNoLiveNeighbours_When_FetchingNumberOfLiveNeighbours_Then_IntegerIsReturned()
//         {
//             var god = new God();
//             var world = new World(god, 10, 10);
//             
//             var chosenCity = god.FetchCity(world, 0, 5);
//             chosenCity.GetNumberOfLiveNeighbours(world);
//         
//             Assert.Equal(0, chosenCity.LiveNeighbours);
//         }
//     }
// }