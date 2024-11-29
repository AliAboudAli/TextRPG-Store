using System.Text.Json;
using RPG_Store.Items;
using RPG_Store.Store;

namespace RPG_Store.Utils
{
    public class FileManager
    {
        private const string Path = "inventory.json";

        //opslaan de inventory
        public static void SaveInventory(Inventory inventory)
        {
            try
            {
                string write = JsonSerializer.Serialize(inventory.inventory);
                File.WriteAllText(Path, write);
                Console.WriteLine("Game File Saved");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong when saving your game: {e.Message}");
            }
        }

        // laad vanuit de laatste save 
        public static void LoadInventory(Inventory inventory)
        {
            try
            {
                if (File.Exists(Path))
                {
                    string json = File.ReadAllText(Path);
                    var items = JsonSerializer.Deserialize<List<Item>>(json);

                    inventory.inventory = items ?? new List<Item>(); 
                    Console.WriteLine("Game File Loaded successfully.");
                }
                else
                {
                    Console.WriteLine("Game File not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while loading inventory: {ex.Message}");
            }
        }
    }
}