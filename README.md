# Conway's Game of Life

Conway's Game of Life is a 'zero player' game devised by John Horton Conway in 1970. Cells are placed on a grid / world and depending on four rules, will live or die. The player setups up the initial state of the game and then watches how it evolves. 

# How To Play

  - To run the game open the Project folder and navigate to `GameOfLife/GameOfLife` in the terminal and type `dotnet run` or open in your IDE and run the program there. 
  - You will first be asked to enter the dimensions of your world and then asked for your initial seed inputs. You can enter as many as you like in the format of number--comma--number like this: `3,4` `16,23` `45,2` etc. Once entered, hit `return` to enter the next one. 
  - (The program assumes that there is a 'perfect' user when inputting seeds that will enter the format correctly).
  - Once you've finished entering your seeds, type `x` and hit enter. 
  - Sit back or lean forward in anticipation and watch the patterns your seeds create. 
  - The program will keep running whilst there are live cells. If you want to exit the program hit `ctrl + c` in the terminal or stop your IDE.  


# Rules

The universe of the Game of Life is a two-dimensional orthogonal grid of square cells, each of which is in one of two possible states, live or dead. 

- Every cell interacts with its eight neighbors, which are the cells that are directly horizontally, vertically, or diagonally adjacent.
- If the cell is on the fringe of the world, it's neighbour will be wrapped around on the opposite side of the world, as if it is spherical. For example, on a 5x5 world, the Top Neighbour for `2,0` would be `2,4`. 
 
Once the inital seeds for the cells are input by the user, time passes in Ticks. In each tick, the current generation of cells is analysed to see if the cells will live or die in the next tick. The cells live and die simultaneously and they are analysed based on four rules: 
- Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.
- Any live cell with more than three live neighbours dies, as if by overcrowding.
- Any live cell with two or three live neighbours lives on to the next generation.
- Any dead cell with exactly three live neighbours becomes a live cell.

# Kata Requirmenets:
The requirments of this kata were to be able to: 
- Visualize the game in the console
- Be able to define how big the world/grid is (10x10, 50x80, etc.)
- Be able to set the inital state of the world
