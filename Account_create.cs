using System;
namespace BankingApp;
class Account_create{
    #region Data Members (variables)
    private string User_Name;
    private int Age;
    private string date_of_birth;
    private string CNIC;
    private string Father_Name;
    private static int Unique_Id = 6996910;
    private int Account_Id;
    private string _pin;
       #endregion
    #region Properties of Data Members (Getter & Setter)
    public string Name{
        get {return User_Name;}
        set {User_Name = value;}
    }
    public int age{
        get {return Age;}
        set {Age = value;}
    }
    public string father{
        get {return Father_Name;}
        set {Father_Name = value;}
    }
    public string cnic{
        get {return CNIC;}
        set { CNIC = value; }
}
    public string dob{ //Date of birth
        get {return date_of_birth;}
        set {date_of_birth = value;}
    }
     public int Id{
        get {return Account_Id;}
    }
    public string Pin{
        get {return _pin;}
        set {_pin = value;}
    }
    #endregion
    public void DisplayInfo(){  
        Console.WriteLine("\n-------------------------------------\n");
        Console.WriteLine($"Your Name: {Name}");
        Console.WriteLine($"Your Father Name: {father}");
        Console.WriteLine($"Your CNIC: {cnic}");
        Console.WriteLine($"Your Age: {age}");
        Console.WriteLine($"Your Date of Birth: {dob}");
        Console.WriteLine($"Your Account Number: {Id}");
        Console.WriteLine("*** Account Created Successfully ***");
        Console.WriteLine("------------------------------------------");
    }

    public Account_create(){ // constructor call 
        Unique_Id++;
        Account_Id = Unique_Id;
    }

}
