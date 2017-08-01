using System;
using System.Collections.Generic;
using System.Text;

namespace RobotsAndPencils.Model
{
    public class Deck
    {
        const int DEAL_FROM = 0;

        public List<Card> Available { get; private set; }
        public List<Card> Dealt { get; private set; }
        public Deck()
        {
            Available = new List<Card>();
            Dealt = new List<Card>();

            //Initialize the deck
            foreach(Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach(Face face in Enum.GetValues(typeof(Face)))
                {
                    Available.Add(new Card(suit, face));
                }
            }
        }

        public Card Deal()
        {
            if(Available.Count < 1)
            {
                throw new Exception("there are no cards left to deal");
            }
            Card toDeal = Available[DEAL_FROM];
            Available.RemoveAt(DEAL_FROM);

            Dealt.Add(toDeal);
            return toDeal;
        }

        public List<Card> Deal(int count)
        {
            if(Available.Count < count)
            {
                throw new Exception("there are not enough cards left to deal " + count);
            }
            List<Card> hand = Available.GetRange(0, count);
            Available.RemoveRange(0, count);
            Dealt.AddRange(hand);

            return hand;
        }

        public void Shuffle()
        {
            Random random = new Random();
            Available.AddRange(Dealt);
            Dealt.Clear();

            for(var cardIndex = (Available.Count - 1); cardIndex > 0; cardIndex--)
            {
                int randomCardIndex = (random.Next(0, cardIndex) % cardIndex);
                Card cardToMove = Available[randomCardIndex];
                Available[randomCardIndex] = Available[cardIndex];
                Available[cardIndex] = cardToMove;
            }
        }
    }
}
