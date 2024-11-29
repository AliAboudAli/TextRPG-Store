using RPG_Store.Items;
using RPG_Store.Utils;

namespace RPG_Store.Store
{
    public class Inventory
    {
        public List<Item> inventory { get; set; } = new List<Item>();
        private Random rand = new Random();

        // Voeg een item toe aan de inventaris als het nog niet bestaat
        public void AddItem(Item item)
        {
            // Check of het item al bestaat in de inventaris op basis van de naam
            if (!inventory.Any(i => i.name == item.name))  // Voorkom dubbele items
            {
                inventory.Add(item);
            }
        }

        // Toon alle items in de inventaris
        public void DisplayItems()
        {
            if (inventory.Count == 0)
            {
                // geen items meer
                Console.WriteLine("We don't have any items due to Black Friday and Cyber Monday :/");
                return;
            }

            Console.WriteLine("Your inventory:");
            foreach (var item in inventory)
            {
                item.DisplayStatus();
            }
        }

        // Willekeurige generatie van items 
        public void GenerateItems()
        {
            inventory.Clear(); // Verwijder bestaande items 
            int numItems = rand.Next(5, 10); // Aantal items om te genereren

            // Verzamel een aantal items per type
            List<string> generatedNames = new List<string>(); // Om gecontroleerd te genereren

            for (int i = 0; i < numItems; i++)
            {
                int stock = rand.Next(0, 20);
                int price = rand.Next(5, 55);
                int value = rand.Next(10, 100);

                string itemName = string.Empty;

                //Lijsten van items gedefineerd
                switch (rand.Next(3))
                {
                    case 0: // Alle wapens
                        itemName = $"Elucidator Long Sword (Weight: 160KG)";
                        if (!generatedNames.Contains(itemName))
                        {
                            AddItem(new Weapon(itemName, price, stock, value,
                                rand.Next(5, 30),
                                rand.Next(10, 50),
                                rand.Next(5, 70)));
                            generatedNames.Add(itemName);
                        }

                        itemName = $"Ice Breaker Standard Sword (Weight: 145KG)";
                        if (!generatedNames.Contains(itemName))
                        {
                            AddItem(new Weapon(itemName, price, stock, value,
                                rand.Next(5, 30),
                                rand.Next(10, 50),
                                rand.Next(5, 70)));
                            generatedNames.Add(itemName);
                        }

                        itemName = $"Demon Dagger Sword (Weight: 85KG)";
                        if (!generatedNames.Contains(itemName))
                        {
                            AddItem(new Weapon(itemName, price, stock, value,
                                rand.Next(5, 30),
                                rand.Next(10, 50),
                                rand.Next(5, 70)));
                            generatedNames.Add(itemName);
                        }

                        break;

                    case 1: // Alle armor
                        itemName = $"Diamond Spiker Armor (Legendary)";
                        if (!generatedNames.Contains(itemName))
                        {
                            AddItem(new Armor(itemName, price, stock, value,
                                rand.Next(1, 100),
                                rand.Next(2, 30)));
                            generatedNames.Add(itemName);
                        }

                        itemName = $"Ruby Flames Armor (Extra Rare)";
                        if (!generatedNames.Contains(itemName))
                        {
                            AddItem(new Armor(itemName, price, stock, value,
                                rand.Next(1, 100),
                                rand.Next(2, 30)));
                            generatedNames.Add(itemName);
                        }

                        itemName = $"Blue Marmite Armor (Common)";
                        if (!generatedNames.Contains(itemName))
                        {
                            AddItem(new Armor(itemName, price, stock, value,
                                rand.Next(1, 100),
                                rand.Next(2, 30)));
                            generatedNames.Add(itemName);
                        }

                        break;

                    case 2: // Alle potions
                        itemName = $"Potion of Healing (Common)";
                        if (!generatedNames.Contains(itemName))
                        {
                            AddItem(new Potion(itemName, price, stock, value,
                                "Healing", rand.Next(1, 55)));
                            generatedNames.Add(itemName);
                        }

                        itemName = $"Potion of Night Vision (Extra Rare)";
                        if (!generatedNames.Contains(itemName))
                        {
                            AddItem(new Potion(itemName, price, stock, value,
                                "Healing", rand.Next(1, 55)));
                            generatedNames.Add(itemName);
                        }

                        itemName = $"Potion of Revive (Legendary)";
                        if (!generatedNames.Contains(itemName))
                        {
                            AddItem(new Potion(itemName, price, stock, value,
                                "Healing", rand.Next(1, 55)));
                            generatedNames.Add(itemName);
                        }

                        break;
                }
            }

            DisplayItems(); // Toon de gegenereerde items
        }

        public void SaveInventory()
        {
            FileManager.SaveInventory(this);
        }
        public void LoadInventory()
        {
            FileManager.LoadInventory(this);
        }
    }
}