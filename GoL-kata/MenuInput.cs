using System;
using System.Collections.Generic;

namespace GoL_kata
{
    class MenuInput : IInput
    {
        // TODO: TEST ALL OF THESE INPUTS TO SEE IF THEY BREAK.
        
        public InputData ReadUserInput()
        {
            var keyDictionary = GetKeyDictionary();
            var nameDictionary = GetNameDictionary();
            var seedDictionary = GetDataDictionary();

            Console.WriteLine("================ MENU ================");
            Console.WriteLine("Which pattern would you like to input?");
            
            foreach (var item in nameDictionary)
            {
                Console.WriteLine("[{0}]: {1}", item.Key, item.Value);
            }
            Console.WriteLine();
            
            var found = false;
            string seedName = "null";
            InputData input = new InputData();

            Console.Write("Please select an option...  ");
            while (!found)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                
                while (!keyDictionary.ContainsKey(key))
                {
                    key = Console.ReadKey(true).Key;
                }
                seedName = nameDictionary[keyDictionary[key]];

                if (seedDictionary.ContainsKey(seedName))
                {
                    input = seedDictionary[seedName];
                    found = true;
                }
            }

            Console.WriteLine("\nYou have chosen the " + seedDictionary[seedName] + " as your pattern.");
            
            return input;
        }

        private Dictionary<ConsoleKey, string> GetKeyDictionary()
        {
            return new Dictionary<ConsoleKey, string>()
            {
                { ConsoleKey.A, "A" },
                { ConsoleKey.B, "B" },
                { ConsoleKey.C, "C" },
                { ConsoleKey.D, "D" },
                { ConsoleKey.E, "E" },
                { ConsoleKey.F, "F" },
                { ConsoleKey.G, "G" }
            };
        }

        private Dictionary<string, string> GetNameDictionary()
        {
            return new Dictionary<string, string>()
            {
                { "A", "Beehive" },
                { "B", "Blinker" },
                { "C", "Beacon" },
                { "D", "Pulsar" },
                { "E", "Penta-decathlon" },
                { "F", "Glider" },
                { "G", "Middle-weight spaceship"}
            };
        }

        private Dictionary<string, InputData> GetDataDictionary()
        {
            return new Dictionary<string, InputData>()
            {
                { "Beehive", new InputData {
                    boardHeight = 5, boardWidth = 6, seedHeight = 3, seedWidth = 4, seedString = new[] {"-XX-", "X--X", "-XX-"}
                } },
                { "Blinker", new InputData
                {
                    boardHeight = 5, boardWidth = 5, seedHeight = 3, seedWidth = 3, seedString = new[] {"---", "XXX", "---"}
                } },
                { "Beacon", new InputData
                {
                    boardHeight = 6, boardWidth = 6, seedHeight = 4, seedWidth = 4, seedString = new[] {"XX--", "XX--", "--XX", "--XX"}
                } },
                { "Pulsar", new InputData
                {
                    boardHeight = 17, boardWidth = 17, seedHeight = 13, seedWidth = 13, 
                    seedString = new[] {
                        "--XXX---XXX--", "-------------", "X----X-X----X", "X----X-X----X", "X----X-X----X", "--XXX---XXX--", "-------------",
                        "--XXX---XXX--", "X----X-X----X", "X----X-X----X", "X----X-X----X", "-------------", "--XXX---XXX--"
                    }
                } },
                { "Penta-decathlon", new InputData
                {
                    boardHeight = 11, boardWidth = 18, seedHeight = 3, seedWidth = 10, seedString = new[] {"--X----X--", "XX-XXXX-XX", "--X----X--"}
                } },
                { "Glider", new InputData
                {
                    boardHeight = 20, boardWidth = 20, seedHeight = 3, seedWidth = 3, seedString = new[] {"-X-", "--X", "XXX"}
                } },
                { "Middle-weight spaceship", new InputData
                {
                    boardHeight = 11, boardWidth = 25, seedHeight = 5, seedWidth = 6, seedString = new[] {"--X---", "X---X-", "-----X", "X----X", "-XXXXX"}
                } }
            };
        }
    }
}