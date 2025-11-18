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
        bool isInt = true;

        do
        {
            Console.Write(prompt);
            isInt = int.TryParse(Console.ReadLine(), out num);
            if (!isInt || (min != null && num < min) || (max != null && num > max))
            {
                Console.WriteLine($"\nEnter a valid integer in range[{(min == null ? int.MinValue : min)},{(max == null ? int.MaxValue : max)}]");
            }
        }
        while(!isInt || (min != null && num < min) || (max != null && num > max));

        return num;
    }
    

    static (string value, int intValue) GetIntOrExit(string prompt, int? min=null, int? max=null)
    {
        // Method to return "Exit" string if ReadLine() returns "Exit"
        // Or return integer if ReadLine() is integer
        // Or repeat
        // min <= integer <= max

        int num;
        bool isInt;
        string userInput;

        do
        {
            Console.Write(prompt);
            userInput = Console.ReadLine() ?? "";
            if (userInput.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
            {
                return ("exit", 0);
            }

            isInt = int.TryParse(userInput, out num);
            if (!isInt || (min != null && num < min) || (max != null && num > max))
            {
                Console.WriteLine($"\nEnter a valid integer in range[{(min == null ? int.MinValue : min)},{(max == null ? int.MaxValue : max)}]");
            }
        }
        while (!isInt || (min != null && num < min) || (max != null && num > max));

        return ("", num);
    }


static (string value, long longValue) GetLongOrExit(string prompt, long? min=null, long? max=null)
    {
        // Method to return "Exit" string if ReadLine() returns "Exit"
        // Or return integer if ReadLine() is integer
        // Or repeat
        // min <= integer <= max

        long num;
        bool isLong;
        string userInput;

        do
        {
            Console.Write(prompt);
            userInput = Console.ReadLine() ?? "";
            if (userInput.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
            {
                return ("exit", 0);
            }

            isLong = long.TryParse(userInput, out num);
            if (!isLong || (min != null && num < min) || (max != null && num > max))
            {
                Console.WriteLine($"\nEnter a valid integer in range[{(min == null ? int.MinValue : min)},{(max == null ? int.MaxValue : max)}]");
            }
        }
        while (!isLong || (min != null && num < min) || (max != null && num > max));

        return ("", num);
    }

    static void ChooseOperationToPractice()
    {
        // Method to choose certain math operation to practice like:
        // addition

        while (true)
        {
            Console.WriteLine("Program to practice elementary math like addition.");
            Console.WriteLine("1. Addition and subtraction");
            Console.WriteLine("2. Multiplication");
            int choice = GetInt("", 1, 2);

            Console.Clear();

            switch (choice)
            {
                case 1:
                    {
                        PracticeAddition();
                        break;
                    }
                case 2:
                    {
                        ChooseMultiplicationType();
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


    static void ChooseMultiplicationType()
    {
        // Method to choose type of multiplication to practice

        int previousChoice = 0;

        while (true)
        {
            Console.WriteLine("Choose the type of multiplication to practice:");
            Console.WriteLine("1. Straight line method of multiplication");
            Console.WriteLine("2. Multiplying numbers close to 10^x");
            Console.WriteLine("3. Use of additions to multiply");
            Console.WriteLine("4. Use of percentage to multiply");
            Console.WriteLine("5. Back to main menu");
            int choice = GetInt("", 1, 5);
            if (choice != previousChoice)
            {
                previousChoice = choice;
                ResetScore();
            }

            Console.Clear();

            switch (choice)
            {
                case 1:
                    {
                        ChooseNoOfDigitsForStraightLineMethod();
                        break;
                    }
                case 2:
                    {
                        ChooseMultiplyingNumbersCloseToCertainPowerOf10();
                        break;
                    }
                case 3:
                    {
                        StartTest(12); // Test 12 is multiplying using additions
                        break;
                    }
                case 4:
                    {
                        StartTest(13); // Test 13 is multiplying using percentage
                        break;
                    }
                case 5: return;
                default:
                    {
                        Console.WriteLine("Error!");
                        break;
                    }
            }
        }
    }


    static void ChooseNoOfDigitsForStraightLineMethod()
    {
        // Method to choose no. of digits for straight line multiplication method

        int previousChoice = 0;
        while (true)
        {
            Console.WriteLine("Choose no. of digits to practice straight line method of multiplication:");
            Console.WriteLine("1. 2,3-digit nums");
            Console.WriteLine("2. 3+ digits");
            Console.WriteLine("3. Back to multiplication sub-menu");
            int choice = GetInt("", 1, 3);
            if (choice != previousChoice)
            {
                previousChoice = choice;
                ResetScore();
            }

            Console.Clear();

            switch (choice)
            {
                case 1:
                case 2:
                    {
                        StartTest(choice+7); // choice starts from 8
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


    static void ChooseMultiplyingNumbersCloseToCertainPowerOf10()
    {
        // Method to choose multiplying numbers close to certain power of 10

        int previousChoice = 0;
        while (true)
        {
            Console.WriteLine("Choose no. of digits to practice straight line method of multiplication:");
            Console.WriteLine("1. Multiplying numbers close to 100");
            Console.WriteLine("2. Multiplying numbers close to 1000");
            Console.WriteLine("3. Back to multiplication sub-menu");
            int choice = GetInt("", 1, 3);
            if (choice != previousChoice)
            {
                previousChoice = choice;
                ResetScore();
            }

            Console.Clear();

            switch (choice)
            {
                case 1:
                case 2:
                    {
                        StartTest(choice+9); // choice starts from 10
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


    static void PracticeAddition()
    {
        // Method to choose type of addition practice

        int previousChoice = 0;
        while (true)
        {
            Console.WriteLine("Choose type of addition practice:");
            Console.WriteLine("1. Sum two 2-digit +ve integers.");
            Console.WriteLine("2. Sum ten 2-digit +ve integers.");
            Console.WriteLine("3. Sum ten integers in range[1000, 99999]");
            Console.WriteLine("4. Subtraction of integers in range[10, 99]");
            Console.WriteLine("5. Subtraction of integers in range[10, 999]");
            Console.WriteLine("6. Subtraction of integers in range[10, 9999]");
            Console.WriteLine("7. Subtraction of integers in range[10, 99999]");
            Console.WriteLine("8. Back to main menu.");
            int choice = GetInt("", 1, 8);
            if (choice != previousChoice)
            {
                previousChoice = choice;
                ResetScore();
            }

            Console.Clear();

            switch (choice)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                    {
                        StartTest(choice);
                        break;
                    }
                case 8: return;
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
        // Method to Start test

        TimeSpan time = TimeSpan.FromSeconds(300);

        while(true)
        {
            Console.WriteLine("Do the test until time runs out.");
            PrintScoreBoard(time);
            Console.WriteLine();
            Console.WriteLine("1. Start test");
            Console.WriteLine("2. Change time");
            Console.WriteLine("3. Reset scores");
            Console.WriteLine("4. Back");
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
                            case 3:
                                {
                                    StartSumTenBigIntegers(time);
                                    break;
                                }
                            case 4:
                                {
                                    StartTestSubIntegers10To99(time);
                                    break;
                                }
                            case 5:
                                {
                                    StartTestSubIntegers10To999(time);
                                    break;
                                }
                            case 6:
                                {
                                    StartTestSubIntegers10To9999(time);
                                    break;
                                }
                            case 7:
                                {
                                    StartTestSubIntegers10To99999(time);
                                    break;
                                }
                            case 8:
                                {
                                    StartTest2To3DigitStraightLineMultiplication(time);
                                    break;
                                }
                            case 9:
                                {
                                    StartTest3PlusDigitStraightLineMultiplication(time);
                                    break;
                                }
                            case 10:
                                {
                                    StartMultiplyingNumbersCloseTo100(time);
                                    break;
                                }
                            case 11:
                                {
                                    StartMultiplyingNumbersCloseTo1000(time);
                                    break;
                                }
                            case 12:
                                {
                                    StartTestMultiplyingNumbersUsingAdditions(time);
                                    break;
                                }
                            case 13:
                                {
                                    StartTestMultiplyingNumbersUsingPercentage(time);
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
    

    static void StartTestMultiplyingNumbersUsingAdditions(TimeSpan time)
    {
        // Method to practice multiplication of 2,3-digit numbers using additions
        // or user enters "exit"

        Random rng = new Random();
        Stopwatch stopwatch = new();
        stopwatch.Start();
        
        while(stopwatch.Elapsed < time)
        {
            Console.WriteLine("Multiply numbers using additions");
            Console.WriteLine("Enter \"exit\" to go back");
            PrintScoreBoard(time);
            Console.WriteLine();
            
            int n1 = rng.Next(10, 1000);
            int n2 = rng.Next(10, 1000);
            int product = n1 * n2;

            var (stringValue, userInput) = GetIntOrExit($"{n1} x {n2} = ");
            if (stringValue.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.Clear();
                break;
            }

            attemptThisTest += 1;
            if(product == userInput)
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


    static void StartTestMultiplyingNumbersUsingPercentage(TimeSpan time)
    {
        // Method to practice multiplication of 2,3-digit numbers using percentage
        // or user enters "exit"

        Random rng = new Random();
        Stopwatch stopwatch = new();
        stopwatch.Start();
        
        while(stopwatch.Elapsed < time)
        {
            Console.WriteLine("Multiply numbers using percentage");
            Console.WriteLine("Enter \"exit\" to go back");
            PrintScoreBoard(time);
            Console.WriteLine();
            
            int n1 = rng.Next(10, 1000);
            int n2 = rng.Next(10, 1000);
            int product = n1 * n2;

            var (stringValue, userInput) = GetIntOrExit($"{n1} x {n2} = ");
            if (stringValue.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.Clear();
                break;
            }

            attemptThisTest += 1;
            if(product == userInput)
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
    

    static void StartMultiplyingNumbersCloseTo100(TimeSpan time)
    {
        // Method to practice multiplication of numbers close to 100
        // or user enters "exit"

        Random rng = new Random();
        Stopwatch stopwatch = new();
        stopwatch.Start();

        while (stopwatch.Elapsed < time)
        {
            Console.WriteLine("Multiply numbers close to 100");
            Console.WriteLine("Enter \"exit\" to go back");
            PrintScoreBoard(time);
            Console.WriteLine();

            int n1 = rng.Next(80, 121);
            int n2 = rng.Next(80, 121);
            int product = n1 * n2;

            var (stringValue, userInput) = GetIntOrExit($"{n1} x {n2} = ");
            if (stringValue.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.Clear();
                break;
            }

            attemptThisTest += 1;
            if (product == userInput)
            {
                correctThisTest += 1;
            }

            if (correctThisTest > maxCorrect)
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


    static void StartMultiplyingNumbersCloseTo1000(TimeSpan time)
    {
        // Method to practice multiplication of numbers close to 1000
        // or user enters "exit"

        Random rng = new Random();
        Stopwatch stopwatch = new();
        stopwatch.Start();
        
        while(stopwatch.Elapsed < time)
        {
            Console.WriteLine("Multiply numbers close to 1000");
            Console.WriteLine("Enter \"exit\" to go back");
            PrintScoreBoard(time);
            Console.WriteLine();
            
            int n1 = rng.Next(980, 1021);
            int n2 = rng.Next(980, 1021);
            int product = n1 * n2;

            var (stringValue, userInput) = GetIntOrExit($"{n1} x {n2} = ");
            if (stringValue.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.Clear();
                break;
            }

            attemptThisTest += 1;
            if(product == userInput)
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


    static void StartTest2To3DigitStraightLineMultiplication(TimeSpan time)
    {
        // Method to practice multiplication of 2,3-digit multiplication by straight line method
        // or user enters "exit"

        Random rng = new Random();
        Stopwatch stopwatch = new();
        stopwatch.Start();

        while (stopwatch.Elapsed < time)
        {
            Console.WriteLine("Multiply numbers using straight line method");
            Console.WriteLine("Enter \"exit\" to go back");
            PrintScoreBoard(time);
            Console.WriteLine();

            int n1 = rng.Next(10, 1000);
            int n2 = rng.Next(10, 1000);
            int product = n1 * n2;

            var (stringValue, userInput) = GetIntOrExit($"{n1} x {n2} = ");
            if (stringValue.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.Clear();
                break;
            }

            attemptThisTest += 1;
            if (product == userInput)
            {
                correctThisTest += 1;
            }

            if (correctThisTest > maxCorrect)
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


    static void StartTest3PlusDigitStraightLineMultiplication(TimeSpan time)
    {
        // Method to practice multiplication of 2-5 digit multiplication by straight line method
        // or user enters "exit"

        Random rng = new Random();
        Stopwatch stopwatch = new();
        stopwatch.Start();
        
        while(stopwatch.Elapsed < time)
        {
            Console.WriteLine("Multiply numbers using straight line method");
            Console.WriteLine("Enter \"exit\" to go back");
            PrintScoreBoard(time);
            Console.WriteLine();
            
            int n1 = rng.Next(10, 100000);
            int n2 = rng.Next(10, 100000);
            long product = n1 * n2;

            var (stringValue, userInput) = GetLongOrExit($"{n1} x {n2} = ");
            if (stringValue.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.Clear();
                break;
            }

            attemptThisTest += 1;
            if(product == userInput)
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
        // or user enters "exit"

        Random rng = new Random();
        Stopwatch stopwatch = new();
        stopwatch.Start();
        
        while(stopwatch.Elapsed < time)
        {
            Console.WriteLine("Sum as many integers as you can before time runs out.");
            Console.WriteLine("Enter \"exit\" to go back");
            PrintScoreBoard(time);
            Console.WriteLine();
            
            int n1 = rng.Next(10, 100);
            int n2 = rng.Next(10, 100);
            int sum = n1 + n2;

            var (stringValue, userInput) = GetIntOrExit($"{n1} + {n2} = ");
            if (stringValue.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
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
    

    static void StartTestSubIntegers10To99(TimeSpan time)
    {
        // Method to run subtract two 2-digit +ve integers until time runs out
        // or user enters "exit"

        Random rng = new Random();
        Stopwatch stopwatch = new();
        stopwatch.Start();
        
        while(stopwatch.Elapsed < time)
        {
            Console.WriteLine("Subtract as many integers as you can before time runs out.");
            Console.WriteLine("Enter \"exit\" to go back");
            PrintScoreBoard(time);
            Console.WriteLine();
            
            int n1 = rng.Next(10, 100);
            int n2 = rng.Next(10, 100);
            int sum = n1 - n2;

            var (stringValue, userInput) = GetIntOrExit($"{n1} - {n2} = ");
            if (stringValue.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
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


    static void StartTestSubIntegers10To999(TimeSpan time)
    {
        // Method to run subtract two 2 to 3-digit +ve integers until time runs out
        // or user enters "exit"

        Random rng = new Random();
        Stopwatch stopwatch = new();
        stopwatch.Start();
        
        while(stopwatch.Elapsed < time)
        {
            Console.WriteLine("Subtract as many integers as you can before time runs out.");
            Console.WriteLine("Enter \"exit\" to go back");
            PrintScoreBoard(time);
            Console.WriteLine();
            
            int n1 = rng.Next(10, 1000);
            int n2 = rng.Next(10, 1000);
            int sum = n1 - n2;

            var (stringValue, userInput) = GetIntOrExit($"{n1} - {n2} = ");
            if (stringValue.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
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


    static void StartTestSubIntegers10To9999(TimeSpan time)
    {
        // Method to run subtract two 2 to 4-digit +ve integers until time runs out
        // or user enters "exit"

        Random rng = new Random();
        Stopwatch stopwatch = new();
        stopwatch.Start();
        
        while(stopwatch.Elapsed < time)
        {
            Console.WriteLine("Subtract as many integers as you can before time runs out.");
            Console.WriteLine("Enter \"exit\" to go back");
            PrintScoreBoard(time);
            Console.WriteLine();
            
            int n1 = rng.Next(10, 10000);
            int n2 = rng.Next(10, 10000);
            int sum = n1 - n2;

            var (stringValue, userInput) = GetIntOrExit($"{n1} - {n2} = ");
            if (stringValue.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
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


    static void StartTestSubIntegers10To99999(TimeSpan time)
    {
        // Method to run subtract two 2 to 5-digit +ve integers until time runs out
        // or user enters "exit"

        Random rng = new Random();
        Stopwatch stopwatch = new();
        stopwatch.Start();
        
        while(stopwatch.Elapsed < time)
        {
            Console.WriteLine("Subtract as many integers as you can before time runs out.");
            Console.WriteLine("Enter \"exit\" to go back");
            PrintScoreBoard(time);
            Console.WriteLine();
            
            int n1 = rng.Next(10, 100000);
            int n2 = rng.Next(10, 100000);
            int sum = n1 - n2;

            var (stringValue, userInput) = GetIntOrExit($"{n1} - {n2} = ");
            if (stringValue.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
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
        // or user enters "exit"

        Random rng = new Random();
        Stopwatch stopwatch = new();
        stopwatch.Start();

        while (stopwatch.Elapsed < time)
        {
            Console.WriteLine("Sum as many integers as you can before time runs out.");
            Console.WriteLine("Enter \"exit\" to go back");
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

            var (stringValue, userInput) = GetIntOrExit($"{n1} + {n2} + {n3} + {n4} + {n5} + {n6} + {n7} + {n8} + {n9} + {n10} = ");
            if (stringValue.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.Clear();
                break;
            }

            attemptThisTest += 1;
            if (sum == userInput)
            {
                correctThisTest += 1;
            }

            if (correctThisTest > maxCorrect)
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
    

    static void StartSumTenBigIntegers(TimeSpan time)
    {
        // Method to run sum ten 3 to 5-digit +ve integers until time runs out
        // or user enters "exit"

        Random rng = new Random();
        Stopwatch stopwatch = new();
        stopwatch.Start();
        
        while(stopwatch.Elapsed < time)
        {
            Console.WriteLine("Sum as many integers as you can before time runs out.");
            Console.WriteLine("Enter \"exit\" to go back");
            PrintScoreBoard(time);
            Console.WriteLine();
            
            int n2 = rng.Next(1000, 100000);
            int n1 = rng.Next(1000, 100000);
            int n3 = rng.Next(1000, 100000);
            int n4 = rng.Next(1000, 100000);
            int n5 = rng.Next(1000, 100000);
            int n6 = rng.Next(1000, 100000);
            int n7 = rng.Next(1000, 100000);
            int n8 = rng.Next(1000, 100000);
            int n9 = rng.Next(1000, 100000);
            int n10 = rng.Next(1000, 100000);
            int sum = n1 + n2 + n3 + n4 + n5 + n6 + n7 + n8 + n9 + n10;

            var (stringValue, userInput) = GetIntOrExit($"{n1} + {n2} + {n3} + {n4} + {n5} + {n6} + {n7} + {n8} + {n9} + {n10} = ");
            if (stringValue.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
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
        Console.Write($"{maxCorrect / (double)maxCorrectCount:p2}");
        Console.WriteLine();
        Console.Write("Current score: ".PadLeft(PAD_LEFT));
        Console.Write($"{correctThisTest}/{attemptThisTest}".PadRight(PAD_RIGHT));
        Console.Write("Average correct/test: ".PadLeft(PAD_LEFT));
        Console.Write($"{averageCorrectPerTest}");
        Console.WriteLine();
        Console.Write("Current score%: ".PadLeft(PAD_LEFT));
        Console.Write($"{correctThisTest / (double)attemptThisTest:p2}".PadRight(PAD_RIGHT));
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