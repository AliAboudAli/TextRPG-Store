namespace RPG_Store.Items
{
    public class Potion : Item
    {
        public string Effect { get; set; }
        public int Power { get; set; }

        public  string Type => "Potion"; //nodig voor het opslaan van de potion in de database op in de laden
        
        public Potion(string name, int price, int stock, int gold, string effect, int power)
            : base(name, price, stock, gold)
        {
            Effect = effect;
            Power = power;
        }

        public override void DisplayStatus()
        {
            base.DisplayStatus();
            Console.WriteLine($"Effect: {Effect}, Power: {Power}");
        }
    }
}