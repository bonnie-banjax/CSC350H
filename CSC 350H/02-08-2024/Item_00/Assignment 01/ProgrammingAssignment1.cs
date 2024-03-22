using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleCards;
//using Cards2;

namespace ProgrammingAssignment1
{
    /// <summary>
    /// Programming Assignment 1
    /// Your name: Andrew Mobus
	/// Date: 02-06-2024
	/// Ver: (1?)
    /// </summary>
    class Program
    {
        //-----------------------------------------------------------|-----------------------------------------------------------
        public struct Player
        {

            public int ID; // string playerID
            public int maxCards;
            public int handSize;
            public List<Card> hand; // if List doesn't have a len() function  | Count() function 

        };
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
                    if (players[i].hand.Count() < dealCount[i])
                    {
                        //Card card = theDeck.TakeTopCard();
                        players[i].hand.Add(theDeck.TakeTopCard()); //theDeck.TakeTopCard()
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
            {
                for (int i = 0; i < player.hand.Count(); i++)
                    player.hand[i].FlipOver();
            }

        }
        //-----------------------------------------------------------|-----------------------------------------------------------
        static public void ShowEm(List<Player> players)
        {

            foreach (Player player in players)
            {
                for (int i = 0; i < player.hand.Count(); i++)
                    Console.Write("Player (" + (player.ID + 1) + ") card is " + player.hand[i].Rank + player.hand[i].Suit + '\n');
            }


        }
        //-----------------------------------------------------------|-----------------------------------------------------------
        static void Main(string[] args)
        {
            int[] specs = { 2, 3, 3, 2 };
            int numPlayers = specs.Count();
            Deck deck_00 = new Deck();
            List<Player> player = new List<Player> { }; // alternative:

            for (int i = 0; i < numPlayers; i++)
            { player.Add(new Player { ID = i, hand = new List<Card> { }, handSize = 0, maxCards = 5 }); }

            DealEm(deck_00, player, specs);
            FlipEm(player);
            ShowEm(player);
        }
        //-----------------------------------------------------------|-----------------------------------------------------------
    }
}
