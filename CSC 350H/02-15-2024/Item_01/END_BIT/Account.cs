using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace END_BIT
{
    internal class Account
    {
        string id; // string used for AgentID
        double balance;
        int transaction_count; // a value of 0 for handSize means no cards
        private LinkedList<string> transaction_log = new();



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

        public double Withdraw(double withdraw_AMT)
        {
            double start_AMT, end_AMT;
            start_AMT = Balance; // uses property to access
            end_AMT = Balance - withdraw_AMT; // uses property to access


            transaction_log.AddLast((string)("Withdrawl: "+ withdraw_AMT + "\n Updated Balance" + start_AMT + " -> " + end_AMT));
            transaction_count++;
            balance -= withdraw_AMT;

            return balance;
        }

        public double Deposit(double deposit_AMT)
        {
            double start_AMT, end_AMT;
            start_AMT = Balance; // uses property to access
            end_AMT = Balance + deposit_AMT; // uses property to access

            transaction_log.AddLast("Deposit: " + deposit_AMT + "\n Updated Balance" + start_AMT + " -> " + end_AMT);
            transaction_count++;
            balance += deposit_AMT;

            return balance;
        }

        public void WalkTransactions()
        {
            int track = 0;
            foreach (var item in transaction_log)
                Console.WriteLine("(" + track++ + ") " + item);


        }
    }
}
