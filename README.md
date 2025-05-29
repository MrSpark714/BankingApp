# Banking Console Application 🏦

A secure console-based banking system developed in C# that demonstrates core Object-Oriented Programming principles.


## Features ✨

- **Account Management**
  - Create new accounts with validation
  - Login system with PIN protection
  - Account information display

- **Financial Operations**
  - Balance inquiry
  - Money transfers between accounts
  - Mobile recharge
  - Bill payments
  - Fees payments

- **Security**
  - CNIC validation
  - PIN entry masking
  - Age verification (18+)

## Technology Stack 💻

- C# (.NET Core)
- Object-Oriented Programming
- Console Application Architecture

## System Design 🏗️

```mermaid
classDiagram
    class AccountBase{
        <<abstract>>
        +string Name
        +string CNIC
        +DisplayBasicInfo()
        +abstract DisplayInfo()
    }
    
    class CurrentAccount{
        +GenerateAccountID()
        +account_status()
    }
    
    class Validation{
        +GetValidCNIC()
        +GetValidPin()
        +IsCNICExist()
    }
    
    class TransactionBase{
        +Welcome_screen()
        +MobileRecharge()
        +SendMoney()
    }
    
    AccountBase <|-- CurrentAccount
    TransactionBase --> CurrentAccount