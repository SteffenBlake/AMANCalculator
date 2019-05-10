using System;

namespace AMANCalculator
{
    class Program
    {
        private const int trials = 100000;

        private const int sampleSize = 1690;
        private const decimal noiseCount = 1370;
        private const decimal thudCount = 274;
        private const decimal loudThudCount = 46;

        private const decimal noiseValue = 50_000;
        private const decimal thudValue = 300_000;
        private const decimal loudThudValue = 20_000_000;

        static void Main(string[] args)
        {
            try
            {
                PerformTrials();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }
            finally
            {
                Console.WriteLine("<Press enter to end the program>");
                Console.ReadKey(true);
            }
        }

        private static void PerformTrials()
        {
            var rnd = new Random();

            if (noiseCount + thudCount + loudThudCount != sampleSize)
            {
                throw new ArgumentOutOfRangeException(nameof(sampleSize), "Expected sample size to be equal to Noise+Thuds+LoudThuds, please double check your numbers!");
            }

            var averageValue =
                (noiseCount / sampleSize) * noiseValue +
                (thudCount / sampleSize) * thudValue +
                (loudThudCount / sampleSize) * loudThudValue;

            var totalValue = 0m;

            for (var trialN = 0; trialN < trials; trialN++)
            {
                // Value from 0-10
                var completion = (trialN * 20) / trials;
                var notCompletion = 20 - completion;
                var progressBar = "▐" + new string('▓', completion) + new string(' ', notCompletion) + "▌";

                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"Trials performed: {trialN}/{trials}");
                Console.WriteLine(progressBar);

                totalValue += PerformTrial(averageValue, rnd);
            }

            var averageReturns = totalValue / trials;

            Console.WriteLine($"Average returns: {averageReturns:N0}");
        }

        private static decimal PerformTrial(decimal averageValue, Random rnd)
        {
            var mimic = rnd.Next(10);

            var currentVal = 0m;

            // Keep opening chests until we've opened more value than 'average' value of next chest
            for (var chestsN = 0; IsProfitable(currentVal, averageValue, chestsN); chestsN++)
            {
                // We hit the mimic!
                if (chestsN == mimic)
                {
                    return 0;
                }

                // Calculate 

                var result = rnd.Next(sampleSize) + 1;

                // Noise
                if (result <= noiseCount)
                {
                    currentVal += noiseValue;
                }
                // Thud
                else if (result <= (noiseCount + thudCount))
                {
                    currentVal += thudValue;
                }
                // Loud thud
                else if (result <= (noiseCount + thudCount + loudThudCount))
                {
                    currentVal += loudThudValue;
                }
                // Error
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(result), $"Expected a Result between 1 and {sampleSize} (inclusive). Was: {result}");
                }

            }

            // Stop opening chests, we hit value threshold!
            return currentVal;
        }

        private static bool IsProfitable(decimal currentVal, decimal averageValue, int chestsN)
        {
            var successChance = (10 - chestsN) / 10m;
            var failureChance = 1m - successChance;

            return (currentVal * failureChance) < (averageValue * successChance);
        }
    }
}
