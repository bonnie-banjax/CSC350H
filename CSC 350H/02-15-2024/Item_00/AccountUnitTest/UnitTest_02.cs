using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LABBIT_03;

// [PREFACE]:
// while these tests meet the word of the assignment, they are not not in the spirit
// I had to fiddle with a lot of the base code, which was already not in the state
// I thought I left it after finishing the initial test lab; I'm currently working
// to overhaul & refactor all the classes to be more robust going forward, ie
// for use in the upcoming Elevens assignment

namespace AccountUnitTest
{
    [TestClass]
    public class UnitTest_02
    {

        // -----------------------------------------------------------|-----------------------------------------------------------

        // Constructor Test(s)

        [TestMethod]
        public void testMethod_01()
        {
            int expr_00 = 52;
            Deck testDeck = new();

            Assert.AreEqual(expr_00, testDeck.Count);

        }

        // checks that there are no duplicates
        [TestMethod]
        public void testMethod_01b()
        {

            Deck testDeck = new();
            testDeck.unshuffled_deck();
            bool flag = false;

            while (testDeck.Count > 0) {
                Card checkMe = testDeck.Draw();
                foreach (Card card in testDeck.cards) {
                    if (checkMe == card)
                        flag = true;
                }
            }

            Assert.IsFalse(flag);

        }


        // -----------------------------------------------------------|-----------------------------------------------------------

        // checks that draw removes a card
        [TestMethod]
        public void testMethod_02()
        {
            int expr_00 = 51;
            Deck testDeck = new();
            testDeck.Draw();

            Assert.AreEqual(expr_00, testDeck.Count);
        }

        // -----------------------------------------------------------|-----------------------------------------------------------


        // tests that draw returns the card is removes
        // unshuffled deck creates a new (unshuffled) deck,
        // based on the order of the mCopy (master copy) deck,
        // which is why it is called twice; once to take a card,
        // and a second time so that the first draw can be
        // compared to the second draw
        [TestMethod]
        public void testMethod_03a()
        {
            Deck testDeck = new();
            testDeck.unshuffled_deck();
            Card testCard = testDeck.Draw();
            testDeck.unshuffled_deck();

            Assert.AreEqual(testDeck.Draw(), testCard);

        }

        //refinement of above, just makes two unshuffled decks
        [TestMethod]
        public void testMethod_03b()
        {
            Deck deck_01 = new(), deck_02 = new();
            deck_01.unshuffled_deck();
            deck_02.unshuffled_deck();

            Assert.AreEqual(deck_01.Draw(), deck_02.Draw());

        }


        // -----------------------------------------------------------|-----------------------------------------------------------


        // checks that cut method works by check that
        // the lengths of two unshuffled decks are the same,
        // but that they don't return the same topcard
        // this test kind of piggybakcs off of the test
        // that validates 
        [TestMethod]
        public void testMethod_04a()
        {
            Deck deck_01 = new(), deck_02 = new();
            deck_01.unshuffled_deck();
            deck_02.unshuffled_deck();

            deck_01.Cut(1); // deck_01.Cut((deck_01.Count / 2));
            Assert.AreEqual(deck_01.Count, deck_02.Count);
            Assert.AreNotEqual(deck_01.Draw(), deck_02.Draw());

        }

        //checks that cut at index 0 doesn't do anything
        [TestMethod]
        public void testMethod_04b()
        {
            Deck deck_01 = new(), deck_02 = new();
            deck_01.unshuffled_deck();
            deck_02.unshuffled_deck();

            deck_01.Cut(0);
            Assert.AreEqual(deck_01.Count, deck_02.Count);
            Assert.AreEqual(deck_01.Draw(), deck_02.Draw());

        }


        //checks that cut at last index doesn't do anything
        [TestMethod]
        public void testMethod_04c()
        {
            Deck deck_01 = new(), deck_02 = new();
            deck_01.unshuffled_deck();
            deck_02.unshuffled_deck();

            deck_01.Cut(deck_01.Count);
            Assert.AreEqual(deck_01.Count, deck_02.Count);
            Assert.AreEqual(deck_01.Draw(), deck_02.Draw());

        }


        // -----------------------------------------------------------|-----------------------------------------------------------

        // Shuffling Section

        [TestMethod]
        public void testMethod_05()
        {
            //bool shufCheck = validateShuffle(Deck.ProfShuffle());
            Assert.IsTrue(validateShuffle(Deck.ProfShuffle()));
        }

        public static bool validateShuffle(int[] tempArray)
        {
            bool validation = false;
            for (int i = 0; i < tempArray.Length; i++)
            {
                if (tempArray[i] == i)
                { return validation; }
            }
            return !validation;
        }

        // plan to update to allow automatic paramater amounts
        // rather than hard coding each function to test
        public static void validateShufflers(int rounds)
        {
            //Control
            int[] vals_00 = new int[52];
            for (int i = 0; i < 52; i++)
                vals_00[i] = i;

            int[] vals_01;
            int[] vals_02;
            int[] vals_03;

            bool valid_00;
            bool valid_01;
            bool valid_02;
            bool valid_03;

            int passes_00 = 0;
            int passes_01 = 0;
            int passes_02 = 0;
            int passes_03 = 0;


            for (int i = 0; i < rounds; i++)
            {
                vals_01 = Deck.NativeShuffle();
                vals_02 = Deck.ProfShuffle();
                vals_03 = Deck.PartialShuffle();

                valid_00 = validateShuffle(vals_00);
                valid_01 = validateShuffle(vals_01);
                valid_02 = validateShuffle(vals_02);
                valid_03 = validateShuffle(vals_03);


                if (valid_00 == true)
                    passes_00++;
                if (valid_01 == true)
                    passes_01++;
                if (valid_02 == true)
                    passes_02++;
                if (valid_03 == true)
                    passes_03++;

            }

            Console.WriteLine("TEST RESULTS: ");
            Console.WriteLine("Control Passes: " + passes_00);
            Console.WriteLine("PartialShuffle Passes: " + passes_03);
            Console.WriteLine("NativeShuffle Passes: " + passes_01);
            Console.WriteLine("ProfShuffle Passes: " + passes_02);

        }


        // -----------------------------------------------------------|-----------------------------------------------------------

        // checks that the players hand is sorted in ascending order of rank
        [TestMethod]
        public void testMethod_06()
        {
            bool flag = false;
            Deck deck_01 = new();
            Agent agent_01 = new("01", 10);

            agent_01.assignDeck(deck_01);

            for (int i = 0; i< 4; i ++)
                agent_01.addCard(20);
            
            for (int i = 1; i < agent_01.hand.Count; i++)
            {
                if (agent_01.hand[i - 1].Rank > agent_01.hand[i].Rank)
                    flag = true;
            }

            Assert.IsFalse(flag);


           }
    }
}
