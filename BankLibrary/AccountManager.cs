﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary
{
    public class AccountManager : IAccountManager
    {
        Dictionary<string, Account> accounts;

        public AccountManager()
        {
            accounts = new Dictionary<string, Account>();
        }

        /// <summary>
        /// Adds a account with that cardnumber
        /// </summary>
        /// <param name="account">the account to add</param>
        /// <param name="CardNumber">the cardnumber the account goes with</param>
        /// <returns>if it was possible</returns>
        public bool AddAccount(Account account, string CardNumber)
        {
            if (accounts.ContainsKey(CardNumber))
            {
                return false;
            }
            else
            {
                accounts.Add(CardNumber, account);
                return true;
            }

        }

        /// <summary>
        /// gets the account for that card
        /// </summary>
        /// <param name="CardNumber">the cardnumber</param>
        /// <returns>the account with that cardnumber</returns>
        public Account GetAccount(string CardNumber)
        {
            if (accounts.ContainsKey(CardNumber))
            {
                return accounts[CardNumber];
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
