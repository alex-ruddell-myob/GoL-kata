using System;
using System.Threading;

namespace GoL_kata
{
    public class Game
    {
        private Board _board;
        private int _iteration = 0;

        public void Iterate()
        {
            Board newBoard = new Board(_board.BoardWidth, _board.BoardHeight);
            
            // Game logic here
            for (int i = 0; i < _board.BoardHeight; i++)
            {
                for (int j = 0; j < _board.BoardWidth; j++)
                {
                    Cell cell = _board.CellArray[i, j];

                    int aliveNeighbours = CountLiveNeighbours(cell, _board.CellArray, _board.BoardHeight, _board.BoardWidth);

                    newBoard.CellArray[i, j] = UpdateCellStatus(_board.CellArray[i, j], aliveNeighbours);
                }
            }

            _iteration++;
            _board = newBoard;
        }

        public static int CountLiveNeighbours(Cell cell, Cell[,] cellArray, int boardHeight, int boardWidth)
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

        public static Cell UpdateCellStatus(Cell cell, int aliveNeighbours)
        {
            Cell newCell = new Cell();
            newCell.row = cell.row;
            newCell.column = cell.column;
            
            if (cell.alive)
            {
                if (aliveNeighbours < 2 || aliveNeighbours > 3)
                {
                    newCell.alive = false;
                }
                else
                {
                    newCell.alive = true;
                }
            }
            else
            {
                if (aliveNeighbours == 3)
                {
                    newCell.alive = true;
                }
            }

            return newCell;
        }

        private static int[] ValidateCellRange(int row, int column, int boardHeight, int boardWidth)
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

        public void Print()
        {
            // Delay to better visualise the board
            Thread.Sleep(1000);
            ConsoleIO.PrintGameBoard(_board, _iteration);
        }

        public Game(InputData inputData)
        {
            _board = new Board(inputData);
        }
    }
}