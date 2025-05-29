using System;
using System.Globalization;
namespace BankingApp;

class Validation
{
    public static string GetValidName()
    {
        while (true)
        {
            string name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
            {
                return name;
            }
            else
            {
                Console.Write("Invalid Name! Try again: ");
            }
        }
    }
    public static string GetValidFatherName()
    {
        while (true)
        {
            string input_father_name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input_father_name))
            {
                return input_father_name;
            }
            else
            {
                Console.Write("Invalid Argument! Try again: ");
            }
        }
    }
    public static string GetValidCNIC()
    {
        while (true)
        {
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                string NewInput = new string(input.Where(char.IsDigit).ToArray());

                if (NewInput.Length == 13)
                {
                    return NewInput;
                }
                else
                {
                    Console.Write(NewInput.Length < 13 ?
                     "Too Short ! Must be 13 Digits. Please Try again: " :
                     "Too long! Must be 13 digits. Please Try again: ");
                }
            }
            else
            {
                Console.WriteLine("CNIC cannot be Empty! Try Again: ");
            }
        }
    }
    public static int GetValidAge()
    {
        while (true)
        {
            int input_age = Convert.ToInt32(Console.ReadLine());
            if (input_age <= 0)
            {
                Console.Write("Invalid Input! Try Again: ");
                continue;
            }
            if (input_age >= 18)
            {
                return input_age;
            }
            else
            {
                Console.WriteLine("Error: You are under Age So don't create an Account. ");
                return 0;
            }
        }
    }
    public static string GetValidDate()
    {
        while (true)
        {
            string input_dob = Console.ReadLine();
            if (string.IsNullOrEmpty(input_dob) || input_dob.Length < 8)
            {
                Console.Write("Invalid Input! Try again: ");
            }
            if (input_dob.Length == 8)
            {
                string formatted = $"{input_dob.Substring(0, 2)}-{input_dob.Substring(2, 2)}-{input_dob.Substring(4)}";
                if (DateTime.TryParseExact(formatted, "dd-MM-yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
                {
                    return formatted;
                }
                else
                {
                    Console.Write("Invalid date! Try again (DDMMYYYY): ");
                }
            }
        }
    }
    public static string GetValidPin()
    {
        while (true)
        {
            string pin = ReadPin();
            if (pin.Length == 4)
            {
                return pin;
            }
            else
            {
                Console.Write("PIn must 4 Digits. Try Again: ");
            }
        }

    }
    static string ReadPin()
    {
        string pin = "";
        ConsoleKeyInfo key;
        while (true)
        {
            key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Enter) break;

            if (char.IsDigit(key.KeyChar))
            {
                pin += key.KeyChar;
            }
        }
        return pin;
    }
    static public float? GetAmountValid(float balance)
    {
        while (true)
        {
            Console.Write("Enter amount: ");
            string input = Console.ReadLine();

            if (float.TryParse(input, out float amount))
            {
                if (balance < amount)
                {
                    Console.WriteLine("Your Balance is Insufficient!");
                    return 0;
                }
                if (amount >= 0 && amount <= balance)
                {
                    return amount;
                }

                Console.WriteLine("Amount must be positive. Try again.");
            }
            else
            {
                Console.WriteLine("Invalid number format. Try again.");
            }
        }
    }
    static public string IsCNICExist(CurrentAccount[] a, int CAI)
    {
        while (true)
        {
            Console.Write("Enter CNIC (Without Dashes): ");
            string CNIC = GetValidCNIC();
            if (!(IsCNICSame(a, CNIC, CAI)))
            {
                return CNIC;
            }
            Console.WriteLine("This CNIC is Already Taken. Try another CNIC: ");
        }
    }
    static private bool IsCNICSame(CurrentAccount[] a, string cnic, int CAI)
    {
        // CAI stands for Current Account Index
        if (CAI == 0)
        {
            return false;
        }
        for (int i = 0; i < CAI; i++)
        {
            if (a[i] != null && a[i].CNIC == cnic)
            {
                return true;
            }
        }
        return false;
    }
    static public string GetValidMobileNo()
    {
        while (true)
        {
            Console.WriteLine("Enter Your Phone No(11 Digits): ");
            string input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input) && input.Length == 11)
            {
                return input;
            }
            else
            {
                Console.Write("Invalid Input! Try Again: ");
            }
        }
    }
    public static float GetAmountValid(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine();
            if (float.TryParse(input, out float amount))
            {
                if (amount >= 50 && amount <= 500)
                {
                    return amount;
                }
                Console.WriteLine("Invalid Amount. Try again.");
            }
            else
            {
                Console.WriteLine("Invalid number format. Try again.");
            }
        }
    }
    public static string GetValidAccountNumber()
    {
        while (true)
        {
            string input = Console.ReadLine();
            if (input.Length == 9)
            {
                return "CUR-" + input;
            }
            else
            {
                Console.Write("Invalid Input! Try Again: ");
            }
        }
    }
    static public int fees()
    {
        Random random = new Random();
        return random.Next(1000, 1200);
    }
}