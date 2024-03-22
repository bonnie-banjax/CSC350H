using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleCards;

namespace Assignment_01_v2
{
    /// <summary>
    /// Programming Assignment 1 Refactor
    /// Your name: Andrew Mobus
    /// Date: 02-06-2024
    /// Ver: (1?)
    /// </summary>
    class ASN_01_v2
    {
        //-----------------------------------------------------------|-----------------------------------------------------------

        //-----------------------------------------------------------|-----------------------------------------------------------
        static public void DealEm(Deck theDeck, List<Player> players, int[] specs)
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
        static public void FlipEm(List<Player> players)
        {
            foreach (Player player in players)
                player.FlipCards();
        }
        //-----------------------------------------------------------|-----------------------------------------------------------
        static public void ShowEm(List<Player> players)
        {
            foreach (Player player in players)
                 player.ShowCards();
        }
        //-----------------------------------------------------------|-----------------------------------------------------------
        static void Main(string[] args)
        {
            int[] specs = { 2, 3, 3, 2 };
            int numPlayers = specs.Count();
            Deck deck_00 = new();
            List<Player> players = new() { };
            List<Card> played_cards = new(); 

            for (int i = 0; i < numPlayers; i++)
            { players.Add(new Player(Convert.ToString(i+1), 5)); }

            foreach (Player player in players)
                player.assignDeck(deck_00);

            deck_00.Shuffle();

            DealEm(deck_00, players, specs);
            FlipEm(players);
            ShowEm(players);

            for (int i = 0; players[1].HandSize > 0; i++) // experimental for loop, originally played card i
                played_cards.Add(players[1].playCard(0)); // play card autoamtically flips card
            Console.WriteLine("First Card Played: " + played_cards[0].Rank + " " + played_cards[0].Suit);
            players[1].ShowCards();
            players[1].addCard(100); // card isn't flipped on purpose
            players[1].ShowCards(); // card isn't flipped on purpose
            players[1].getCard(0).FlipOver();
            Console.WriteLine("Next Drawn Card: " + players[1].getCard(0).Rank + " " + players[1].getCard(0).Suit); // getCard doesn't remove
        }
        //-----------------------------------------------------------|-----------------------------------------------------------
    }
}
