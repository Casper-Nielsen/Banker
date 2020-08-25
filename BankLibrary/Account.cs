using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary
{
    public class Account
    {
        private double balance;
        public int Pin { get; private set; }

        public Account(double balance, int pin)
        {
            this.balance = balance;
            Pin = pin;
        }
        /// <summary>
        /// gets the balance
        /// </summary>
        /// <returns>balance</returns>
        public double GetBalance()
        {
            return balance;
        }

        /// <summary>
        /// withdraw the amount if balance is over
        /// </summary>
        /// <param name="amount">the amount to withdraw</param>
        /// <returns>if it is done</returns>
        public bool Withdraw(double amount)
        {
            if (amount > 0 && balance >= amount)
            {
                balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
