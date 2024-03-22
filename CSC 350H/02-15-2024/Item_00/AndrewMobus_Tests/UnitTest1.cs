using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LABBIT_03;

//note 15-17 are guidelines
namespace AccountUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        // assertion usage practice
        //[TestMethod]
        public void PracticeMethod_00()
        {
            Double initBal = 1000000.00;
            double charge_out = 3291.07;
            double expectedResult_01 = initBal;
            int expectedResult_02 = 10;
            int iters = 5;

            Account ex_00 = new("TEST_ACCOUNT", initBal);

            Assert.AreEqual<double>(initBal, ex_00.Balance);
            for (int i = 0; i < iters; i++)
                ex_00.Withdraw(charge_out);
            Assert.AreNotEqual(initBal, ex_00.Balance);
            Assert.IsTrue(initBal > ex_00.Balance);
            Assert.AreEqual(iters, ex_00.Transations);
            for (int i = 0; i < iters; i++)
                ex_00.Deposit(charge_out);
            Assert.AreEqual<double>(initBal, ex_00.Balance);
            Assert.IsTrue(2 * iters == ex_00.Transations);
        }
        // -----------------------------------------------------------|-----------------------------------------------------------



        // for default constructor
        [TestMethod]
        public void TestMethod_01a()
        {
            double expr_01 = 0;
            string expr_02 = "[-]";
            double expr_03 = 0;
            Account ex_00 = new();

            Assert.AreEqual(expr_01, ex_00.Balance);
            Assert.AreEqual(expr_02, ex_00.AcccountID);
            Assert.AreEqual(expr_03, ex_00.Transations);
        }

        // for initialized constructor
        [TestMethod]
        public void TestMethod_01b()
        {
            double initBal = 1000000.00;
            string account_name = "PROX";
            double expr_03 = 0;
            Account ex_00 = new(account_name, initBal);

            Assert.AreEqual<double>(initBal, ex_00.Balance);
            Assert.AreEqual<string>(account_name, ex_00.AcccountID);
            Assert.AreEqual<double>(expr_03, ex_00.Transations);
        }


        // -----------------------------------------------------------|-----------------------------------------------------------

        // 2A & 2B are the practice test from slide

        // for withdrawl method
        [TestMethod]
        public void TestMethod_02A()
        {
            double beginningBalance = 11.99;
            double withdrawlAmount = 4.55;
            double expected = 7.44;
            Account prox = new("PROX", beginningBalance);

            prox.Withdraw(withdrawlAmount);
            double actual = prox.Balance;
            Assert.AreEqual(expected, actual, 0.001, "WITHDRAWL ERROR");
        }

        // -----------------------------------------------------------|-----------------------------------------------------------

        // for deposit method 
        [TestMethod]
        public void TestMethod_02B()
        {
            double beginningBalance = 7.44;
            double depositAmount = 4.55;
            double expected = 11.99;
            Account prox = new("PROX", beginningBalance);

            prox.Deposit(depositAmount);
            double actual = prox.Balance;
            Assert.AreEqual(expected, actual, 0.001, "DEPOSIT ERROR");
        }

        // -----------------------------------------------------------|-----------------------------------------------------------

        // for the transaction logger counter
        [TestMethod]
        public void TestMethod_03()
        {

            Double initBal = 1000000.00;
            double charge_out = 1;
            int expectedResult = 10;
            int iters = 5;

            Account ex_00 = new("PROX", initBal);

            for (int i = 0; i < iters; i++)
                ex_00.Withdraw(charge_out);
            Assert.AreEqual(iters, ex_00.Transations);
            for (int i = 0; i < iters; i++)
                ex_00.Deposit(charge_out);
            Assert.IsTrue(expectedResult == ex_00.Transations);

        }

        // this will be for the logger itself once refactored
        // since at time of writing the function records as
        // strings rather than numerical values
        public void TestMethod_04()
        {

        }

    }
}