using System;
using System.Collections.Generic;
using System.Linq;

namespace Qwixx
{
	public class Dice
	{
		public List<Die> DiceList { get; set; }
		public List<(string, int)> ColorValues {get; set; }
		public List<(string, int)> WhiteValues { get; set; }
		Random Rand { get; set; }
		int NumDice { get; set; }
		public List<string> Colors { get; set; }

		public class Die
		{
			private string Color { get; set; }
			private int CurrValue { get; set; }

			public Die(string color)
			{
				this.Color = color;
				this.CurrValue = 0;
				//this.active= true;
			}

			public string GetColor()
			{
				return this.Color;
			}

			public int GetValue()
			{
				return this.CurrValue;
			}

			public void SetValue(int value)
			{
				this.CurrValue = value;
			}

			
		}

		public List<Die> GetDice()
		{
			return this.DiceList;
		}


		public Dice()
		{
			// initiallize rand
			Rand = new Random();

			// add starting dice to list
			this.DiceList = new List<Die>();
			this.Colors= new List<string>();
			this.WhiteValues = new List<(string, int)>();
			this.ColorValues = new List<(string, int)>();
			this.NumDice = 0;
			this.AddDie("white");
			this.AddDie("white");
			this.AddDie("red");
			this.AddDie("green");
			this.AddDie("blue");
			this.AddDie("yellow");
		}

		public void AddDie(string color)
		{
			this.DiceList.Add(new Die(color));
			this.AddColor(color);
			this.NumDice++;
		}

		public bool RemoveDie(string color)
		{
			foreach (Die d in this.DiceList)
			{
				if (d.GetColor().Equals(color)) {
					this.DiceList.Remove(d);
					this.NumDice--;
					return true;
				}
			}
			Console.Write("there is no dice with color: " + color);
			return false;
		}


		public void RollDice()
		{
			foreach (var die in this.DiceList)
			{
				die.SetValue(Rand.Next(1, 7));
			}

			this.UpdateValues();
		}

		public (string, int)[] GetRoll()
		{
			(string, int)[] DiceRoll;

			DiceRoll = new (string, int)[this.NumDice];

			for (int i = 0; i < this.NumDice; i++)
			{
				DiceRoll[i] = (this.DiceList[i].GetColor(), this.DiceList[i].GetValue());
			}

			return DiceRoll;
		}

		public void UpdateValues()
		{
			this.WhiteValues = new List<(string, int)>();
			this.ColorValues = new List<(string, int)>();



			// add white
			this.WhiteValues.Add(("white", this.DiceList[0].GetValue() + this.DiceList[1].GetValue()));


			// add other colors to white die
			for (int i = 2; i < this.NumDice; i++)
			{
				this.ColorValues.Add((this.DiceList[i].GetColor(), this.DiceList[i].GetValue() + this.DiceList[0].GetValue()));
				this.ColorValues.Add((this.DiceList[i].GetColor(), this.DiceList[i].GetValue() + this.DiceList[1].GetValue()));
			}


		}


		public void DisplayRoll()
		{
			Console.WriteLine("The current roll is: ");
			foreach (var item in this.WhiteValues)
			{
				Console.WriteLine(item.Item1 + ": " + item.Item2);
			}
			foreach (var item in this.ColorValues)
			{
				Console.WriteLine(item.Item1 + ": " + item.Item2);
			}
		}


		public bool AddColor(string color)
		{
			foreach (string item in this.Colors)
			{
				if (item.Equals(color))
				{
					return false;
				}
			}
			Colors.Add(color);
			return true;
		}
	}
}
