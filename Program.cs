using System;
namespace BankingApp;
class Program{
    private static Account_create[] accounts = new Account_create[50];
    private static int current_Account_Index = 0;
    public static void Main(string[] args)
    {

        Console.WriteLine("\tWellcome To Bank\n");
        while (true)
        {
            Console.WriteLine("1: If you have an existing Account.");
            Console.WriteLine("2: Create a New Account.");
            Console.WriteLine("3: Exit.");
            Console.Write("Enter Your Choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch(choice){
                case 1:
                // Here making Atm processing
                case 2:
                    if(current_Account_Index == 50)
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
        Account_create a1 = new Account_create();

                #region [Name Input]
                Console.Write("Enter Your Name: ");
                while(true){
                    string input_name = Console.ReadLine();
                    if(!string.IsNullOrWhiteSpace(input_name)){
                        a1.Name = input_name;
                        break;
                    }
                    else{
                        Console.Write("Invalid Name! Try again: ");
                    }
                }
                #endregion

                #region [Father Name Input]
                Console.Write("Enter Your Father Name: ");
                while(true){
                    string input_father_name = Console.ReadLine();
                    if(!string.IsNullOrWhiteSpace(input_father_name)){
                        a1.father = input_father_name;
                        break;
                    }
                    else{
                        Console.Write("Invalid Argument! Try again: ");
                    }
                }
                #endregion 

                #region [Input CNIC Number]
                Console.Write("Enter Your CNIC (without Dash - ): ");
                while(true){
                    string input = Console.ReadLine();
                    if(!string.IsNullOrWhiteSpace(input)){
                        string NewInput = new string(input.Where(char.IsDigit).ToArray());

                        if(NewInput.Length == 13){
                            a1.cnic = NewInput;
                            break;
                        }
                        else{
                            Console.Write(NewInput.Length < 13 ?
                             "Too Short ! Must be 13 Digits. Please Try again: ":
                             "Too long! Must be 13 digits. Please Try again: " );
                        }
                    }
                    else{
                        Console.WriteLine("CNIC cannot be Empty! Try Again: ");
                    }
                }
                #endregion
                
                #region [Input Age User]
                Console.Write("Enter Your Age: ");
                while(true){
                int input_age = Convert.ToInt32(Console.ReadLine());
                if(input_age >= 18){
                    a1.age = input_age;
                    break;
                }
                else{
                    Console.Write("Error: You are under Age So don't create an Account. ");
                    break;
                    }
                }
                #endregion

                #region [Input Date of birth]
                Console.Write("Enter Your Date of Birth (DDMMYYYY): ");
                while(true){
                string input_dob = Console.ReadLine();
                if(input_dob.Length == 8 || string.IsNullOrEmpty(input_dob)){
                    a1.dob = input_dob;
                    break;
                  }
                else{ Console.Write("Invalid Input! Try again: "); }  
                }
                #endregion

                #region [Input Pin Passward]
                Console.WriteLine("Enter Your Pin Password (4-Digits only): ");
                while(true){
                string input_pin = Console.ReadLine();
                if(input_pin.Length == 4 || string.IsNullOrEmpty(input_pin)){
                    a1.Pin = input_pin;
                    break;
                  }
                else{ Console.Write("Invalid Input! Try again: "); }  
                }
                #endregion

                // Adding new account into Array
                accounts[current_Account_Index] = a1;
                current_Account_Index++;
                a1.DisplayInfo();
    }
}