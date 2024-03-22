using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABBIT_03
{
    public class Deck
    {
        public List<Card> cards = new(); // shouldn't be public
        public LinkedList<Card> discards = new(); // can be public, but also maybe not (?)
        public static Dictionary<int, Card> mCopy = new(); // this can be public, but also could not
        static Random randi = new();
        


        public int Count { get { return cards.Count; } }

        // -----------------------------------------------------------|-----------------------------------------------------------

        public Deck()
        {
            if (mCopy.Count() == 0)
                master_deck();
            deck_list();

        }

        // -----------------------------------------------------------|-----------------------------------------------------------

        public void deck_list_00()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    cards.Add(new Card(suit, rank));
                }
            }
        }

        public void deck_list()
        {
            cards.Clear();
            discards.Clear();
            int[] buffer = ProfShuffle(mCopy.Count);
            int II = mCopy.Count - 1;
            for (int i = II; i >= 0; i--) // still kinda of scuffed
                cards.Add(mCopy[buffer[i]]);
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

        private static void master_deck() // public 
        {
        int index = 0;

        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                mCopy.Add(index++, new Card(suit, rank));

        }

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

        // SHUFFLE SECTION

        public void Shuffle(){
            int[] buffer = ProfShuffle(mCopy.Count);
            cards.Clear();
            for (int i = mCopy.Count; i > 0; i--)
                cards.Add(mCopy[buffer[i]]);
        }

        public static int[] NativeShuffle(int theDeckSize = 100)
        {

            int delve_limit = 100;
            int deckSize = theDeckSize; //mCopy.Count();
            int[] tempArray = new int[deckSize];

            for (int i = 0; i < deckSize; i++)
                tempArray[i] = i;

            PreShuffle(tempArray, deckSize);
            PostShuffle(tempArray, delve_limit);

            return tempArray;
        }

        public static void PreShuffle(int[] tempArray, int deckSize) //, int swapLimit = 100 
        {
            for (int i = 0; i < deckSize; i++)
            {
                int a = randi.Next(0, deckSize);
                Swap(ref tempArray[i], ref tempArray[a]); 
            }
        }

        public static void PostShuffle(int[] tempArray, int delvesLeft) //, int swapLimit = 100 
        {
            if (--delvesLeft == 0)
                return;
            bool same_spot = false;
            int deckSize = tempArray.Length;


            for (int i = 0; i < tempArray.Length; i++) {
                if (tempArray[i] == i) {
                    same_spot = true;
                    Swap(ref tempArray[i], ref tempArray[randi.Next(0, deckSize)]);
                }
            }

            if (same_spot == true)
                PostShuffle(tempArray, delvesLeft);
        }

        public static int[] ProfShuffle(int theDeckSize = 100)
        {
            int deckSize = theDeckSize; //mCopy.Count();
            int[] tempArray = new int[deckSize];


            for (int i = 0; i < deckSize; i++)
                tempArray[i] = i;
            
            for (int i = deckSize -1 ; i > 0; i--)
                Swap(ref tempArray[i], ref tempArray[randi.Next(i)]);

            return tempArray;
        }

        // used for shuffle validation profile; about ~430 out of 1000 pass
        public static int[] PartialShuffle(int theDeckSize = 100)
        {
            int deckSize = theDeckSize; // mCopy.Count();
            int[] tempArray = new int[deckSize];

            for (int i = 0; i < deckSize; i++)
                tempArray[i] = i;

            for (int i = 0; i < deckSize; i++)
            {
                int a = randi.Next(0, deckSize);
                Swap(ref tempArray[i], ref tempArray[a]);
            }


            return tempArray;
        }
        // temporary variants used for benchmark test
        public static void NativeShuffle_01()
        {

            int delve_limit = 100;
            int deckSize = 100; //mCopy.Count();
            int[] tempArray = new int[deckSize];

            for (int i = 0; i < deckSize; i++)
                tempArray[i] = i;

            PreShuffle(tempArray, deckSize);
            PostShuffle(tempArray, delve_limit);

        }
        public static void ProfShuffle_01()
        {
            int deckSize = 100; //mCopy.Count();
            int[] tempArray = new int[deckSize];

            for (int i = 0; i < deckSize; i++)
                tempArray[i] = i;

            for (int i = deckSize - 1; i > 0; i--)
                Swap(ref tempArray[i], ref tempArray[randi.Next(i)]);

        }
        public static void ProfShuffle_02(int arg)
        {
            int deckSize = arg; //mCopy.Count();
            int[] tempArray = new int[deckSize];

            for (int i = 0; i < deckSize; i++)
                tempArray[i] = i;

            for (int i = deckSize - 1; i > 0; i--)
                Swap(ref tempArray[i], ref tempArray[randi.Next(i)]);

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

        

        // -----------------------------------------------------------|-----------------------------------------------------------
        static void Swap(ref int a, ref int b)
        {
            int temp;
            temp = a;
            a = b;
            b = temp;
        }
        // -----------------------------------------------------------|-----------------------------------------------------------
        static void SelectionSort(int[] arg)
        {
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
            //return arr;
        }

        static void SelectionSort(List<int> arg)
        {
            int n = arg.Count;

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
            //return arr;
        }
        // -----------------------------------------------------------|-----------------------------------------------------------
        static void showArray(int[] arr, int lineLen = 10)
        {
            int n = arr.Length;
            int entries_per_line = 0;
            for (int i = 0; i < n; ++i) {
                Console.Write(arr[i] + " ");
                //if (i % lineLen == 0)
                 //   Console.WriteLine('\n');
                if (++entries_per_line >= lineLen)
                {
                    Console.WriteLine('\n');
                    entries_per_line = 0;
                }
            }
            Console.WriteLine();
        }

        static void show(List<Card> arr, int lineLen = 10)
        {
            int n = arr.Count();
            int entries_per_line = 0;
            for (int i = 0; i < n; ++i)
            {
                if (arr[i].Hidden != true)
                    arr[i].Flip();
                Console.WriteLine(arr[i].Rank + " of " + arr[i].Suit);
                Console.Write(arr[i] + " ");
                if (i % lineLen == 0)
                    Console.WriteLine('\n');

            }
            Console.WriteLine();
        }

        // -----------------------------------------------------------|-----------------------------------------------------------
    }
}
