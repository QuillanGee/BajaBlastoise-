namespace Cpsc370Final;

public class Game
{
    public int GenerateSecretNumber()
    {
        Random random = new Random();
        return random.Next(1, 11); //1-10 inclusive
    }
    
    public List<int> InitializeValidGuesses()
    {
        List<int> validGuesses = new List<int>();
        for (int i = 1; i <= (int)GameValues.categories; i++)
        {
            validGuesses.Add(i);
        }
        return validGuesses;
    }
    
    public int SelectCategory(List<int> validGuesses, int categorySelected)
    {
 
        if (!validGuesses.Contains(categorySelected))
        {
            throw new Exception();
        }
        return categorySelected;
    }
    
    public bool ContinuePlayingOrQuit(int choiceBeginOrExit)
    {
       
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
    
    public string GetClue(int category, int secretNumber)
    {
        string categoryName =(Enum.GetName(typeof(Categories), category));
        var PTF = ParseTextFiles.ParseTextFile(categoryName + ".txt");

        return PTF[secretNumber];
    }

    public bool HandleEndGame(int secretNumber, int guess)
    {
        bool isWinner = false;
        if (guess == secretNumber)
        {
            isWinner = true;
        }
        else
        {
            isWinner = false;
        }
        return isWinner;

    }
}