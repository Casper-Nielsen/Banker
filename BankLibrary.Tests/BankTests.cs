﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankLibrary.Tests
{
    public class BankTests
    {
        private IBank Setup()
        {
            IAccountManager accountManager = new AccountManager();
            accountManager.AddAccount(new Account(1000, 5352), 1000);
            accountManager.AddAccount(new Account(1000, 5352), 2000);
            return new Bank(accountManager);
        }

        [Theory]
        [InlineData(1000, 5352, true)]
        [InlineData(2000, 5235, false)]
        public void Validate_SimpleCardAndPinShouldValidate(int x, int y, bool expected)
        {
            // Arrage
            IBank bank = Setup();
            // Act
            bool actual = bank.Validate(x, y);
            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1000, 10, true)]
        [InlineData(2000, 100, true)]
        [InlineData(2000, 1001, false)]
        public void Withdraw_SimpleValueShouldWithdraw(int x, int y, bool expected)
        {
            // Arrage
            IBank bank = Setup();
            // Act
            bool actual = bank.Validate(x, y);
            // assert
            Assert.Equal(expected, actual);
        }
    }
}