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

namespace Racetrack
{
    //Main Class holds the objects and maintains the Interface interactions.
    public sealed partial class MainPage : Page
    {
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

        }

        //Method to execute on Load
        public void OnLoad(object sender, RoutedEventArgs e)
        {

        }

        //Method to set the Bettor on click of Radio Button
        public void OnBettorSelectorClicked(object sender, RoutedEventArgs e)
        {

        }

        //This method will execute on click of Place Bet button
        //The method will call Place Bet method from Bettor class and 
        //Update the label if the bet is successfully placed
        public void OnPlaceBet(object sender, RoutedEventArgs e)
        {

        }

        //Method that will be executed on click of Start button
        public void OnStartRace(object sender, RoutedEventArgs e)
        {

        }

        //This method checks if the Greyhound has reached the finish line
        public void OnRaceTimer(object sender, RoutedEventArgs e)
        {

        }

    }
}
