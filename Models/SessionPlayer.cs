using System;
namespace Blackjack.Models
{
    public class SessionPlayer
    {
        public int Chips = 20;
        public string Name = "";

        override public string ToString()
        {
            return this.Name + " " + this.Chips;
        }
    }
}
