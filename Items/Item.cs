using RPG_Store.Store;

namespace RPG_Store.Items;

public class Item
{
    private Armor _armor;
    private Potion _potion;
    private Weapon _weapon;

    public int gold
    {
        get => gold = 0;
        set => gold = value;
    }

    //constructor
    public Item(Armor armor, Potion potion, Weapon weapon, int _gold)
    {
        //vergelijk de values
        _armor = armor;
        _potion = potion;
        _weapon = weapon;
        gold = _gold;
    }
}

public class Shop
{
    
    public void viewMenu(Armor, Potion, Weapon) //dit komt later als ik alles heb geschreven
    {
        //makkelijke menu voor alle items die straks inkomen
        // hergebruik je waardes die je aan de overige classes hebt toegediend
        // sla deze data op vanwege voorraadigheid van de items dus stel je hebt 4 zwaarden en dan zodra het op is dat vul het bij
    }

    /// <summary>
    ///  Dit wordt alles bij gehouden om het kopen en verkopen van items
    /// waarvan kan je eenvoudig winkel inventaries controleren of er genoeg items zijn.
    /// Ook kan je gemakkelijk verkopen in de inventory weet dat er een item is bij gekomen waardoor de goud als currcency eraf zal halen vanuit de winkel.
    /// Met transacties kunnen voldaan of niet dit wordt voldaan na de controle.    /// </summary>
    /// <param name="buyItem"></param>
    /// /// <param name="sellItem"></param>
    /// <returns></returns>

    //verkoop en koop methode
     public (bool isfinished, int stockUpdate, int balanceUpdate) storeLogic
        (bool isBuying, int itemStock, int itemPrice, int userbalanceGold, int inStock)
    {
        //kopen
        if (isBuying) // dit bepaalt of de gebruiker koopt of wilt verkopen
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
                
                return(false, itemStock, userbalanceGold);
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