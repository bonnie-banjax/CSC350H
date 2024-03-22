using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cards2;

namespace CardTest2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            deck.Print();
            Card c1 = new Card(Rank.Nine, Suit.Diamonds);
            Console.WriteLine(c1.getScore());
            string input = Console.ReadLine();
            //
            //
            while ( /* input is not 'q'  */ )
            {
                // Add your code between this comment
                // and the comment below. You can of
                // course add more space between the
                // comments as needed

                // declare a deck variables and create a deck object
                // DON'T SHUFFLE THE DECK


                // deal 2 cards each to 4 players (deal properly, dealing
                // the first card to each player before dealing the
                // second card to each player)


                // deal 1 more card to players 2 and 3


                // flip all the cards over


                // print the cards for player 1


                // print the cards for player 2


                // print the cards for player 3


                // print the cards for player 4


                // Don't add or modify any code below
                // this comment
                input = Console.ReadLine();
            }        
        }
    }
}
