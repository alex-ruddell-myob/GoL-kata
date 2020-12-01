namespace GoL_kata
{
    public class InputData
    {
        public int boardHeight;
        public int boardWidth;
        public int seedHeight;
        public int seedWidth;

        public string[] seedString;
        
        // TODO: Decide if I actually want this at all. If yes, move.
        /*public bool[,] seedArray;

        public void ConvertStringToSeed()
        {
            // Do this in the ConsoleIO application?
            // TODO: Unit test this!
            for (int i = 0; i < seedHeight; i++)
            {
                for (int j = 0; j < seedWidth; j++)
                {
                    if (seedString[i][j] == 'X')
                    {
                        seedArray[i, j] = true;
                    }
                    else
                    {
                        seedArray[i, j] = false;
                    }
                }
            }
        }*/
    }
}