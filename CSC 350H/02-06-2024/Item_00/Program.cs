//--------------------------------------------[]--------------------------------------------\\

// Andrew Mobus

// CSC 350H
// 02-06-2024



// C# programming sample / example project:

// Program.cs


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DiceGame
{
	internal class Program
	{

//--------------------------------------------[]--------------------------------------------\\
		static void Main(string[] args)
		{

			string done = " ";
			do
			{
				Func_04();
				Console.WriteLine("Input EXIT to terminate program: ");
				done = Console.ReadLine();

			} while (done != "EXIT") ;

		}
//--------------------------------------------[]--------------------------------------------\\
		static void Func_00()
        {
			Dice dice = new Dice();
			dice.Roll();
			Console.WriteLine("After Roll a Dice, I get " + dice.Top);

		}

//--------------------------------------------[]--------------------------------------------\\

		static void Func_01()
		{
			Dice die_01 = new Dice();
			Dice die_02 = new Dice();

			die_01.Roll();
			die_02.Roll();

			int a, b;
			a = die_01.Top;
			b = die_02.Top;

			if (a > b)
				Console.WriteLine("Die_02 result: " + a + " is greater");
			else
				Console.WriteLine("Die_02 result: " + b + " is greater");


		}



//--------------------------------------------[]--------------------------------------------\\
		static void Func_02()
		{
			Dice dice = new Dice();

			int diceEx = 0;
			List<int> diceRolls = new List<int>();

			for (int i = 0; i < 10; i++)
			{
				dice.Roll();
				diceEx = dice.Top;
				diceRolls.Add(diceEx);
			}

			Console.WriteLine("Input value to check for (must be integer 1-6): ");
			int arg = int.Parse(Console.ReadLine());

			foreach (int roll in diceRolls)
			{
				if (roll == arg)
					Console.WriteLine("Roll result: " + arg + " found.");
				else
					Console.WriteLine("Roll result: " + arg + " not found.");
				
			}

		}

		//--------------------------------------------[]--------------------------------------------\\

		static void Func_03()
		{
			Dice dice = new Dice();

			int diceEx = 0;
			List<int> diceRolls = new List<int>();
			List<int> buffer = new List<int>();
			diceRolls.Add(diceEx);
			bool flag_00 = false;


			for (int i = 0; i < 5; i++)
			{
				dice.Roll();
				diceEx = dice.Top;

				foreach (int roll in diceRolls)
					if (roll == diceEx)
						flag_00 = true;

				if (flag_00 != true)
					buffer.Add(diceEx);

				if (buffer != null)
					foreach (int result in buffer)
						diceRolls.Add(result);


				buffer.Clear();

			}

			foreach (int roll in diceRolls)
			{
				Console.WriteLine("Roll result: " + roll);
			}
		}
//--------------------------------------------[]--------------------------------------------\\

		static void Func_04()
        {
			Console.WriteLine("Input option: (0, 1, 2, 3)");
			string opt = Console.ReadLine();

			switch (opt) {
				case "0":
					Func_00();
					break;
				case "1":
					Func_01();
					break;
				case "2":
					Func_02();
					break;
				case "3":
					Func_03();
					break;
				default:
					break;
			}
        }

//--------------------------------------------[]--------------------------------------------\\


	}
}

//--------------------------------------------[]--------------------------------------------\\

// lab: test the dice class
// 1 create two dice objects, roll the bpth dices & compare which is bigger
// 2 Implement a method to check if an arrray to keep track of the topsides after
// rolling N = 5 times contains a given number
// 3 implement a method to create a dice array with unique numbers




