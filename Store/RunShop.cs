namespace RPG_Store.Store;

public class RunShop
{
    private Inventory _inventory = new Inventory();
    private Shop _shop = new Shop();

    public void Loop()
    {
        while (true) //hoofdloop van de winkel
        {
            _shop.ViewMenu(); //Menu
            
            Console.Write("Fabro Blacksmith Store ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    _inventory.DisplayItems();
                    break;
                case "2":
                    _inventory.GenerateItems();
                    break;
                case "3":
                    //TODO: 3. Buy item
                    break;
                case "4":
                    //TODO: 4. Sell item
                    break;
                case "5":
                    Console.Clear();
                    for (int i = 5; i >= 1; i--)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Game is quitting in {i} seconds");
                        Thread.Sleep(1000);
                        Console.Beep(1200, 750);
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                    }
                    Environment.Exit(0);
                    
                    break;
                default:
                    
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Invalid input");
                    Console.ResetColor();
                    break;
            }
            
        }
    }
}