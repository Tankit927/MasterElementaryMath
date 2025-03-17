// Program to practice elementary math like:
// Addition

// Known Issue
//     If you go outside the bounds of the window then bad things will happen.
//     So make sure that window size is sufficiently large

// Note about timer
//     It just show the total time and doesn't countdown because
//     I am too dumb to figure out how to implement running timer
//     while waiting for user input.


using System.Runtime.Intrinsics.X86;

class ElementaryMathPractice
{
    const int PAD = 20;
    static int[] AV = {0, 1}; // averageNumerator, averageDenominator
    static int[] MAX_SCORE = {0, 1}; // maxNumerator, maxDenominator

    static void Main()
    {
        ChooseOperationToPractice();
    }


    static int GetInt(string prompt, int? min=null, int? max=null)
    {
        // Method to user input integer
        // min <= integer <= max

        int num;
        bool isInt;
        int count = 0;

        do
        {
            Console.Write(prompt);
            isInt = int.TryParse(Console.ReadLine(), out num);
            count += 2;
            if(!isInt || (min != null && num < min) || (max != null && num > max))
            {
                Console.WriteLine($"\nEnter a valid integer in range[{(min == null ? int.MinValue : min)},{(max == null ? int.MaxValue : max)}]");
                count += 1;
            }
        }
        while(!isInt || (min != null && num < min) || (max != null && num > max));

        Clear(count);

        return num;
    }


    static void ChooseOperationToPractice()
    {
        // Method to choose certain math operation to practice like:
        // addition

        bool notImplementedOrError = false;

        while(true)
        {
            Console.WriteLine("Program to practice elementary math like addition.");
            Console.WriteLine("1. Addition");
            int choice = GetInt("", 1, 1);

            if(notImplementedOrError)
            {
                Clear(4);
            }
            else
            {
                Clear(3);
            }

            switch(choice)
            {
                case 1:
                    {
                        PracticeAddition(); 
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Error!");
                        notImplementedOrError = true;
                        continue;
                    }
            }

            notImplementedOrError = false;
        }
    }


    static void PracticeAddition()
    {
        // Method to choose type of addition practice
        // 1. Sum two 2-digit +ve integers
        // 2. Sum ten 2-digit +ve integers
        // 3. Back to main menu

        bool notImplementedOrError = false;

        while(true)
        {
            Console.WriteLine("Choose type of addition practice:");
            Console.WriteLine("1. Sum two 2-digit +ve integers.");
            Console.WriteLine("2. Sum ten 2-digit +ve integers.");
            Console.WriteLine("3. Back to main menu.");
            int choice = GetInt("", 1, 3);

            if(notImplementedOrError)
            {
                Clear(6);
            }
            else
            {
                Clear(5);
            }

            switch(choice)
            {
                case 1:
                    {
                        SumTwoTwoDigitNums();
                        break;
                    }
                case 2:
                    {
                        // Call appropriate method
                        Console.WriteLine("Not implemented yet");
                        notImplementedOrError = true;
                        continue;
                    }
                case 3: return;
                default:
                    {
                        Console.WriteLine("Error!");
                        notImplementedOrError = true;
                        continue;
                    }
            }

            notImplementedOrError = false;
        }
    }


    static void SumTwoTwoDigitNums()
    {
        // Method to practice addition of 2 digit +ve integers

        int time = 10;
        int score, count;
        score = count = 0;
        bool notImplementedOrError = false;

        while(true)
        {
            Console.WriteLine("Sum as many integers as you can before time runs out.");
            Console.Write("Time: ".PadLeft(PAD));
            Console.Write($"{time}s".PadRight(PAD));
            Console.Write("Max score: ".PadLeft(PAD));
            Console.Write($"{MAX_SCORE[0]}/{MAX_SCORE[1]}");
            Console.WriteLine();
            Console.Write("".PadLeft(PAD));
            Console.Write("".PadRight(PAD));
            Console.Write("Max score%: ".PadLeft(PAD));
            Console.Write($"{MAX_SCORE[0]/(double)MAX_SCORE[1]:p2}");
            Console.WriteLine();
            Console.Write("Current score: ".PadLeft(PAD));
            Console.Write($"{score}/{count}".PadRight(PAD));
            Console.Write("Average score: ".PadLeft(PAD));
            Console.Write($"{AV[0]}/{AV[1]}");
            Console.WriteLine();
            Console.Write("Current score%: ".PadLeft(PAD));
            Console.Write($"{score/(double)count:p2}".PadRight(PAD));
            Console.Write("Average score%: ".PadLeft(PAD));
            Console.Write($"{AV[0]/(double)AV[1]:p2}");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("1. Start test");
            Console.WriteLine("2. Change time");
            Console.WriteLine("3. Back to addition sub-menu");
            int choice = GetInt("", 1, 3);

            if(notImplementedOrError)
            {
                Clear(11);
            }
            else
            {
                Clear(10);
            }

            switch(choice)
            {
                case 1:
                    {
                        int[] scoreBoard = StartSumTwoTwoDigitNums(time);
                        score = scoreBoard[0];
                        count = scoreBoard[1];
                        break;
                    }
                case 2:
                    {
                        time = GetInt("Enter time in seconds = ", 1);
                        Clear(1);
                        break;
                    }
                case 3: return;
                default:
                    {
                        Console.WriteLine("Error!");
                        notImplementedOrError = true;
                        continue;
                    }
            }

            notImplementedOrError = false;
        }
    }


    static int[] StartSumTwoTwoDigitNums(int time)
    {
        // Method to run sum two 2-digit +ve integers until time runs out
        // or user enters -1

        int[] scoreBoard = {0, 0, AV[0], AV[1], MAX_SCORE[0], MAX_SCORE[1]}; // score, count, averageNumerator, averageDenominator, maxScore, maxScoreCount
        Random rng = new Random();
        DateTime start = DateTime.Now;
        DateTime end = start.AddSeconds(time);
        
        while(DateTime.Now < end)
        {
            Console.WriteLine("Sum as many integers as you can before time runs out.");
            Console.WriteLine("Enter -1 to exit prematurely");
            Console.Write("Time: ".PadLeft(PAD));
            Console.Write($"{time}s".PadRight(PAD));
            Console.Write("Max score: ".PadLeft(PAD));
            Console.Write($"{scoreBoard[4]}/{scoreBoard[5]}");
            Console.WriteLine();
            Console.Write("".PadLeft(PAD));
            Console.Write("".PadRight(PAD));
            Console.Write("Max score%: ".PadLeft(PAD));
            Console.Write($"{scoreBoard[4]/(double)scoreBoard[5]:p2}");
            Console.WriteLine();
            Console.Write("Current score: ".PadLeft(PAD));
            Console.Write($"{scoreBoard[0]}/{scoreBoard[1]}".PadRight(PAD));
            Console.Write("Average score: ".PadLeft(PAD));
            Console.Write($"{scoreBoard[2]}/{scoreBoard[3]}");
            Console.WriteLine();
            Console.Write("Current score%: ".PadLeft(PAD));
            Console.Write($"{scoreBoard[0]/(double)scoreBoard[1]:p2}".PadRight(PAD));
            Console.Write("Average score%: ".PadLeft(PAD));
            Console.Write($"{scoreBoard[2]/(double)scoreBoard[3]:p2}");
            Console.WriteLine();
            Console.WriteLine();
            
            int n1 = rng.Next(10, 100);
            int n2 = rng.Next(10, 100);
            int sum = n1 + n2;
            
            int userInput = GetInt($"{n1} + {n2} = ");
            if(userInput == -1)
            {
                Clear(8);
                AV = GetAverageInFraction(scoreBoard[2], scoreBoard[3], 1, scoreBoard[0], scoreBoard[1]);
                scoreBoard[2] = AV[0];
                scoreBoard[3] = AV[1];
                MAX_SCORE = Max(scoreBoard[0], scoreBoard[1], MAX_SCORE[0], MAX_SCORE[1]);
                scoreBoard[4] = MAX_SCORE[0];
                scoreBoard[5] = MAX_SCORE[1];
                return scoreBoard;
            }

            scoreBoard[1] += 1;
            if(sum == userInput)
            {
                scoreBoard[0] += 1;
            }

            AV = GetAverageInFraction(scoreBoard[2], scoreBoard[3], 1, scoreBoard[0], scoreBoard[1]);
            scoreBoard[2] = AV[0];
            scoreBoard[3] = AV[1];
            MAX_SCORE = Max(scoreBoard[0], scoreBoard[1], MAX_SCORE[0], MAX_SCORE[1]);
            scoreBoard[4] = MAX_SCORE[0];
            scoreBoard[5] = MAX_SCORE[1];

            Clear(8);
        }

        return scoreBoard;
    }


    static int[] Max(int n1, int d1, int n2, int d2)
    {
        // Method to return greater fraction
        // n1/d1, n2/d2

        if(n1*d2 > n2*d1)
        {
            return [n1, d1];
        }

        return [n2, d2];
    }


    static int[] GetAverageInFraction(int currentAverageNumerator, int currentAverageDenominator, int count, int newTermNumerator, int newTermDenominator)
    {
        // Method to calculate running average

        // Step 1: av *= (count -1)
        int gcd = GetGCD(currentAverageDenominator, count-1 == 0 ? count : count-1);
        currentAverageDenominator /= gcd;
        int tempCount = (count - 1) / gcd;
        currentAverageNumerator *= tempCount;

        // Step 2: av += newTerm
        int lcm = GetLCM(currentAverageDenominator, newTermDenominator);
        currentAverageNumerator *= (lcm / currentAverageDenominator);
        newTermNumerator *= (lcm / newTermDenominator);
        currentAverageNumerator += newTermNumerator;
        gcd = GetGCD(currentAverageNumerator, lcm);
        currentAverageNumerator /= gcd;
        currentAverageDenominator = lcm / gcd;

        // Step 3: av /= count
        gcd = GetGCD(currentAverageNumerator, count);
        currentAverageNumerator /= gcd;
        count /= gcd;
        currentAverageDenominator *= count;

        return [currentAverageNumerator, currentAverageDenominator];
    }


    static int GetLCM(params int[] myArray)
    {
        // Method to calculate LCM(Least Common Multiple) of given integers

        int len = myArray.Length;
        int[] temp = new int[len];

        for(int i = 0; i < myArray.Length; i++)
        {
            temp[i] = Math.Abs(myArray[i]);
        }

        int largest = temp[0];

        for(int i = 1; i < len; i++)
        {
            if(temp[i] > largest)
            {
                largest = temp[i];
            }
        }

        int lcm = 1;
        int[] primes = GeneratePrimesUpto(largest); // prime nos. upto largest num
        while(!IsEachElementOne(temp))
        {
            for(int i = 0; i < primes.Length; i++)
            {
                if(IsAnyElementDivBy(primes[i], temp))
                {
                    for(int j = 0; j < len; j++)
                    {
                        if(temp[j] > 1 && temp[j] % primes[i] == 0)
                        {
                            lcm *= primes[i];
                            temp[j] /= primes[i];
                        }
                    }

                    break;
                }
            }
        }

        return lcm;
    }


    static bool IsEachElementOne(params int[] myArray)
    {
        // Method to check whether each element in given array is 1

        foreach(int i in myArray)
        {
            if(i != 1)
            {
                return false;
            }
        }

        return true;
    }


    static bool IsAnyElementDivBy(int num, params int[] myArray)
    {
        // Method to check whether any element(>1) of given array is divisible
        // by given integer

        foreach(int i in myArray)
        {
            if(i > 1 && i % num == 0)
            {
                return true;
            }
        }

        return false;
    }


    static int[] GeneratePrimesUpto(int num)
    {
        // Method to generate prime numbers upto a certain given integer
        // using seive of erathosthenes

        int len = num - 1;
        int[] nums = new int[len];
        int[] mask = new int[len]; // 0-unmarked, 1-prime, 2-composite
        int noOfPrimes = 0;

        for(int i = 0; i < len; i++)
        {
            nums[i] = i + 2;
        }

        for(int i = 0; i < len; i++)
        {
            if(mask[i] == 0)
            {
                int temp = nums[i];
                mask[i] = 1;
                noOfPrimes += 1;
                
                for(int j = i + temp; j < len; j += temp)
                {
                    mask[j] = 2;
                }
            }
        }

        int[] primes = new int[noOfPrimes];

        for(int i = 0, j = 0; i < len; i++)
        {
            if(mask[i] == 1)
            {
                primes[j] = nums[i];
                j += 1;
            }
        }

        return primes;
    }


    static int GetGCD(params int[] myArray)
    {
        // Method to find GCD(Greatest Common Divisor) of given integers

        int len = myArray.Length;
        int[] temp = new int[len];
        int gcd = Math.Abs(myArray[0]);

        for(int i = 0; i < len; i++)
        {
            temp[i] = Math.Abs(myArray[i]);
            if(temp[i] < gcd)
            {
                gcd = temp[i];
            }
        }

        for(; gcd >= 1; gcd--)
        {
            for(int i = 0; i < len; i++)
            {
                if(temp[i] % gcd != 0)
                {
                    break;
                }
                else if(i == len-1)
                {
                    return gcd;
                }
            }
        }

        return gcd == 0 ? 1 : gcd;
    }


    static void Clear(int n=1)
    {
        // Method to clear given no. of previous lines starting from current line

        for(int i = 1, row = Console.CursorTop; i <= n; i++, row--)
        {
            Console.SetCursorPosition(0, row);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, row);
        }
    }
}