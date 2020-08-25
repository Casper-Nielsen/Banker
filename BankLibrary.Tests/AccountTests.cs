using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using BankLibrary;

namespace BankLibrary.Tests
{
    public class AccountTests
    {
        [Theory]
        [InlineData(5,5)]
        [InlineData(500, 500)]
        public void GetBalance_shouldGetBalance(double x, double expected)
        {
            // Arrage
            Account account = new Account(x,1111);
            // Act
            double actual = account.GetBalance();
            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(5, 5, true)]
        [InlineData(50, 500, false)]
        [InlineData(500, 50, true)]
        [InlineData(500, -50, false)]
        public void Withdraw_simpleValuesShouldWithdraw(double x, double y, bool expected)
        {
            // Arrage
            Account account = new Account(x, 1111);
            // Act
            bool actual = account.Withdraw(y);
            // assert
            Assert.Equal(expected, actual);
        }
    }
}
