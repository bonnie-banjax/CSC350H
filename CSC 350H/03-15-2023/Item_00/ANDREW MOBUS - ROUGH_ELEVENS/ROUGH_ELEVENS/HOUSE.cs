using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROUGH_ELEVENS
{



    public class HOUSE
    {
        //-----------------------------------------------------------|-----------------------------------------------------------

        public Agent TableSet;
        public Deck houseDeck;
        public Validator validChecker; // (*1)
        public bool GameEnd;

        public RULESET DaRules = new();
        public Dictionary<string, RULESET> RuleSets; // IDictionary, HybridDictionary, OrderedDictionary?
        public LOGGER Audit = new();


        // (*1) this instance isn't strictly needed at the moment; the implementation of Validator was as a static class until
        // concurrent to the writing of this comment. The class was changed in order to allow House to have its own instance of
        // Validator to make clear the component relationship, and (eventually) better prepare for more complete encapsulation
        
        //-----------------------------------------------------------|-----------------------------------------------------------

        public HOUSE()
        {

        }
        void tableSettings(int size) // for here, 9
        {

            TableSet = new("TABLE", size);
            houseDeck = new();
            TableSet.assignDeck(houseDeck);
            for (int i = 0; i < TableSet.MaxCards; i++)
                TableSet.addCard(houseDeck.Draw());
        }

        //-----------------------------------------------------------|-----------------------------------------------------------

        // could pass in (table.getHand) just as list parameter
        // & rest works & could therefore put in Validator (not quite)
        // probably an Agent method
        public int[] hand_to_array(Agent table) // (List<Object> hand, Type obtype) ? (not quite)
        {
            if (table.HandSize == 0)
                return null;

            List<Card> checkset = table.GetHand;
            List<int> checklist = new();
            foreach (var card in checkset)
                checklist.Add((int)card.Rank);
            int[] TableArray = checklist.ToArray();

            return TableArray;
        }

        public bool validMoveExists(Agent table, int checkCon, (int a, int b, int c)extraCon) // for here, 11
        {
            if (table.HandSize == 0)
                return false;

            int[] exraCon = [extraCon.a, extraCon.b, extraCon.c];
            (int a, int b, int c) xtraCon = (exraCon[0], exraCon[1], exraCon[2]);

            return Validator.valid_move_exists(table.hand_to_array(), checkCon, extraCon); //validate_set_02(TableArray, checkCon);
        }


        //-----------------------------------------------------------|-----------------------------------------------------------

        public void PlayLoop(RULESET rules, string mode = "AUTO")
        {
            Console.WriteLine("[----------------------------------------------|----------------------------------------------]");

            if (rules.rule.Count == 0)
            { Console.WriteLine("[ERROR]: RULESET UNSPECIFIED"); return; }


            // setup data (*1)
            int cached_01 = (int)rules.rule["tableHandSize"];
            int cached_02 = (int)rules.rule["pairCheck"];
            int cached_03 = (int)rules.rule["triadCheck"];
            (int, int, int) cached_04 = ((int, int, int))rules.rule["triadTuple"];
            int[] cached_05 = (int[])rules.rule["triadCheckArray"];


            // (*1) the names of these variable bely their purpose; they are cached for performance,
            // and clarity in that these are the values required here, outlined in type.
            // by passing a rule struct that contains the dictionary parings, it allows those values
            // to be more easily changed without breaking changes, and leaves a clear path for
            // (abstraction / code reuse) in that this play loop matches to a ruleset with these
            // value signatures, allowing the ruleset struct to be more flexible (bad explanation)

            tableSettings(cached_01); 

            int turnCounter = 0; // could this be hanled by a genereal / generic counter function ?
            GameEnd = false; // trade off of global vs local game end variable
            // end setup data
            


            do {
                Console.Write("[" + (turnCounter++) + "]");
                GameEnd = !validMoveExists(TableSet, cached_02, cached_04);

                switch (mode)
                {
                    case "AUTO":
                        AutoMove(cached_02, cached_03, cached_05);
                        break;
                    case "MANUAL":
                        ManualMove(cached_02, cached_03, cached_05);
                        break;
                    default:
                        break;
                } // END_SWITCH
            } while (GameEnd != true);

            EvaluateGameState();

            Console.WriteLine("[----------------------------------------------|----------------------------------------------]");
        }

        // this function is still in development; the idea is to use the State struct
        // pattern to define the end conditions, as a means of extensibility
        // but right now this is a glorified boolean check with some feature sprinkles.
        public void EvaluateGameState()
        {

            LinkedList<object> seed_01 = new();
            LinkedList<object> seed_02 = new();

            seed_01.AddLast(TableSet.HandSize); // for EndState
            seed_02.AddLast(0); // For WinCon (will be part of RuleSet data)

            bool outcome;
            State EndState = new(seed_01); // this is outcome
            State WinCon = new(seed_02); // state object defining what victory looks like

            
            if (EndState == WinCon)
            { outcome = true; }
            else { outcome = false; }

            if (outcome == true)
                Audit.AddLog("[V]");
            else { Audit.AddLog("[F]"); }

            if (TableSet.HandSize != 0)
            { Console.WriteLine("Failure"); }
            else
            { Console.WriteLine("Victory"); }
        }

        //-----------------------------------------------------------|-----------------------------------------------------------
        public void ManualMove(int localPair, int localTriad, int[] triadArray)
        {
            TableSet.ShowCards_concise();
            Console.Write("Enter option (PAIR, TRIAD, AUTO, EXIT): ");
            string opt = Console.ReadLine();

            switch (opt)
            {
                case "PAIR":
                    Console.Write("Enter (pair): ");

                    Console.Write("Enter (1): ");
                    int a = int.Parse(Console.ReadLine());
                    Console.Write("Enter (2): ");
                    int b = int.Parse(Console.ReadLine());
                    
                    processMove(a, b, localPair);
                    break;
                case "TRIAD":
                    Console.Write("Enter (triad): ");

                    Console.Write("Enter (1): ");
                    int c = int.Parse(Console.ReadLine());
                    Console.Write("Enter (2): ");
                    int d = int.Parse(Console.ReadLine());
                    Console.Write("Enter (3): ");
                    int e = int.Parse(Console.ReadLine());
                    
                    processMove(c, d, e, localTriad);
                    break;
                case "AUTO":
                    AutoMove(localPair, localTriad, triadArray);
                    break;
                case "EXIT":
                    GameEnd = true;
                    break;
                default:
                    break;
            }

        } // END_FUNC
        
        private void AutoMove(int localPair, int localTriad, int[] triadArray)
        {
            
            (int, int, int) triadTuple = (triadArray[0], triadArray[1], triadArray[2]); // refactor into array form & pass as parameter
            int[] pair_indexes = Validator.find_pair_index(TableSet.hand_to_array(), localPair);
            int[] triad_indexes = Validator.find_triad_index(TableSet.hand_to_array(), triadTuple);

            // game end refactor required
            if (((pair_indexes[0] >= 0) || (triad_indexes[0] >= 0)) == false)
                GameEnd = true;

            // these can be refactored, at least in their bool conditions
            if (pair_indexes[0] >= 0)
            {
                autoprocessMove(pair_indexes);
                Console.WriteLine("Indexes: " + pair_indexes[0] + " " + pair_indexes[1]);
            }
            if (pair_indexes[0] < 0 && triad_indexes[0] >= 0) // could be else if instead of if
            {
                autoprocessMove(triad_indexes); 
                Console.WriteLine("Indexes: " + triad_indexes[0] + " " + triad_indexes[1] + " " + triad_indexes[2]);
            }
        } // END_FUNC

        //-----------------------------------------------------------|-----------------------------------------------------------
        
        public void processMove(int nDex_01, int nDex_02, int checkCon)
        {
            if (nDex_01 == nDex_02)
                return;
            
            Card C1 = TableSet.getCard(nDex_01);
            Card C2 = TableSet.getCard(nDex_02);
            bool isValid = Validator.validate_set([(int)C1.Rank, (int)C2.Rank], checkCon);

            int[] n = [nDex_01, nDex_02];
            int[] tempDex = sortMaxMin(ref n);

            if (isValid == true && houseDeck.CardCount !=0) // doesn't track table discard
            {
                TableSet.addCard(houseDeck.Draw(), nDex_01);
                TableSet.addCard(houseDeck.Draw(), nDex_02);
            }
            else if (isValid == true && houseDeck.CardCount == 0)
            {
                foreach (int i in tempDex)
                    TableSet.removeCard(i);
            }
            else
                Console.WriteLine("Move is Invalid");
        } // END_FUNC

        public void processMove(int nDex_01, int nDex_02, int nDex_03, int checkCon)
        {
            // doesn't need the identical index check that pair does
            
            Card C1 = TableSet.getCard(nDex_01);
            Card C2 = TableSet.getCard(nDex_02);
            Card C3 = TableSet.getCard(nDex_03);
            bool isValid = Validator.validate_set([(int)C1.Rank, (int)C2.Rank, (int)C3.Rank], checkCon);

            int[] n = [nDex_01, nDex_02, nDex_03];
            int[] tempDex = sortMaxMin(ref n);

            if (isValid == true && houseDeck.CardCount != 0)
                foreach (int index in tempDex)
                    TableSet.addCard(houseDeck.Draw(), index);
            else if (isValid == true && houseDeck.CardCount == 0)
                foreach (int index in tempDex)
                    TableSet.removeCard(index);
            else { Console.WriteLine("Move is Invalid"); }

        } // END_FUNC

        // relies on receiving an array with [-1] as means of validating
        // good example on trade-off between performance & security
        public void autoprocessMove(int[] nDexes)
        {
            if (nDexes[0] == (-1))
                return; // Console.WriteLine("INVALID ");

            int[] descendOrder = sortMaxMin(ref nDexes);//
            foreach (int i in nDexes)
            {
                if (houseDeck.CardCount != 0)
                    TableSet.addCard(houseDeck.Draw(), (i)); //(nDexes[i])
                else { TableSet.removeCard(i); } // (nDexes[i])
            }

            /*
            // Still can't get this to work
            int[] ascend = sortMinMax(ref nDexes);
            int a = nDexes.Length - 1;
            for (int i = a; i > 0; i--)
            {
                if (houseDeck.CardCount != 0)
                    TableSet.addCard(houseDeck.Draw(), (ascend[i]));
                else { TableSet.removeCard((ascend[i])); }
            }
            */






        } // END_FUNC

        //-----------------------------------------------------------|-----------------------------------------------------------


        public int[] sortMinMax(ref int[] SortMe) // min
        {
            int[] arg = SortMe;

            int n = arg.Length;

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
            SortMe = arg;
            return SortMe;
        }

        public int[] sortMaxMin(ref int[] SortMe) // min
        {
            int[] arg = SortMe;

            int n = arg.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int maxIndex = i;
                for (int j = i + 1; j < n; j++)
                    if (arg[j] > arg[maxIndex])
                        maxIndex = j;

                int temp = arg[maxIndex];
                arg[maxIndex] = arg[i];
                arg[i] = temp;
            }
            SortMe = arg;
            return SortMe;
        }

        //-----------------------------------------------------------|-----------------------------------------------------------
    }
}


