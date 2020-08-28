using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary
{
    public interface IAccountManager
    {
        Account GetAccount(string CardNumber);
        bool AddAccount(Account account, string CardNumber);
    }
}
