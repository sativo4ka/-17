#nullable disable
using System;
using System.Collections.Generic;

namespace КТ17
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите очки игроков через пробел:");
            string inputScores = Console.ReadLine();
            List<int> scores = new List<int>();

            if (!string.IsNullOrWhiteSpace(inputScores))
            {
                string[] parts = inputScores.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string part in parts)
                {
                    if (int.TryParse(part, out int score))
                    {
                        scores.Add(score);
                    }
                }
            }

            if (scores.Count == 0)
            {
                scores = new List<int> { 55, 70, 40, 90 };
            }

            Console.WriteLine("Введите размер бонуса:");
            int bonusValue = 10;
            string bonusInput = Console.ReadLine();
            if (bonusInput != null && int.TryParse(bonusInput, out int parsedBonus))
            {
                bonusValue = parsedBonus;
            }

            Console.WriteLine("Введите проходной балл:");
            int passingThreshold = 60;
            string thresholdInput = Console.ReadLine();
            if (thresholdInput != null && int.TryParse(thresholdInput, out int parsedThreshold))
            {
                passingThreshold = parsedThreshold;
            }

            Console.WriteLine();

            Action<int> printScore = n => Console.WriteLine($"Очки: {n}");

            foreach (int score in scores)
            {
                printScore(score);
            }

            Func<int, int> applyBonus = n => n + bonusValue;

            int testScore = 55;
            Console.WriteLine($"{applyBonus(testScore)} (если бонус +{bonusValue})");

            Predicate<int> isPassing = n => n >= passingThreshold;

            int firstPassing = scores.Find(isPassing);
            Console.WriteLine($"{firstPassing} — первое значение >= {passingThreshold}");

            Func<int, bool> funcIsPassing = n => n >= passingThreshold;
            Predicate<int> validPredicate = new Predicate<int>(funcIsPassing);
        }
    }
}