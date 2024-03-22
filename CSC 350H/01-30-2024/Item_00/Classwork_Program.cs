using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Classwork
{
    class Classwork_Program
    {
        static void Main(string[] args)
        {
            int done = 1;
            while (done != 0)
            {
                int arg = int.Parse(Console.ReadLine());
                //func2(temps, temps);
                // func3(arg);
                func4();
                done = int.Parse(Console.ReadLine());

            }
        }
        static void func1()
        {
            // int totalSecondsPlayed = 100;
            // const int secondsPerMinute = 60;
            // int minutesPlayed = totalSecondsPlayed / secondsPerMinute;
            // int secondsPlayed = totalSecondsPlayed % secondsPerMinute;
            // Console.WriteLine("");
            // Console.WriteLine("");

            Console.Write("Enter x coordinate: ");
            int xCoor = int.Parse(Console.ReadLine());
            Console.Write("Enter y coordinate: ");
            int yCoor = int.Parse(Console.ReadLine());
            Console.WriteLine("X-COORD: " + xCoor);
            Console.WriteLine("Y-COORD: " + yCoor);

            const int MaxScore = 100;
            int score = 50;
            float percent = (float)MaxScore / score;

            Console.WriteLine("Percentage: " + percent);
            Console.WriteLine("Done: ");
        }

        static void func2(float temp1 = 100, float temp2 = 100)
        {
            // float temp1 = 0.0F;
            // float temp2 = 0.0F;

            // F to C
            temp1 = ((temp1 - 32) / 9) * 5;

            // C to F
            temp2 = ((temp2 * 9) / 5) + 32;

            Console.WriteLine("F to C:" + temp1);
            Console.WriteLine("C to F:" + temp2);

        }

        static void func3(double arg)
        {
            double angle = arg;
            Console.Write("Enter angle in degrees ");
            angle = double.Parse(Console.ReadLine());
            //angle *= 180 / Math.PI 180 /;
            angle *= Math.PI / 180;
            Console.WriteLine(Math.Cos(angle));
            Console.WriteLine(Math.Sin(angle));
            
        }

        static void func4()
        {
            string str = "3, 7, 1, 5";
            int spaceIndex = str.IndexOf(" ");

            Console.WriteLine("OG String: " + str);
            Console.WriteLine("Space Index: " + spaceIndex);

            string[] numbers = str.Split(',');
            float x2 = float.Parse(numbers[0]);
            Console.WriteLine(numbers[0]);

            for (int i = 0; i < 4; i++)
            {
            Console.WriteLine(numbers[i]);
            }



            string str2 = str.Substring(0, spaceIndex);
            float x1 = float.Parse(str2);
            
            string str3 = str.Substring(spaceIndex + 1);
            int spaceIndex_2 = str3.IndexOf(" ");

            // Math.Atan2()
            // Math.Sqrt()

        }
    }
}
