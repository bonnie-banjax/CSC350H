// Andrew Mobus

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleCards;

namespace CSC350H_Spring2024_02_01_2024
{
    internal class Scuffed_Deck
    {
        static void Main(string[] args)
        {
            // NeoDecker();
            decker();
        }

        static void decker()
        {
            Deck deck = new Deck();
            Card card = null;

            while (deck.Empty != true)
                Draw(deck, card);

            Deck deck_2 = new Deck();

            deck_2.Shuffle();

            struct Player { };
            //Random cut_point = new Random(52);

            //deck_2.Cut(cut_point.Next());
            deck_2.Cut(21);

            while (deck_2.Empty != true)
                Draw(deck_2, card);


        }

        static void Draw(Deck deck, Card card)
        {

            card = deck.TakeTopCard();
            card.FlipOver();
            Console.WriteLine(card.Rank + " " + card.Suit);
        }

        static void NeoDecker()
        {
            Deck deck = new Deck();
            
            
            Card card1 = deck.TakeTopCard();

            Card card2 = deck.TakeTopCard();

            Card card3 = deck.TakeTopCard();

            Card card4 = deck.TakeTopCard();

            Card card5 = deck.TakeTopCard();


            List<Card> NeoDeck = new List<Card> { card1, card2, card3, card4, card5 };
            int counter = 0;
            
            //for (int i = 0; i < 52; i++)
                //NeoDeck.Append(Card card = null);

            // or (!deck.Empty)


            while (deck.Empty != true)
            {
                counter++;
                NeoDeck.Append(deck.TakeTopCard());
            }
            
            Console.WriteLine(counter); //Console.WriteLine(NeoDeck[0].Rank + " " + NeoDeck[0].Suit);

            foreach (Card l_card in NeoDeck)
            {
                l_card.FlipOver();
                Console.WriteLine(l_card.Rank + " " + l_card.Suit);
            }
            

        }

    }

}


/*
Write code to 
create a new deck and tell the deck to print itself
tell the deck to shuffle and print itself
take the top card from the deck and print the card rank and suit (check Card class for rank and suit)
    take the top card from the deck and print the card rank and suit 
Cut the deck of cards at a random position
print all cards in the deck
*/
