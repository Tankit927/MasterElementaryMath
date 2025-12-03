// Program to practice elementary math like:
// Addition

// Note about timer
//     It just show the total time and doesn't countdown because
//     I am too dumb to figure out how to implement running timer
//     while waiting for user input.


using System.Diagnostics;

public record OWS(string description, string word); // One word substitution blueprint

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

    static decimal[,] inverseProportionalityTable =
    {
        {9.09m, -8.33m},
        {10m, -9.09m},
        {11.11m, -10m},
        {12.5m, -11.11m},
        {14.28m, -12.5m},
        {16.66m, -14.28m},
        {20m, -16.66m},
        {25m, -20m},
        {33.33m, -25m},
        {50m, -33.33m},
        {60m, -37.5m},
        {66.66m, -40m},
        {75m, -42.85m},
        {100m, -50m},
    };

    static int[] fractionToPercentageTable = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 15, 16, 20, 25, 30, 40, 60 };

    private static readonly List<OWS> owsList =
        [
            // One word substitution list Top 200
            // Order is as given in BlackBook keeping synonyms are together
            // Description, word
            new("A person who loves all mankind", "Philanthropist"),
            new("Someone who freely money and help to people who need it", "Philanthropist"),            
            new("Someone who freely money and help to people who need it", "Altruist"),            
            new("Someone who make charitable donations intended to the welfare of other people", "Altruist"),
            new("Someone who make charitable donations intended to the welfare of other people", "Philanthropist"),
            new("An inscripton on a tombstone in the memory of the person who has died", "Epitaph"),
            new("Something no longer in use", "Obsolete"),
            new("Handwriting which is difficult or impossible to read", "Illegible"),
            new("Something that cannot be avoided", "Inevitable"),
            new("Certain to happen", "Inevitable"),
            new("A place for keeping the birds in a confined space", "Aviary"),
            new("Belonging to the same time", "Contemporary"),
            new("A person living in the same age as another", "Contemporary"),
            new("A person who can endure pain and hardship without showing his feelings/complaining", "Stoic"),
            new("One who doesn't believe in the existence of God", "Atheist"),
            new("A person who draw or make maps", "Cartographer"),
            new("An extreme fear of being in a small confined space", "Claustrophobia"),
            new("One who knows everything", "Omniscient"),
            new("A solution for all difficulties or diseases", "Panacea"),
            new("A person who knows and is able to use several languages", "Polyglot"),
            new("An arrangement of events or dates in order of their occurrence", "Chronology"),
            new("A speech or presentation made without previous preparation", "Extempore"),
            new("One who is difficult to please", "Fastidious"),
            new("An imagined society where everything is perfect and everyone is happy", "Utopia"),
            new("A place of ideal perfection especially in laws, government, and social conditions", "Utopia"),
            new("One who plays for pleasure rather than as a profession", "Amateur"),
            new("A person who is neither well experienced nor professional", "Amateur"),
            new("A non-professional who is inept in a particular activity", "Amateur"),
            new("Able to use left and right hand equally well", "Ambidextrous"),
            new("A person who attacks or criticizes cherished beliefs or institutions", "Iconoclast"),
            new("One who cannot make mistake", "Infallible"),
            new("The place where public, government or historical records are kept", "Archive"),
            new("A person who love or collect books", "Bibliophile"),
            new("The murder of a whole race or a group of people", "Genocide"),
            new("A sound that cannot be heard", "Inaudible"),
            new("One who cannot be corrected", "Incorrigible"),
            new("One who is beyond reform", "Incorrigible"),
            new("A person who writes or edits dictionaries", "Lexicographer"),
            new("Someone working or acting merely for money or other rewards", "Mercenary"),
            new("A soldier who fights for the sake of money", "Mercenary"),
            new("A person who hates and avoids other people", "Misanthrope"),
            new("Sentimental longing for a period in the past", "Nostalgia"),
            new("Animal that can live both on land and in water", "Amphibians"),
            new("The life history of a person written by himself", "Autobiography"),
            new("A person who eats human flesh", "Cannibal"),
            new("A person employed to drive a private or hired car", "Chauffeur"),
            new("The scientific study of worms and insects", "Entomology"),
            new("One who is unable to pay debts", "Insolvent"),
            new("One who is unable to pay debts", "Bankrupt"),
            new("A person with strong desire to steal", "Kleptomania"),
            new("Government or rule by a small group of people", "Oligarchy"),
            new("One who is all powerful", "Omnipotent"),
            new("A person who collect or study stamps", "Philatelist"),
            new("A person who never takes alcoholic drinks", "Teetotaller"),
            new("Someone having many skills", "Versatile"),
            new("A person who believes that laws and governments are not necessary", "Anarchist"),
            new("A person who believes in or tries to bring about a state of lawlessness", "Anarchist"),
            new("The art of beautiful handwriting", "Calligraphy"),
            new("A group of stars that forms a shape in the sky and has a name", "Constellation"),
            new("An animal that lives in groups", "Gregarious"),
            new("Tending to associate with others of one's kind", "Gregarious"),
            new("A quiet person who is more interested in his own thoughts and feelings than in spending time with other people", "Introvert"),
            new("A piece of land/garden in which fruit trees are grown", "Orchard"),
            new("Fit to drink water", "Potable"),
            new("A person who helps another to commit a crime or to do something morally wrong", "Accomplice"),
            new("A partner in crime", "Accomplice"),
            new("One who is not sure about God's existence", "Agnostic"),
            new("A partial or total loss of memory", "Amnesia"),
            new("A situation in a country, an organization, etc. in which there is no government, order/control", "Anarchy"),
            new("A person who regards the whole world as his country", "Cosmopolitan"),
            new("One who is a citizen not of a country but of the world", "Cosmopolitan"),
            new("A person who leaves his country to live in another", "Emigrant"),
            new("Lasting for a very short time", "Ephemeral"),
            new("To free somebody from all blame", "Exonerate"),
            new("One who is easily deceived", "Gullible"),
            new("Holding an office without receiving a pay", "Honorary"),
            new("A person who suffers from an imaginary illness", "Hypochondriac"),
            new("A person who is abnormally anxious about his health", "Hypochondriac"),
            new("A person pretending to be somebody he isn't", "Hypocrite"),
            new("That which cannot be conquered", "Invincible"),
            new("A place where money is coined by authority of the government", "Mint"),
            new("A person who admires himself/herself too much, especially his appearance", "Narcissist"),
            new("Well known for being bad", "Notorious"), 
            new("A person of evil reputation", "Notorious"),
            new("A person who collects coins", "Numismatist"),
            new("A large number of fish swimming together", "Shoal"),
            new("A place where bees are kept", "Apiary"),
            new("A military structure where arms and ammunition and other military equipment are stored", "Arsenal"),
            new("The story of a person's life written by somebody else", "Biography"),
            new("House or shelter of a gipsy", "Caravan"), 
            new("A group of people, especially traders or pilgrims, travelling together across a desert", "Caravan"),
            new("A man who knows a lot about things like food, music and art", "Connoisseur"),
            new("Man behaving more like a woman than as a man", "Effeminate"),
            new("A poem that express lament for the dead", "Elegy"),
            new("A short speech at the end of a play", "Epilogue"),
            new("A person who believes that all events are predetermined or subject to fate", "Fatalist"),
            new("A person who sells and arranges cut flowers", "Florist"),
            new("Extreme fear of wate", "Hydrophobia"),
            new("A plan of a journey, including the route and the places that will be visited", "Itinerary"),
            new("A copy of a book, piece of music, etc. before it has been printed", "Manuscript"), 
            new("A paper written by hand", "Manuscript"),
            new("A person who dislikes woman", "Misogynist"),
            new("A person who walks on foot and not travelling in a vehicle", "Pedestrian"),
            new("A person who always expects bad things to happen or something not to be successful", "Pessimist"),
            new("Occuring or coming into existence after a person's death", "Posthumous"),
            new("The murder of a king", "Regicide"),
            new("Someone who walks about in sleep", "Somnambulist"),
            new("The scientific study of sound", "Acoustics"),
            new("Money paid to former wife, husband or partner when the marriage is ended", "Alimony"),
            new("The study of human race, especially of its origin, development, customs and beliefs", "Anthropology"),
            new("A glass tank where fish and water plants are kept", "Aquarium"),
            new("A person who is chosen to settle a disagreement", "Arbitrator"), 
            new("A person appointed by two parties to resolve a dispute", "Arbitrator"),
            new("The study of human history and prehistory through the excavation of sites", "Archaeology"),
            new("A government by the nobles", "Aristocracy"), 
            new("Government by person of highest social order", "Aristocracy"), 
            new("Hard but easily broken", "Brittle"), 
            new("Liable to break easily", "Brittle"),
            new("An assembly of worshippers", "Congregation"), 
            new("A group of people who have come together in a religious building for worship and prayer", "Congregation"),
            new("A keeper or custodian of a museum or other collection", "Curator"),
            new("The scientific study of skin diseases", "Dermatology"),
            new("Causing or ending in death", "Fatal"),
            new("One who eats too much", "Glutton"),
            new("A person who cannot read or write", "Illiterate"),
            new("The condition of being unable to sleep over a period of time", "Insomnia"),
            new("A person who supervises during an examination", "Invigilator"),
            new("That through which light cannot pass", "Opaque"),
            new("Violation of something holy or sacred", "Sacrilege"),
            new("A speech made to oneself", "Soliloquy"),
            new("One who lends money on high rates of interest", "Usurer"),
            new("One who offers one's services without being forced", "Volunteer"),
            new("To give up one's authority or throne", "Abdicate"),
            new("A publication containing astronomical or meteorological annual calendar that contains important dates and time", "Almanac"),
            new("Capable of being understood in either of two or more possible senses, and therefore not definite", "Ambiguous"),
            new("Whose names are not known", "Anonymous"), 
            new("An unknown author", "Anonymous"),
            new("A person who renounces a religious or political belief or principle", "Apostate"),
            new("One who makes official examination of accounts/financial records", "Auditor"),
            new("A person who can speak only two languages", "Bilingual"),
            new("Words uttered impiously about God", "Blasphemy"),
            new("The act of speaking irreverently about sacred things", "Blasphemy"),
            new("The scientific study of plants and their structure", "Botany"),
            new("An arrangement of flowers that is usually given as a present", "Bouquet"),
            new("A person that one work with at the same place, in a profession or a business", "Colleague"),
            new("Gradual recovery of health and strength", "Convalescence"),
            new("A person who readily believes others", "Credulous"), 
            new("A doctor who studies and treats skin diseases", "Dermatologist"),
            new("A thing fit to be eaten", "Edible"),
            new("Widespread outbreak of a disease that affects large populations at the same time", "Epidemic"),
            new("A person filled with excessive and single minded zeal, especially for an extreme religious or political cause", "Fanatic"),
            new("The plants and vegetation of a particular region", "Flora"),
            new("A person who has escaped from captivity or is in hiding", "Fugitive"),
            new("The study of Earth, including the origin and history of the rocks and soil of which the earth is made", "Geology"),
            new("That which cannot be believed", "Incredible"),
            new("Incapable of feeling tired or exhausted", "Indefatigable"),
            new("That can burn/catch fire easily", "Inflammable"),
            new("That which cannot be called back", "Irrevocable"),
            new("Giving undue favours to one's own kith and kin", "Nepotism"),
            new("A person who is new to a profession without training or experience in a skill or subject", "Novice"),
            new("The study or collection of coins", "Numismatics"),
            new("A notice of a person's death", "Obituary"),
            new("One who see bright side of things", "Optimist"),
            new("A person who opposes war or use of military force", "Pacifist"),
            new("A person who does not like, understand or enjoy the beauty of art, literature, music, etc.", "Philistine"),
            new("Stealing of ideas or writings of someone else", "Plagiarism"),
            new("Government by the richest people of a country", "Plutocracy"),
            new("The scientific study of mind and how it influences behaviour", "Psychology"),
            new("A person who withdraws from the world to live in seclusion and often in solitude", "Recluse"),
            new("A close fitting cover for a sword or knife", "Sheath"), 
            new("Cover for the blade of a weapon or tool", "Sheath"),
            new("Something kept as a reminder of an event", "Souvenir"),
            new("In exactly the same words as were used originally", "Verbatim"),
            new("A person who is long experienced or practiced in an activity", "Veteran"),
            new("A decorative ring of flowers and leaves", "Wreath"),
            new("Fear of great heights", "Acrophobia"),
            new("Concerned with beauty or the appreciation of beauty", "Aesthetic"),
            new("A list of item to be discussed at a meeting", "Agenda"),
            new("Medicine to nullify the effect of poison or other medicine", "Antidote"),
            new("Animals and plants growing or living in or near water", "Aquatic"),
            new("One who denies oneself ordinary bodily pleasures", "Ascetic"),
            new("A person engaged in or trained for spaceflight", "Astronaut"),
            new("The scientific study of celestial bodies like sun, moon, stars, planets, etc.", "Astronomy"),
            new("A doctor who specializes in the study and treatment of heart diseases", "Cardiologist"),
            new("Animals that eat meat", "Carnivorous"),
            new("A place where gambling games are played", "Casino"),
            new("A list or collection of books or informative graphics", "Catalogue"),
            new("A funeral procession", "Cortege"),
            new("Centre of attraction", "Cynosure"),
            new("A leader who sways his followers by his oratory", "Demagogue"),
            new("The study of population and its dynamics", "Demography"),
            new("A large bedroom for a number of people in a school or institution", "Dormitory"),
            new("A game in which no one wins", "Draw"),
            new("A book or set of books giving information about all areas of knowledge", "Encyclopedia"),
            new("Murder of one's brother or sister", "Fratricide"),
            new("A very small village", "Hamlet"),
            new("A building in which aircraft are housed", "Hangar"),
            new("All(things or people) of the same or similar kind or nature", "Homogeneous"),
            new("That which cannot be satisfied", "Insatiable"),
            new("Someone who is killed fighting for the cause of religion or faith", "Martyr"),
            new("A place for keeping dead bodies before burial or cremation", "Mortuary"),
            new("Present everywhere", "Omnipresent"),
            new("The scientific study of birds", "Ornithology"),
            new("A fictitious name especially one assumed by an author", "Pseudonym"),
            new("Dress with medals, ribbons worn at offical ceremony, symbols of royalty", "Regalia"),
            new("A person very reserved in speech", "Reticent"),
            new("One who helps a person in need", "Samaritan"),
            new("An office with high salary but no work", "Sinecure"),
            new("The study of the nature of God and religious beliefs", "Theology"), 
            new("The study of religion", "Theology"),
            new("A place where animals are slaughtered for consumption as food", "Abattoir"),
            new("An official pardon", "Amnesty"), 
            new("The formal act of liberating someone", "Amnesty"),
            new("A system of government of a country in which one person has complete power", "Autocracy"),
            new("A large bundle bound for storage or transport", "Bale"),
            new("An instrument used for measuring atmospheric pressure", "Barometer"),
            new("A group of girls/boys/birds, etc.", "Bevy"),
            new("A list of books referred to in a scholarly work", "Bibliography"),
            new("A government run by officials in a state", "Bureaucracy"),
            new("Harsh or discordant sound", "Cacophony"), 
            new("Loud confusing disagreeable sounds", "Cacophony"), 
            new("An incongruous or chaotic mixture", "Cacophony"),
            new("A person skilled at producing beautiful handwriting", "Calligrapher"),
            new("The art or process of drawing or making maps", "Cartography"),
            new("One who plans the steps and moves in a dance", "Choreographer"),
            new("Easily spread from one person to another", "Contagious"),
            new("A disease which spreads with contact", "Contagious"),
            new("One who sneers at the aims and beliefs of his fellow men", "Cynic"),
            new("A person who believes that only selfishness motivates human actions", "Cynic"),
            new("A system of government in which all the people of a country can vote to elect their representatives", "Democracy"),
        ];

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
    

    static (string value, decimal decimalValue) GetDecimalOrExit(string prompt, decimal? min=null, decimal? max=null)
    {
        // Method to return "Exit" string if ReadLine() returns "Exit"
        // Or return integer if ReadLine() is integer
        // Or repeat
        // min <= integer <= max

        decimal num;
        bool isDecimal;
        string userInput;

        do
        {
            Console.Write(prompt);
            userInput = Console.ReadLine() ?? "";
            if (userInput.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
            {
                return ("exit", 0);
            }

            isDecimal = decimal.TryParse(userInput, out num);
            if (!isDecimal || (min != null && num < min) || (max != null && num > max))
            {
                Console.WriteLine($"\nEnter a valid number in range[{(min == null ? decimal.MinValue : min)},{(max == null ? decimal.MaxValue : max)}]");
            }
        }
        while (!isDecimal || (min != null && num < min) || (max != null && num > max));

        return ("", num);
    }


static (string value, long longValue) GetLongOrExit(string prompt, long? min = null, long? max = null)
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
                Console.WriteLine($"\nEnter a valid integer in range[{(min == null ? long.MinValue : min)},{(max == null ? long.MaxValue : max)}]");
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
            Console.WriteLine("3. Percentage calculation using percentage rule upto 1 decimal point without rounding");
            Console.WriteLine("4. Ratio comparison");
            Console.WriteLine("5. Multiplication table practice [12,19]");
            Console.WriteLine("6. Practice squares upto 30");
            Console.WriteLine("7. Product constancy table or inverse proportionality table");
            Console.WriteLine("8. Fraction to percentage conversion");
            Console.WriteLine("9. Percentage to fraction conversion");
            Console.WriteLine("10. One word substitutions (Top 200)");
            int choice = GetInt("", 1, 10);

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
                case 3:
                    {
                        StartTest(14); // Percentage rule test is test 14
                        break;
                    }
                case 4:
                    {
                        StartTest(15); // Ratio comparison test is test 15
                        break;
                    }
                case 5:
                    {
                        StartTest(16); // Multiplication table practice is test 16
                        break;
                    }
                case 6:
                    {
                        StartTest(17); // Practice squares is test 17
                        break;
                    }
                case 7:
                    {
                        ChooseTypeOfInverseProportionality();
                        break;
                    }
                case 8:
                    {
                        StartTest(20); // Fraction to percentage conversion is test 20
                        break;
                    }
                case 9:
                    {
                        StartTest(21); // Percentage to fraction conversion is test 21
                        break;
                    }
                case 10:
                    {
                        StartTest(22); // Top 200 one word substitutions test
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


    static void ChooseTypeOfInverseProportionality()
    {
        // Method to choose type of inverse proportionality to practice

        int previousChoice = 0;

        while (true)
        {
            Console.WriteLine("Choose inverse proportionality order:");
            Console.WriteLine("1. increase-decrease order");
            Console.WriteLine("2. Any order");
            Console.WriteLine("3. Back to main menu");
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
                        StartTest(18); // Increase-decrease order of inverse proportionality is test 18
                        break;
                    }
                case 2:
                    {
                        StartTest(19); // Any order of inverse proportionality is test 19
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
                            case 14:
                                {
                                    StartTestPercentageCalculationUsingPercentageRule(time);
                                    break;
                                }
                            case 15:
                                {
                                    StartTestRatioComparison(time);
                                    break;
                                }
                            case 16:
                                {
                                    StartMultiplicationTableTest(time);
                                    break;
                                }
                            case 17:
                                {
                                    StartPracticingSquares(time);
                                    break;
                                }
                            case 18:
                                {
                                    IncreaseDecreaseOrderOfInverseProportionality(time);
                                    break;
                                }
                            case 19:
                                {
                                    AnyOrderOfInverseProportionality(time);
                                    break;
                                }
                            case 20:
                                {
                                    StartFractionToPercentageConversionTest(time);
                                    break;
                                }
                            case 21:
                                {
                                    StartPercentageToFractionConversionTest(time);
                                    break;
                                }
                            case 22:
                                {
                                    Start200OneWordSubstitutionTest(time);
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
    

    static void StartFractionToPercentageConversionTest(TimeSpan time)
    {
        // Method to practice fraction to percentage conversion
        // or user enters "exit"

        Random rng = new Random();
        Stopwatch stopwatch = new();
        stopwatch.Start();
        int len = fractionToPercentageTable.Length;
        int dIndex = 1, nIndex = 0;

        while (stopwatch.Elapsed < time)
        {
            Console.WriteLine("Fraction to percentage conversion exercise (2 decimal places without rounding)");
            Console.WriteLine("Enter \"exit\" to go back");
            PrintScoreBoard(time);
            Console.WriteLine();
            do
            {
                dIndex = rng.Next(1, len);
            }
            while (fractionToPercentageTable[dIndex] == 10);
            do
            {
                nIndex = rng.Next(0, dIndex);
            }
            while (!IsCoprime(fractionToPercentageTable[dIndex], fractionToPercentageTable[nIndex]));

            decimal percentValue = ((decimal)fractionToPercentageTable[nIndex] / fractionToPercentageTable[dIndex]) * 100;
            percentValue = Math.Truncate(percentValue * 100) / 100;

            var (stringValue, userInput) = GetDecimalOrExit($"{fractionToPercentageTable[nIndex]} / {fractionToPercentageTable[dIndex]} = ");

            if (stringValue.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.Clear();
                break;
            }
            attemptThisTest += 1;
            if (userInput == percentValue)
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


    static void StartPercentageToFractionConversionTest(TimeSpan time)
    {
        // Method to practice percentage to fraction conversion
        // or user enters "exit"

        Random rng = new Random();
        Stopwatch stopwatch = new();
        stopwatch.Start();
        int len = fractionToPercentageTable.Length;
        int dIndex = 1, nIndex = 0;

        while (stopwatch.Elapsed < time)
        {
            Console.WriteLine("Percentage to Fraction conversion exercise");
            Console.WriteLine("Enter \"exit\" to go back");
            PrintScoreBoard(time);
            Console.WriteLine();
            do
            {
                dIndex = rng.Next(1, len);
            }
            while (fractionToPercentageTable[dIndex] == 10);
            do
            {
                nIndex = rng.Next(0, dIndex);
            }
            while (!IsCoprime(fractionToPercentageTable[dIndex], fractionToPercentageTable[nIndex]));

            decimal percentValue = ((decimal)fractionToPercentageTable[nIndex] / fractionToPercentageTable[dIndex]) * 100;
            percentValue = Math.Truncate(percentValue * 100) / 100;

            Console.WriteLine(percentValue);

            var (stringValue, userInputNumerator) = GetIntOrExit($"Numerator = ");
            if (stringValue.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.Clear();
                break;
            }

            var (stringValue2, userInputDenominator) = GetIntOrExit($"Denominator = ");
            if (stringValue2.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.Clear();
                break;
            }
            
            attemptThisTest += 1;
            if (userInputNumerator == fractionToPercentageTable[nIndex] && userInputDenominator == fractionToPercentageTable[dIndex])
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


    static void Start200OneWordSubstitutionTest(TimeSpan time)
    {
        // Method to practice top 200 one word substitutions
        // or user enters "-1"

        Random rng = new Random();
        Stopwatch stopwatch = new();
        int len = owsList.Count;
        Lookup<string, string> owsLookup = (Lookup<string, string>)owsList.ToLookup(s => s.description, s => s.word);
        stopwatch.Start();

        while (stopwatch.Elapsed < time)
        {
            Console.WriteLine("Top 200 one word substitutions");
            Console.WriteLine("Enter \"-1\" to go back");
            PrintScoreBoard(time);
            Console.WriteLine();
            
            OWS my_ows = owsList[rng.Next(0, len)];
            string key = my_ows.description;
            Console.WriteLine(key);
            string word = Console.ReadLine() ?? "";
            word = word.Trim();

            if (word.Equals("-1", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.Clear();
                break;
            }

            List<string> words = owsLookup[key].ToList();
            
            attemptThisTest += 1;
            if (words.Contains(word, StringComparer.InvariantCultureIgnoreCase))
            {
                correctThisTest += 1;
            }
            else
            {
                foreach(string s in words)
                {
                    Console.WriteLine(s);
                }

                Thread.Sleep(3000);
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


    static int GCD(int n1, int n2)
    {
        // Method to calculate GCD of two given +ve integers

        n1 = Math.Abs(n1);
        n2 = Math.Abs(n2);

        if (n1 < n2)
        {
            int temp = n1;
            n1 = n2;
            n2 = temp;
        }

        while (n2 > 0)
        {
            int r = n1 % n2;
            n1 = n2;
            n2 = r;
        }

        return n1;
    }


    static bool IsCoprime(int n1, int n2)
    {
        // Method to determine whether given two integers are coprime or not

        if (GCD(n1, n2) == 1)
        {
            return true;
        }

        return false;
    }


    static void IncreaseDecreaseOrderOfInverseProportionality(TimeSpan time)
    {
        // Method to practice inverse proportionality
        // Given A --> B +x%
        // Find B --> A
        // or user enters "exit"

        Random rng = new Random();
        Stopwatch stopwatch = new();
        stopwatch.Start();
        int rows = inverseProportionalityTable.GetLength(0);

        while (stopwatch.Elapsed < time)
        {
            Console.WriteLine("Inverse proportionality exercise");
            Console.WriteLine("Enter \"exit\" to go back");
            PrintScoreBoard(time);
            Console.WriteLine();

            int row = rng.Next(0, rows);
            Console.WriteLine($"A --> B {inverseProportionalityTable[row, 0]}");

            var (stringValue, userInput) = GetDecimalOrExit("B --> A = ");
            if (stringValue.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.Clear();
                break;
            }

            attemptThisTest += 1;
            if (userInput == inverseProportionalityTable[row, 1])
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


    static void AnyOrderOfInverseProportionality(TimeSpan time)
    {
        // Method to practice inverse proportionality in any order
        // Given A --> B +-x%
        // Find B --> A
        // or user enters "exit"

        Random rng = new Random();
        Stopwatch stopwatch = new();
        stopwatch.Start();
        int rows = inverseProportionalityTable.GetLength(0);

        while (stopwatch.Elapsed < time)
        {
            Console.WriteLine("Inverse proportionality exercise");
            Console.WriteLine("Enter \"exit\" to go back");
            PrintScoreBoard(time);
            Console.WriteLine();

            int row = rng.Next(0, rows);
            int col = rng.Next(0, 2);
            Console.WriteLine($"A --> B {inverseProportionalityTable[row, col]}");

            var (stringValue, userInput) = GetDecimalOrExit("B --> A = ");
            if (stringValue.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.Clear();
                break;
            }

            attemptThisTest += 1;
            if (userInput == inverseProportionalityTable[row,Math.Abs(col-1)])
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


    static void StartPracticingSquares(TimeSpan time)
    {
        // Method to practice squares upto 30
        // or user enters "exit"

        Random rng = new Random();
        Stopwatch stopwatch = new();
        stopwatch.Start();

        while (stopwatch.Elapsed < time)
        {
            Console.WriteLine("Practice squares upto 30");
            Console.WriteLine("Enter \"exit\" to go back");
            PrintScoreBoard(time);
            Console.WriteLine();

            int n1 = rng.Next(2, 30);
            int square = (int)Math.Pow(n1, 2);

            var (stringValue, userInput) = GetIntOrExit($"{n1}^2 = ");
            if (stringValue.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.Clear();
                break;
            }

            attemptThisTest += 1;
            if (square == userInput)
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
    

    static void StartMultiplicationTableTest(TimeSpan time)
    {
        // Method to practice tables [12,19]
        // or user enters "exit"

        Random rng = new Random();
        Stopwatch stopwatch = new();
        stopwatch.Start();

        while (stopwatch.Elapsed < time)
        {
            Console.WriteLine("Practice tables [12,19]");
            Console.WriteLine("Enter \"exit\" to go back");
            PrintScoreBoard(time);
            Console.WriteLine();

            int n1 = rng.Next(12, 20);
            int n2 = rng.Next(2, 10);
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
    

    static void StartTestRatioComparison(TimeSpan time)
    {
        // Method to practice finding greater ratio
        // or user enters "exit"

        Random rng = new Random();
        Stopwatch stopwatch = new();
        stopwatch.Start();

        while (stopwatch.Elapsed < time)
        {
            Console.WriteLine("Type 1 if first ratio is greater or 2 if second is greater or 3 if both same");
            Console.WriteLine("Enter \"exit\" to go back");
            PrintScoreBoard(time);
            Console.WriteLine();

            int n1 = rng.Next(10, 1000);
            int n2 = rng.Next(10, 1000);
            int n3 = rng.Next(10, 1000);
            int n4 = rng.Next(10, 1000);
            decimal firstRatio = (decimal)n1 / n2;
            decimal secondRatio = (decimal)n3 / n4;

            var (stringValue, userInput) = GetIntOrExit($"First ratio = {n1}/{n2}\nSecond ratio = {n3}/{n4}\n");
            if (stringValue.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.Clear();
                break;
            }

            attemptThisTest += 1;
            if ((userInput == 1 && firstRatio > secondRatio) || (userInput == 2 && secondRatio > firstRatio) || (userInput == 3 && firstRatio == secondRatio))
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
    

    static void StartTestPercentageCalculationUsingPercentageRule(TimeSpan time)
    {
        // Method to practice percentage calculation using percentage rule
        // or user enters "exit"

        Random rng = new Random();
        Stopwatch stopwatch = new();
        stopwatch.Start();

        while (stopwatch.Elapsed < time)
        {
            Console.WriteLine("Calculate percentage using percentage rule upto 1 decimal place without rounding");
            Console.WriteLine("Enter \"exit\" to go back");
            PrintScoreBoard(time);
            Console.WriteLine();

            int n1 = rng.Next(10, 1000);
            int n2 = rng.Next(10, 1000);
            decimal percent = ((decimal)n1 / n2) * 100;
            percent = Math.Truncate(percent * 10) / 10;

            var (stringValue, userInput) = GetDecimalOrExit($"({n1} / {n2})% = ");
            if (stringValue.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.Clear();
                break;
            }

            attemptThisTest += 1;
            if (percent == userInput)
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
    

    static void StartTestMultiplyingNumbersUsingAdditions(TimeSpan time)
    {
        // Method to practice multiplication of 2,3-digit numbers using additions
        // or user enters "exit"

        Random rng = new Random();
        Stopwatch stopwatch = new();
        stopwatch.Start();

        while (stopwatch.Elapsed < time)
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
            long product = (long)n1 * n2;

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