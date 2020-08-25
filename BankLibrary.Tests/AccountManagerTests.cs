using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankLibrary.Tests
{
    public class AccountManagerTests
    {


        static IAccountManager accountManager;
        public IAccountManager AccountManager
        {
            get
            {
                if (accountManager == null)
                {
                    accountManager = new AccountManager();
                }
                return accountManager;
            }
        }
        
        [Theory]
        [InlineData(1, true)]
        [InlineData(2, true)]
        [InlineData(1, false)]
        public void AddAccount_simpleAccountShouldAdd(int x, bool expected)
        {
            // Arrage

            // Act
            bool actual = AccountManager.AddAccount(new Account(0, 0), x);
            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1000, 5352, 12345, 12345, true)]
        [InlineData(2000, 5235, 12345, 12345, false)]
        public void GetAccount_ShouldGetSimpleAccount(double x,int y, int z, int v, bool expected)
        {
            // Arrage
            AccountManager.AddAccount(new Account(x,y), z);
            // Act
            bool actual = AccountManager.GetAccount(v).Pin == y;
            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(3000, 3534, 54231, 5431)]
        public void GetAccount_InvalidCardShouldFail(double x, int y, int z, int v)
        {
            // Arrage
            AccountManager.AddAccount(new Account(x, y), z);
            // Act
            // assert
            Assert.Throws<ArgumentOutOfRangeException>(() => AccountManager.GetAccount(v));
        }
    }
}
