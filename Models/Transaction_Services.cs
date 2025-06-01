using System.Collections;

namespace BankingApp;
class TransactionService
{
    static public void Report(CurrentAccount account, string ID, int amount, string Bill_Student_type, string Fees_Bill_Payment)
    {
        Console.WriteLine("-------------------------");
        Console.WriteLine($"Your Name: {account.Name} ");
        Console.WriteLine($"Your {Bill_Student_type} ID: {ID} ");
        Console.WriteLine($"Your {Fees_Bill_Payment} is {amount} PKR.");
        Console.WriteLine("-------------------------");
    }
    static public void Payment(CurrentAccount account, int Amount, string Fees_Bill, string ID)
    {
        Console.Write($"You want to Pay {Fees_Bill} Payment Press (Y/N): ");
        var key = Console.ReadKey();
        if (!(key.KeyChar == 'Y' || key.KeyChar == 'y'))
        {
            Console.WriteLine("\nYou dno't Pay Your Fees.");
            Console.WriteLine("\nPress Any Key to back...");
            Console.ReadKey(true);
            return;
        }
        if ((int)account.Balance < Amount)
        {
            Console.WriteLine("\nYour Balance is Insufficient!");
            Console.WriteLine("Press Any Key to back...");
            Console.ReadKey(true);
            return;
        }
        account.Balance -= Amount;
        switch (Fees_Bill)
        {
            case "Fees Payments":
                TransactionSlip(account, Amount, Fees_Bill, ID);
                break;
            case "Bill Payments":
                TransactionSlip(account, Amount, Fees_Bill, ID);
                break;            
        }
    }
    static public void AccountDetails(CurrentAccount account)
    {
        Console.Clear();
        Console.WriteLine("\n-------------------------------------");
        Console.WriteLine("\t Account Details");
        Console.WriteLine($"Your Name: {account.Name}");
        Console.WriteLine($"Your Father Name: {account.Father_Name}");
        Console.WriteLine($"Your CNIC: {account.CNIC}");
        Console.WriteLine($"Your Age: {account.Age}");
        Console.WriteLine($"Your Date of Birth: {account.date_of_birth}");
        Console.WriteLine($"Your Account ID: {account.Account_Id}");
        Console.WriteLine($"Your Balance: {account.Balance} PKR");
        Console.WriteLine("Account Type : Current");
        Console.WriteLine("-------------------------------------");
        Console.WriteLine("Press Any to Key Back...");
        Console.ReadKey();
        return;
    }
    static public void TransactionSlip(CurrentAccount SenderAccount, CurrentAccount ReceiverAccount, float amount)
    {
        Console.Clear();
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("\t=== Transaction Successful ===");
        Console.WriteLine($"\t\t{DateTime.Now}");
        Console.WriteLine($"\t\tRs.{amount}");
        Console.WriteLine($"To:\t{ReceiverAccount.Name} | {ReceiverAccount.Account_Id}");
        Console.WriteLine($"From:\t{SenderAccount.Name} | {SenderAccount.Account_Id}");
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("Press any key to baack...");
        Console.ReadKey();
    }
    static public void TransactionSlip(CurrentAccount account, float amount, string MobileNumber)
    {
        Console.Clear();
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("\t=== Transaction Successful ===");
        Console.WriteLine($"\t\t{DateTime.Now}");
        Console.WriteLine($"\t\tRs.{amount}");
        Console.WriteLine("\t== Mobile Recharge ==");
        Console.WriteLine($"To:\t{MobileNumber}");
        Console.WriteLine($"From:\t{account.Name} | {account.Account_Id}");
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("Press any key to baack...");
        Console.ReadKey();
    }
    static private void TransactionSlip(CurrentAccount account, float amount, string Bill_Fees, string ID)
    {
        Console.Clear();
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("\t=== Transaction Successful ===");
        Console.WriteLine($"\t\t{DateTime.Now}");
        Console.WriteLine($"\t\tRs.{amount}");
        Console.WriteLine($"\t== {Bill_Fees} ==");
        Console.WriteLine($"To:\t{ID}");
        Console.WriteLine($"From:\t{account.Name} | {account.Account_Id}");
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("Press any key to baack...");
        Console.ReadKey();
    }
}