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

            var board = new Board(userInput);
            
            int iteration = 0;
            ConsoleIO.PrintGameBoard(board, iteration);
            
            while (!Console.KeyAvailable)
            {
                board = Game.Iterate(board);
                iteration++;
                
                ConsoleIO.PrintGameBoard(board, iteration);

                Console.Write("\nPress ANY KEY to end game...");
                Thread.Sleep(1000);
            }
        }

        static void Initialise()
        {
            Console.WriteLine("Welcome to Conway's Game of Life!\n");
            
            // PULSAR SEED
            InputData pulsarInput = new InputData();
            pulsarInput.boardHeight = 17;
            pulsarInput.boardWidth = 17;
            pulsarInput.seedHeight = 13;
            pulsarInput.seedWidth = 13;
            pulsarInput.seedString = new string[13];
            pulsarInput.seedString[0] = "--XXX---XXX--";
            pulsarInput.seedString[1] = "-------------";
            pulsarInput.seedString[2] = "X----X-X----X";
            pulsarInput.seedString[3] = "X----X-X----X";
            pulsarInput.seedString[4] = "X----X-X----X";
            pulsarInput.seedString[5] = "--XXX---XXX--";
            pulsarInput.seedString[6] = "-------------";
            pulsarInput.seedString[7] = "--XXX---XXX--";
            pulsarInput.seedString[8] = "X----X-X----X";
            pulsarInput.seedString[9] = "X----X-X----X";
            pulsarInput.seedString[10] = "X----X-X----X";
            pulsarInput.seedString[11] = "-------------";
            pulsarInput.seedString[12] = "--XXX---XXX--";
        }
    }
}