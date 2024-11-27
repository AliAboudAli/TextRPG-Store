namespace RPG_Store.Items;

public class Armor : Item
{
    private int Defense { get; }
    private int Handeling { get; }

    public Armor(string name, int price, int stock, int gold, int defense, int handeling)
        : base(name, price, stock, gold)
    {
        Defense = defense;
        Handeling = handeling;
    }

    public override void DisplayStatus()
    {
        base.DisplayStatus();
        Console.WriteLine("Defense: " + Defense);
        Console.WriteLine("Handeling: " + Handeling);
    }
}