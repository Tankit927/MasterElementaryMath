// Program to practice elementary math like:
// Addition

// Known Issue
//     If you go outside the bounds of the window then bad things will happen.
//     So make sure that window size is sufficiently large

// Note about timer
//     It just show the total time and doesn't countdown because
//     I am too dumb to figure out how to implement running timer
//     while waiting for user input.


class ElementaryMathPractice
{
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
            Console.WriteLine($"Time = {time} s");
            Console.WriteLine($"Score = {score}/{count}");
            Console.WriteLine($"Percentage = {(score/(double)count):p2}");
            Console.WriteLine();
            Console.WriteLine("1. Start test");
            Console.WriteLine("2. Change time");
            Console.WriteLine("3. Back to addition sub-menu");
            int choice = GetInt("", 1, 3);

            if(notImplementedOrError)
            {
                Clear(10);
            }
            else
            {
                Clear(9);
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

        int[] scoreBoard = {0, 0, 0, 0, 0, 0}; // score, count, averageScore, totalCount, maxScore, maxScoreCount
        Random rng = new Random();
        DateTime start = DateTime.Now;
        DateTime end = start.AddSeconds(time);
        
        while(DateTime.Now < end)
        {
            Console.WriteLine("Sum as many integers as you can before time runs out.");
            Console.WriteLine("Enter -1 to exit prematurely");
            Console.WriteLine($"Time = {time} s");
            Console.WriteLine($"Score = {scoreBoard[0]}/{scoreBoard[1]}");
            Console.WriteLine($"Percentage = {scoreBoard[0]/(double)scoreBoard[1]:p2}");
            Console.WriteLine();
            
            int n1 = rng.Next(10, 100);
            int n2 = rng.Next(10, 100);
            int sum = n1 + n2;
            
            int userInput = GetInt($"{n1} + {n2} = ");
            if(userInput == -1)
            {
                Clear(7);
                return scoreBoard;
            }

            scoreBoard[1] += 1;
            if(sum == userInput)
            {
                scoreBoard[0] += 1;
            }

            Clear(7);
        }

        return scoreBoard;
    }


    static int[] GetAverageInFraction(int currentAverageNumerator, int currentAverageDenominator, int count, int newTerm=0)
    {
        // Method to calculate running average

        // Step 1: av *= (count -1)
        // Find GCD of currentAverageDenominator & (count - 1)
        // currentAverageDenominator /= GCD
        // int tempCount = (count - 1) / GCD
        // currentAverageNumerator *= tempCount

        // Step 2: av += newTerm
        // newTerm *= currentAverageDenominator
        // currentAverageNumerator += newTerm
        // Find GCD of currentAverageNumerator & currentAverageDenominator
        // currentAverageNumerator /= GCD
        // currentAverageDenominator /= GCD

        // Step 3: av /= count
        // Find GCD of currentAverageNumerator & count
        // currentAverageNumerator /= GCD
        // count /= GCD
        // currentAverageDenominator *= count

        // return {currentAverageNumerator, currentAverageDenominator}
    }


    static int GetGCD(params int[] myArray)
    {
        // Method to find GCD(Greatest Common Divisor) of given integers

        int gcd = Math.Abs(myArray[0]);
        int len = myArray.Length;

        for(int i = 0; i < len; i++)
        {
            myArray[i] = Math.Abs(myArray[i]);
            if(myArray[i] < gcd)
            {
                gcd = myArray[i];
            }
        }

        for(; gcd >= 1; gcd--)
        {
            for(int i = 0; i < len; i++)
            {
                if(myArray[i] % gcd != 0)
                {
                    break;
                }
                else if(i == len-1)
                {
                    return gcd;
                }
            }
        }

        return gcd;
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