namespace GoL_kata
{
    public struct Cell
    {
        public int row;
        public int column;

        public bool alive;
        // public bool active; 
        // Active as in, has been activated by surrounding cells. Trying to decrease computational intensity.
    }
}