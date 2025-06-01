namespace BankingApp;
class Services
{
    private static CurrentAccount[] accounts = new CurrentAccount[50];
    internal static int current_Account_Index = 0;
    public static void CreateAccount()
    {
        CurrentAccount a1 = new CurrentAccount();
        bool account_status = false;

        Console.Clear();
        Console.WriteLine("*** Account Creation ***");
        Console.Write("Enter Your Name: ");
        a1.Name = Validation.GetValidName();

        Console.Write("Enter Your Father Name: ");
        a1.Father_Name = Validation.GetValidFatherName();

        a1.CNIC = Validation.IsCNICExist(accounts, current_Account_Index);

        Console.Write("Enter Your Age: ");
        a1.Age = Validation.GetValidAge();

        Console.Write("Enter Your Date of Birth (DDMMYYYY): ");
        a1.date_of_birth = Validation.GetValidDate();

        Console.Write("Enter Your Pin (4-Digits only): ");
        a1.Pin = Validation.GetValidPin();

        account_status = true;
        a1.account_status(account_status);

        // Adding new account into Array
        accounts[current_Account_Index] = a1;
        current_Account_Index++;
        Console.Clear();
        a1.DisplayInfo();
    }
    public static void Login()
    {
        if (current_Account_Index == 0)
        {
            Console.WriteLine("No Account Found ! Create a Account first:");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            return;
        }
        bool tryagain = true;
        while (tryagain)
        {
            bool loggedIn = false;
            Console.Clear();
            string cnic, pin;
            try
            {
                Console.Write("\nEnter Your CNIC Without Dash (-):");
                cnic = Validation.GetValidCNIC();
                Console.Write("\nEnter Your PIN: ");
                pin = Validation.GetValidPin();

                CurrentAccount account = FindAccount(cnic, pin);

                if (account != null)
                {
                    TransactionBase.Wellcome_screen(account);
                    tryagain = false;
                    loggedIn = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine("Press any Key to try again...");
                Console.ReadKey();
                continue;
            }

            if (!loggedIn)
            {
                Console.WriteLine("Error : CNIC Or PIN is Incorrect!");
                Console.WriteLine("Press (0) to Main Menu Or Any Key to Try Again...");
                var Key = Console.ReadKey(true);
                if (Key.KeyChar == '0') return;
            }
        }
    }
    private static CurrentAccount FindAccount(string cnic, string pin)
    {
        for (int i = 0; i < current_Account_Index; i++)
        {
            if (accounts[i] != null && cnic == accounts[i].CNIC && pin == accounts[i].Pin)
            {
                return accounts[i];
            }
        }
        return null;
    }
    public static CurrentAccount FindAccountNumber(string AccountNumber)
    {
        for (int i = 0; i < current_Account_Index; i++)
        {
            if (accounts[i] != null && AccountNumber == accounts[i].Account_Id)
            {
                return accounts[i];
            }
        }
        return null;
    }
    static public void Exit()
    {
        Console.WriteLine("\t Thanks for Using Our Services!");
        Console.WriteLine("Press Any Key to Complete Exit....");
        Console.ReadKey(true);
        return;
    }
    static public int fees()
    {
        Random random = new Random();
        return random.Next(1000, 1200);
    }
    static public void About()
    {
        Console.Clear();
        Console.WriteLine("-------------------------------------");
        Console.WriteLine("\t     About Us");
        Console.WriteLine("  Banking Console Application");
        Console.WriteLine("Application Version : 1.0 v");
        Console.WriteLine("Uploaded On GitHub Dated: 1/June/2025");
        Console.WriteLine("\n Press Any Key to back...");
        Console.ReadKey();
        Console.Clear();
        return;
    }
}