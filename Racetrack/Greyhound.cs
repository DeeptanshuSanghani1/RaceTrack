using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Racetrack
{
    //The Greyhound class will have reference to the 4 Greyhound images
    //It will move the images using Random number and the Run method will return true when a particular greyhound crosses the finish line
    internal class Greyhound
    {
        //Variable to define the starting position for the race
        public int _startPosition = 0;

        //Location on the racetrack
        public int _location = 0;

        //Random number instance for moving the Greyhounds
        public Random _randomizer = null;

        //Length of the Racetrack
        public int _raceTrackLength = 0;

        //Greyhound image
        public Image GHImage = null;

        //Method to reset the starting position of the Images
        public void TakeStartingPosition()
        {

        }

        //The Run method moves the images based on random numbers
        //and returns true when one Greyhound crosses the finish line
        public bool Run()
        {
            return true;
        }
    }
}
