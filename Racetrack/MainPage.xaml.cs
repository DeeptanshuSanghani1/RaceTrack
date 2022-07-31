using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;

namespace Racetrack
{
    //Main Class holds the objects and maintains the Interface interactions.
    public sealed partial class MainPage : Page
    {

        //Bettors List to store information of all bettors
        List<Bettor> _bettorList = new List<Bettor>();

        Bettor _bettor;

        private const int minBet = 5;

        //Main Class holds the objects and maintains the Interface interactions.
        public MainPage()
        {
            this.InitializeComponent();
            CreateRaceHounds();
            CreateBettors();
        }

        //Method to create the Racehounds
        public void CreateRaceHounds()
        {

        }

        //Method to create the Bettors
        public void CreateBettors()
        {
            //Create Bettors and Add to _bettorList
            _bettorList.Add(new Bettor
            {
                Name = "Joe",
                Cash = 75
            });

            _bettorList.Add(new Bettor
            {
                Name = "Bob",
                Cash = 75
            });

            _bettorList.Add(new Bettor
            {
                Name = "Anna",
                Cash = 75
            });
        }

        //Method to execute on Load
        public void OnLoad(object sender, RoutedEventArgs e)
        {
            //Display label to place bet on Load
            minBetAmtLabel.Text = "Minmum Bet is {5}";
        }

        //Method to set the Bettor on click of Radio Button
        public void OnBettorSelectorClicked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            switch ((string)rb.Name)
            {
                case "rbJoe":
                    {
                        SetBettor(0);
                        break;
                    }
                case "rbBob":
                    {
                        SetBettor(1);
                        break;
                    }
                case "rbAnna":
                    {
                        SetBettor(2);
                        break;
                    }
            }
        }

        //This method will be called on the text change event for the Amount field
        public void OnTextAmountChanged(object sender, RoutedEventArgs e) 
        {
            //Identify the Control that triggered the method and store the value from each bettor's amount to BetAmount
            //The method checks if a non-numeric value is entered and displays an error message
            TextBox textBox = sender as TextBox;
            switch (textBox.Name)
            {
                case "JoesBetAmt":
                    {
                        if (int.TryParse(textBox.Text, out int value))
                            BetAmount.Text = JoesBetAmt.Text;
                        else
                            new MessageDialog("Please enter a numeric value");
                        break;
                    }
                case "BobsBetAmt":
                    {
                        if (int.TryParse(textBox.Text, out int value))
                            BetAmount.Text = BobsBetAmt.Text;
                        else
                            new MessageDialog("Please enter a numeric value");
                        break;
                    }
                case "AnnasBetAmt":
                    {
                        if (int.TryParse(textBox.Text, out int value))
                            BetAmount.Text = AnnasBetAmt.Text;
                        else
                            new MessageDialog("Please enter a numeric value");
                        break;
                    }
            }
        }

        //This method will execute on click of Place Bet button
        //The method will call Place Bet method from Bettor class and 
        //Update the label if the bet is successfully placed
        public void OnPlaceBet(object sender, RoutedEventArgs e)
        {
            if (SelectDog.SelectedItem == null)
                new MessageDialog("Select a Dog for placing the bet !!");
                
            _bettor.PlaceBet(int.Parse(BetAmount.Text), int.Parse(SelectDog.Text));
            if (_bettor.Name == "Joe")
            {
                JoesBetAmt.BorderThickness = new Thickness(0, 0, 0, 0);
                JoesBetAmt.Text = _bettor.Name + _bettor.UpdateLabels();
            }
            else if (_bettor.Name == "Bob")
            {
                BobsBetAmt.BorderThickness = new Thickness(0, 0, 0, 0);
                BobsBetAmt.Text = _bettor.Name + _bettor.UpdateLabels();
            }
            else
            {
                AnnasBetAmt.BorderThickness = new Thickness(0, 0, 0, 0);
                AnnasBetAmt.Text = _bettor.Name + _bettor.UpdateLabels();
            }
        }

        //Method that will be executed on click of Start button
        public void OnStartRace(object sender, RoutedEventArgs e)
        {

        }

        //This method checks if the Greyhound has reached the finish line
        public void OnRaceTimer(object sender, RoutedEventArgs e)
        {

        }

        private void SetBettor(int pindex)
        {
            _bettor = _bettorList[pindex];
            CurrentBettor.Text = _bettor.Name;
            if (_bettor.betPlaced != null)
            {
                BetAmount.Text = _bettor.betPlaced.Amount.ToString();
                SelectDog.Text = _bettor.betPlaced.Racehound.ToString();
            }
            else
            {
                BetAmount.Text = minBet.ToString();  //Set the default value for bet amount to 5
                SelectDog.Text = "1";  //Set the default vlaue for Dog to 1
            }

        }
    }
}
