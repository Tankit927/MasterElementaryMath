// Program to practice elementary math like:
// Addition

// Note about timer
//     It just show the total time and doesn't countdown because
//     I am too dumb to figure out how to implement running timer
//     while waiting for user input.


using System.Diagnostics;

class ElementaryMathPractice
{
    const int PAD_LEFT = 25;
    const int PAD_RIGHT = 7;
    static int correctThisTest = 0;
    static int totalTestCount = 0;
    static int averageCorrectPerTest = 0; // ((averageCorrectPerTest * (totalTestCount-1)) + CorrectThisTest) / totalTestCount
    static int attemptThisTest = 0;
    static int averageAttemptPerTest = 0; // ((averageAttemptPerTest * (totalTestCount-1)) + AttemptThisTest) / totalTestCount
    static int maxCorrect = 0;
    static int maxCorrectCount = 0;

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

        return num;
    }


    static void ChooseOperationToPractice()
    {
        // Method to choose certain math operation to practice like:
        // addition

        while(true)
        {
            Console.WriteLine("Program to practice elementary math like addition.");
            Console.WriteLine("1. Addition");
            int choice = GetInt("", 1, 1);

            Console.Clear();

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
                        continue;
                    }
            }
        }
    }


    static void PracticeAddition()
    {
        // Method to choose type of addition practice
        // 1. Sum two 2-digit +ve integers
        // 2. Sum ten 2-digit +ve integers
        // 3. Back to main menu

        int previousChoice = 0;
        while(true)
        {
            Console.WriteLine("Choose type of addition practice:");
            Console.WriteLine("1. Sum two 2-digit +ve integers.");
            Console.WriteLine("2. Sum ten 2-digit +ve integers.");
            Console.WriteLine("3. Back to main menu.");
            int choice = GetInt("", 1, 3);
            if(choice != previousChoice)
            {
                previousChoice = choice;
                ResetScore();
            }

            Console.Clear();

            switch(choice)
            {
                case 1:
                    {
                        StartTest(1);
                        break;
                    }
                case 2:
                    {
                        StartTest(2);
                        break;
                    }
                case 3: return;
                default:
                    {
                        Console.WriteLine("Error!");
                        break;
                    }
            }
        }
    }


    static void StartTest(int test)
    {
        // Method to practice addition of 2 digit +ve integers

        TimeSpan time = TimeSpan.FromSeconds(300);

        while(true)
        {
            Console.WriteLine("Sum as many integers as you can before time runs out.");
            PrintScoreBoard(time);
            Console.WriteLine();
            Console.WriteLine("1. Start test");
            Console.WriteLine("2. Change time");
            Console.WriteLine("3. Reset scores");
            Console.WriteLine("4. Back to addition sub-menu");
            int choice = GetInt("", 1, 4);

            Console.Clear();

            switch(choice)
            {
                case 1:
                    {
                        correctThisTest = 0;
                        attemptThisTest = 0;
                        totalTestCount += 1;
                        switch(test)
                        {
                            case 1:
                                {
                                    StartSumTwoTwoDigitNums(time);
                                    break;
                                }
                            case 2:
                                {
                                    StartSumTenTwoDigitNums(time);
                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("Error!");
                                    break;
                                }
                        }
                        averageCorrectPerTest = ((averageCorrectPerTest * (totalTestCount-1)) + correctThisTest) / totalTestCount;
                        averageAttemptPerTest = ((averageAttemptPerTest * (totalTestCount-1)) + attemptThisTest) / totalTestCount;
                        break;
                    }
                case 2:
                    {
                        TimeSpan temp = time;
                        time = TimeSpan.FromSeconds(GetInt("Enter time in seconds = ", 1));
                        if(time != temp)
                        {
                            ResetScore();
                        }

                        break;
                    }
                case 3:
                    {
                        ResetScore();
                        break;
                    }
                case 4: return;
                default:
                    {
                        Console.WriteLine("Error!");
                        continue;
                    }
            }
        }
    }


    static void ResetScore()
    {
        // Method to reset score

        correctThisTest = 0;
        attemptThisTest = 0;
        averageAttemptPerTest = 0;
        averageCorrectPerTest = 0;
        totalTestCount = 0;
        maxCorrect = 0;
        maxCorrectCount = 0;
    }


    static void StartSumTwoTwoDigitNums(TimeSpan time)
    {
        // Method to run sum two 2-digit +ve integers until time runs out
        // or user enters -1

        Random rng = new Random();
        Stopwatch stopwatch = new();
        stopwatch.Start();
        
        while(stopwatch.Elapsed < time)
        {
            Console.WriteLine("Sum as many integers as you can before time runs out.");
            Console.WriteLine("Enter -1 to exit prematurely");
            PrintScoreBoard(time);
            Console.WriteLine();
            
            int n1 = rng.Next(10, 100);
            int n2 = rng.Next(10, 100);
            int sum = n1 + n2;
            
            int userInput = GetInt($"{n1} + {n2} = ");
            if(userInput == -1)
            {
                Console.Clear();
                break;
            }

            attemptThisTest += 1;
            if(sum == userInput)
            {
                correctThisTest += 1;
            }

            if(correctThisTest > maxCorrect)
            {
                maxCorrect = correctThisTest;
                maxCorrectCount = attemptThisTest;
            }

            Console.Clear();
        }

        stopwatch.Stop();
        stopwatch.Reset();
        return;
    }


    static void StartSumTenTwoDigitNums(TimeSpan time)
    {
        // Method to run sum ten 2-digit +ve integers until time runs out
        // or user enters -1

        Random rng = new Random();
        Stopwatch stopwatch = new();
        stopwatch.Start();
        
        while(stopwatch.Elapsed < time)
        {
            Console.WriteLine("Sum as many integers as you can before time runs out.");
            Console.WriteLine("Enter -1 to exit prematurely");
            PrintScoreBoard(time);
            Console.WriteLine();
            
            int n1 = rng.Next(10, 100);
            int n2 = rng.Next(10, 100);
            int n3 = rng.Next(10, 100);
            int n4 = rng.Next(10, 100);
            int n5 = rng.Next(10, 100);
            int n6 = rng.Next(10, 100);
            int n7 = rng.Next(10, 100);
            int n8 = rng.Next(10, 100);
            int n9 = rng.Next(10, 100);
            int n10 = rng.Next(10, 100);
            int sum = n1 + n2 + n3 + n4 + n5 + n6 + n7 + n8 + n9 + n10;
            
            int userInput = GetInt($"{n1} + {n2} + {n3} + {n4} + {n5} + {n6} + {n7} + {n8} + {n9} + {n10} = ");
            if(userInput == -1)
            {
                Console.Clear();
                break;
            }

            attemptThisTest += 1;
            if(sum == userInput)
            {
                correctThisTest += 1;
            }

            if(correctThisTest > maxCorrect)
            {
                maxCorrect = correctThisTest;
                maxCorrectCount = attemptThisTest;
            }

            Console.Clear();
        }

        stopwatch.Stop();
        stopwatch.Reset();
        return;
    }


    static void PrintScoreBoard(TimeSpan time)
    {
        // Method to print scoreboard

        Console.Write("Time: ".PadLeft(PAD_LEFT));
        Console.Write($"{time.TotalSeconds}s".PadRight(PAD_RIGHT));
        Console.Write("Max score: ".PadLeft(PAD_LEFT));
        Console.Write($"{maxCorrect}/{maxCorrectCount}");
        Console.WriteLine();
        Console.Write("Test count: ".PadLeft(PAD_LEFT));
        Console.Write($"{totalTestCount}".PadRight(PAD_RIGHT));
        Console.Write("Max score%: ".PadLeft(PAD_LEFT));
        Console.Write($"{maxCorrect/(double)maxCorrectCount:p2}");
        Console.WriteLine();
        Console.Write("Current score: ".PadLeft(PAD_LEFT));
        Console.Write($"{correctThisTest}/{attemptThisTest}".PadRight(PAD_RIGHT));
        Console.Write("Average correct/test: ".PadLeft(PAD_LEFT));
        Console.Write($"{averageCorrectPerTest}");
        Console.WriteLine();
        Console.Write("Current score%: ".PadLeft(PAD_LEFT));
        Console.Write($"{correctThisTest/(double)attemptThisTest:p2}".PadRight(PAD_RIGHT));
        Console.Write("Average attempt/test: ".PadLeft(PAD_LEFT));
        Console.Write($"{averageAttemptPerTest}");
        Console.WriteLine();
    }


    static void Clear(int n=1) // Not using this method. Still here just in case.
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