
struct Hand {

int handSize = 7;
int Hand[] = {};

}

struct Player {

	Hand One = 7, {}
	Hand Two = 7, {}
	Hand Three = 7, {}
	Hand Four = 7, {}

}

struct Hand {

int maxCards;
List<Card> 

}


foreach (p in players) // not the right option, it will complain, do normal for loop
{
	p.maxCards = 5
	p.handSize = 0;
}

//-----------------------------------------------------------|-----------------------------------------------------------

struct Player {

int ID; // string playerID
int maxCards;
int handSize;
List<Card> hand; // if List doesn't have a len() function  | Count() function 
 
}



int specs[] = {2, 3, 3, 2}
int numPlayers = specs.Length();

Player player[numPlayers] = new Array(); // not sure it works like this (but it validated (?)
List<Player> players = new List() // alternative:

for (int i = 0; i < numPlayers; i++)
{
	player[i] = new Player();
	player[i].ID = i; // to string (?)
	player[i].maxCards = 5;
	player[i].handSize = 0;
}


Deck deck_00 = new Deck();


public void DealEm(Deck theDeck, List players, const int specs[])
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
	

	while ( (totalCards < 0) && (failsafe < theDeck.Count() ) ) {
		for (int i = 0; i < count; i++) {
			if players[i].Hand.Count < dealCount[i] {
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