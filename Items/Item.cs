using RPG_Store.Store;
using RPG_Store.Items;

namespace RPG_Store.Items;

public abstract class Item
{
    private int _gold; 

    //eigenschap voor goud
    //veilig op te slaan voor goud waarde voor de currency
    public int gold
    {
        get => gold = 0; //stuurt de waarde van gold terug 
        set => gold = value; // stelt een waarde van goud in
    }
    
    //eigenschappen
    public string name { get; set; }
    public int price { get; set; }
    public int stock { get; set; }
    
    //constructor
    public Item(string Name, int Price, int Stock, int _gold)
    {
        name = Name;
        price = Price;
        stock = Stock;
        gold = _gold;
    }
    // weergaven voor info van item
    public virtual void DisplayStatus()
    {
        Console.WriteLine($"{name} =" +
                          $" price: {price} = In Stock: " + 
                                     $"{stock} = Gold: " +
                                     $"{gold}");
    }
}