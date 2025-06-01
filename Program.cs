namespace BankingApp;
class Program
{
    public static void Main(string[] args)
    {
        Console.Title = "Banking Application";
        Console.WriteLine("\n\tWellcome To Bank\n");
        while (true)
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("1: Login for Existing Account.");
            Console.WriteLine("2: Create a New Account.");
            Console.WriteLine("3: About Us.");
            Console.WriteLine("4: Exit.");
            Console.Write("Enter Your Choice: ");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid Input! Please enter a Number: ");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Services.Login();
                    break;
                case 2:
                    if (Services.current_Account_Index == 50)
                    {
                        Console.WriteLine("Maximum Account Limit Reached (50 Accounts).");
                        break;
                    }
                    Services.CreateAccount();
                    break;
                case 3:
                    Services.About();
                    break;
                case 4:
                    Services.Exit();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice! Try again: ");
                    break;
            }
        }
    } 
}