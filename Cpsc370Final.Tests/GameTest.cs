namespace Cpsc370Final.Tests;

public class GameTest
{
    [Fact]
    public void IsNumber()
    {
        Game game = new Game();
        int result = game.GenerateSecretNumber();
        Assert.InRange(result, 1, 10);
    }

    [Fact]
    public void IsValidGuessesInitialized()
    {
        Game game = new Game();
        int categoriesCount = (int)GameValues.categories;
        
        List<int> validatedGuesses = game.InitializeValidGuesses();
        
        Assert.NotNull(validatedGuesses);
        Assert.Equal(categoriesCount, validatedGuesses.Count);

        for (int i = 0; i < validatedGuesses.Count; i++)
        {
            Assert.Contains(1, validatedGuesses);
        }
    }

    [Fact]
    public void IsSelectedCategoryAvailable()
    {
        Game game = new Game();
        List<int> guessedCategories = new List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        int selectedNumber = 3;
        
        int result = game.SelectCategory(guessedCategories, selectedNumber);
        
        Assert.Equal(selectedNumber, result);
    }

    [Fact]
    public void ContinueGameTest()
    {
        Game game = new Game();
        int choice = 1;
        
        bool result = game.ContinuePlayingOrQuit(choice);
        
        Assert.True(result);
    }

    [Fact]
    public void DiscontinueGameTest()
    {
        Game game = new Game();
        int choice = 2;
        
        bool result = game.ContinuePlayingOrQuit(choice);
        
        Assert.False(result);
    }

    [Fact]
    public void IsGameOverWinningTest()
    {
        Game game = new Game();
        int choice = 3;
        int secretNumber = 3;
        
        bool gameResults = game.HandleEndGame(choice, secretNumber);
        
        Assert.True(gameResults);
    }

    [Fact]
    public void IsGameOverLosingTest()
    {
        Game game = new Game();
        int choice = 4;
        int secretNumber = 3;
        
        bool gameResults = game.HandleEndGame(choice, secretNumber);
        
        Assert.False(gameResults);
    }

}