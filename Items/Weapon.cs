namespace RPG_Store.Items;

public class Weapon : Item
{
    private int Damage { get; }
    private int Range { get; }
    private int Speed { get; }

    public Weapon(string name, int price, int stock, int gold, int damage, int range, int speed) 
       : base(name, price, stock, gold)
    {
        Damage = damage;
        Range = range;
        Speed = speed;
    }

    public override void DisplayStatus()
    {
        base.DisplayStatus();
        Console.WriteLine("Damage: " + Damage);
        Console.WriteLine("Range: " + Range);
        Console.WriteLine("Speed: " + Speed);
    }
}