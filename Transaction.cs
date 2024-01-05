using System;

namespace ATM_Simulator;

    public enum TransactionType
    {
        Deposit,
        Withdraw
    }
    
    class Transaction
    {
        public string AccountNumber { get; set; }
        public TransactionType Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime Timestamp { get; set; }

        public Transaction(string accountNumber, TransactionType type, decimal amount)
        {
            AccountNumber = accountNumber;
            Type = type;
            Amount = amount;
            Timestamp = DateTime.Now;
        }

        public string GetTransactionDetails()
        {
            return $"Account: {AccountNumber}, Time: {Timestamp}, Transaction: {Type}, Amount: {Amount}";
        }
    }