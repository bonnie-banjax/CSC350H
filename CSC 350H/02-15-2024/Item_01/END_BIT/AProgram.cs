using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace END_BIT
{
    internal class AProgram
    {
        static void Main(string[] args)
        {
            Account ex_00 = new("TEST_ACCOUNT", 1000000.00);
            Console.WriteLine("ACCOUNT: " + ex_00.AcccountID + " | " + " BALANCE: " + ex_00.Balance);
            for (int i = 0; i < 5; i++)
                ex_00.Withdraw(3291.00);
            
            Console.WriteLine("ACCOUNT: " + ex_00.AcccountID + " | "  + " BALANCE: " + ex_00.Balance);
            ex_00.WalkTransactions();

            for (int i = 0; i < 5; i++)
                ex_00.Deposit(3291.00);
            Console.WriteLine("ACCOUNT: " + ex_00.AcccountID + " | " + " BALANCE: " + ex_00.Balance);
            ex_00.WalkTransactions();

            Prototyper.validateShufflers(1000);
            Prototyper.Bench_00();
        }


    }

}
