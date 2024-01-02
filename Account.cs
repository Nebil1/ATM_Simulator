using System;

namespace ATM_Simulator{

class Account
    {
        public string CardHolder { get; set; }
        public string AccountNumber { get; set; }
        public int Pin { get; set; }
        public string IdNumber { get; set; }
        public decimal Balance { get; set; }

        private List<string> transactionHistory = new List<string>();
    
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
        var transaction = new Transaction(CardHolder, TransactionType.Deposit, amount);
        transactionHistory.Add($"User: {CardHolder}, Time: {DateTime.Now}, Transaction: Withdraw, Amount: {amount};");
        SaveTransactionHistory();
    }

    public void Withdraw(decimal amount)
    {
        Balance -= amount;
        var transaction = new Transaction(CardHolder, TransactionType.Withdraw, amount);
        transactionHistory.Add($"User: {CardHolder}, Time: {DateTime.Now}, Transaction: Withdraw, Amount: {amount};");
        SaveTransactionHistory();
    }

    private void SaveTransactionHistory()
    {
        try
        {
            System.IO.File.WriteAllLines("transactionHistory.txt", transactionHistory);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n{ex.Message}");
        }
    }
  }
}