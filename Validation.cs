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
    
}