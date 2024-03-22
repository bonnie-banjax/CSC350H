using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LABBIT_03
{
    public class Prototyper
    {
        //-----------------------------------------------------------|-----------------------------------------------------------

        //-----------------------------------------------------------|-----------------------------------------------------------
        static public void DealEm(Deck theDeck, List<Agent> players, int[] specs)
        {

            int size = specs.Length;
            int count = players.Count();
            int totalCards = 0;

            int[] dealCount = { 0, 0, 0, 0 }; //int dealCount[size];

            int failsafe = 0;


            for (int i = 0; i < size; i++)
            {
                dealCount[i] = specs[i];
                totalCards += specs[i];
            }


            do
            {
                for (int i = 0; i < count; i++)
                {
                    if (players[i].HandSize < dealCount[i]) //players[i].hand.Count() < dealCount[i]
                    {

                        players[i].addCard(100); // 100 used to insure over max hand size without repeated calls to MaxCards
                        totalCards -= 1;
                    }
                }

                failsafe += 1;
            } while ((totalCards > 0) && (failsafe < 100));


        }
        //-----------------------------------------------------------|-----------------------------------------------------------
        static public void FlipEm(List<Agent> players)
        {
            foreach (Agent player in players)
                player.FlipCards();
        }
        //-----------------------------------------------------------|-----------------------------------------------------------
        static public void ShowEm(List<Agent> players)
        {
            foreach (Agent player in players)
                player.ShowCards();
        }
        //-----------------------------------------------------------|-----------------------------------------------------------
        static List<Agent> Basic_setup(Deck argDeck)
        {

            int[] specs = { 2, 3, 3, 2 }; // { 2, 3, 3, 2 }
            int numPlayers = specs.Count();
            int cards_per_player = 0;
            int max_cards_per_player = 0;
            
            Deck deck_00 = argDeck;
            List<Agent> players = new() { };


            for (int i = 0; i < numPlayers; i++)
            { players.Add(new Agent(Convert.ToString(i + 1), max_cards_per_player)); }

            foreach (Agent player in players)
                player.assignDeck(deck_00);


            return players;
        }
        //-----------------------------------------------------------|-----------------------------------------------------------
        static void Test_00(int[] args)
        {
            int[] specs = args; // { 2, 3, 3, 2 }
            int numPlayers = specs.Count();
            Deck deck_00 = new();
            List<Agent> players = new() { };

            for (int i = 0; i < numPlayers; i++)
            { players.Add(new Agent(Convert.ToString(i + 1), 5)); }

            foreach (Agent player in players)
                player.assignDeck(deck_00);

            deck_00.Shuffle();

            DealEm(deck_00, players, specs);
            FlipEm(players);
            ShowEm(players);
        }
        //-----------------------------------------------------------|-----------------------------------------------------------
        static void Test_01(int[] args)
        {
            int[] specs = args; //{ 2, 3, 3, 2 }
            int numPlayers = specs.Count();
            Deck deck_00 = new();
            List<Agent> players = new() { };
            LinkedList<Card> played_cards = new();


            for (int i = 0; i < numPlayers; i++)
            { players.Add(new Agent(Convert.ToString(i + 1), 5)); }

            foreach (Agent player in players)
                player.assignDeck(deck_00);

            deck_00.Shuffle();


            for (int i = 0; players[1].HandSize > 0; i++) // experimental for loop, originally played card i
                played_cards.Append(players[1].playCard(0)); // play card autoamtically flips card
            
            Console.WriteLine("First Card Played: " + played_cards.First().Rank + " " + played_cards.First().Suit);
            players[1].ShowCards();
            players[1].addCard(100); // card isn't flipped on purpose
            players[1].ShowCards(); // card isn't flipped on purpose
            players[1].getCard(0).Flip();
            Console.WriteLine("Next Drawn Card: " + players[1].getCard(0).Rank + " " + players[1].getCard(0).Suit); // getCard doesn't remove
        }
        //-----------------------------------------------------------|-----------------------------------------------------------
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

        //-----------------------------------------------------------|-----------------------------------------------------------

        // Somewhat overboard tests

        public static void proto_01(int counter)
        {
            Console.WriteLine("[ " + counter + " ]");
        }

        public static void Bench_00()
        {
            int iter = 1000;
            Benchmark(Deck.NativeShuffle_01, iter);
            Benchmark(Deck.ProfShuffle_01, iter);
        }


        public static void Bench_03()
        {
            int iter = 1000;

            // equivalent to vlock comment below it
            for (int i = 1; i <= (iter * iter); i*=10)
                Benchmark(Deck.ProfShuffle_02, i, iter);
            /*
            Benchmark(Deck.ProfShuffle_02, 10, iter);
            Benchmark(Deck.ProfShuffle_02, 100, iter);
            Benchmark(Deck.ProfShuffle_02, 1_000, iter);
            Benchmark(Deck.ProfShuffle_02, 10_000, iter);
            Benchmark(Deck.ProfShuffle_02, 100_000, iter);
            Benchmark(Deck.ProfShuffle_02, 1_000_000, iter);
            */

            // overshot, still fine tuning
            for (int i = 1; i <= (iter * iter); i *= 10)
                Benchmark(Deck.ProfShuffle_02, iter, iter*i);

        }
        
        // incomplete, extraneous
        public static void Bench_04()
        {
            int val = 0;
            Benchmark(proto_01, ref val , 10);
        }

        //-----------------------------------------------------------|-----------------------------------------------------------

        // I grabbed this base benchmarking test off Stack Overflow
        private static void Benchmark(Action act, int iterations)
        {
            GC.Collect();
            act.Invoke(); // run once outside of loop to avoid initialization costs
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                act.Invoke();
            }
            sw.Stop();
            Console.WriteLine("Per Iteration: " + (sw.ElapsedMilliseconds / (float)iterations).ToString());
            Console.WriteLine("Total Milliseconds: " + (sw.ElapsedMilliseconds).ToString());
        }

        private static void Benchmark(Action<string> act, string obj, int iterations)
        {
            GC.Collect();
            act.Invoke(obj); // run once outside of loop to avoid initialization costs
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                act.Invoke(obj);
            }
            sw.Stop();
            Console.WriteLine("Per Iteration: " + (sw.ElapsedMilliseconds / (float)iterations).ToString());
            Console.WriteLine("Total Milliseconds: " + (sw.ElapsedMilliseconds).ToString());
        }

        private static void Benchmark(Action<int> act, int obj, int iterations)
        {
            GC.Collect();
            act.Invoke(obj); // run once outside of loop to avoid initialization costs
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                act.Invoke(obj);
            }
            sw.Stop();
            Console.WriteLine("Per Iteration: " + (sw.ElapsedMilliseconds / (float)iterations).ToString());
            Console.WriteLine("Total Milliseconds: " + (sw.ElapsedMilliseconds).ToString());
        }

        private static void Benchmark(Action<int> act, ref int obj, int iterations)
        {
            GC.Collect();
            act.Invoke(obj); // run once outside of loop to avoid initialization costs
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                act.Invoke(obj);
            }
            sw.Stop();
            Console.WriteLine("Per Iteration: " + (sw.ElapsedMilliseconds / (float)iterations).ToString());
            Console.WriteLine("Total Milliseconds: " + (sw.ElapsedMilliseconds).ToString());
        }

        //-----------------------------------------------------------|-----------------------------------------------------------
    }
}
