namespace RPG_Store.Items
{
    public class Armor : Item
    {
        public int Defense { get; set; }
        public int Handling { get; set; }

        public Armor(string name, int price, int stock, int gold, int defense, int handling)
            : base(name, price, stock, gold)
        {
            Defense = defense;
            Handling = handling;
        }

        public override void DisplayStatus()
        {
            base.DisplayStatus();
            Console.WriteLine($"Defense: {Defense}, Handling: {Handling}");
        }
    }
}