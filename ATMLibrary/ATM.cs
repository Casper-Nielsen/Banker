using BankLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATMLibrary
{
    public class ATM
    {
        private ICard card;
        private IBank bank;

        public ATM(IBank bank)
        {
            this.bank = bank;
        }
        /// <summary>
        /// inserts the card if there is not a card in it
        /// </summary>
        /// <param name="card">the card to be inserted</param>
        /// <returns>if it got inserted</returns>
        public bool InserCard(ICard card)
        {
            if (this.card == null)
            {
                this.card = card;
                return true;
            }
            return false;
        }

        /// <summary>
        /// signs in with a pin and the cardnumber
        /// </summary>
        /// <param name="pin">the pin code</param>
        /// <returns>it is a valid sign in</returns>
        public bool SignIn(int pin)
        {
            if (card != null)
            {
                try
                {
                    return bank.Validate(card.GetCardNumber(), pin);
                }
                catch (ArgumentOutOfRangeException)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// removes the card if it is there is any
        /// </summary>
        /// <returns>the card</returns>
        public ICard RemoveCard()
        {
            ICard card = this.card;
            this.card = null;
            return card;
        }

        /// <summary>
        /// withdraws money if there is enough
        /// </summary>
        /// <param name="amount">the amount that will be withdrawn</param>
        /// <returns>the money that is withdrawn</returns>
        public double WithdrawMoney(double amount)
        {
            if(card != null && bank.Withdraw(card.GetCardNumber(), amount))
            {
                return amount;
            }
            return 0;
        }
    }
}
