using System.Text.Json;
using RPG_Store.Items;
using RPG_Store.Store;

namespace RPG_Store.Utils
{
    /// <summary>
    /// Doel van de klassen: laden en opslaan voor de inventory
    /// waarom:
    /// kiezen van JSON is nodig om inventory te kunnen opslaan en te laden.
    /// JSON heeft goede bestandheer ze kunnen snel en eenvoudig opslaan en laden.
    /// </summary>
    public class FileManager
    {
        private const string Path = "inventory.json"; // het bestand waarin de inventaris wordt opgeslagen.
                                                      // het gebruik van een constante maakt het bestandspad makkelijker te beheren

        //opslaan de inventory
        public static void SaveInventory(Inventory inventory)
        {
            try //voor errors als er iets mis gaat met het opslaan
            {
                string write = JsonSerializer.Serialize(inventory.inventory); // we laten de process waarvan de object wordt omgezet in formaat dat kan overdragen naar JSON.
                File.WriteAllText(Path, write); //we schrijven de JSON naar het bestand.
                Console.WriteLine("Game File Saved");
            }
            catch (Exception e) //stel het gaat mis deze melding 
            {
                Console.WriteLine($"Something went wrong when saving your game: {e.Message}");
            }
        }

        // laad vanuit de laatste save 
        public static void LoadInventory(Inventory inventory)
        {
            try //voor errors als er iets mis gaat met het laden
            {
                if (File.Exists(Path)) //controleer de bestand of het bestaat
                {
                    string json = File.ReadAllText(Path); //JSON leest de bestand.
                    var items = JsonSerializer.Deserialize<List<Item>>(json); //de JSON wordt geconverteerd naar een lijst van objecten

                    inventory.inventory = items ?? new List<Item>(); //als deserialisatie mislukt, stel de inventaris in als een lege lijst
                    Console.WriteLine("Game File Loaded successfully."); //yay
                }
                else
                {
                    Console.WriteLine("Game File not found."); //geen bestand gevonden
                }
            }
            catch (Exception ex) //mislukt
            {
                Console.WriteLine($"Error while loading inventory: {ex.Message}");
            }
        }
    }
}