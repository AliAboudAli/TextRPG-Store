namespace RPG_Store.Store;
public class RunShop
{
    private Inventory _inventory = new Inventory(); // Instantie van inventory
    private ShopLogic _shoplogic = new ShopLogic(); // Instantie van shop
    private int userGold = 50; // Basis start goud voor de gebruiker

    public void Menu() //main menu
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Fabrico!");
        Console.WriteLine("       _\n     _|=|__________\n    /              \\\n   /                \\\n  /__________________\\\n   ||  || /--\\ ||  ||\n   ||[]|| | .| ||[]||\n ()||__||_|__|_||__||()\n( )|-|-|-|====|-|-|-|( ) \n^^^^^^^^^^====^^^^^^^^^^^");
        Console.WriteLine("___________        ___.            .__                 \n\\_   _____/_____   \\_ |__  _______ |__|  ____    ____  \n |    __)  \\__  \\   | __ \\ \\_  __ \\|  |_/ ___\\  /  _ \\ \n |     \\    / __ \\_ | \\_\\ \\ |  | \\/|  |\\  \\___ (  <_> )\n \\___  /   (____  / |___  / |__|   |__| \\___  > \\____/ \n     \\/         \\/      \\/                  \\/         ");
        Console.WriteLine("Press any key to continue...");
    
        Console.ReadLine(); 
        Loop();
    } 
    //het hoofdinterface voor het winkelbeheer systeem, hiermee blijft de programma draaien, ander kan zijn variabele controle
    public void Loop()
    {
        while (true) // Hoofdloop van de winkel
        {
            Console.Clear();
            _shoplogic.ViewMenu(); // roept menu functie

            _inventory.DisplayItems(); //Toon steeds de inventory
            Console.WriteLine();
            
            Console.WriteLine("Gold:"); //toon constant hoeveel goud je hebt, gebruiker moet weten hoeveel hij mag besteden
            Console.WriteLine(userGold);

            Console.Write("select: 1-7 ---->");

            string input = Console.ReadLine(); // leest de gebruikersinvoer, flexible datatype
            
            switch (input) //betere verwerkingskeuze dan een if-else statement, leesbaarder en eenvoudiger te debuggen
            { //alleen aanroepen van overige functies van andere klassen
                case "1": // Show inventory
                    Console.Clear();
                    _inventory.DisplayItems(); //toont ook de geupdated versie als er aanpassingen zijn
                    break;

                case "2":  //Kopen ->  gekoppeld van shoplogic.cs
                    Console.Clear();
                    
                    var result = ShopLogic.buyItem(_inventory, ref userGold, isBuying: true);  // Kopen logica
                    if (result.isFinished) //archiveert het koperprocess naar buyitem in shopLogic.cs, controleert de voorraad, goud en maakt transacties, toont alle items op een rijtje
                    {
                        Console.WriteLine("Thank you for your purchase!");
                    }
                    else
                    {
                        Console.WriteLine("Unable to complete purchase.");
                    }
                
                    _inventory.DisplayItems();  // Toon bijgewerkte inventaris
                    break;

                case "3": // Verkopen
                    Console.Clear();
                    _shoplogic.SellItem(_inventory, ref userGold); //roept de verkoops methode van shoplogic.cs, toont alle items op een rijtje
                    break;

                case "4": // Nieuwe items genereren
                    _inventory.GenerateItems(); //9 items die randomiseerd met hun waarde die random zijn aanroepen als een keuze.
                    Console.WriteLine("New items have been added to the store inventory.");
                    break;
                
                case "5": //roept de methode loadinventory aan vanwege in de methode worden functie gebruiken wat essentieel is voor het laden van de overig opgeslagen items
                    Console.Clear();
                    _inventory.LoadInventory();
                    break;
                
                case "6":
                    Console.Clear();
                    _inventory.SaveInventory(); //roept save methode aan in inventory hierin haalt het alles uit de inventory in en sla het op in JSON
                    break;
                case "7": // Verlaat winkel
                    Console.Clear();
                    for (int i = 5; i >= 1; i--) // loop loopt door voor 5 seconden
                    {
                        Console.ForegroundColor = ConsoleColor.Red; //kleur van de console
                        Console.WriteLine($"Game is quitting in {i} seconds."); //toont hoeveel seconden er komt voordat de console vanzelf sluit
                        Thread.Sleep(1000); //wacht per 1 seconde om door te gaan
                        Console.Beep(1200, 750); //leuke biepjes waarom niet
                        Console.Clear();
                    }
                    Environment.Exit(0); //doei gebruiker
                    break;

                default: // Voor ongeldige invoer
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Invalid input.");
                    Console.ResetColor();
                    break;
            }
        }
    }
}