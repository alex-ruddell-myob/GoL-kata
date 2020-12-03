using System;
using System.Data;

namespace GoL_kata
{
    public class Board
    {
        public int BoardHeight;
        public int BoardWidth;
        private int _seedHeight;
        private int _seedWidth;
        private string[] _seedString;

        public Cell[,] CellArray;

        private void InitialiseCellArray()
        {
            CellArray = new Cell[BoardHeight, BoardWidth];
            
            for (int row = 0; row < BoardHeight; row++)
            {
                for (int column = 0; column < BoardWidth; column++)
                {
                    CellArray[row, column] = new Cell(row, column, false);
                }
            }
            
        }

        private void PlantSeed()
        {
            int midHeight = BoardHeight / 2;
            int midWidth = BoardWidth / 2;

            int seedStartRow = midHeight - _seedHeight / 2;
            int seedStartColumn = midWidth - _seedWidth / 2;

            for (int i = 0; i < _seedHeight; i++)
            {
                for (int j = 0; j < _seedWidth; j++)
                {
                    if (_seedString[i][j] == 'X')
                    {
                        CellArray[seedStartRow + i, seedStartColumn + j].alive = true;
                    }
                }
            }
        }
        
        public int CountLiveNeighbours(int[] cellIndex)
        {
            int currentRow = cellIndex[0];
            int currentColumn = cellIndex[1];
            
            Cell currentCell = CellArray[currentRow, currentColumn];
            int aliveCount = 0;
            
            for (int i = currentCell.row - 1; i <= currentCell.row + 1; i++)
            {
                for (int j = currentCell.column - 1; j <= currentCell.column + 1; j++)
                {
                    int[] testingCellIndex = {i, j};
                    
                    if (CellExists(testingCellIndex))
                    {
                        Cell testingCell = CellArray[i, j];
                        if (!Equals(currentCell, testingCell))
                        {
                            if (CellArray[i, j].alive)
                            {
                                aliveCount++;
                            }
                        }
                    }
                }
            }

            return aliveCount;
        }

        private bool CellExists(int[] cellIndex)
        {
            int row = cellIndex[0];
            int column = cellIndex[1];
            
            if (row == BoardHeight || row == -1 || column == BoardWidth || column == -1)
            {
                return false;
            }

            return true;
        }

        private int[] ValidateCellRange(int row, int column)
        {
            var indices = new int[2] {row, column};

            // If boardHeight = 100, cell rows range from 0 to 99
            if (row == BoardHeight)
            {
                indices[0] = 0;
            }

            if (row == -1)
            {
                indices[0] = BoardHeight - 1;
            }

            if (column == BoardWidth)
            {
                indices[1] = 0;
            }

            if (column == -1)
            {
                indices[1] = BoardWidth - 1;
            }

            return indices;
        }
        
        // CONSTRUCTORS
        public Board(int width, int height)
        {
            BoardHeight = height;
            BoardWidth = width;
            
            InitialiseCellArray();

        }
        
        public Board(InputData input)
        {
            BoardHeight = input.boardHeight;
            BoardWidth = input.boardWidth;
            _seedHeight = input.seedHeight;
            _seedWidth = input.seedWidth;
            _seedString = input.seedString;
            
            InitialiseCellArray();
            PlantSeed();
        }
    }
}