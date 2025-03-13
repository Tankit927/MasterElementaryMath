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
}