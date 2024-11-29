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
         else
         {
             //laat je inventory zien dan zij het zoeken naar elk item in de inventory
             Console.WriteLine("Your inventory:");
             foreach (var item in inventory)
             {
                 item.DisplayStatus();//toon de item in de inventory van de winkel sinkel
             }
         }
     }
     //item wordt verwijderd als de gebruiker iets koopt in de winkel
     public void RemoveItem(Item item)
     {
         inventory.Remove(item);
     }
     
     /// <summary>
     /// willekeurige genereert de inventory(winkel)
     /// items kunnen leeg in de inventory zijn (niet beschikbaar)
     /// </summary>
     //laat een willekeurige nieuwe items genereren en toe te voegen aan de inventory
     public void GenerateItems()
     {
         inventory.Clear();
         int numItems = rand.Next(5, 10);
         
         //aantal willekeurige items 
         for (int i = 0; i < numItems; i++)
         {
             int stock = rand.Next(0, 20);
             int price = rand.Next(5, 55);
             int value = rand.Next(10, 100);
             
             
             switch (rand.Next(3))
             {
                 case 0:
                     Additems(new Weapon($"Sword {i + 1}", price, stock, value, 
                         rand.Next(5, 30), 
                           rand.Next(10, 50),
                           rand.Next(5, 70)
                     ));
                     break;
                 
                 case 1:
                     Additems(new Armor($"Armor {i + 1}", price, stock, value,
                         rand.Next(1, 100),
                         rand.Next(2, 30)
                         ));
                     break;
                 case 2 :
                     Additems(new Potion($"Potion {i + 1}" , price, stock, value,
                         "Healing",
                         rand.Next(1, 55),
                         true
                     ));
                     break;
             }
         }
         DisplayItems();
     }
}