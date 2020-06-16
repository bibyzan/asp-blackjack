using System;
namespace Blackjack.Models
{
    public class Card
    {
        public int Val, Suit;

        public Card(int val, int suit)
        {
            this.Val = val;
            this.Suit = suit;
        }

        override public string ToString()
        {
            char[] s = { 'h', 's', 'c', 'd' };
            string[] v = { "a", "2", "3", "4", "5", "6", "7", "8", "9", "t", "j", "q", "k" };

            return v[this.Val - 1] + s[this.Suit - 1];
        }

        public int CalcVal()
        {
            //check for aces
            if (this.Val > 10)
            {
                return 10;
            }
            else if (this.Val == 1)
            {
                return 11;
            }
            else
            {
                return Val;
            }
        }

        /*public ImageIcon cardImage()
		{
			return new ImageIcon("cardimages\\" + toString() + ".gif");
		}*/
    }
}
