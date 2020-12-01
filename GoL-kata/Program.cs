using System;
using System.Threading;

namespace GoL_kata
{
    class Program
    {
        static void Main(string[] args)
        {
            Initialise();
            
            InputData userInput = ConsoleIO.ReadUserInput();
            //userInput.ConvertStringToSeed(); // FIX THIS?

            var board = new Board(userInput);
            int iteration = 0;
            ConsoleIO.PrintGameBoard(board, iteration);
            
            while (!Console.KeyAvailable)
            {
                board = Game.Iterate(board);
                iteration++;
                ConsoleIO.PrintGameBoard(board, iteration);

                Console.Write("\nPress ANY KEY to end game...");
                Thread.Sleep(2000);
            }

            // USER INPUT creates BOARD object DONE!!
            // BOARD object instantiates cells DONE!!
            // BOARD is passed through GAME to alter state until the game finishes
            // BOARD is printed each time.

            

        }

        static void Initialise()
        {
            Console.WriteLine("Welcome to Conway's Game of Life!\n");
        }
    }
}