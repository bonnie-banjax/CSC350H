// Dice.cs

// Andrew Mobus

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiceGame
{
	internal class Dice // public class Dice
	{

		int numSides;
		int top;
		static Random random = new Random();

		public int NumSides { get { return numSides; } }
		public int Top { get { return top; } }

		public Dice()
		{
			numSides = 6;
			top = 1;
		}

		public Dice(int numSides)
		{
			this.numSides = numSides;
			top = 1;
		}

		public void Roll()
		{
			//Random random = new Random();
			top = random.Next(numSides) + 1;
		}

	}
}

