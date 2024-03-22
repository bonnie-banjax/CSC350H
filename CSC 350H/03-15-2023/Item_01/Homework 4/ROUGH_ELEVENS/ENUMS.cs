using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROUGH_ELEVENS
{
    public enum Suit
    {
        NULL,
        SWORDS,
        WANDS,
        COINS,
        HEARTS
    }
    public enum abSuit // AbvrSuit
    {
        NULL,
        SW,
        WA,
        CO,
        HRT,
    }

    public enum Rank
    {
        // gotta be more efficient way // issue of null
        NULL,
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
    public enum abRank // AbvrRank
    {
        // gotta be more efficient way // issue of null
        NULL,
        _A,
        _1,
        _2,
        _3,
        _4,
        _5,
        _6,
        _7,
        _8,
        _9,
        _10,
        _J,
        _Q,
        _K,

        //etc

    }

}
