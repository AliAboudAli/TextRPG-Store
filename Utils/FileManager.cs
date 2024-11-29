using System;
using System.IO;
using System.Text.Json;
using RPG_Store.Items;
using RPG_Store.Store;
using System.Collections.Generic;

namespace RPG_Store.Utils
{
    public class FileManager
    {
        private const string Path = "inventory.json";

        // Methode om de inventaris op te slaan
        public static void SaveInventory(Inventory inventory)
        {
            try
            {
                // Controleer of het bestand bestaat
                if (File.Exists(Path))
                {
                    string write = JsonSerializer.Serialize(inventory.inventory);
                    File.WriteAllText(Path, write);
                    Console.WriteLine("Game File Saved");
                }
                else
                {
                    // Als het bestand nog niet bestaat, wordt het nieuw aangemaakt
                    string write = JsonSerializer.Serialize(inventory.inventory);
                    File.WriteAllText(Path, write);
                    Console.WriteLine("Game File Created and Saved");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong when saving your game: {e.Message}");
            }
        }

        // Methode om de inventaris te laden
        public static void LoadInventory(Inventory inventory)
        {
            try
            {
                // Controleer of het bestand bestaat
                if (File.Exists(Path))
                {
                    string read = File.ReadAllText(Path);


                    inventory.inventory = JsonSerializer.Deserialize<List<Item>>(read);

                    Console.WriteLine("Game File Loaded successfully");
                }
                else
                {
                    Console.WriteLine("Game File not found");
                }
            }
            catch (Exception error)
            {
                Console.WriteLine($"Warning, something went wrong. Read the following message: {error.Message}");
            }
        }
    }
}
