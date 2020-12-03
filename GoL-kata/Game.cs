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
            var newBoard = new Board(_board.BoardWidth - (_board.numOverflow * 2), _board.BoardHeight - (_board.numOverflow * 2));
            
            for (var cellRow = 0; cellRow < _board.BoardHeight; cellRow++)
            {
                for (var cellColumn = 0; cellColumn < _board.BoardWidth; cellColumn++)
                {
                    int[] cellIndex = { cellRow, cellColumn };
                    
                    var aliveNeighbours = _board.CountLiveNeighbours(cellIndex);
                    var currentState = _board.CellArray[cellRow, cellColumn].alive;

                    newBoard.CellArray[cellRow, cellColumn].UpdateCellStatus(aliveNeighbours, currentState);
                }
            }

            _iteration++;
            _board = newBoard;
        }

        public bool NoLiveCells()
        {
            int count = 0;
            
            // TODO: use "cell.active" to sort this out! make overflow cells "inactive" cells
            for (int i = _board.numOverflow; i < _board.BoardHeight - _board.numOverflow; i++)
            {
                for (int j = _board.numOverflow; j < _board.BoardWidth - _board.numOverflow; j++)
                {
                    if (_board.CellArray[i, j].alive)
                    {
                        count++;
                    }
                }
            }
            
            if (count == 0)
            {
                return true;
            }

            return false;
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