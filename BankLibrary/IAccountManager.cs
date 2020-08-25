using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary
{
    public interface IAccountManager
    {
        Account GetAccount(int CardNumber);
        bool AddAccount(Account account, int CardNumber);
    }
}
