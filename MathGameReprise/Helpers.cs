using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathReprise
{
    internal class Helpers
    {
        static List<Game> games = new List<Game> { };

        internal static void ShowGameHistory()
        {
            Console.Clear();
            Console.WriteLine("Game History");
            Console.WriteLine("-------------------------------------------------------");
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Date} - {game.Type},{game.Difficulty}: {game.Score}pts in {game.Timer} seconds");
            }
            Console.WriteLine("\n-----------------------------------------------------\n");
            Console.WriteLine("Press any key to return to the Menu.");
            Console.ReadKey(true);
        }
        internal static void AddToHistory(Game game)
        {
            games.Add(game);
        }

        internal static GameType OperatorSwitchCase(ConsoleKeyInfo userInput)
        {
            while (true)
            {
                if (userInput.Key == ConsoleKey.Escape)
                {
                    Environment.Exit(1);
                }
                switch (userInput.KeyChar)
                {
                    case '1':
                        return GameType.Addition;
                    case '2':
                        return GameType.Subtraction;
                    case '3':
                        return GameType.Multiplication;
                    case '4':
                        return GameType.Division;
                    case '5':
                        return GameType.Random;
                    case '6':
                        Helpers.ShowGameHistory();
                        return GameType.TEMP;
                    case '0':
                        Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Please choose a valid option.\n");
                        userInput = Console.ReadKey(true);
                        break;
                }
            }
        }

        internal static Difficulty DifficultySwitchCase(ConsoleKeyInfo userInput)
        {
            while (true)
            {
                if (userInput.Key == ConsoleKey.Escape)
                {
                    Environment.Exit(1);
                }
                switch (userInput.KeyChar)
                {
                    case '1':
                        return Difficulty.Easy;
                    case '2':
                        return Difficulty.Normal;
                    case '3':
                        return Difficulty.Hard;
                    case '4':
                        return Difficulty.TEMP;
                    case '0':
                        Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Please choose an existing option.");
                        userInput = Console.ReadKey(true);
                        break;
                }
            }
        }

        internal static char GetMathOperator(GameType Type)
        {
            Random random = new Random();
            switch (Type)
            {
                case GameType.Addition:
                    return '+';
                case GameType.Subtraction:
                    return '-';
                case GameType.Multiplication:
                    return '*';
                case GameType.Division:
                    return '/';
                case GameType.Random:
                    switch (random.Next(1, 5))
                    {
                        case 1:
                            return '+';
                        case 2:
                            return '-';
                        case 3:
                            return '*';
                        case 4:
                            return '/';
                        default:
                            return '+';
                    }
                default:
                    return 'e';
            }

        }

        internal static int GetRandomNumber(char mathOperator, Difficulty difficulty)
        {
            Random random = new Random();
            if (mathOperator == '+' || mathOperator == '-')
            {
                switch (difficulty)
                {
                    case Difficulty.Easy:
                        return random.Next(0, 11);
                    case Difficulty.Normal:
                        return random.Next(0, 101);
                    case Difficulty.Hard:
                        return random.Next(0, 1001);
                    default:
                        return random.Next(0, 1);
                }
            }
            else
            {
                switch (difficulty)
                {
                    case Difficulty.Easy:
                        return random.Next(0, 11);
                    case Difficulty.Normal:
                        return random.Next(0, 51);
                    case Difficulty.Hard:
                        return random.Next(0, 101);
                    default:
                        return random.Next(0, 1);
                }
            }
        }

        internal static int CalculateAnswer(char mathOperator, int a, int b)
        {
            switch (mathOperator)
            {
                case '+':
                    return a + b;
                case '-':
                    if (a > b)
                    {
                        return a - b;
                    }
                    return -1;
                case '*':
                    return a * b;
                case '/':
                    if (b == 0)
                    {
                        return -1;
                    } 
                    if( a % b == 0)
                    {
                        return a / b;
                    }
                    return -1;
                default:
                    return -1;
            }

        }

        internal static int AnswerValidation()
        {
            int input;
            while (true)
            {
                Console.Write("Answer: ");
                string readLine = Console.ReadLine();
                if (!int.TryParse(readLine, out input))
                {
                    Console.WriteLine("Only numbers, please!");
                }
                else
                {
                    break;
                }
            }
            return input;
        }
    }
}
