using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLibrary
{
    public enum Suit
    {
        Club = 1,
        Diamond,
        Heart,
        Spade
    }

    public enum Rank
    {
        Deuce = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14
    }
    public abstract class SuperCard : IEquatable<SuperCard> , IComparable<SuperCard> 
    {
        
        public Rank CardRank { get; set; }
        public abstract Suit CardSuit { get; set; }
        public abstract void Display();
        public bool inplay { get; set; }


        public int CompareTo (SuperCard other)
        {

            int result = this.CardSuit.CompareTo(other.CardSuit);
            if (result == 0)
                result = this.CardRank.CompareTo(other.CardRank);
            return result;

        }
        public bool Equals(SuperCard otherCard)
        {
           
                if (this.CardSuit.Equals(otherCard.CardSuit))
                {
                    return true;
                }
                
                    return false;

        }




}
public class CardClub : SuperCard
    {

        private Suit _CardSuit = Suit.Club;
        public override Suit CardSuit
        {
            get
            {
                return _CardSuit;
            }
            set
            {

            }


        }
        public CardClub (Rank cRank)
        {
            CardRank = cRank;
        }

        public override void Display()
        {
            // Code to Display a diamond card...
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(CardRank + " of " + CardSuit + "s ♣");
            Console.ResetColor();
        }


    }

    public class CardDiamond : SuperCard
    {

        private Suit _CardSuit = Suit.Diamond;
        public override Suit CardSuit
        {
            get
            {
                return _CardSuit;
            }
            set
            {

            }

        }
        public CardDiamond(Rank cRank)
        {
            CardRank = cRank;
        }

        public override void Display()
        {
            // Code to Display a diamond card...
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(CardRank + " of " + CardSuit + "s ♦");
            Console.ResetColor();
        }



    }
    public class CardHeart : SuperCard
    {

        private Suit _CardSuit = Suit.Heart;
        public override Suit CardSuit
        {
            get
            {
                return _CardSuit;
            }
            set
            {

            }

        }
        public CardHeart(Rank cRank)
        {
            CardRank = cRank;
        }
        public override void Display()
        {
            // Code to Display a heart card...
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(CardRank + " of " + CardSuit + "s ♥");
            Console.ResetColor();
        }



    }
    public class CardSpade : SuperCard
    {

        private Suit _CardSuit = Suit.Spade;
        public override Suit CardSuit
        {
            get
            {
                return _CardSuit;
            }
            set
            {

            }

        }
        public CardSpade(Rank cRank)
        {
            CardRank = cRank;
        }
        public override void Display()
        {
            // Code to Display a Spade card...
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(CardRank + " of " + CardSuit + "s ♠");
            Console.ResetColor();
        }


    }
    public class CardSet
    {
        public void ResetUsage()
        {
            for (int i = 0; i < cardArray.Length; i++)
            {
                cardArray[i].inplay = false;    
            }
            

        }
        public SuperCard[] cardArray;
        public Random random = new Random();
        public CardSet()
        {
            cardArray = new SuperCard[52];
           
            

            int i = 0;
            while(i <= 51) 
            {
                for (int a =  2; a <= 14; a++)
                {
                   
                      cardArray[i] = new CardClub((Rank)(a));
                      i++;
   
                }
                for (int b = 2; b <= 14; b++)
                {
                    cardArray[i] = new CardHeart((Rank)(b));
                    i++;
                }
                for (int c = 2; c <= 14; c++)
                {

                    cardArray[i] = new CardSpade((Rank)(c));
                    i++;

                }
                for (int d = 2; d <= 14; d++)
                {
                    cardArray[i] = new CardDiamond((Rank)(d));
                    i++;
                }

            }

        }

        public SuperCard[] GetCards(int number)
        {
            SuperCard[] mcardArray = new SuperCard[number];


            for (int i = 0; i < number; i++)
            {
                
                int randomNumber = random.Next(2,52);
                mcardArray[i] = cardArray[randomNumber];
      
                if (cardArray[randomNumber].inplay == true)
                {
                    while (cardArray[randomNumber].inplay == true)
                    {
                        randomNumber = random.Next(2, 52);
                        mcardArray[i] = cardArray[randomNumber];
                    }                   
                }
                if (cardArray[randomNumber].inplay == false)
                {
                    cardArray[randomNumber].inplay = true;
                }
            }
            return mcardArray;
       
        }
        public SuperCard GetOneCard()
        {
            SuperCard mcard;

            int randomNumber = random.Next(2, 52);
            mcard = cardArray[randomNumber];

            if (cardArray[randomNumber].inplay == true)
            {
                while (cardArray[randomNumber].inplay == true)
                {
                    randomNumber = random.Next(2, 52);
                    mcard = cardArray[randomNumber];
                }
            }
            if (cardArray[randomNumber].inplay == false)
            {
                cardArray[randomNumber].inplay = true;
            }
            return mcard;
        }

    }

}



