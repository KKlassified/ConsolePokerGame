using CardLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int howManyCards = 5;
            int balance = 10;
            

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkBlue;

            Console.WriteLine("Welcome player, Were going to play poker today");
            Console.WriteLine(" You have $10 to start, and each time you play the game it will be a $1 bet");
            Console.ReadLine();
            CardSet myDeck = new CardSet();
            while (balance > 0)
            {
                Console.Clear();
                myDeck.ResetUsage();

                myDeck.GetCards(howManyCards);
                SuperCard[] computerHand = myDeck.GetCards(howManyCards);
                SuperCard[] playersHand = myDeck.GetCards(howManyCards);
                Array.Sort(computerHand); 
                Array.Sort(playersHand); 

                DisplayHands(computerHand, playersHand);


                PlayersDrawsOne(playersHand, myDeck, computerHand);
                
                ComputerDrawsOne(computerHand, myDeck);

                Array.Sort(computerHand);
                Array.Sort(playersHand);

                Console.WriteLine();

                DisplayHands(computerHand, playersHand);


                bool won = CompareHands(computerHand, playersHand);

                if (won == true)
                {
                    balance++;
                    Console.WriteLine("You have won the game and got 1$");
                    Console.WriteLine("Your balance is {0}$", balance);
                }
                if (won == false)
                {
                    balance--;
                    Console.WriteLine("You have lost 1$. Click enter to try again");
                    Console.WriteLine("Your balance is {0}$",balance);
                    if (balance == 0)
                    {

                        Console.WriteLine("You are out of money the game is over");

                    }
                }
                Console.ReadLine();

            }




            
            

    }

        private static void ComputerDrawsOne(SuperCard[] computerHand, CardSet myDeck)
        {
            bool compFlush;
            compFlush = Flush(computerHand);
            SuperCard LowestValue = computerHand[0];
            int sindex = 0;

            if (compFlush == false)
            {
                for (int index = 0; index < computerHand.Length; ++index)
                {
                    if (computerHand[index].CardRank < LowestValue.CardRank)
                    {
                        LowestValue = computerHand[index];
                        sindex = index;


                    }

                }


                if (Convert.ToInt32(LowestValue.CardRank) < 8)
                {
                    computerHand[sindex] = myDeck.GetOneCard();
                }
            }


        }

        private static void PlayersDrawsOne(SuperCard[] playersHand, CardSet myDeck, SuperCard[] computerHand)
        {
            Console.WriteLine("If you want to replace a card type 1-5, The top card is one and the bottom is 5.");
            Console.WriteLine("Or 0 to keep your hand.");
            
            int ui = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            if (ui == 1)
            {
                playersHand[0] = myDeck.GetOneCard();

            }
            if (ui == 2)
            {
                playersHand[1] = myDeck.GetOneCard();
               

            }
            if (ui == 3)
            {
                playersHand[2] = myDeck.GetOneCard();
             
            }
            if (ui == 4)
            {
                playersHand[3] = myDeck.GetOneCard();
                
            }
            if (ui == 5)
            {
                playersHand[4] = myDeck.GetOneCard();

            }

            else if (ui == 0)
            {
                playersHand[0] = playersHand[0];
            }
        }

        public static bool CompareHands(SuperCard[] computerHand, SuperCard[] playersHand)
        {
            int cSum = 0, pSum = 0;
            bool winner = true,compFlush,playerFlush;
            
            compFlush=Flush(computerHand);
            playerFlush=Flush(playersHand);
            if (compFlush == true)
            {
                Console.WriteLine("Computer got a flush");
                return winner = false;
            }
            else
            {
                if (playerFlush == true)
                {
                    Console.WriteLine("Player got a flush");
                    return winner;
                }

                for (int i = 0; i < computerHand.Length; i++)
                {
                    int cHandTotal;
                    cHandTotal = Convert.ToInt32(computerHand[i].CardRank);

                    cSum = cSum + cHandTotal;
                }
                for (int i = 0; i < playersHand.Length; i++)
                {
                    int pHandTotal = Convert.ToInt32(playersHand[i].CardRank);
                    pSum = pSum + pHandTotal;
                }
                if (pSum < cSum)
                {
                    return winner = false;
                }

            }
            return winner;

        }

        public static void DisplayHands(SuperCard[] computerHand, SuperCard[] playersHand)
        {
            Console.WriteLine("Computers hand");

            for (int i = 0; i < computerHand.Length; i++)
            {
                    computerHand[i].Display();
            }
            Console.WriteLine("Player's hand");
            for (int i = 0; i < playersHand.Length; i++)
            {
                playersHand[i].Display();
            }


        }
        public static bool Flush(SuperCard[] hand) // can be called passing in either 
                                                    //the players hand or the computers hand
        {
            bool flush = true;
            SuperCard firstCard = hand[0];
            for (int i = 0; i < hand.Length; i++)
            {

                if (hand[i].CardSuit.Equals(firstCard.CardSuit))
                {
                    flush = true;
                }
                if (hand[i].CardSuit != firstCard.CardSuit)
                {
                    flush = false;
                    break;
                }
            }
            return flush;
        }

    }
}
