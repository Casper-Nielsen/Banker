using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary
{
    public interface IBank
    {
        bool Validate(string cardNumber, int pin);
        bool Withdraw(string cardNumber, double amount);
        double GetBalance(string cardNumber);
    }
}
