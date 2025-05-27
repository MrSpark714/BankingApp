namespace BankingApp;

class TransactionBase : AccountBase
{
    public override void DisplayInfo()
    {
        // 
    }
    static public void Wellcome_screen(string Name, string ID)
    {
        Console.Clear();
        Console.WriteLine($"Wellcome To Sir {Name} Account # {ID}");
        Console.WriteLine("\n1. Check Balance.");
        Console.WriteLine("2. Deposite Cash.");
        Console.WriteLine("3. WithDraw Cash.");
        Console.WriteLine("4. Last Transaction.");
        Console.WriteLine("5. Exit.");
        Console.WriteLine("0. Account Mangement.");
        int choice = Convert.ToInt32(Console.ReadLine());
    }

}