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

        /// <summary>
        /// gets the balance of the account with that cardnumber
        /// </summary>
        /// <param name="cardNumber">the cardnumber for the account</param>
        /// <returns>the balance</returns>
        public double GetBalance(string cardNumber)
        {
            return accountManager.GetAccount(cardNumber).GetBalance();
        }

        /// <summary>
        /// validates if the cardnumbers account uses the pin code
        /// </summary>
        /// <param name="cardNumber">the cardnumber for the account</param>
        /// <param name="pin">the pin code</param>
        /// <returns>if it is validate</returns>
        public bool Validate(string cardNumber, int pin)
        {
            return accountManager.GetAccount(cardNumber).Pin == pin;
        }

        /// <summary>
        /// withdraws some money for the account
        /// </summary>
        /// <param name="cardNumber">the cardnymber</param>
        /// <param name="amount">the amount that will be withdraws</param>
        /// <returns>if it was posible</returns>
        public bool Withdraw(string cardNumber, double amount)
        {
            if (accountManager.GetAccount(cardNumber).GetBalance() >= amount)
            {
                accountManager.GetAccount(cardNumber).Withdraw(amount);
                return true;
            }
            return false;
        }
    }
}
