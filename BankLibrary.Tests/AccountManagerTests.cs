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
        [InlineData("1000", true)]
        [InlineData("218515102", true)]
        [InlineData("4444444444444444", true)]
        public void AddAccount_simpleAccountShouldAdd(string x, bool expected)
        {
            // Arrage

            // Act
            bool actual = AccountManager.AddAccount(new Account(0, 0), x);
            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1000, 5352, "12345","12345", true)]
        [InlineData(2000, 5235, "1234", "1234", true)]
        public void GetAccount_ShouldGetSimpleAccount(double x,int y, string z, string v, bool expected)
        {
            // Arrage
            AccountManager.AddAccount(new Account(x,y), z);
            // Act
            bool actual = AccountManager.GetAccount(v).Pin == y;
            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(3000, 3534, "54231", "5431")]
        public void GetAccount_InvalidCardShouldFail(double x, int y, string z, string v)
        {
            // Arrage
            AccountManager.AddAccount(new Account(x, y), z);
            // Act
            // assert
            Assert.Throws<ArgumentOutOfRangeException>(() => AccountManager.GetAccount(v));
        }
    }
}
