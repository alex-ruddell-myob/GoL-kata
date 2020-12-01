using System;

namespace GoL_kata
{
    class Game
    {

        public static Board Iterate(Board board)
        {
            Board newBoard = board;
            
            // Game logic here
            for (int i = 0; i < board.BoardHeight; i++)
            {
                for (int j = 0; j < board.BoardWidth; j++)
                {
                    Cell cell = board.CellArray[i, j];
                    int aliveNeighbours = CountLiveNeighbours(cell, board.CellArray, board.BoardHeight, board.BoardWidth);
                
                    if (cell.alive)
                    {
                        if (aliveNeighbours < 2 || aliveNeighbours > 3)
                        {
                            cell.alive = false;
                        }
                    }
                    else
                    {
                        if (aliveNeighbours == 3)
                        {
                            cell.alive = true;
                        }
                    }
                    
                    // Update cell
                    newBoard.CellArray[i, j] = cell;
                }
            }
            
            return newBoard;
        }

        private static int CountLiveNeighbours(Cell cell, Cell[,] cellArray, int boardHeight, int boardWidth)
        {
            int aliveCount = 0;
            
            for (int i = cell.row - 1; i <= cell.row + 1; i++)
            {
                for (int j = cell.column - 1; j <= cell.column + 1; j++)
                {
                    // Overflow to either side of the board.
                    var indices = ValidateCellRange(i, j, boardHeight, boardWidth);
                    int row = indices[0];
                    int col = indices[1];
                    
                    if (!(Equals(cell, cellArray[row, col])))
                    {
                        if (cellArray[row, col].alive)
                        {
                            aliveCount++;
                        }
                    }
                }
            }

            return aliveCount;
        }

        public static int[] ValidateCellRange(int row, int column, int boardHeight, int boardWidth)
        {
            var indices = new int[2] {row, column};

            // If boardHeight = 100, cell rows range from 0 to 99
            if (row == boardHeight)
            {
                indices[0] = 0;
            }

            if (row == -1)
            {
                indices[0] = boardHeight - 1;
            }

            if (column == boardWidth)
            {
                indices[1] = 0;
            }

            if (column == -1)
            {
                indices[1] = boardWidth - 1;
            }

            return indices;
        }
    }
}