using BankLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ATMLibrary.Tests
{
    public class ATMTests
    {

        [Theory]
        [InlineData("1000")]
        [InlineData("2000")]
        public void InsertCard_ShouldInsertCard(string x)
        {
            // Arrage
            ICard card = new Card(x);
            ATM atm = new ATM(new Bank(new AccountManager()));
            // Act

            // assert
            Assert.True(atm.InserCard(card));
        }
        [Theory]
        [InlineData("1000", 1234, "1000", 1234, true)]
        [InlineData("2000", 1234, "2000", 1235, false)]
        [InlineData("1000", 1234, "2000", 1234, false)]
        public void SingIn_ShouldSignInWithCard(string cn, int cp, string bcn, int bcp, bool expected)
        {
            // Arrage
            ICard card = new Card(cn);
            IAccountManager accountManager = new AccountManager();
            accountManager.AddAccount(new Account(1000, bcp), bcn);
            ATM atm = new ATM(new Bank(accountManager));
            // Act
            atm.InserCard(card);
            bool actual = atm.SignIn(cp);
            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1234, "1000", 1234, false)]
        [InlineData(1234, "2000", 1235, false)]
        public void SingIn_ShouldNotAllowSignInWithoutCard(int cp, string bcn, int bcp, bool expected)
        {
            // Arrage
            IAccountManager accountManager = new AccountManager();
            accountManager.AddAccount(new Account(1000, bcp), bcn);
            ATM atm = new ATM(new Bank(accountManager));
            // Act
            bool actual = atm.SignIn(cp);
            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RemoveCard_ShouldRemoveCard()
        {
            // Arrage
            ATM atm = new ATM(new Bank(new AccountManager()));
            // Act
            ICard card = new Card("1234");
            atm.InserCard(card);

            // assert
            Assert.Equal(card, atm.RemoveCard());
        }
        [Fact]
        public void RemoveCard_ShouldNotRemoveCardIfNoCardInIt()
        {
            // Arrage
            ATM atm = new ATM(new Bank(new AccountManager()));
            // Act
            // assert
            Assert.True(null == atm.RemoveCard());
        }

        [Theory]
        [InlineData("1000", 1234, 100, "1000", 1234, 1000, true)]
        [InlineData("2000", 1234, 1100, "2000", 1235, 1000, false)]
        public void WithdrawMoney_ShouldWithdrawMoneyIfEnought(string cn, int cp, int withdraw, string bcn, int bcp, int amount, bool expected)
        {
            // Arrage
            IAccountManager accountManager = new AccountManager();
            accountManager.AddAccount(new Account(amount, bcp), bcn);
            ATM atm = new ATM(new Bank(accountManager));
            // Act
            ICard card = new Card(cn);
            atm.InserCard(card);
            bool actual = withdraw == atm.WithdrawMoney(withdraw);
            // assert
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData("1000", 1234, 100, "1000", 1234, 1000, true)]
        [InlineData("2000", 1234, 1100, "2000", 1235, 1000, true)]
        public void WithdrawMoney_ShouldNotWithdrawMoneyIfNoCardIsInserted(string cn, int cp, int withdraw, string bcn, int bcp, int amount, bool expected)
        {
            // Arrage
            IAccountManager accountManager = new AccountManager();
            accountManager.AddAccount(new Account(amount, bcp), bcn);
            ATM atm = new ATM(new Bank(accountManager));
            // Act
            ICard card = new Card(cn);
            bool actual = 0 == atm.WithdrawMoney(withdraw);
            // assert
            Assert.Equal(expected, actual);
        }
    }
}

