using System;
using System.Collections.Generic;

namespace Blackjack.Models
{
    public class Hand
    {
        public List<Card> Cards = new List<Card>();
        public int Score = 0;
        public bool IsAce = false;

        public void AddCard(Card draw)
        {
            this.Score += draw.CalcVal();
            this.Cards.Add(draw);
            if (draw.CalcVal() == 11)
            {
                this.IsAce = true;
            }
            if (this.Score > 21 && this.IsAce)
            {
                this.Score -= 10;
            }
        }

        override public String ToString()
        {
            String str = "";

            foreach (Card card in this.Cards)
            {
                str += card.ToString() + " ";
            }

            return str;
        }

        public void Reset()
        {
            this.IsAce = false;
            this.Score = 0;
        }
    }
}
