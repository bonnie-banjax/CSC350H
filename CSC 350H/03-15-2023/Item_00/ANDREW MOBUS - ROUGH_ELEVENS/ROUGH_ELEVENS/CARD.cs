using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROUGH_ELEVENS
{
    public class Card
    {
        Rank rank; // Rank rank;
        Suit suit; // Suit suit;
        bool hidden; // hide - faceUp - face

        public Suit Suit { get { return suit; } }
        public Rank Rank { get { return rank; } }
        public bool Hidden { get { return hidden; } }

        public Card(Suit suit, Rank rank)
        {
            this.suit = suit;
            this.rank = rank;
            this.hidden = true;
        }

        public void Flip()
        { hidden ^= hidden; } // ^ is the exclusive or operator 

        public (int, int) enumValues()
        {
            return ((int)suit, (int)rank);
        }

    }
}
