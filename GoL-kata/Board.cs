using System;

namespace GoL_kata
{
    class Board
    {
        public readonly int BoardHeight;
        public readonly int BoardWidth;
        private int _seedHeight;
        private int _seedWidth;

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
            int seedHeightHalf = _seedHeight / 2;
            int seedWidthHalf = _seedWidth / 2;
            
            //int seedRowStart = midHeight - Int32.Parse(_seedHeight / 2);


        }
        
        public Board(InputData input)
        {
            BoardHeight = input.boardHeight;
            BoardWidth = input.boardWidth;
            _seedHeight = input.seedHeight;
            _seedWidth = input.seedWidth;
            
            InitialiseCellArray();
            PlantSeed();
        }
    }
}