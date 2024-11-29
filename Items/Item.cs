
namespace RPG_Store.Items
{
    public class Item
    {
        //eigenschap voor goud
        //veilig op te slaan voor goud waarde voor de currency
        public string name { get; set; }
        public int price { get; set; }
        public int stock { get; set; }
        public int gold { get; set; }
        public string Type { get; }
        
        public Item(string Name, int Price, int Stock, int Gold)
        {
            name = Name;
            price = Price;
            stock = Stock;
            gold = Gold;
        }

        //overschrijf de methode van de base class
        public virtual void DisplayStatus()
        {
            Console.WriteLine($"{name} = Price: {price}, In Stock: {stock}, Gold: {gold}");
        }
    }
}