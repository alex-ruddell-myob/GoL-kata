using System;

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

            for (int i = 0; i < BoardHeight; i++)
            {
                for (int j = 0; j < BoardWidth; j++)
                {
                    CellArray[i, j].alive = false;
                    // _cellArray[i, j].active = true; // Ignore this for now.
                    CellArray[i, j].row = i;
                    CellArray[i, j].column = j;
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