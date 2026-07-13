Game of Life Strings
The universe of the Game of Life is an infinite two-dimensional orthogonal grid of square cells, each of which is in one of two possible states, alive or dead. Every cell interacts with its eight neighbours, which are the cells that are horizontally, vertically, or diagonally adjacent. At each step in time, the following transitions occur:

- Any live cell with fewer than two live neighbours dies, as if caused by under-population.
- Any live cell with two or three live neighbours lives on to the next generation.
- Any live cell with more than three live neighbours dies, as if by overcrowding.
- Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.

Implement the method that calculates new generation of game of life. The method receives a string in the format "000_000_000" that represents the matrix NxM of 0's (dead cell) and 1's (living cell).

And returns a string in the same format "000_000_000" that represents equally sized array representing the next generation. Cells outside the array must be considered dead. Cells that would born out of the array boundaries should be ignored (universe never grows beyond the initial NxM grid).
Examples
Input: "000_111_000"
Output: 010_010_010
Input: "11"
Output: 00