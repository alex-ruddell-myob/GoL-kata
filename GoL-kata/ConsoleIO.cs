using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Threading.Tasks.Sources;

namespace GoL_kata
{
    static class ConsoleIO
    {
        private static IInput _inputSystem;
        
        public static IInput GetUserSelectInputType()
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

            var type = "default";
            
            switch (key)
            {
                case ConsoleKey.A:
                    _inputSystem = new UserInput();
                    type = "Manual Input";
                    break;
                case ConsoleKey.B:
                    _inputSystem = new MenuInput();
                    type = "Menu Input";
                    break;
            }

            Console.WriteLine("\nYou have chosen " + type + "\n");
            return _inputSystem;
        }
        
        public static void PrintGameBoard(Board board, int iteration)
        {
            Console.WriteLine("\n\nGame Tick: " + iteration + "\n");
            for (int i = 1; i < board.BoardHeight - 1; i++)
            {
                for (int j = 1; j < board.BoardWidth - 1; j++)
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