using RPG_Store.Items;

namespace RPG_Store.Store;

public class Inventory
{
     public List<Item> invent = new List<Item>();
     public Random rand = new Random();

     //toevoegen van items aan de inventaris
     public void Additems(Item item)
     {
         invent.Add(item);
     }
     //laat tonen hoeveel items er in de inventaris staan
     public void DisplayItems()
     {
         if (invent.Count == 0)
         {
             Console.WriteLine("We don't have any items due to black friday and cyber monday :/");
             return;
         }

         //laat je inventory zien dan zij het zoeken naar elk item in de inventory
         Console.WriteLine("Your inventory:");
         foreach (var item in invent)
         {
             Console.WriteLine(item);
         }
     }
     
     public void RemoveItem(Item item)
     {
         invent.Remove(item);
     }
     //items die bijgehouden worden hoeveel per wapen nog zijn
}