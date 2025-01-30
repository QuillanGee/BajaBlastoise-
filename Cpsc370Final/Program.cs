namespace Cpsc370Final;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 1)
            Console.WriteLine("Usage: Cpsc370Final <arguments>");

        // you can delete this if/when you like
        ShowArguments(args);

        DisplayInstructions();
        GameLoop();

    }

    // this is just an example of how to get the command
    // line arguments so you can use them
    private static void ShowArguments(string[] args)
    {
        for (int i = 0; i < args.Length; i++)
        {
            Console.WriteLine("  Argument " + i + ": " + args[i]);
        }
    }

    private static void GameLoop()
    {
        bool continuePlaying = true;

        while (continuePlaying == true)
        {
            try
            {
                continuePlaying = ContinuePlayingOrQuit();
                if (continuePlaying == false)
                {
                    break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Please enter a valid number");
                continue;
            }

            List<int> validGuesses = InitializeValidGuesses();
            int secretNumber = GenerateSecretNumber();
            for (int i = 1; i <= (int)GameValues.rounds; i++)
            {
                int categoryUsed = RoundLoop(i, validGuesses, secretNumber);
                validGuesses.Remove(categoryUsed);

            }

            HandleEndGame(secretNumber);

            validGuesses.Clear();


        }
    }

    private static bool ContinuePlayingOrQuit()
    {
        Console.WriteLine("\n Enter \"1\" to begin new game \n Enter \"2\" to Exit");

        int choiceBeginOrExit = int.Parse(Console.ReadLine());
        if (choiceBeginOrExit == 1)
        {
           return true;
        }
        else if (choiceBeginOrExit == 2)
        {
            return false;
        }
        else
        {
            throw new Exception();
        }

    }

    private static int RoundLoop(int round, List<int> validGuesses, int secretNumber)
    {
        if (round == (int)GameValues.rounds)
        {
            Console.WriteLine("Ok Final Round!");
        }

        while (true)
        {
            try
            {
                ShowCategories(validGuesses);
                int category = SelectCategory(validGuesses);
                GiveClue(category,secretNumber);
                return category;
            }
            catch (Exception e)
            {
                Console.WriteLine("Please make a valid category selection");
            }
        }
        
    }

    private static int SelectCategory(List<int> validGuesses)
    {
        int categorySelected = int.Parse(Console.ReadLine());
        if (!validGuesses.Contains(categorySelected))
        {
            throw new Exception();
        }
        return categorySelected;
    }

    private static void ShowCategories(List<int> validGuesses)
    {
        Console.WriteLine("Select the number corresponding to which category you wish to see");
        foreach (int category in validGuesses)
        {
            Console.WriteLine("    " + category + ": " + Enum.GetName(typeof(Categories), category));
        }
    }
    

    private static List<int> InitializeValidGuesses()
    {
        List<int> validGuesses = new List<int>();
        for (int i = 1; i <= (int)GameValues.categories; i++)
        {
            validGuesses.Add(i);
        }
        return validGuesses;
    }

    private static int GenerateSecretNumber()
    {
        Random random = new Random();
        return random.Next(1, 11); //1-10 inclusive
    }

    private static void HandleEndGame(int secretNumber)
    {
        Console.WriteLine("\n What number am I thinking of?");
        while (true)
        {
            try
            {
                int guess = int.Parse(Console.ReadLine());
                if (guess == secretNumber)
                {
                    Console.WriteLine("You Win!");
                }
                else
                {
                    Console.WriteLine("You Lose! Sorry, the number I was thinking of was " + secretNumber);
                }

                break;
            }
            catch (Exception e)
            {
                Console.WriteLine("Please enter a number 1-10");
            }
        }
        
    }

    private static void GiveClue(int category, int secretNumber)
    {
       // ParseTextFiles.IntializeDictionaries();

        // Get the clue based on the category and secret number
        string clue = GetClue(category, secretNumber);

        if (!string.IsNullOrEmpty(clue))
        {
            Console.WriteLine("\nClue: " + clue + "\n");
        }
        else
        {
            Console.WriteLine("\nNo clue found for the selected category and number.\n");
        }
    }
    private static string GetClue(int category, int secretNumber)
    {
        string categoryName =(Enum.GetName(typeof(Categories), category));
        var PTF = ParseTextFiles.ParseTextFile(categoryName + ".txt");

        return PTF[secretNumber];
    }

    private static void DisplayInstructions()
    {
        Console.WriteLine("Welcome to The Number Guessing Game! \nI am thinking of a secret number 1-10. 1 is the worst and 10 is the best. You will choose categories to get clues about what number it could be.");
    }
}