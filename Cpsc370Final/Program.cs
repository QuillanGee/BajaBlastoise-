namespace Cpsc370Final;

class Program
{
    static void Main(string[] args)
    {

        DisplayInstructions();
        Game game = new Game();
        GameLoop(game);

    }



    private static void GameLoop(Game game)
    {
        bool continuePlaying = true;

        while (continuePlaying == true)
        {
            try
            {
                Console.WriteLine("\n Enter \"1\" to begin new game \n Enter \"2\" to Exit");
                int choiceBeginOrExit = int.Parse(Console.ReadLine());
                continuePlaying = game.ContinuePlayingOrQuit(choiceBeginOrExit);

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

            List<int> validGuesses = game.InitializeValidGuesses();
            int secretNumber = game.GenerateSecretNumber();
            for (int i = 1; i <= (int)GameValues.rounds; i++)
            {
                int categoryUsed = RoundLoop(game, i, validGuesses, secretNumber);
                validGuesses.Remove(categoryUsed);

            }

            Console.WriteLine("\n What number am I thinking of?");
            int finalGuess = GetFinalGuess();
            bool isWinner = game.HandleEndGame(secretNumber, finalGuess);
            DisplayResult(isWinner, secretNumber);

            validGuesses.Clear();


        }
    }


    private static int RoundLoop(Game game, int round, List<int> validGuesses, int secretNumber)
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
                int categorySelected = int.Parse(Console.ReadLine());
                int category = game.SelectCategory(validGuesses, categorySelected);

                GiveClue(game, category, secretNumber);
                return category;
            }
            catch (Exception e)
            {
                Console.WriteLine("Please make a valid category selection");
            }
        }

    }



    private static void ShowCategories(List<int> validGuesses)
    {
        Console.WriteLine("Select the number corresponding to which category you wish to see");
        foreach (int category in validGuesses)
        {
            Console.WriteLine("    " + category + ": " + Enum.GetName(typeof(Categories), category));
        }
    }





    private static void GiveClue(Game game, int category, int secretNumber)
    {
        // ParseTextFiles.IntializeDictionaries();

        // Get the clue based on the category and secret number
        string clue = game.GetClue(category, secretNumber);

        if (!string.IsNullOrEmpty(clue))
        {
            Console.WriteLine("\nClue: " + clue + "\n");
        }
        else
        {
            Console.WriteLine("\nNo clue found for the selected category and number.\n");
        }
    }


    private static void DisplayInstructions()
    {
        Console.WriteLine(
            "Welcome to The Number Guessing Game! \nI am thinking of a secret number 1-10. 1 is the worst and 10 is the best. You will choose categories to get clues about what number it could be.");

    }

    private static void DisplayResult(bool isWinner, int secretNumber)
    {
        if (isWinner)
        {
            Console.WriteLine("You Win!");
        }
        else
        {
            Console.WriteLine("You Lose! Sorry, the number I was thinking of was " + secretNumber);
        }
    }

    private static int GetFinalGuess()
    {
        while (true)
        {
            try
            {
                int guess = int.Parse(Console.ReadLine());
                if (guess > 10 || guess < 1)
                {
                    throw new Exception();
                }

                return guess;
            }
            catch (Exception e)
            {
                Console.WriteLine("Please enter a number 1-10");
            }
        }
        
    }
}