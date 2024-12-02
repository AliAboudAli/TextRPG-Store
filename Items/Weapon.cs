namespace RPG_Store.Items
{
    public class Weapon : Item
    {
        public int Damage { get; set; }
        public int Range { get; set; }
        public int Speed { get; set; }

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
            Console.WriteLine($"Damage: {Damage}, Range: {Range}, Speed: {Speed}");
        }
    }
}