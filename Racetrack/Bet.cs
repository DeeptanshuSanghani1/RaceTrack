using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racetrack
{
    //This class will store the amount and racehound for each bettor when the bet is placed.
    //The class also has methods for payout
    internal class Bet
    {
        //Private variable for amount of bet
        private int _amount;

        //Private variable for the racehound against which a bet is placed
        private int _racehound;

        //Binding _amount variable
        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        //Binding _racehound variable
        public int Racehound
        {
            get { return _racehound; }
            set { _racehound = value; }
        }

        public Bet() { }

        //Constructor Class for bet
        public Bet(int amt, int hound)
        {
            this._amount = amt;
            this._racehound = hound;
        }

        public Bettor _bettor = new Bettor();
        //This method calculates the payout amount and adds it to the Winners total cash
        public int Payout(int winner)
        {
            if (winner == Racehound)
                return Amount;
            else
                return -1 * Amount;
        }

        // This method returns a string that says who placed the bet and for how much amount.
        public string GetDescription()
        {
            return " bets $ " + Amount + " on dog # " + Racehound;
        }
    }
}
