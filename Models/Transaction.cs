using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq.Expressions;

namespace BankingApp;

class TransactionBase
{
    static public void Wellcome_screen(CurrentAccount account)
    {
        while (true)
        {
            int choice = 0;
            Menu(account);
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.Write("\nTry Again: ");
            }
            switch (choice)
            {
                case 0:
                    Console.Clear();
                    return;
                case 1:
                    ShowBalance(account);
                    break;
                case 2:
                    MobileRecharge(account);
                    break;
                case 3:
                    SendMoney(account);
                    break;
                case 4:
                    FeesPayments(account);
                    break;
                case 5:
                    BillPayment(account);
                    break;
                case 6:
                    Program.Exit();
                    Environment.Exit(0);
                    break;
            }
        }
    }
    static private void Menu(CurrentAccount account)
    {
        Console.Clear();
        Console.WriteLine($"Wellcome Sir {account.Name} Account # {account.Account_Id}");
        Console.WriteLine("\n1. Check Balance.");
        Console.WriteLine("2. Mobile Load.");
        Console.WriteLine("3. Send Money.");
        Console.WriteLine("4. Fees Payment.");
        Console.WriteLine("5. Bill Payment.");
        Console.WriteLine("6. Exit.");
        Console.WriteLine("0. Main Menu");
        Console.Write("Enter Your Choice: ");
    }
    static private void ShowBalance(CurrentAccount account)
    {
        Console.Clear();
        Console.WriteLine("*** Check Balance ***");
        Console.WriteLine($"Your Balance is {CheckBalance(account)}$ ");
        Console.WriteLine("\nPress Any key to back...");
        Console.ReadKey();
        return;
    }
    static private float CheckBalance(CurrentAccount account)
    {
        return account.Balance;
    }
    static private void MobileRecharge(CurrentAccount account)
    {
        Console.Clear();
        if (account.Balance == 0 || account.Balance <= 50)
        {
            Console.WriteLine("Your Balance is Insuffisent For this Transaction.");
            Console.WriteLine("Press any Key to Back...");
            Console.ReadKey(true);
            return;
        }
        Console.WriteLine("*** Mobile Recharge ***");
        string PhoneNo = Validation.GetValidMobileNo();
        float? RechargeAmount = Validation.GetAmountValid("Enter Amount (50 - 500): ");
        account.Balance -= RechargeAmount.Value;
        Console.WriteLine("Mobile Recharge Suucessfully Done!");
        Console.WriteLine("Press Any Key to Back...");
        Console.ReadKey();
    }
    static private void SendMoney(CurrentAccount account)
    {
        Console.Clear();
        Console.WriteLine("*** Send Money ***");
        Console.Write("Enter Account Number.(Without CUR-): ");
        string account_number = Validation.GetValidAccountNumber();

        CurrentAccount secondAccount = Program.FindAccountNumber(account_number);
        if (secondAccount == null)
        {
            Console.WriteLine($"{account_number} is Not found!");
            Console.WriteLine("Press any Key to back...");
            Console.ReadKey(true);
            return;
        }
        float? amount = Validation.GetAmountValid(account.Balance);
        account.Balance -= amount.Value;
        secondAccount.Balance += amount.Value;
        Console.WriteLine($"Transfer {amount}$ to {secondAccount.Account_Id} Successfully.");
        Console.WriteLine("Press any Key to back...");
        Console.ReadKey(true);
    }
    static private void FeesPayments(CurrentAccount account)
    {
        Console.Clear();
        Console.WriteLine("*** Fees Payments ***");
        Console.WriteLine("-- Here You can Pay Your fees by Using your Student ID --");
        Console.Write("Enter Your Student ID: ");
        string StudentID = Console.ReadLine();
        int fees = Validation.fees();
        Report(account, StudentID, fees,"Student", "Fees Payment");
        Payment(account, fees);
    }
    static private void BillPayment(CurrentAccount account)
    {
        Console.Clear();
        Console.WriteLine("*** Bill Payments ***");
        Console.Write("Enter Your Bill ID: ");
        string Id = Console.ReadLine();
        int BillAmount = Validation.fees();
        Report(account, Id, BillAmount, "Bill", "Bill Payment");
        Payment(account, BillAmount);
    }
    static private void Report(CurrentAccount account, string ID, int amount, string Bill_Student_type, string Fees_Bill_Payment)
    {
        Console.WriteLine("-------------------------");
        Console.WriteLine($"Your Name: {account.Name} ");
        Console.WriteLine($"Your {Bill_Student_type} ID: {ID} ");
        Console.WriteLine($"Your {Fees_Bill_Payment} is {amount}");
        Console.WriteLine("-------------------------");
    }
    static private void Payment(CurrentAccount account, int Amount)
    {
        Console.Write("You want to Pay Bill Payment Press (Y/N): ");
        var key = Console.ReadKey();
        if (!(key.KeyChar == 'Y' || key.KeyChar == 'y'))
        {
            Console.WriteLine("\nYou dno't Pay Your Fees.");
            Console.WriteLine("\nPress Any Key to back...");
            Console.ReadKey(true);
            return;
        }
        if ((int)CheckBalance(account) < Amount)
        {
            Console.WriteLine("Your Balance is Insufficient!");
            Console.WriteLine("Press Any Key to back...");
            Console.ReadKey(true);
            return;
        }
        account.Balance -= Amount;
        Console.WriteLine($"\nYour Bill Payment {Amount}$ is Successfully Payed!");
        Console.WriteLine("Press Any Key to back...");
        Console.ReadKey(true);
        return;
    }
}