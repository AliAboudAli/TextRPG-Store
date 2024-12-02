namespace RPG_Store.Items
{
    /// <summary>
    /// we moeten methode displaystatus overscrhijven om specifieke eigenschappen te tonen, om het erfelijkheid van item mee tenemen naar child
    /// constructor wordt gebruikt om alle relevante gegevens van een potion object direct bij het maken van het object in te stellen
    /// andere subklassen zijn indentiek behalve de nieuwe eigenschappen wat een logische reden heeft en past bij de item
    /// </summary>
    public class Potion : Item //afgeleid van item alle eigenschappen kunnen hergebruikt worden, potions is al een item dus we hoeven niet nog een keer schrijven
    {
        //eigenschappen die item niet heeft maar anders is dan item
        public string Effect { get; set; }
        public int Power { get; set; }
        
        
        //constructor voor potion eigenschappen 
        public Potion(string name, int price, int stock, int gold, string effect, int power) //effect en power zijn eigenschappen die nieuw zijn
            : base(name, price, stock, gold) //base roept de contructor van item aan
        {
            Effect = effect;
            Power = power;
        }

        public override void DisplayStatus() //overschrijf van DisplayStatus van item
        {
            base.DisplayStatus();
            Console.WriteLine($"Effect: {Effect}, Power: {Power}");
        }
    }
}