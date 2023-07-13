using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Qwixx
{
	public class Player
	{
		public String Name { get; set; }
		public Board Board { get; set; }


		public Player(String name)
		{
			this.Name = name;
			this.Board= new Board();
		}

		public void PromptMarkColor(List<(string, int)> values)
		{
			// prompts player to select which number they want to mark
			List<(string, int)> moves = GetValidMoves(values);

		}

		public List<(string, int)> GetValidMoves(List<(string, int)> values)
		{
			List < (string, int) > valid = new List<(string, int)> ();
			foreach (var item in values)
			{
				if (this.Board.IsValid(item.Item1, item.Item2))
				{
					valid.Add(item);
				}
			}

			if (valid.Count > 0)
			{
				return valid;
			}
			return null;

		}
	}

	

	internal class ComputerPlayer
	{
		public String Name { get; set; }
		public Board Board { get; set; }

		public ComputerPlayer(String name)
		{
			this.Name = name;
			this.Board = new Board();
		}

		public int ScoreMove(Board.Line line, int number)
		{
			return 1;
		}
	}
}
