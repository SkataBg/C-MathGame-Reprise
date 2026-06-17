using System.Diagnostics.Metrics;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Timers;
using static System.Formats.Asn1.AsnWriter;

namespace MathReprise
{
    internal class GameEngine
    {
        int counter;
        internal void StartGame(Game currentGame)
        {
            counter = 0;
            Random random = new Random();
            var timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += TickTime;
            timer.Start();

            for (int i = 0; i < 5; i++)
            {
                int answer = -1;
                int a = 0;
                int b = 0;
                char mathOperator = Helpers.GetMathOperator(currentGame.Type);

                while (answer == -1)
                {
                    a = Helpers.GetRandomNumber(mathOperator, currentGame.Difficulty);
                    b = Helpers.GetRandomNumber(mathOperator, currentGame.Difficulty);
                    answer = Helpers.CalculateAnswer(mathOperator, a, b);
                }

                Console.WriteLine($"\nWhat is {a}{mathOperator}{b}?");
                int userAnswer = Helpers.AnswerValidation();

                if (userAnswer == answer)
                {
                    Console.WriteLine("Correct! Have a point! +1");
                    currentGame.Score++;
                }
                else
                {
                    Console.WriteLine("Incorrect! No points!");
                }
            }
            timer.Stop();
            currentGame.Timer = counter;
            currentGame.Date = DateTime.Now;
            Helpers.AddToHistory(currentGame);
            Console.WriteLine($"You scored {currentGame.Score} pts in {currentGame.Timer} seconds.\n" +
    $"Press any key to return to the menu.");
            Console.ReadKey(true);
            Console.Clear();
        }

        public void TickTime(object sender, EventArgs e)
        {
            counter++;
        }
    }
}

