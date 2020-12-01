using System;

namespace GoL_kata
{
    class Program
    {
        static void Main(string[] args)
        {
            Initialise();
            
            InputData userInput = ConsoleIO.ReadUserInput();
            //userInput.ConvertStringToSeed();

            var board = new Board(userInput);

            // USER INPUT creates BOARD object
            // BOARD object instantiates cells
            // BOARD is passed through GAME to alter state until the game finishes
            // BOARD is printed each time.
            
            // board = Adapter(data), or something similar
            int iteration = 1;
            
            ConsoleIO.PrintGameBoard(board, iteration);

        }

        static void Initialise()
        {
            Console.WriteLine("Welcome to Conway's Game of Life!\n");
        }
    }
}