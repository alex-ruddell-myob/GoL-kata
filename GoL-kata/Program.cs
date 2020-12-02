using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace GoL_kata
{
    class Program
    {
        private static IInput _inputSystem;
        
        static void Main(string[] args)
        {
            Initialise();

            InputData userInput = _inputSystem.ReadUserInput();

            var board = new Board(userInput);
            
            int iteration = 0;
            ConsoleOutput.PrintGameBoard(board, iteration);
            
            while (!Console.KeyAvailable)
            {
                board = Game.Iterate(board);
                iteration++;
                
                ConsoleOutput.PrintGameBoard(board, iteration);

                Console.Write("\nPress ANY KEY to end game...");
                Thread.Sleep(1000);
            }
        }

        static void Initialise()
        {
            Console.WriteLine("Welcome to Conway's Game of Life!\n");
            Console.WriteLine("How would you like to play?");
            Console.WriteLine("\t[A] Enter your own seed");
            Console.WriteLine("\t[B] Select a cool seed\n");
            
            Console.Write("\rPlease select an option...  ");

            var key = Console.ReadKey().Key;
            var type = "default";
            
            while (key != ConsoleKey.A && key != ConsoleKey.B)
            {
                key = Console.ReadKey().Key;
            }

            switch (key)
            {
                case ConsoleKey.A:
                    _inputSystem = new ConsoleInput();
                    type = "Console Input";
                    break;
                case ConsoleKey.B:
                    _inputSystem = new MenuInput();
                    type = "Menu Input";
                    break;
            }

            Console.WriteLine("\nYou have selected " + type + "\n");
        }
    }
}