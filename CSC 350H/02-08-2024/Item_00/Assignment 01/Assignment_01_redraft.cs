using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using ConsoleCards;
using Cards2;


namespace ProgrammingAssignment1 
{
	class Programed
    {
		public struct Player
		{

			public int ID; // string playerID
			public int maxCards;
			public int handSize;
			public List<Card> hand; // if List doesn't have a len() function  | Count() function 

		};

		static void Main(string[] args)
		{



			Deck deck_00 = new Deck();


			// List<int> specs = new List<int> { 2, 3, 3, 2 };
			int[] specs = { 2, 3, 3, 2 };
			int numPlayers = specs.Count();

			//Player player[numPlayers] = new Array(); // not sure it works like this (but it validated (?)
			List<Player> player = new List<Player> { }; // alternative:

			for (int i = 0; i<numPlayers; i++) {
				player[i] = new Player {ID = i, hand = { }, handSize = 0, maxCards = 5 };
			}

			DealEm(deck_00, player, specs);

		}

		static public void DealEm(Deck theDeck, List<Player> players, int[] specs)
		{

			int size = specs.Length;
			int count = players.Count();
			int totalCards = 0;
			//int dealCount[size];
			int failsafe = 0;
            int[] dealCount = { };


			for (int i = 0; i < size; i++)
			{
				dealCount[i] = specs[i];
				totalCards += specs[i];
			}


			while ((totalCards < 0) && (failsafe < 100))
			{
				for (int i = 0; i < count; i++)
				{
					if (players[i].hand.Count < dealCount[i])
					{
						players[i].hand.Add(theDeck.TakeTopCard());
						totalCards -= 1;
					}
				}

				failsafe += 1;
			}


		}

		static public void FlipEm(List<Player> players)
		{

			foreach (Player player in players)
			{
				for (int i = 0; i < player.hand.Count(); i++)
					player.hand[i].FlipOver();
			}

		}

		static public void ShowEm(List<Player> players)
		{

			foreach (Player player in players)
			{
				for (int i = 0; i < player.hand.Count(); i++)
					Console.Write("Player (" + player.ID + ") card is " + player.hand[i]);
			}


		}

//-----------------------------------------------------------|-----------------------------------------------------------
	}
//-----------------------------------------------------------|-----------------------------------------------------------
}
//-----------------------------------------------------------|-----------------------------------------------------------

/*
public void DealEm(Deck theDeck, List players, specs)
{

	int size = specs.Count();
	int count = players.Count();
	int totalCards = 0;
	int dealCount[size];

	for (int i = 0; i < size; i++)
	{
		dealCount[i] = specs[i];
		totalCards += specs[i];
	}


	while ((totalCards < 0) && (failsafe < theDeck.Count()))
	{
		for (int i = 0; i < count; i++)
		{
			if (players[i].Hand.Count < dealCount[i])
			{
				players[i].Hand.Add(theDeck.draw());
				totalCards -= 1;
			}
		}

		failsafe += 1;
	}


}

public void FlipEm(List players)
{

	foreach (player in players)
	{
		for (int i = 0; i < player.Hand.Count(); i++)
			player.Hand[i].Flip()
				}

}

public void ShowEm(List players)
{

	foreach (player in players)
	{
		for (int i = 0; i < player.Hand.Count(); i++)
			Console.Write("Player (" + player.ID + ") is " + cardplayer.Hand[i])
					}


}

*/
