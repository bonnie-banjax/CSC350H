using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABBIT_03
{
    public struct LOG
    {
        public string act_id;
        public char type_code;
        public double start_AMT;
        public double change_AMT;
        public double end_AMT;

        public LOG(string a, char b, double c, double d, double e)
        {
            act_id = a;
            type_code = b;
            start_AMT = c;
            change_AMT = d;
            end_AMT = e;
        }
    }
    
    public class Account
    {
        string id;
        double balance;
        int transaction_count; // transaction_count
        private SortedDictionary<int,(double start_AMT, double change_AMT, double end_AMT)> balanceLog = new(); // (start, action, end)
        private SortedDictionary<int, (string act_id, char type_code, double start_AMT, double change_AMT, double end_AMT)> checkLog = new(); // (id, typecode; start, action, end)
        
        // typecode: [+] for deposit, [-] for withdrawl; 1 for deponsit, -1 for withdrawl (?)
        // static string TC_D = "[+]"; // typecode_deposit
        // static string TC_W = "[-]"; // typecode_withdraw
        const char _D = '+'; // typecode_deposit
        const char _W = '-'; // typecode_withdraw


        public string AcccountID { get { return id; } }
        public double Balance { get { return balance; } } // these should really be private!
        public int Transations { get { return transaction_count; } }


        public Account()
        {
            id = "[?]";
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

            Logger_01( (start_AMT, change_AMT, end_AMT) );

            return balance += change_AMT;
        }

        public double Deposit(double the_AMT)
        {
            double start_AMT, change_AMT, end_AMT;
            start_AMT = Balance;
            change_AMT = the_AMT;
            end_AMT = Balance + change_AMT;

            Logger_01( (start_AMT, change_AMT, end_AMT) );

            return balance += change_AMT;
        }

        public void Logger( (double start_AMT, double change_AMT, double end_AMT) AMT)
        {
            balanceLog[transaction_count++] = (AMT.start_AMT, AMT.change_AMT, AMT.end_AMT);
        }

        //need (withdrawl / deposit) 0 procedure (?)
        public void Logger_01( (double start_AMT, double change_AMT, double end_AMT) AMT)
        {
            char type_code = ' ';

            if (AMT.start_AMT == AMT.end_AMT)
                return; // return error code? is this an error per se? wasted CPU resources?
            else if (AMT.start_AMT < AMT.end_AMT)
                type_code = _D;
            else if (AMT.start_AMT > AMT.end_AMT)
                type_code = _W;
            else
                return; // this is for sure an error state

            this.checkLog[this.transaction_count++] = (this.id, type_code, AMT.start_AMT, AMT.change_AMT, AMT.end_AMT);
        }

        public void WalkLogs()
        {
            // reveals trailing double rounding inaccuracies but seems to work alright
            for (int i = 0; i < transaction_count; i++) {
                CheckLog(i);
            }
        }

        public void CheckLog(int nDex)
        {
            var A = checkLog[nDex];
            Console.WriteLine("Account ID: " + A.act_id);
            Console.WriteLine("Transaction Type: " + "[" + A.type_code + "]");
            Console.WriteLine("Start Amount: " + A.start_AMT);
            Console.WriteLine("Change Amount: " + A.change_AMT);
            Console.WriteLine ("End Amount: " + A.end_AMT);
        }

        public LOG getLog(int nDex)
        {
            var A = checkLog[nDex];

            LOG targLog = new(A.act_id, A.type_code, A.start_AMT, A.change_AMT, A.end_AMT);


            return targLog;
        }

        public void check_Balance()
        {
            Console.WriteLine("ACCOUNT: " + AcccountID + " | " + " BALANCE: " + Balance);
        }
    }
}
