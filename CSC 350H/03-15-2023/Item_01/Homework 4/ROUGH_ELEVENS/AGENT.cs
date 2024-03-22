using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ROUGH_ELEVENS
{
    public class Agent
    {
        //-----------------------------------------------------------|-----------------------------------------------------------
        string id; // string used for AgentID
        int maxCards;
       
        private List<Card> hand = new();
        Deck myDeck; // reference to a deck, originally a pointer

        public string ID { get { return id; } set { id = value; } }
        public int MaxCards { get { return maxCards; } set { maxCards = value ; } }
        public int HandSize { get { return hand.Count; } }
        //-----------------------------------------------------------|-----------------------------------------------------------
        public List<Card> GetHand { get { return hand; } }
        //-----------------------------------------------------------|-----------------------------------------------------------
        public Agent()
        {
            id = "[-]";
            maxCards = 0;
        }
        public Agent(string arg1, int arg2)
        {
            id = arg1;
            maxCards = arg2;
        }
        public Agent(Deck theDeck, string arg1, int arg2)
        {
            id = arg1;
            maxCards = arg2;

            if (theDeck != null)
                assignDeck(theDeck);
            else myDeck = null;
        }

        //-----------------------------------------------------------|-----------------------------------------------------------
        public void assignDeck(Deck theDeck)
        {
            if (theDeck != null)
                myDeck = theDeck;
        }
        //-----------------------------------------------------------|-----------------------------------------------------------

        public bool addCard (Card theCard, int nDex = -1)
        {
            if (theCard == null)
                return false;
            else if (nDex >= 0 && nDex < hand.Count()) {
                hand[nDex] = theCard;
                // hand.Insert(nDex, theCard); // its inserting, not overwriting // could really be solved with a circular buffer
                return true;
            }
            else if (hand.Count < maxCards) {
                hand.Add(theCard);
                return true;
            }
            else return false;
        }
        public bool removeCard(int nDex = -1)
        {
            if (nDex >= 0 && nDex < hand.Count())
            {
                hand.RemoveAt(nDex);
                return true;
            }
            else return false;
        }
        //-----------------------------------------------------------|-----------------------------------------------------------
        public Card playCard(int nDex = -1)
        {
            if (nDex >= 0 && nDex < hand.Count())
            {
                Card theCard = hand[nDex];
                hand.RemoveAt(nDex);

                if (theCard.Hidden != true)
                    theCard.Flip();
                return theCard;
            }
            else return null;
        }
        public Card getCard(int nDex = -1)
        {
            if (nDex >= 0 && nDex < hand.Count())
            {
                Card theCard = hand[nDex];
                return theCard;
            }
            else return null;
        }
        //-----------------------------------------------------------|-----------------------------------------------------------
        public void FlipCards() {
            foreach (Card card in hand)
                card.Flip();
        }
        public void ShowCards_verbose()
        {
            int counter = 0;
            if (hand.Count != 0)
                foreach (Card card in hand)
                { 
                    Console.Write("Agent (" + (ID) + ") card [" + (counter++) + "] is " + card.Rank + " of " + card.Suit + '\n');
                }
                    
            else Console.Write("Agent (" + (ID) + ") has no cards" + '\n');
        }
        public void ShowCards_concise()
        {
            int counter = 0;
            int chunksize = 3;
            if (hand.Count != 0)
                foreach (Card card in hand)
                {
                    Console.Write( "[" + (counter++) + ": " + card.Rank + "_" + card.Suit + ']');
                    if (counter % chunksize == 0)
                        Console.Write('\n');
                }

            else Console.Write("[EMPTY]" + '\n');
        }
        //-----------------------------------------------------------|-----------------------------------------------------------

        public int[] hand_to_array() // Orignally from HOUSE but makes more sense here
        {
            if (HandSize == 0)
                return null;

            List<Card> checkset = GetHand;
            List<int> checklist = new();
            foreach (var card in checkset)
                checklist.Add((int)card.Rank);
            int[] TableArray = checklist.ToArray();

            return TableArray;
        }

        public void sortHand_01() // Min-Max
        {
            List<Card> arg = hand;

            int n = arg.Count;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                    if (arg[j].Rank < arg[minIndex].Rank)
                        minIndex = j;

                Card temp = arg[minIndex];
                arg[minIndex] = arg[i];
                arg[i] = temp;
            }
            hand = arg;
        }

        public void sortHand_02() // Max-Min
        {
            List<Card> arg = hand;

            int n = arg.Count;

            for (int i = 0; i < n - 1; i++)
            {
                int maxIndex = i;
                for (int j = i + 1; j < n; j++)
                    if (arg[j].Rank > arg[maxIndex].Rank)
                        maxIndex = j;

                Card temp = arg[maxIndex];
                arg[maxIndex] = arg[i];
                arg[i] = temp;
            }
            hand = arg;
        }

        //-----------------------------------------------------------|-----------------------------------------------------------

    };
}
