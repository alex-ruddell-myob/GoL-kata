namespace GoL_kata
{
    public class Cell
    {
        public int row;
        public int column;

        public bool alive;
        // public bool active; 
        // Active as in, has been activated by surrounding cells. Trying to decrease computational intensity.

        public void UpdateCellStatus(int aliveNeighbours, bool currentState)
        {
            if (currentState)
            {
                if (aliveNeighbours < 2 || aliveNeighbours > 3)
                {
                    alive = false;
                }
                else
                {
                    alive = true;
                }
            }
            else
            {
                if (aliveNeighbours == 3)
                {
                    alive = true;
                }
            }
        }

        public Cell(int row, int column, bool alive)
        {
            this.row = row;
            this.column = column;
            this.alive = alive;
        }
    }
}