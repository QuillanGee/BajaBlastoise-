namespace Cpsc370Final;

public static class ParseTextFiles
{
    public static Dictionary<int, string> ShoeBrand;
    public static Dictionary<int, string> Drinks;
    public static Dictionary<int, string> FastFoodChains;
    public static Dictionary<int, string> Fingers;
    public static Dictionary<int, string> DogBreeds;
    public static Dictionary<int, string> Races;
    public static Dictionary<int, string> States;
    public static Dictionary<int, string> Letters;
    public static Dictionary<int, string> IceCreamFlavors;
    public static Dictionary<int, string> Cereals;

    public static void IntializeDictionaries()
    {
        ShoeBrand = ParseTextFile("ShoeBrands.txt");
        Drinks = ParseTextFile("Drinks.txt");
        FastFoodChains = ParseTextFile("FastFoodChains.txt");
        Fingers = ParseTextFile("Fingers.txt");
        DogBreeds = ParseTextFile("DogBreeds.txt");
        Races = ParseTextFile("Races.txt");
        States = ParseTextFile("States.txt");
        Letters = ParseTextFile("Letters.txt");
        IceCreamFlavors = ParseTextFile("IceCreamFlavors.txt");
        Cereals = ParseTextFile("Cereals.txt");
    }
    
    public static Dictionary<int, string> ParseTextFile(string textFile)
    {
        Dictionary<int,string> dict = new Dictionary<int, string>();
        
        string basePath = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(basePath, textFile); // Combines path safely
        
        using (StreamReader sr = new StreamReader(filePath))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                //makes sure no white spaces in front or back
                List<string> words = line.Split(",").Select(w => w.Trim()).ToList(); 
                int key = int.Parse(words[0]);
                string value = words[1];
                dict[key] = value; 
            }

        }

        return dict;
    }
}