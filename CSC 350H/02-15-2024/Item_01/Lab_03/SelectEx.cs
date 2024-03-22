// Andrew Mobus
// Lab 3 Part 1: Selection Sort

using System;
using System.ComponentModel.DataAnnotations;


namespace Lab_03
{
    internal class SelectEx
    {
        static void Main(string[] args)
        {
            Random rander = new Random();
            int[] argInts = new int[100];
            List<int> argList = new List<int> {0, 0, 0, 0};

            RandFill(argInts, rander);
            RandFill(argList, rander);

            Console.WriteLine("Unsorted Items");
            showArray(argInts);
            showList(argList);

            SelectionSort(argInts);
            SelectionSort(argList);
            
            Console.WriteLine("Sorted Items");
            showArray(argInts);
            showList(argList);
        }
        
        // -----------------------------------------------------------|-----------------------------------------------------------
        static void RandFill(int[] arg, Random randInst) {
            int n = arg.Length;

            for (int i = 0; i < n; i++)
                arg[i] = randInst.Next(-100, 100);

        }

        static void RandFill(List<int> arg, Random randInst) {
            int n = arg.Count;

            for (int i = 0; i < n; i++)
                arg[i] = randInst.Next(-100, 100);

        }
        // -----------------------------------------------------------|-----------------------------------------------------------
        static void SelectionSort(int[] arg)
        {
            int n = arg.Length;

            for (int i = 0; i < n -1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                    if (arg[j] < arg[minIndex])
                        minIndex = j;

                int temp = arg[minIndex];
                arg[minIndex] = arg[i];
                arg[i] = temp;
            }
            //return arr;
        }

        static void SelectionSort(List<int> arg)
        {
            int n = arg.Count;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                    if (arg[j] < arg[minIndex])
                        minIndex = j;

                int temp = arg[minIndex];
                arg[minIndex] = arg[i];
                arg[i] = temp;
            }
            //return arr;
        }
        // -----------------------------------------------------------|-----------------------------------------------------------
        static void showArray(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }

        static void showList(List<int> arr)
        {
            int n = arr.Count;
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
        // -----------------------------------------------------------|-----------------------------------------------------------
        static void Swapper(ref int a, ref int b)
        {
            int temp;
            temp = a;
            a = b;
            b = temp;
        }
        // -----------------------------------------------------------|-----------------------------------------------------------
    }
}

