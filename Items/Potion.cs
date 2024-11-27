namespace RPG_Store.Items;

public class Potion : Item
{
    private string Effect { get; set; }
    private float Duration { get; set; }
    private bool Drinkable { get; set; }

    public Potion(string name, int stock, int price, int gold, string effect, float duration, bool drinkable)
        : base(name, stock, price, gold)
    {
        Effect = effect;
        Duration = duration;
        Drinkable = drinkable;
    }

    public override void DisplayStatus()
    {
        base.DisplayStatus();
        Console.WriteLine($"Effect: {Effect}");
        Console.WriteLine($"Duration: {Duration} minutes");
        Console.WriteLine($"Drinkable: {Drinkable}");
    }
}