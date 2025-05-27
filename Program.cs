using System;
namespace BankingApp;

class Program
{
    private static CurrentAccount[] accounts = new CurrentAccount[50];
    private static int current_Account_Index = 0;
    public static void Main(string[] args)
    {

        Console.WriteLine("\n\tWellcome To Bank\n");
        while (true)
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("1: Login for Existing Account.");
            Console.WriteLine("2: Create a New Account.");
            Console.WriteLine("3: Exit.");
            Console.Write("Enter Your Choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Login();
                    break;
                case 2:
                    if (current_Account_Index == 50)
                    {
                        Console.WriteLine("Maximum Account Limit Reached (50 Accounts).");
                        break;
                    }
                    CreateNewAccount();
                    break;
                case 3:
                    Console.WriteLine("*** Thanks For Using ***");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice! Try again: ");
                    break;
            }
        }

    }
    // This Function is Helping to Create New Account
    private static void CreateNewAccount()
    {
        CurrentAccount a1 = new CurrentAccount();
        bool account_status = false;

        Console.Clear();
        Console.WriteLine("*** Account Creation ***");
        Console.Write("Enter Your Name: ");
        a1.Name = Validation.GetValidName();

        Console.Write("Enter Your Father Name: ");
        a1.Father_Name = Validation.GetValidFatherName();

        Console.Write("Enter Your CNIC (without Dash - ): ");
        a1.CNIC = Validation.GetValidCNIC();

        Console.Write("Enter Your Age: ");
        a1.Age = Validation.GetValidAge();

        Console.Write("Enter Your Date of Birth (DDMMYYYY): ");
        a1.date_of_birth = Validation.GetValidDate();

        Console.Write("Enter Your Pin (4-Digits only): ");
        a1.Pin = Validation.GetValidPin();

        account_status = true;
        if (account_status) { }
        a1.account_status(account_status);

        // Adding new account into Array
        accounts[current_Account_Index] = a1;
        current_Account_Index++;
        Console.Clear();
        a1.DisplayInfo();
    }
    private static void Login()
    {
        if (current_Account_Index == 0)
        {
            Console.WriteLine("No Account Found ! Create a Account first:");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return;
        }
        bool tryagain = true;
        while (tryagain)
        {
            Console.Clear();
            string cnic = "", pin = "";
            try
            {
                Console.Write("\nEnter Your CNIC Without Dash (-):");
                cnic = Validation.GetValidCNIC();
                Console.Write("\nEnter Your PIN: ");
                pin = Validation.GetValidPin();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine("Press any Key to try again...");
                Console.ReadKey();
                continue;
            } 
            bool loggedIn = false;
            for (int i = 0; i < current_Account_Index; i++)
            {
                if (accounts[i] != null && cnic == accounts[i].CNIC && pin == accounts[i].Pin)
                {
                    TransactionBase.Wellcome_screen(accounts[i].Name, accounts[i].Account_Id);
                    loggedIn = true;
                    tryagain = false;
                    break;
                }
            }
            if (!loggedIn)
            {
                Console.WriteLine("Error : CNIC Or PIN is Incorrect!");
                Console.WriteLine("Press (0) to Main Menu Or Any Key to Try Again...");
                var Key = Console.ReadKey();
                if (Key.KeyChar == '0') return;
            }
        }
    }
}