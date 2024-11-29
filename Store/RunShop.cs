namespace RPG_Store.Store;
public class RunShop
{
    private Inventory _inventory = new Inventory(); // Instantie van inventory
    private Shop _shop = new Shop(); // Instantie van shop
    private int userGold = 50; // Basis start goud voor de gebruiker

    public void Loop()
    {
        while (true) // Hoofdloop van de winkel
        {
            _shop.ViewMenu(); // Menu

            Console.Write("Fabro Blacksmith Store: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1": // Toon inventaris
                    Console.Clear();
                    _inventory.DisplayItems();
                    break;

                case "2": // Kopen
                    Console.Clear();
                    if (_inventory.inventory.Count > 0)
                    {
                        var itemToBuy = _inventory.inventory[0];
                        var result = Shop.buyItem(
                            isBuying: true,
                            itemStock: itemToBuy.stock,
                            itemPrice: itemToBuy.price,
                            userbalanceGold: userGold,
                            inStock: 1
                        );
                        if (result.isfinished)
                        {
                            Console.WriteLine("Thank you for your recent purchase!");
                            itemToBuy.stock = result.stockUpdate;
                            userGold = result.balanceUpdate;
                        }
                        else
                        {
                            Console.WriteLine("We've been robbed, and our items are gone!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Stocked out!");
                    }
                    break;

                case "3": // Verkopen
                    Console.Clear();
                    if (_inventory.inventory.Count > 0)
                    {
                        var itemToSell = _inventory.inventory[0];
                        _shop.sellItem(itemToSell, ref userGold, sellCount: 1);
                    }
                    else
                    {
                        Console.WriteLine("We can't accept any items at this moment.");
                    }
                    break;

                case "4": // Nieuwe items genereren
                    _inventory.GenerateItems();
                    Console.WriteLine("New items have been added to the store inventory.");
                    break;

                case "5": // Verlaat winkel
                    Console.Clear();
                    for (int i = 5; i >= 1; i--)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Game is quitting in {i} seconds.");
                        Thread.Sleep(1000);
                        Console.Beep(1200, 750);
                        Console.Clear();
                    }
                    Environment.Exit(0);
                    break;

                default: // Ongeldige invoer
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Invalid input.");
                    Console.ResetColor();
                    break;
            }
        }
    }
}