namespace Cpsc370Final;

public static class ParseTextFiles
{
    public static Dictionary<int, string> ShoeBrand;
    public static Dictionary<int, string> Drink;
    public static Dictionary<int, string> FastFoodChain;
    public static Dictionary<int, string> Fingers;
    public static Dictionary<int, string> DogBreeds;
    public static Dictionary<int, string> Race;
    public static Dictionary<int, string> States;
    public static Dictionary<int, string> Letters;
    public static Dictionary<int, string> IcecreamFlavor;
    public static Dictionary<int, string> Cereal;

    public static void IntializeDictionaries()
    {
        ShoeBrand = ParseTextFile("ShoeBrand.txt");
        Drink = ParseTextFile("Drinks.txt");
        FastFoodChain = ParseTextFile("Fast.txt");
        Fingers = ParseTextFile("Fingers.txt");
        DogBreeds = ParseTextFile("DogBreeds.txt");
        Race = ParseTextFile("Race.txt");
        States = ParseTextFile("States.txt");
        Letters = ParseTextFile("Letters.txt");
        IcecreamFlavor = ParseTextFile("IcecreamFlavors.txt");
        Cereal = ParseTextFile("Cereal.txt");
    }
    
    private static Dictionary<int, string> ParseTextFile(string textFile)
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