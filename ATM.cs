//using System;
using static System.Console;

namespace ATM_Simulator
{
   class ATM
   {
    private  List<Account> accounts; 
    private Logger logger = new Logger();
    
    enum MenuOption
    {
        CheckBalance = 1,
        Withdraw,
        Deposit,
        Exit
    }
    
    public ATM()
    {
        accounts = new List<Account>
        {
            new Account("John Smith", "100021", 1111, "123123123", 2000),
            new Account("Rose Smith", "100023", 2222, "321321321", 3000),
        };
    }

    static void Welcome()
    {
        WriteLine("======================================");
        WriteLine("||                                  ||");
        WriteLine("||              WELCOME             ||");
        WriteLine("||                                  ||");
        WriteLine("======================================");
    }

    Account Login()
    {
        Account? account = null;
        int attempts = 0;

        while (attempts < 3)
        {
            try{
                WriteLine("Please enter your card number");
                string? cardNumber = ReadLine();

                if (string.IsNullOrEmpty(cardNumber) || cardNumber.Length != 6)
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("\nInvalid input. Card number must be a 6 digit number");
                    ResetColor();
                    attempts++;
                    continue;
                }

                WriteLine("Please enter your pin");
                string? pinInput = ReadLine();
                int pin;

                if (!int.TryParse(pinInput, out pin) || pinInput.Length != 4)
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("\nInvalid pin, try again\n");
                    ResetColor();
                    attempts++;
                    continue;
                }
                account = accounts.FirstOrDefault(a => a.AccountNumber == cardNumber && a.Pin == pin);

                if (account != null)
                {
                    break;
                }
                else
                {
                    WriteLine("Invalid Card number or pin");
                    attempts++;
                }
            }
            catch (Exception ex)
            {
                WriteLine("An error occured: " + ex.Message);
                logger.LogSystemError(ex);
                attempts++;
            }
        }

        if (attempts == 3)
        {
            WriteLine("\nMaximum login attempts exceeded.");
        }

        return account;
    }

    public void Run()
    {
        Welcome();
        Account? account = Login();

        // Check if login was succesful
        if (account == null)
        {
            WriteLine("Login failed. Exiting program");
            return;
        }

        // Login successful
        WriteLine($"\nWelcome {account.CardHolder}\n");
        logger.LogSuccessfulLogin(account.CardHolder);
        logger.LogUserActivity(account.CardHolder, $" Log in at {DateTime.Now}");

        bool continueUsingATM = true;
        while(continueUsingATM)
        {
            if (account != null)
            {
                MenuOption option = DisplayMenuAndGetSelection();

                switch (option)
                {

                case MenuOption.CheckBalance:
                    ForegroundColor = ConsoleColor.Blue;
                    WriteLine($"\nYour balance is {account.Balance:C} \n");
                    logger.LogUserActivity(account.CardHolder, $" Checked balance of {account.Balance}");
                    ResetColor();
                    break;

                case MenuOption.Withdraw:
                    while (true)
                    {
                        WriteLine("\nPlease enter the amount you want to withdraw, or 'E' to exit");
                        string? input = ReadLine();

                        if (input.ToUpper() == "E")
                        {
                            break;
                        }

                        if (decimal.TryParse(input, out decimal amount))
                        {
                            if (amount > account.Balance)
                            {
                                ForegroundColor = ConsoleColor.Red;
                                WriteLine("\nInsufficient balance. \n");
                                ResetColor();
                            }
                            else
                            {
                                account.Withdraw(amount);
                                ForegroundColor = ConsoleColor.Green;
                                WriteLine($"\nWithdrawal successful. Your new balance is {account.Balance:C}\n");
                                logger.LogUserActivity(account.CardHolder, $" Withdrawal of {amount}");
                                ResetColor();
                                break;
                            }
                        }
                        else
                        {
                            ForegroundColor = ConsoleColor.Red;
                            WriteLine("\nInvalid input. Please enter a valid amount.\n");
                            ResetColor();
                        }
                    }
                    break;
                            
                case MenuOption.Deposit:
                    while (true)
                        {
                            WriteLine("\nPlease enter the amount you want to deposit, or 'E' to exit");
                            string? depositInput = ReadLine();
                            decimal depositAmount;

                            if (depositInput.ToUpper() == "E")
                            {
                                break;
                            }

                            if (decimal.TryParse(depositInput, out depositAmount))
                            {
                                account.Deposit(depositAmount);
                                ForegroundColor = ConsoleColor.Green;
                                WriteLine($"\nDeposit successful. Your new balance is {account.Balance:C}\n");
                                logger.LogUserActivity(account.CardHolder, $" Deposit of {depositAmount}");
                                ResetColor();
                                break;
                            }
                            else
                            {
                                ForegroundColor = ConsoleColor.Red;
                                WriteLine("\nInvalid input. Please enter a valid amount.\n");
                                ResetColor();
                            }
                        }
                    break;

                case MenuOption.Exit:
                    WriteLine("\nThank you for using our ATM");
                    logger.LogUserActivity(account.CardHolder, $" Log out at {DateTime.Now}");
                    continueUsingATM = false;
                    break;
                    
                default:
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("Invalid option");
                    ResetColor();
                    break;
                }
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("\nInvalid card number or pin \n");
                ResetColor();

                WriteLine("Do you want to try again? (Y/N)");
                string? answer = ReadLine();
                if (answer == "y" || answer == "Y")
                {   
                    Clear();
                    Login();
                }
                else
                {
                    ForegroundColor = ConsoleColor.DarkBlue;
                    WriteLine("\nThank you for using our ATM\n");
                }
            }      
        }
    }

    MenuOption DisplayMenuAndGetSelection()
    {
        ForegroundColor = ConsoleColor.Yellow;
        WriteLine("Please select an option");
        WriteLine("1. Check Balance");
        WriteLine("2. Withdraw");
        WriteLine("3. Deposit");
        WriteLine("4. Exit");
        ResetColor();

        string? option = ReadLine();
        int optionInt;
        if (int.TryParse(option, out optionInt) && Enum.IsDefined(typeof(MenuOption), optionInt))
        {
            return (MenuOption)optionInt;
        }
        else
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine("\nInvalid input. Please enter a number between 1 and 4.\n");
            ResetColor();
            return DisplayMenuAndGetSelection(); // Recursively call the method until a valid input is received
        }
    }
  }
}