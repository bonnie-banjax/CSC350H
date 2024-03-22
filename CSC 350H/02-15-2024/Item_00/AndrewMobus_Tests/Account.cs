using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABBIT_03
{
    public class Account
    {
        string id;
        double balance;
        int transaction_count;
        private LinkedList<string> transaction_log = new();
        private SortedDictionary<int,(double, double, double)> balanceLog = new(); // (start, action, end)


        public string AcccountID { get { return id; } }
        public double Balance { get { return balance; } } // these should really be private!
        public int Transations { get { return transaction_count; } }


        public Account()
        {
            id = "[-]";
            balance = 0;
            transaction_count = 0;

        }

        public Account(string customer_ID, double starting_balance = 0)
        {
            id = customer_ID;
            balance = starting_balance;

        }

        public double Withdraw(double the_AMT)
        {
            double start_AMT, change_AMT, end_AMT;
            start_AMT = Balance;
            change_AMT = (-1) * the_AMT;
            end_AMT = Balance + change_AMT;

            Logger((start_AMT, change_AMT, end_AMT));

            return balance += change_AMT;
        }

        public double Deposit(double the_AMT)
        {
            double start_AMT, change_AMT, end_AMT;
            start_AMT = Balance;
            change_AMT = the_AMT;
            end_AMT = Balance + change_AMT;

            Logger( (start_AMT, change_AMT, end_AMT) );

            return balance += change_AMT;
        }

        //incomplete
        public void Logger((double start_AMT, double change_AMT, double end_AMT) AMT)
        {
            //Console.WriteLine("ACCOUNT: " + AcccountID + " | " + " BALANCE: " + Balance);
            balanceLog[++transaction_count] = (AMT.start_AMT, AMT.change_AMT, AMT.end_AMT);
            //balanceLog.Add(++transaction_count, (AMT.start_AMT, AMT.change_AMT, AMT.end_AMT));

        }

        public void WalkLogs()
        {
            int track = 0;
            foreach (var item in transaction_log)
                Console.WriteLine("(" + track++ + ") " + item);

        }

        public void check_Balance()
        {
            Console.WriteLine("ACCOUNT: " + AcccountID + " | " + " BALANCE: " + Balance);
        }
    }
}
