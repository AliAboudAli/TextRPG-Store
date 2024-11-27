namespace RPG_Store;

public class Shop
{
    //Menu voor de winkel
    public void ViewMenu()
    {
        //fabro is referenced van AC 2 
        Console.WriteLine("Welcome visitor to Fabro!");
        Console.WriteLine("Number 1 : Inventory");
        Console.WriteLine("Number 2 : Buy");
        Console.WriteLine("Number 3 : Sell");
        Console.WriteLine("Number 4 : Add item");
        Console.WriteLine("Number 5 : Leave Fabro");
    }
    //verkoop en koop methode
    /// <summary>
    /// Dit wordt alles bij gehouden om het kopen en verkopen van items
    /// waarvan kan je eenvoudig winkel inventaries controleren of er genoeg items zijn.
    /// Ook kan je gemakkelijk verkopen in de inventory en weet dat er een item is bij gekomen waardoor de goud als currcency eraf zal halen vanuit de winkel.
    /// Met transacties kunnen voldaan of niet dit wordt voldaan na de controle./// </summary>
    /// <param name="buyItem"></param>
    /// /// <param name="sellItem"></param>
    /// <returns></returns>
    public (bool isfinished, int stockUpdate, int balanceUpdate) storeLogic
        (bool isBuying, int itemStock, int itemPrice, int userbalanceGold, int inStock)
    {
        //kopen is waar
        if (isBuying) // dan bepaal of de gebruiker koopt of wilt verkopen
        {
            //controleert of er genoeg in de inventory is en er genoeg goud is
            if (itemStock >= inStock && userbalanceGold >= (itemPrice * inStock))
            {
                itemStock -= inStock;
                userbalanceGold -= itemStock * itemPrice;
                return (true, itemStock, userbalanceGold);
            }
            else
            {
                /*transactie niet goed verlopen
                als de controle niet voldoende saldo aan goud heb dan stuurt het naar deze else statement
                false terug sturen als de gebruiker niet voldoende saldo heeft */

                return (false, itemStock, userbalanceGold);
            }
        }
        else //verkopen
        {
            // update de instock en voeg goud toe aan de gebruiker
            itemStock += inStock;
            userbalanceGold += itemStock * itemPrice;
            return (true, itemStock, userbalanceGold);
        }
    }
}