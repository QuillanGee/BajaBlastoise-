namespace Cpsc370Final.Tests;

public class GameTest
{
    [Fact]
    public void Test1()
    {
        
    }

    [Fact]
    public void IsNumber()
    {
        Game game = new Game();
        int result = game.GenerateSecretNumber();
        Assert.InRange(result, 1, 10);
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

}