﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racetrack
{
    //The Bettor class maintains private state for name, cash, an instance of Bet
    //and reference to the UI elements directly related to them.
    internal class Bettor
    {
        //Private variable for Bettor name
        private string _name;

        //Private variable for total cash for each Bettor
        private int _cash;


        //Binding _name variable
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        //Public Cash variable
        public int Cash
        {
            get { return _cash; }
            set { _cash = value; }
        }

        //Constructor Class for Bettor
        public Bettor(string nm, int cash)
        {
            this._name = nm;
            this._cash = cash;
        }

        //Create an instance of Bet and store it in betPlaced field
        public Bet betPlaced = null;

        //Method to place a new bet and store in betPlaced field
        //The class will return true if the bettor has enough money to bet
        public bool PlaceBet(int betAmount, Greyhound houndToWin)
        {
            return true;
        }

        //Method to initialize the bet amount to 0
        public void ClearBet()
        {

        }

        //This method uses betPlaced to payout the amount to the winner
        public void Collect(int winner)
        {

        }

        //Method to change the label when the bet is placed
        public void UpdateLabels()
        {

        }
    }
}
