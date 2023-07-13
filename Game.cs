using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qwixx
{
	internal class Game
	{
		// player list
		public List<Player> PlayerList { get; set; }

		public int CurrPlayer { get; set; }

		public bool IsWinner { get; set; }

		public int NumLocks { get; set; }

		public Dice Dice { get; set; }

		// get player names

		public void StartRound()
		{
			// currplayer rolls dice
			this.Dice.RollDice();

			// each player can mark off white dice total on their board (not required)
			this.MarkWhites();

			// currplayer can add a white die and a color die together and mark their board
			// curr player must do one of these or take a penalty
			// change currplayer
			this.NextPlayer();
		}




		public int NumPlayers { get; set; }

		public Game()
		{
			PlayerList = new List<Player>();
			CurrPlayer = 0;
			IsWinner = false;
			NumLocks = 0;
			Dice = new Dice();
		}

		public void NextPlayer()
		{
			if (this.CurrPlayer < PlayerList.Count - 1)
			{
				this.CurrPlayer++;
			}
			else
			{

				this.CurrPlayer = 0;
			}
		}

		public void MarkWhites()
		{
			int Player = 0;
			while (Player < this.PlayerList.Count())
			{
				Console.WriteLine(this.PlayerList[Player].Name + " would you like to mark a " + this.Dice.WhiteValues[0].Item2);

				Player++;
			}
		}
	}
}
