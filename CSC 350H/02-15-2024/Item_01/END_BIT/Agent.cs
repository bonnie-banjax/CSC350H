﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace END_BIT
{
    internal class Agent
    {
        //-----------------------------------------------------------|-----------------------------------------------------------
        string id; // string used for AgentID
        int maxCards;
        int handSize; // a value of 0 for handSize means no cards
        private List<Card> hand = new List<Card>();
        Deck myDeck; // reference to a deck, originally a pointer
        //unsafe public Deck* deckPtr = null; // failed pointer implementation

        public string ID { get { return id; } }
        public int MaxCards { get { return maxCards; } }
        public int HandSize { get { return handSize; } }
        //-----------------------------------------------------------|-----------------------------------------------------------
        public Agent()
        {
            id = "[-]";
            maxCards = 0;
            handSize = 0;
        }
        public Agent(string arg1, int arg2)
        {
            id = arg1;
            maxCards = arg2;
            handSize = 0;
        }
        public Agent(Deck theDeck, string arg1, int arg2)
        {
            id = arg1;
            maxCards = arg2;
            handSize = 0;

            if (theDeck != null)
                assignDeck(theDeck);
            else myDeck = null;
        }
        //-----------------------------------------------------------|-----------------------------------------------------------
        ~Agent()
        {

        }
        //-----------------------------------------------------------|-----------------------------------------------------------
        public void assignDeck(Deck theDeck)
        {
            if (theDeck != null)
                myDeck = theDeck;
        }
        //-----------------------------------------------------------|-----------------------------------------------------------
        unsafe private Card drawCard(Deck theDeck = null)
        {
            if (theDeck != null && handSize + 1 < maxCards)
            {
                Card theCard = theDeck.Draw();
                return theCard;
            }
            else if (theDeck == null && handSize + 1 < maxCards)
            {
                Card theCard = myDeck.Draw();
                return theCard;
            }
            else return null;
        }

        // still has some bugs to work out in both allowing no card
        // or index to be specified but being able to handle such input
        // when desired; currently need to specify an index over 
        // maxCards in order to insure card is appeneded, rather
        // than overwriting a prior card
        public bool addCard(int nDex = -1, Card theCard = null)
        {
            if (nDex == -1)
                return false;
            if (theCard == null && myDeck == null)
                return false;
            if (theCard == null && myDeck != null)
                theCard = drawCard();

            if (nDex >= 0 && nDex < hand.Count())
            {
                hand.Insert(nDex, theCard);
                handSize++;
                return true;
            }
            else if (handSize + 1 < maxCards)
            {
                hand.Add(theCard);
                handSize++;
                return true;
            }
            else return false;
        }
        public bool removeCard(int nDex = -1)
        {
            if (nDex >= 0 && nDex < hand.Count())
            {
                hand.RemoveAt(nDex);
                handSize--;
                return true;
            }
            else return false;
        }
        //-----------------------------------------------------------|-----------------------------------------------------------
        public Card playCard(int nDex)
        {
            if (nDex >= 0 && nDex < hand.Count())
            {
                Card theCard = hand[nDex];
                hand.RemoveAt(nDex);
                handSize--;
                if (theCard.Hidden != true)
                    theCard.Flip();
                return theCard;
            }
            else return null;
        }
        public Card getCard(int nDex)
        {
            if (nDex <= 0 && nDex < hand.Count())
            {
                Card theCard = hand[nDex];
                return theCard;
            }
            else return null;
        }
        //-----------------------------------------------------------|-----------------------------------------------------------
        public void FlipCards()
        {
            foreach (Card card in hand)
            {
                card.Flip();
            }
        }
        public void ShowCards()
        {
            if (hand.Count != 0)
                foreach (Card card in hand)
                    Console.Write("Agent (" + (ID) + ") card is " + card.Rank + " of " + card.Suit + '\n');
            else Console.Write("Agent (" + (ID) + ") has no cards" + '\n');
        }
        //-----------------------------------------------------------|-----------------------------------------------------------

    };
}
