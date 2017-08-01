using System;
using System.Collections.Generic;
using System.Text;

namespace RobotsAndPencils.Model
{
    public struct Card: IEquatable<Card>
    {
        public Suit Suit { get; private set; }
        public Face Face { get; private set; }

        public Card(Suit s, Face f): this()
        {
            Suit = s;
            Face = f;
        }

        public override bool Equals(object obj)
        {
            if(obj is Card)
            {
                return this.Equals((Card)obj);
            }
            return false;
        }

        public bool Equals(Card card)
        {
            return ((Suit == card.Suit) &&
                (Face == card.Face));
        }

        public override int GetHashCode()
        {
            return Suit.GetHashCode() ^ Face.GetHashCode();
        }

        public static bool operator ==(Card lhs, Card rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Card lhs, Card rhs)
        {
            return !lhs.Equals(rhs);
        }
    }
}
