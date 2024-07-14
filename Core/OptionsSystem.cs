using Program;
using System.Text.Json;
using System.IO;


namespace OptionsSystem
{
    public class Options
    {
        private static IConsoleEffects consoleEffects = new ConsoleEffects();

        public void PlayerStatus(PlayerData playerData)
        {
            consoleEffects.PrintDelayEffect($"You currently have {playerData.currentPlayerHP}HP, {playerData.currentPlayerSP}SP, and you are Level {playerData.currentPlayerLevel}.");
        }
           
        public static void SaveData(PlayerData playerData)
        {
            var playerDataToSave = new
        {
            playerData.currentPlayerHP,
            playerData.currentPlayerSP,
            playerData.currentPlayerLevel,
            playerData.currentPlayerExp,
            playerData.currentScripts,
            playerData.Inventory
        };

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(playerDataToSave, options);
            File.WriteAllText("PlayerSave.json", jsonString);
            Console.WriteLine("It's fine, send it.");
        }

    public static void LoadData(PlayerData playerData)
    {
        if (!File.Exists("PlayerSave.json"))
        {
            Console.WriteLine("I think we're busted bro.");
            return; // No return value; just update the existing playerData.
        }

        string jsonString = File.ReadAllText("PlayerSave.json");
        var loadedData = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(jsonString);

            // Update the existing playerData instance with loaded values.
        playerData.currentPlayerHP = loadedData["currentPlayerHP"].GetInt32();
        playerData.currentPlayerSP = loadedData["currentPlayerSP"].GetInt32();
        playerData.currentPlayerLevel = loadedData["currentPlayerLevel"].GetInt32();
        playerData.currentPlayerExp = loadedData["currentPlayerExp"].GetInt32();
        playerData.currentScripts = JsonSerializer.Deserialize<List<string>>(loadedData["currentScripts"].GetRawText());
        playerData.Inventory = JsonSerializer.Deserialize<Dictionary<string, int>>(loadedData["Inventory"].GetRawText());

        Console.WriteLine("Loaded - let's do this!");
    }



    public static void Video()
    {
        Console.WriteLine("Select Screen Resolution:");
        Console.WriteLine("1. 16:9 - 2560x1440");
        Console.WriteLine("2. 16:9 - 1920x1080");
        Console.WriteLine("3. 16:9 - 1366x768");
        Console.WriteLine("4. 16:9 - 1280x720");
        Console.WriteLine("5. 16:10 - 1920x1200");
        Console.WriteLine("6. 16:10 - 1680x1050");
        Console.WriteLine("7. 16:10 - 1440x900");
        Console.WriteLine("8. 16:10 - 1280x800");
        Console.WriteLine("9. 4:3 - 1024x768");
        Console.WriteLine("10. 4:3 - 800x600");
        Console.WriteLine("11. 4:3 - 640x480");
        Console.Write("Enter choice (1-11): ");

        var choice = Console.ReadLine();
        SetResolution(choice);
    }
    static void SetResolution(string choice)
    {
        int width = 640, height = 480;

        switch (choice)
        {
            case "1":
                width = 2560; height = 1440;
                break;
            case "2":
                width = 1920; height = 1080;
                break;
            case "3":
                width = 1366; height = 768;
                break;
            case "4":
                width = 1280; height = 720;
                break;
            case "5":
                width = 1920; height = 1200;
                break;
            case "6":
                width = 1680; height = 1050;
                break;
            case "7":
                width = 1440; height = 900;
                break;
            case "8":
                width = 1280; height = 800;
                break;
            case "9":
                width = 1024; height = 768;
                break;
            case "10":
                width = 800; height = 600;
                break;
            case "11":
                width = 640; height = 480;
                break;
            default:
                Console.WriteLine("Invalid choice. Please select a valid option.");
                return;
        }

        try
        {
            //Adjusting for typical character width and height.
            Console.SetWindowSize(width / 8, height / 18); 
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine($"Error setting resolution: {e.Message}");
        }
    }
        

        static bool soundsEnabled = true; // Default to enabled

    public static void Sound()
       {
            Console.WriteLine("Sound Options:");
            Console.WriteLine("1. Enable Sounds");
            Console.WriteLine("2. Disable Sounds");
            Console.Write("Enter choice (1-2): ");

            var choice = Console.ReadLine();

            switch (choice)
            {
            case "1":
            soundsEnabled = true;
            Console.WriteLine("Sounds have been enabled.");
            break;
            case "2":
            soundsEnabled = false;
            Console.WriteLine("Sounds have been disabled.");
            break;
            default:
            Console.WriteLine("Invalid choice. Please select a valid option.");
            break;
            }
        }

//Example usage of putting this elsewhere in the game below so we can play music but disable/enable it with the soundsEnabled flag.
static void PlayBeep()
{
    if (soundsEnabled)
    {
        Console.Beep();
    }
}
    }
}