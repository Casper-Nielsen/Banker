﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ATMLibrary.Tests
{
    public class CardTests
    {

        [Theory]
        [InlineData("1000", "1000")]
        [InlineData("2000", "2000")]
        public void GetCardNumber_ShouldGetCardNumber(string x, string expected)
        {
            // Arrage
            ICard card = new Card(x);
            // Act
            string actual = card.GetCardNumber();
            // assert
            Assert.Equal(expected, actual);
        }
    }
}
