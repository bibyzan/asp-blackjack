using System;
namespace Blackjack.Models
{
    public class BlackjackGame
    {
		public Hand Dealer = new Hand(), PlayerHand = new Hand();
		public Deck GameDeck = new Deck();
		public int DeckIndex = 0, Bet;
		public SessionPlayer Player = new SessionPlayer();


		public void Start()
		{
			this.Dealer.Cards.Clear();
			this.Dealer.Reset();
			this.PlayerHand.Cards.Clear();
			this.PlayerHand.Reset();
			this.GameDeck.Cards.Shuffle();
			this.DeckIndex = 0;
		}

		public void Turn()
		{
			this.Turn(true);
		}

		public void Turn(bool hit)
		{
			if (hit)
			{
				this.PlayerHand.AddCard(this.GameDeck.Cards[this.DeckIndex]);
				this.DeckIndex++;
			}
			if (this.DealerCheck())
			{
				this.Dealer.AddCard(this.GameDeck.Cards[this.DeckIndex]);
				this.DeckIndex++;
			}
		}

		public string CardString(int i)
		{
			return this.GameDeck.Cards[i].ToString();
		}

		public bool DealerCheck()
		{
			return this.Dealer.Score <= this.PlayerHand.Score;
		}

		public int Check()
		{
			if (this.PlayerHand.Score == 21)
			{
				return 0;
			}
			else if (this.Dealer.Score == 21)
			{
				return 1;
			}
			else if (this.PlayerHand.Score > 21)
			{
				return 2;
			}
			else if (this.Dealer.Score > 21)
			{
				return 3;
			}
			else if (this.PlayerHand.Score < 21 && this.PlayerHand.Score > this.Dealer.Score)
			{
				return 4;
			}
			else
			{
				return 5;
			}
		}

		public String result(int c)
		{
			String[] r = { "playerHand blackjack!", "dealer blackjack!", "playerHand busts", "dealer busts", "playerHand wins!", "dealer wins!" };
			return r[c];
		}

		public void CheckPlayerWin()
		{
			if (this.Check() == 0 || this.Check() == 4 || this.Check() == 3)
			{
				Player.Chips = this.Player.Chips + (this.Bet * 2);
			}
		}

		public void BetChips(int amount)
		{
			this.Bet = amount;
			Player.Chips -= amount;
		}

		public bool IsGameOver()
		{
			return this.PlayerHand.Score >= 21 || this.Dealer.Score >= 21;
		}
	}
}
