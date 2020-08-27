using System;
using System.Collections.Generic;
using System.Text;

namespace ATMLibrary
{
    public class Card : ICard
    {
        private int cardNumber;
        public Card(int cardNumber)
        {
            this.cardNumber = cardNumber;
        }
        /// <summary>
        /// gets the cardnumber 
        /// </summary>
        /// <returns>the cardnumber</returns>
        public int GetCardNumber()
        {
            return cardNumber;
        }
    }
}
