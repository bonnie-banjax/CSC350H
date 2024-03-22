using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABBIT_03
{
    public enum Rank
    {
        // gotta be more efficient way
        ACE,
        TWO,
        THREE,
        FOUR,
        FIVE,
        SIX,
        SEVEN,
        EIGHT,
        NINE,
        TEN,
        JACK,
        QUEEN,
        KING

        //etc

    }
    public enum Suit
    {
        SWORDS,
        WANDS,
        COINS,
        HEARTS
    }

    public class Card
    {
        Rank rank;
        Suit suit;
        bool hidden; // hide - faceUp - face

        public Suit Suit { get { return suit; } }
        public Rank Rank { get { return rank; } }
        public bool Hidden { get { return hidden; } }


        
        public Card(Suit suit, Rank rank)
        {
            this.suit = suit;
            this.rank = rank;
            this.hidden = false;
        }

        ~Card()
        {

        }

        public void Flip()
        {
            hidden ^= hidden;          // ^ is the exclusive or operator 
            // this.hide ^= this.hide; // "true ^ true" is false and "false ^ true" is true.
            //hide = !hide;            // could also do this.faceUp = !faceUp
        }

    }
}
