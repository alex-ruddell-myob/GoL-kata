using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Threading.Tasks.Sources;

namespace GoL_kata
{
    static class ConsoleIO
    {
        public static ConsoleKey GetUserSelection()
        {
            Console.WriteLine("How would you like to play?");
            Console.WriteLine("\t[A] Enter your own seed");
            Console.WriteLine("\t[B] Select a cool seed\n");
            
            Console.Write("Please select an option...  ");

            ConsoleKey key = Console.ReadKey(true).Key;

            while (key != ConsoleKey.A && key != ConsoleKey.B)
            {
                key = Console.ReadKey(true).Key;
            }
            
            return key;
        }
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
                        Console.Write("■ ");
                    }
                    else
                    {
                        Console.Write("□ ");
                    }
                }

                Console.Write("\n");
            }
        }
    }
}