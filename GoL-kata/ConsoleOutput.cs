using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks.Sources;

namespace GoL_kata
{
    static class ConsoleOutput
    {
        public static void PrintGameBoard(Board board, int iteration)
        {
            Console.WriteLine("\n\nGame Tick: " + iteration + "\n");
            for (int i = 0; i < board.BoardHeight; i++)
            {
                for (int j = 0; j < board.BoardWidth; j++)
                {
                    if (board.CellArray[i, j].alive)
                    {
                        // TODO: make 'alive' character cooler
                        Console.Write("■  ");
                    }
                    else
                    {
                        Console.Write("□  ");
                    }
                }

                Console.Write("\n");
            }
        }
    }
}