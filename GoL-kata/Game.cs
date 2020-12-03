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
            
            for (int cellRow = 0; cellRow < _board.BoardHeight; cellRow++)
            {
                for (int cellColumn = 0; cellColumn < _board.BoardWidth; cellColumn++)
                {
                    int[] cellIndex = { cellRow, cellColumn };
                    
                    int aliveNeighbours = _board.CountLiveNeighbours(cellIndex);
                    bool currentState = _board.CellArray[cellRow, cellColumn].alive;

                    newBoard.CellArray[cellRow, cellColumn].UpdateCellStatus(aliveNeighbours, currentState);
                }
            }

            _iteration++;
            _board = newBoard;
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