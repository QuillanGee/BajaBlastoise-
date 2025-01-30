namespace Cpsc370Final.Tests;

using Cpsc370Final;

public class ParseUnitTest
{
    [Fact]
    public void InitializeTest()
    {
        ParseTextFiles.IntializeDictionaries();
        Assert.NotNull(ParseTextFiles.ShoeBrand);
    }

    [Fact]
    public void ParseTest()
    {
        Dictionary<int,string> myDict = Cpsc370Final.ParseTextFiles.ParseTextFile("test1.txt");
        Assert.Equal("turtle",myDict[10]);
    }
}