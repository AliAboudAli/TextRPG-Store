using RPG_Store.Items;
using RPG_Store.Store;

namespace RPG_Store;

/// <summary>
/// klassen biedt logica aan voor verkopen en kopen
/// het biedt methodes om een menu weer te geven en items te kopen en te verkopen.
/// daarmee  kan de gebruiker interactie hebben met de winkel en de voorraad.
/// </summary>
public class ShopLogic
{
    public void ViewMenu()
    {
        // Introductietekst voor de winkel
        Console.WriteLine("Welcome visitor to Fabro!");
        // Opties voor acties in de winkel
        Console.WriteLine("Number 1 : Inventory");
        Console.WriteLine("Number 2 : Buy");
        Console.WriteLine("Number 3 : Sell");
        Console.WriteLine("Number 4 : Add item");
        Console.WriteLine("Number 5 : Load Game");
        Console.WriteLine("Number 6 : Save Game");
        Console.WriteLine("Number 7 : Leave Fabro");
    }

    /// <summary>
    /// Logica voor het kopen van een item, checkt of er genoeg items zijn 
    /// of de gebruiker genoeg goud heeft en past vervolgens de voorraad en het goud aan.
    /// <param name="inventory">De huidige inventaris van de winkel.</param>
    /// <param name="userbalanceGold">De hoeveelheid goud van de gebruiker (by reference).</param>
    /// <param name="isBuying">Geeft aan of de gebruiker in de koopmodus is.</param>
    /// <returns>
    ///  tuple met drie waarden:
    /// - isFinished
    /// - stockUpdate
    /// - balanceUpdate
    /// </returns>
    /// </summary>
    public static (bool isFinished, int stockUpdate, int balanceUpdate) // de bedoeling voor deze tuple methode is om de methode vaak wilt gebruiken en niet hoeft opnieuw te gebruiken
    buyItem(Inventory inventory, ref int userbalanceGold, bool isBuying)
    {
        if (isBuying) // Controle voor koop waar is, dit is nodig dat de gebruiker met 0 gold toch niet items kan kopen
        {
            if (inventory.inventory.Count > 0) // Controleert of er items beschikbaar zijn
            {
                // Toont alle beschikbare items in de inventaris
                Console.WriteLine("Available items for purchase:");
                for (int i = 0; i < inventory.inventory.Count; i++)
                {
                    var item = inventory.inventory[i]; // Verkrijgt het item in de lijst
                    Console.WriteLine($"{i + 1}. {item.name} - Price: {item.price} Gold - In Stock: {item.stock}");
                }
                // Gebruiker kiest een item om te kopen
                Console.Write("Select an item to buy (number): ");
                int choice = int.Parse(Console.ReadLine()) - 1; // -1 omdat de lijstindex begint bij 0

                // Controleer of de keuze geldig is
                if (choice < 0 || choice >= inventory.inventory.Count)
                {
                    Console.WriteLine("Invalid choice.");
                    return (false, 0, userbalanceGold); // Ongeldige keuze stopt de transactie
                }

                var selectedItem = inventory.inventory[choice]; // Verkrijgt het gekozen item

                // Gebruiker geeft aan hoeveel ze willen kopen
                Console.Write("How many would you like to buy? ");
                int buyCount = int.Parse(Console.ReadLine());

                if (buyCount <= 0) // Controleert op een geldige hoeveelheid
                {
                    Console.WriteLine("You must buy at least one item.");
                    return (false, selectedItem.stock, userbalanceGold);
                }

                // Controleert of er voldoende voorraad en goud is
                if (selectedItem.stock >= buyCount && userbalanceGold >= selectedItem.price * buyCount)
                {
                    // Past voorraad en goud aan
                    selectedItem.stock -= buyCount;
                    userbalanceGold -= selectedItem.price * buyCount;

                    Console.WriteLine($"You bought {buyCount} {selectedItem.name}(s) for {selectedItem.price * buyCount} gold.");
                    return (true, selectedItem.stock, userbalanceGold); // Succesvolle transactie
                }
                else
                {
                    // Foutmeldingen voor onvoldoende voorraad of goud
                    if (selectedItem.stock < buyCount)
                    {
                        Console.WriteLine("Not enough stock available.");
                    }
                    else
                    {
                        Console.WriteLine("Not enough gold.");
                    }
                    return (false, selectedItem.stock, userbalanceGold); // Transactie mislukt
                }
            }
        }
        return (false, 0, userbalanceGold);
    }

    /// <summary>
    /// Logica voor het verkopen van een item. het past zich aan de voorraad en goud aan op basis van de verkoop.
    /// <param name="inventory">De huidige inventaris van de winkel.</param>
    /// <param name="userbalanceGold">De hoeveelheid goud van de gebruiker (by reference).</param>
    /// </summary>
    public void SellItem(Inventory inventory, ref int userbalanceGold)
    {
        if (inventory.inventory.Count == 0) // Controleert of de inventaris leeg is
        {
            Console.WriteLine("Sold out of weapons, armor or potions.");
            return; // Stopt de methode als er niets te verkopen is
        }

        // Gebruiker kiest welk item ze willen verkopen
        Console.WriteLine("Which item would you like to sell?");
        for (int i = 0; i < inventory.inventory.Count; i++)
        {
            var item = inventory.inventory[i]; // Verkrijgt elk item
            Console.WriteLine($"{i + 1}. {item.name} (Stock: {item.stock}, Price: {item.price})");
        }

        // Gebruiker selecteert een item
        Console.Write("Select a number to sell an item: ");
        int choice = int.Parse(Console.ReadLine()) - 1;

        // Gebruiker geeft aan hoeveel ze willen verkopen
        Console.Write("How much? ");
        int sellCount = int.Parse(Console.ReadLine());

        var itemToSell = inventory.inventory[choice]; // Verkrijgt het gekozen item

        if (itemToSell.stock >= sellCount) // Controleert of er voldoende voorraad is
        {
            // Past voorraad en goud aan
            itemToSell.stock -= sellCount;
            userbalanceGold += itemToSell.price * sellCount;

            Console.WriteLine($"You sold {sellCount} {itemToSell.name}(s) for {itemToSell.price * sellCount} gold.");
        }
        else
        {
            // Foutmelding voor onvoldoende voorraad
            Console.WriteLine("Not enough stock to sell that many.");
        }
    }
}
