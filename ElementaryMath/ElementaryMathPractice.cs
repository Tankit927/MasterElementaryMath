// Program to practice elementary math like:
// Addition

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

        do
        {
            Console.Write(prompt);
            isInt = int.TryParse(Console.ReadLine(), out num);
            if(!isInt || (min != null && num < min) || (max != null && num > max))
            {
                Console.WriteLine($"\nEnter a valid integer in range[{(min == null ? int.MinValue : min)},{(max == null ? int.MaxValue : max)}]");
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
            Console.WriteLine("\nProgram to practice elementary math like addition.");
            Console.WriteLine("1. Addition");
            int choice = GetInt("", 1, 1);

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
                        break;
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

        while(true)
        {
            Console.WriteLine("\nChoose type of addition practice:");
            Console.WriteLine("1. Sum two 2-digit +ve integers.");
            Console.WriteLine("2. Sum ten 2-digit +ve integers.");
            Console.WriteLine("3. Back to main menu.");
            int choice = GetInt("", 1, 3);

            switch(choice)
            {
                case 1:
                    {
                        // Call appropriate method
                        break;
                    }
                case 2:
                    {
                        // Call appropriate method
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


    static void SumTwoTwoDigitNums()
    {
        // Method to practice addition of 2 digit +ve integers

        int time = 10;
        double score, count;
        score = count = double.NaN;
        while(true)
        {
            Console.WriteLine("Sum as many integers as you can before time runs out.");
            Console.WriteLine($"Time = {time} s");
            Console.WriteLine($"Score = {score}/{count}");
            Console.WriteLine($"Percentage = {(score/count):p2}");
            Console.WriteLine();
            Console.WriteLine("1. Start test");
            Console.WriteLine("2. Change time");
            Console.WriteLine("3. Back to addition sub-menu");
            int choice = GetInt("", 1, 3);

            switch(choice)
            {
                case 1:
                    {
                        // Call Start Test for two 2-digit nums
                        break;
                    }
                case 2:
                    {
                        time = GetInt("Enter time in seconds = ", 1);
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


    static int[] StartSumTwoTwoDigitTest(int time)
    {
        // Method to run sum two 2-digit +ve integers until time runs out
        // or user enters -1

        int[] scoreBoard = {0, 0}; // score, count
        Random rng = new Random();
        DateTime start = DateTime.Now;
        DateTime end = start.AddSeconds(time);

        Console.WriteLine("Sum as many integers as you can before time runs out.");
        Console.WriteLine($"Time = {time}");
        
        while(DateTime.Now < end)
        {
            // Figure out how to display timer

            // long remainingTicks = end.Ticks - DateTime.Now.Ticks;
            // TimeSpan remainingTimeSpan = new TimeSpan(remainingTicks);
            // Console.WriteLine($"Time = {remainingTimeSpan.Seconds}");
            Console.WriteLine($"Score = {scoreBoard[0]}/{scoreBoard[1]}");
            Console.WriteLine($"Percentage = {scoreBoard[0]/(double)scoreBoard[1]:p2}");
            Console.WriteLine();
            
            int n1 = rng.Next(10, 100);
            int n2 = rng.Next(10, 100);
            int sum = n1 + n2;
            
            int userInput = GetInt($"{n1} + {n2} = ");
            if(userInput == -1)
            {
                return scoreBoard;
            }

            scoreBoard[1] += 1;
            if(sum == userInput)
            {
                scoreBoard[0] += 1;
            }

            // Clear previous 4 lines
        }

        return scoreBoard;
    }


    static void ClearCurrentLine()
    {
        // Method to clear current line in console

        int row = Console.CursorTop;
        Console.SetCursorPosition(0, row);
        Console.Write(new string(' ', Console.BufferWidth));
        Console.SetCursorPosition(0, row);
    }


    static void Clear(int n=1)
    {
        // Method to clear given no. of previous lines starting from current line

        int row = Console.CursorTop;

        while(n > 0)
        {
            ClearCurrentLine();
            row -= 1;
            n -= 1;
        }
    }
}