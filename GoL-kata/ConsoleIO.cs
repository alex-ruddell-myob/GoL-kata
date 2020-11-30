using System;

namespace GoL_kata
{
    class ConsoleIO
    {
        public static void ReadUserInput()
        {
            Console.Write("\nPlease enter an integer board height (# cells):  ");
            int boardHeight = Int32.Parse(Console.ReadLine());
            Console.Write("Please enter an integer board width  (# cells):  ");
            int boardWidth = Int32.Parse(Console.ReadLine());

            Console.WriteLine("\nPlease set the initial state of the board. You may enter any shape you want!");
            Console.WriteLine("For example:\n\t\t----XXXX----\n\t\t--XXX-XXX---\n\t\t-X-XXXX-XX--");
            
            Console.Write("\nPlease enter a seed height:  ");
            int seedHeight = Int32.Parse(Console.ReadLine());
            Console.Write("Please enter a seed width :  ");
            int seedWidth = Int32.Parse(Console.ReadLine());
            // TODO: validate that these are less than the board sizes
            
            Console.WriteLine("\nPlease enter your seed line by line...\n");
            Console.Write("Cols  |");
            for (int col = 1; col <= seedWidth; col++)
            {
                Console.Write(col.ToString());
            }
            Console.Write("\n");

            for (int row = 1; row <= seedHeight; row++)
            {
                Console.Write("Row " + row.ToString() + " |");
                string test = Console.ReadLine();
            }
        }

        public static void PrintGameBoard()
        {
            
        }
    }
}