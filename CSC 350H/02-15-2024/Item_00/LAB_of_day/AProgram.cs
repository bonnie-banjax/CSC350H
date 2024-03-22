using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABBIT_03
{
    internal class AProgram
    {
        static void Main(string[] args)
        {
            Deck deck_01 = new();
            Agent agent_01 = new("01", 10);

            agent_01.assignDeck(deck_01);

            for (int i = 0; i < 4; i ++)
                agent_01.addCard(20);
            agent_01.sortHand();

        }


    }

}
