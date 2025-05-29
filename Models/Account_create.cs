using System;
namespace BankingApp;
abstract class AccountBase{
    
    #region Private Variable
    private string _name;
    private string _fathername; 
    private int _age;
    private string _cnic;
    private string _date_of_birth;
    private string _Account_Id;
    private string _pin;
    private float _balance;
    #endregion

    #region Common Propeties
    // public bool is_account_created;
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public int Age{
        get{return _age;} set{ _age = value;}
    }
    public string Father_Name{
        get{return _fathername;} set{ _fathername = value;}
    }
    public string CNIC{
        get{return _cnic;} set{ _cnic = value;}
    }
    public string date_of_birth{ 
        get{return _date_of_birth;} set{ _date_of_birth = value;}
    }
     public string Account_Id{
        set{ _Account_Id = value;} get { return _Account_Id; }
    }
    public string Pin{
         set{_pin = value;}  get{return _pin;}
    }
    public float Balance
    {
        get{return _balance;} set{ _balance = value; }
    }

    #endregion

    #region Abstract Methods
    public abstract void DisplayInfo();

    #endregion

    #region Common Methods
    protected void DisplayBasicInfo()
    {
        Console.WriteLine("\n-------------------------------------");
        Console.WriteLine($"Your Name: {Name}");
        Console.WriteLine($"Your Father Name: {Father_Name}");
        Console.WriteLine($"Your CNIC: {CNIC}");
        Console.WriteLine($"Your Age: {Age}");
        Console.WriteLine($"Your Date of Birth: {date_of_birth}");
        Console.WriteLine($"Your Account ID : {_Account_Id}");
    }
    #endregion
}

class CurrentAccount : AccountBase{
    private static int AccountCount = 1;
    public string GenerateAccountID(){
        string id = $"CUR-2025{AccountCount.ToString("D5")}";
        AccountCount++;
        return id;
    }
    public override void DisplayInfo()
    {
        DisplayBasicInfo();
        Console.WriteLine("Account Type : Current");
        Console.WriteLine("*** Account Created Successfully ***");
        Console.WriteLine("--------------------------------------\n");
        Console.WriteLine("=> Press Any key to go Main Menu.");
        Console.ReadKey(true);
        Console.Clear();
    }
    public bool account_status(bool s)
    {
        if (s == true)
        {
            Account_Id = GenerateAccountID();
            Balance = 5000;
            return true;
        }
        else
        {
            return false;
        }
    }
    public CurrentAccount()
    { // constructor

    }
}