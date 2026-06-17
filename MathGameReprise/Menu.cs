using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MathReprise
{
    internal class Menu
    {
        GameEngine gameEngine = new();
        internal void ShowMenu()
        {
            bool waitingForExitCommand = true;
            ConsoleKeyInfo userInput;

            while (waitingForExitCommand)
            {
                Game game = new();
                int loopTwice = 0;
                Console.Clear();
                Console.WriteLine("WELCOME TO MY GAME\nTap anything to continue.");
                Console.ReadKey(true);
                while (loopTwice < 2)
                {
                    if (loopTwice == 0)
                    {
                        Console.WriteLine("Choose an option from the operations below!");
                        Console.WriteLine("1.[+]      2.[-]      3.[*]       4.[/]      5.[RANDOM]      6.[SHOW HISTORY]      0.[EXIT]");
                    }
                    if (loopTwice == 1)
                    {
                        Console.WriteLine("Choose a difficulty.");
                        Console.WriteLine("1.EASY      2. NORMAL      3.HARD        4.GO BACK     0.EXIT");
                    }

                    userInput = Console.ReadKey(true);

                    if (loopTwice == 0)
                    {
                        game.Type = Helpers.OperatorSwitchCase(userInput);
                        if (game.Type == GameType.TEMP)
                        {
                            loopTwice = -1;
                        }
                    }
                    if (loopTwice == 1)
                    {
                        game.Difficulty = Helpers.DifficultySwitchCase(userInput);
                        if (game.Difficulty == Difficulty.TEMP)
                        {
                            loopTwice = -1;
                        }
                    }
                    loopTwice++;
                }
                Console.WriteLine($"{game.Difficulty} + {game.Type}");
                Console.ReadKey(true);
                gameEngine.StartGame(game);
            }
        }
    }
}
