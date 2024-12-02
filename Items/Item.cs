
namespace RPG_Store.Items
{
    //geen blauwdruk "abstract" gebruikt eerst wel omdat ik niet eerst polyforisme wilt gebruiken maar nergens voor toepassing
    //eerste keuze was een aparte class maken om polyforisme te gebruiken om data te loaden, alleen deed heel buggy
    //hierdoor heb ik geen polyforisme nodig
    //interfaces worden niet toegevoegd omdat het overbodige complexitiet is
    public class Item //parent class voor potion, weapons en armor
    {
        //eigenschap voor goud
        //veilig op te slaan voor goud waarde voor de currency
        public string name { get; set; }
        public int price { get; set; }
        public int stock { get; set; }
        public int gold { get; set; }
        public string Type { get; }
        
        public Item(string Name, int Price, int Stock, int Gold) //we geven specieke waarden aan om later te initaliseren als objecten
        {
            name = Name;
            price = Price;
            stock = Stock;
            gold = Gold;
        } //dit maakt overzichterlijker en bedoeld als OOP

        //overschrijf de methode van de base class
        public virtual void DisplayStatus() //beschrijving voor item
        {
            Console.WriteLine($"{name} = Price: {price}, In Stock: {stock}, Gold: {gold}"); 
            //methode kan overschreven worden naar de subklassen (weapons, armor, potion) voor details toe te voegen
            //we moeten overschrijven omdat te markeren en afleiden voor klassen een extra informatie te geven.
        }
    }
}