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
