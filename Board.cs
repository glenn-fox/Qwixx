using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Qwixx
{
	public class Board
	{
		public class Line
		{
			public string Color { get; set; }
			public bool Reversed { get; set; }
			public bool Locked { get; set; }
			public List<bool> Numbers { get; set; }

			


			public Line(string color, bool reversed) 
			{
				this.Color = color;
				this.Reversed = reversed;
				this.Locked = false;
				// numbers[11] is for points when locking
				this.Numbers = new List<bool>() {false, false, false, false, false, false, false, false, false, false, false, false };

			}
		}


		public List<Line> Lines { get; set; }
		
		//TODO add skips
		public int Skips { get; set; }

		public int Score { get; set; }	
		public int PossibleScore { get; set; }


		public Board()
		{   // reverse, locked, 2-12
			this.Lines = new List<Line>();


			this.Lines.Add(new Line("red", false));
			this.Lines.Add(new Line("yellow", false));
			this.Lines.Add(new Line("green", true));
			this.Lines.Add(new Line("blue", true));
			this.Skips = 0;

			this.Score = 0;	
			this.PossibleScore = 0;
		}

		
		public void UpdateScore()
		{
			int count;

			int Score = 0;

			foreach(Line line in this.Lines)
			{
				count = 0;
				foreach(bool number in line.Numbers)
				{
					if (number)
					{
						count++;
					}
				}
				Score += CalculateScore(count);
			}
			this.Score = Score;
		}


		public int CalculateScore(int count)
		{
			int Total = 0;

			while (count > 0)
			{
				Total += count;
				count--;
			}
			return Total;
		}


		public void DrawBoard()
		{
			foreach(Line line in this.Lines)
			{
				Console.Write(line.Color.PadRight(7) + "|");


				if (line.Reversed ) 
				{
					for (int i = 10; i >= 0; i--)
					{
						if (line.Numbers[i])
						{
							Console.Write("X |");
						}
						else
						{
							Console.Write((i + 2).ToString().PadRight(2) + "|");
						}
					}
				}
				else
				{
					for (int i = 0; i <= 10; i++)
					{
						if (line.Numbers[i])
						{
							Console.Write("X |");
						}
						else
						{
							Console.Write((i + 2).ToString().PadRight(2) + "|");
						}
					}
				}

				if (line.Numbers[11])
				{
					Console.Write("X");
				}
				else
				{
					Console.Write(" ");
				}

				if (line.Locked)
				{
					Console.Write("L|");
				}
				else
				{
					Console.Write(" |");
				}
				Console.WriteLine();
			}


		}


		public bool MarkBoard(string color, int number)
		{
			if (this.IsValid(color, number))
			{
				foreach (Line line in this.Lines)
				{
					if (line.Color.Equals(color))
					{
						line.Numbers[number - 2] = true;
						this.UpdateScore();
						return true;
					}
				}
			}
			Console.WriteLine("invalid markBoard: " + color + " ," + number);
			return false;
		}


		public int GetPossibleScore()
		{
			int possible = 0;




			return possible;
		}


		public bool IsValid(string color, int number)
		{
			foreach(Line line in this.Lines)
			{
				if (line.Color.Equals(color))
				{
					if (line.Reversed)
					{
						for (int i = number - 2; i >= 0; i--)
						{
							if (line.Numbers[i])
							{
								return false;
							}
						}
						return true;
					}
					else
					{
						for (int i = number - 2; i <= 10; i++)
						{
							if (line.Numbers[i])
							{
								return false;
							}
						}
						return true;
					}
				}
			}
			return false;
		}
	}
}
