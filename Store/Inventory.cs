using RPG_Store.Items;
using RPG_Store.Utils;

namespace RPG_Store.Store
{
    /// <summary>
    /// we zorgen dat additem methode logica wordt toegevoegd en item centraal beheerd wordt in plaats van te dupliceren in de methode
    /// we willen dat inventory meest hebruikbaar wordt voor filemanager om op te slaan en laden, maar ook voor de shoplogica
    /// </summary>
    public class Inventory
    {
        public List<Item> inventory { get; set; } = new List<Item>(); //list strings is handig voor gegeneerde namen en voorkomt dubbele items, waarvan dictionary overbodig zou zijn vanwege namen willen bijhouden
        private Random rand = new Random(); //zorgt voor dynamische en varierende inventory
        
        public void AddItem(Item item)
        {
            // bestaat het op basis van naam
            if (!inventory.Any(i => i.name == item.name))  // voorkom dubbele items
            {
                inventory.Add(item); //voeg item
            }
        }

        // Toon alle items in de inventaris
        public void DisplayItems()
        {
            if (inventory.Count == 0) //stel je inventory leeg is omdat de gebruiker geen add item heeft gekozen
            {
                // geen items meer
                Console.WriteLine("We don't have any items due to Black Friday and Cyber Monday :/"); //dan dit
                return; //stop methode
            }

            Console.WriteLine("Your inventory:"); //toch in de inventory?
            foreach (var item in inventory) //zoek elk item in inventory list
            {
                item.DisplayStatus(); //roep in item class de methode DisplayStatus aan
            }
        }

        //willekeurige generatie van items 
        public void GenerateItems() //maak een nieuwe set items
        {
            inventory.Clear(); // leegt de huidige inventory, met elk oproep van deze methode moet de inventory opnieuw gevulden worden 
            int numItems = rand.Next(5, 10); // willekeurige keuze aan aantal items die worden toegevoegd in de inventory.
            //dit is om variatie in elk oproep van de methode, het moet een dynamische inventory blijft.

            // Verzamel een aantal items per type
            List<string> generatedNames = new List<string>(); //behoud lijst van de items die al gegenereerd zijn en voorkom dubbele items.
            //dit vermijdt om meedere items met dezelfde items naam aan de inventory wordt toegevoed.

            for (int i = 0; i < numItems; i++) //herhaal door een lus oom het gegeven aantal items van numItems te genereren, dit bepaalt hoe vaak de itemgenerate herhaald wordt
            {
                //genereert willekeurig waarden voor de voorraad: 
                int stock = rand.Next(0, 20);
                int price = rand.Next(5, 55);
                int value = rand.Next(10, 100);
                //prijs, stock en valuta in elk item, dit zorgt ervoor om geen meedere items identiek zijn.
                
                //nieuwe string voor de naam item dit blijft leeg, omdat dit later in de controle bij elk switch case wordt benomen
                string itemName = string.Empty;

                //Lijsten van items gedefineerd
                switch (rand.Next(3)) //selecteert willekeurig 1 van de drie items, hierdoor pakt elk 3 een kans om te genereren
                {
                    case 0: // genereert alle wapen
                        itemName = $"Elucidator Long Sword (Weight: 160KG)";
                        if (!generatedNames.Contains(itemName)) //controleert of het gegeneerde item al bestaatin generatedNames en vermijdt duplicaten
                        {
                            //we maken een nieuwe wapen met willekeurige items met eigenschappen die toegevoegd worden aan de inventory
                            AddItem(new Weapon(itemName, price, stock, value,
                                rand.Next(5, 30),
                                rand.Next(10, 50),
                                rand.Next(5, 70)));
                            generatedNames.Add(itemName); //voegt naam van de gegeneerde item toe aan de lijst van gegenereerde items.
                            //extra eigenschappen die uniek maken in wapen
                        }
                        //nog meer items voor wapen
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

                    case 1: // // genereert alle armor
                        itemName = $"Diamond Spiker Armor (Legendary)";
                        if (!generatedNames.Contains(itemName))
                        {
                            AddItem(new Armor(itemName, price, stock, value, // maak een nieuwer armor item met willekeurige eigenschappen
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

            DisplayItems(); // roep methode aan om nieuwe items te tonen, biedt visuele feedback en verandering keuze
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