using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary
{
    public interface IBank
    {
        bool Validate(int cardNumber, int pin);
        bool Withdraw(int cardNumber, double amount);
        double GetBalance(int cardNumber);
    }
}
