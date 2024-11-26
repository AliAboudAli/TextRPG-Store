using RPG_Store.Items;
namespace RPG_Store.Store;

public class Inventory
{
     public List<Item> inventory = new List<Item>();
     public Random rand = new Random();

     //toevoegen van items aan de inventaris
     public void Additems(Item item)
     {  
         inventory.Add(item); //voeg de item toe aan de inventory
     }
     //laat tonen hoeveel items er in de inventaris staan
     public void DisplayItems()
     {
         if (inventory.Count == 0) // dit statement controleert of de inventory is leeg
         {
             Console.WriteLine("We don't have any items due to black friday and cyber monday :/");
             return;
         }

         //laat je inventory zien dan zij het zoeken naar elk item in de inventory
         Console.WriteLine("Your inventory:");
         foreach (var item in inventory)
         {
             item.DisplayStatus();//toon de item in de inventory van de winkel sinkel
         }
     }
     //item wordt verwijderd als de gebruiker iets koopt in de winkel
     public void RemoveItem(Item item)
     {
         inventory.Remove(item);
     }
     //laat een willekeurige nieuwe items genereren en toe te voegen aan de inventory
     public void GenerateItems()
     {
         //aantal willekeurige items 
         for (int i = 0; i < rand.Next(1, 6); i++)
         {
             var newItem = new Weapon($"Sword {i + 1}",rand.Next(50, 200), rand.Next(1, 10), 100, rand.Next(10, 50));
             Additems(newItem); //dit voegt willekeurige item toe aan de inventory
         }
     }
}