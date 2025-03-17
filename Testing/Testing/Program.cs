class Program
{
    static void Main()
    {
        Console.WriteLine("Hello World!");

        int[] av = {0, 1};

        av = GetAverageInFraction(av[0], av[1], 1, 1, 2);
        Console.WriteLine($"{av[0]}/{av[1]}");

        av = GetAverageInFraction(av[0], av[1], 2, 1, 3);
        Console.WriteLine($"{av[0]}/{av[1]}");

        av = GetAverageInFraction(av[0], av[1], 3, 1, 4);
        Console.WriteLine($"{av[0]}/{av[1]}");
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

        return gcd;
    }
}