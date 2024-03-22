// ANDREW MOBUS

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAsignment1
{
    class Menu
    {
        static void Main(string[] args)
        {

			string done = " ";
			do
			{
				Func_04();
				Console.WriteLine("Input EXIT to terminate program: ");
				done = Console.ReadLine();

			} while (done != "EXIT");

		}
		//--------------------------------------------[]--------------------------------------------\\
		static void Func_00()
		{
			// placeholder
		}
		//--------------------------------------------[]--------------------------------------------\\
		static void Func_01()
		{
			// placeholder
		}
		//--------------------------------------------[]--------------------------------------------\\
		static void Func_02()
		{
			// placeholder
		}
		//--------------------------------------------[]--------------------------------------------\\
		static void Func_03()
		{
			// placeholder
		}
		//--------------------------------------------[]--------------------------------------------\\
		static void Func_04()
		{
			List<string> options = new List<string> { };
			options.Add("**************");
			options.Add("Menu: ");
			options.Add("1 - New Game ");
			options.Add("2 - Load Game ");
			options.Add("3 - Options ");
			options.Add("4 - Quit ");
			options.Add("**************");

			foreach (string unit in options)
            {
				Console.WriteLine(unit + '\n');
			}

			Console.WriteLine("Input option: ");
			string opt = Console.ReadLine();

			switch (opt)
			{
				case "1":
					Func_00();
					break;
				case "2":
					Func_01();
					break;
				case "3":
					Func_02();
					break;
				case "4":
					Func_03();
					break;
				default:
					break;
			}
		}
		//--------------------------------------------[]--------------------------------------------\\
	}



}
