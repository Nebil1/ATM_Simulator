using System;

namespace ATM_Simulator{

class Account
    {
        public string CardHolder { get; set; }
        public string AccountNumber { get; set; }
        public int Pin { get; set; }
        public string IdNumber { get; set; }
        public decimal Balance { get; set; }
    
    public Account(string cardHolder, string accountNumber, int pin, string idNumber, decimal balance)
    {
        CardHolder = cardHolder;
        AccountNumber = accountNumber;
        Pin = pin;
        IdNumber = idNumber;
        Balance = balance;
    }

    public void Deposit(decimal amount)
    {
        Balance += amount;
    }
    public void Withdraw(decimal amount)
    {
        Balance -= amount;
    }
  }
}