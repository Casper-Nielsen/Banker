using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary
{
    public class Bank : IBank
    {
        private IAccountManager accountManager;
        public Bank(IAccountManager accountManager)
        {
            this.accountManager = accountManager;
        }

        public double GetBalance(int cardNumber)
        {
            throw new NotImplementedException();
        }

        public bool Validate(int cardNumber, int pin)
        {
            return accountManager.GetAccount(cardNumber).Pin == pin;
        }

        public bool Withdraw(int cardNumber, double amount)
        {
            throw new NotImplementedException();
        }
    }
}
