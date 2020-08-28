using System;
using System.Collections.Generic;
using System.Text;

namespace ATMLibrary
{
    public class Card : ICard
    {
        private string cardNumber;
        public Card(string cardNumber)
        {
            this.cardNumber = cardNumber;
        }
        /// <summary>
        /// gets the cardnumber 
        /// </summary>
        /// <returns>the cardnumber</returns>
        public string GetCardNumber()
        {
            return cardNumber;
        }
    }
}
