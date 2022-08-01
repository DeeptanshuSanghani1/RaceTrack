using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml;

namespace Racetrack
{
    //The Greyhound class will have reference to the 4 Greyhound images
    //It will move the images using Random number and the Run method will return true when a particular greyhound crosses the finish line
    internal class Greyhound
    {        
        //Variable to define the starting position for the race
        private int _startPosition;

        //Location on the racetrack
        private Point _location;

        //Random number instance for moving the Greyhounds
        private Random _randomizer;

        //Length of the Racetrack
        private int _raceTrackLength;

        //Image Object
        public Image _ghImage;

        public int StartPosition
        {
            get { return _startPosition; }
            set { _startPosition = value; }
        }

        public Point Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public Random Randomizer
        {
            get { return _randomizer; }
            set { _randomizer = value; }
        }

        public int RaceTrackLength
        {
            get { return _raceTrackLength; }
            set { _raceTrackLength = value; }
        }

        public Image GHImage 
        {
            get { return _ghImage; }
            set { _ghImage = value; }
        }

        public Greyhound() { }

        public Greyhound(int startPosition, Point location, Random randomizer, int raceTrackLength, Image ghImage)
        {
            this._startPosition = startPosition;
            this._location = location;
            this._randomizer = randomizer;
            this._raceTrackLength = raceTrackLength;
            this._ghImage = ghImage;
        }

        //Method to reset the starting position of the Images
        public void TakeStartingPosition(string imageName)
        {
            switch (imageName)
            {
                case "Dog1":
                    GHImage.Margin = new Thickness(10, 30, 0, 0);
                    break;

                case "Dog2":
                    GHImage.Margin = new Thickness(10, 55, 0, 0);
                    break;

                case "Dog3":
                    GHImage.Margin = new Thickness(10, 50, 0, 0);
                    break;

                case "Dog4":
                    GHImage.Margin = new Thickness(10, 210, 0, 0);
                    break;
            }
        }

        //The Run method moves the images based on random numbers
        //and returns true when one Greyhound crosses the finish line
        public bool Run()
        {
            // Move forward random
            int x = Randomizer.Next(20, 50);
            
            // Update the position of Image on the form with the Left and Top Margin
            int CurrentXPosition = Convert.ToInt32(GHImage.Margin.Left);
            int CurrentYPosition = Convert.ToInt32(GHImage.Margin.Top);
            
            // Get the new Left Margin using a Random Number
            int newXPosition = CurrentXPosition + x;

            //Change the Margin of the image so that it moves to the new position
            GHImage.Margin = new Thickness(newXPosition, CurrentYPosition, 0, 0);

            // Return true if any of the Dog's new position is greated than the RaceTrackLength
            if (newXPosition >= RaceTrackLength)
            {
                return true;
            }

            return false;
        }
    }
}
