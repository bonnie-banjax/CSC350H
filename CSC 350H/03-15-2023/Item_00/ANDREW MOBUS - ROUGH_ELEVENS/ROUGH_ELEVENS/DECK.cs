using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROUGH_ELEVENS
{
    public class Deck
    {
        List<Card> cards = new();
        LinkedList<Card> discards = new();
        static Dictionary<int, Card> mCopy = new();
        static Random randi = new();

        public int CardCount { get { return cards.Count; } }

        // -----------------------------------------------------------|-----------------------------------------------------------

        public Deck()
        {
            if (mCopy.Count() == 0)
                master_deck();
            deck_list();

        } // END_FUNC

        // -----------------------------------------------------------|-----------------------------------------------------------

        public void deck_list()
        {
            cards.Clear();
            discards.Clear();
            
            int[] buffer = PrepShuffle(mCopy.Count);
            int II = mCopy.Count - 1;
            for (int i = II; i >= 0; i--) // still kinda of scuffed
                cards.Add(mCopy[buffer[i]]);
        } // END_FUNC

        private static void master_deck() // public 
        {
            int index = 0;

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                { 
                    if ((suit != Suit.NULL) && (rank != Rank.NULL))
                    mCopy.Add(index++, new Card(suit, rank)); }
        } // END_FUNC

        // -----------------------------------------------------------|-----------------------------------------------------------

        public void Cut(int cutPoint)
        {
            List<Card> tempList = new();

            for (int i = 0; i < cutPoint; i++)
            {
                tempList.Add(cards[i]);
            }
            cards.RemoveRange(0, cutPoint);
            cards.InsertRange(cards.Count, tempList);

        }

        // -----------------------------------------------------------|-----------------------------------------------------------

        public void Shuffle(){
            int[] buffer = PrepShuffle(mCopy.Count);
            cards.Clear();
            for (int i = mCopy.Count; i > 0; i--)
                cards.Add(mCopy[buffer[i]]);
        }

        public static int[] PrepShuffle(int theDeckSize)
        {
            int deckSize = theDeckSize; //mCopy.Count();
            int[] tempArray = new int[deckSize];


            for (int i = 0; i < deckSize; i++)
                tempArray[i] = i;
            
            for (int i = deckSize -1 ; i > 0; i--)
                Swap(ref tempArray[i], ref tempArray[randi.Next(i)]);

            return tempArray;
        }

        // this is scuffed
        public void unshuffled_deck()
        {
            cards.Clear();
            discards.Clear();

            int[] buffer = new int[mCopy.Count];
            for (int i = 0; i < mCopy.Count; i++)
                buffer[i] = i;

            int II = mCopy.Count - 1;
            for (int i = II; i >= 0; i--) // still kinda of scuffed
                cards.Add(mCopy[buffer[i]]);
        }

        // -----------------------------------------------------------|-----------------------------------------------------------
        public Card Draw()
        {
            Card topCard = null;

            if (cards.Count == 0)
                Console.WriteLine("Draw failed; Deck is empty");
            else
            {
                topCard = cards[0];
                discards.AddLast(cards[0]);
                cards.RemoveAt(0);
            }
            return topCard;
        }
        // -----------------------------------------------------------|-----------------------------------------------------------
        static void Swap(ref int a, ref int b)
        {
            int temp;
            temp = a;
            a = b;
            b = temp;
        }
        // -----------------------------------------------------------|-----------------------------------------------------------

        public static void Show(List<Card> arr, int lineLen = 10)
        {
            int n = arr.Count();
            for (int i = 0; i < n; ++i)
            {
                if (arr[i].Hidden == true)
                    arr[i].Flip();
                Console.WriteLine(arr[i].Rank + " of " + arr[i].Suit);
                Console.Write(arr[i] + " ");
                if (i % lineLen == 0)
                    Console.WriteLine('\n');
            }
            Console.WriteLine();
        }
        public void Show(int lineLen = 10)
        {
            List<Card> arr = cards; // ineffecient copying, go back & just change arr to cards

            int n = arr.Count();
            int entries_per_line = 0;
            for (int i = 0; i < n; ++i)
            {
                if (arr[i].Hidden == true)
                    arr[i].Flip();
                Console.WriteLine(arr[i].Rank + " of " + arr[i].Suit);
                //Console.Write(arr[i] + " ");
                if (i % lineLen == 0)
                    Console.WriteLine('\n');
            }
            Console.WriteLine();
        }

        // -----------------------------------------------------------|-----------------------------------------------------------
    }
}

/*

 // -----------------------------------------------------------|-----------------------------------------------------------


 // -----------------------------------------------------------|-----------------------------------------------------------

 */