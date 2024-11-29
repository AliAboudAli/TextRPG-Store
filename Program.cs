using RPG_Store.Store;

namespace RPG_Store;
class Program
{
    static void Main(string[] args)
    {
        RunShop run = new RunShop(); //Niels vindt dit prettig :)
        run.Loop();
    }
}