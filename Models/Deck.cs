using System;
using System.Collections.Generic;

namespace Blackjack.Models
{
    public class Deck
    {
        public List<Card> Cards = new List<Card>();

        public Deck()
        {
            for (int suit = 1; suit <= 4; suit++)
            {
                for (int val = 1; val <= 13; val++)
                {
                    this.Cards.Add(new Card(val, suit));
                }
            }
        }

        override public String ToString()
        {
            String str = "";

            foreach (Card card in this.Cards)
            {
                str += card.ToString() + "\n";
            }

            return str;
        }
    }
}
