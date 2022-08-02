using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media.Imaging;
using System.Timers;

namespace Racetrack
{
    //Main Class holds the objects and maintains the Interface interactions.
    public partial class MainPage : Page
    {

        //Bettors List to store information of all bettors
        List<Bettor> _bettorList = new List<Bettor>();
        List<Greyhound> _racehoundList = new List<Greyhound>();
        
        Bettor _bettor;

        private const int minBet = 5;
        private const int distance = 1300;
        Random random = new Random();
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
            //Add 4 Dogs to the Racehound list
            _racehoundList.Add(new Greyhound
            {
                Randomizer = random,
                GHImage = GetImage("Dog1"),
                RaceTrackLength = distance,
                Location = new System.Drawing.Point(0,0),
                StartPosition = 0
            });
            _racehoundList.Add(new Greyhound
            {
                Randomizer = random,
                GHImage = GetImage("Dog2"),
                RaceTrackLength = distance,
                Location = new System.Drawing.Point(0, 0),
                StartPosition = 0
            });
            _racehoundList.Add(new Greyhound
            {
                Randomizer = random,
                GHImage = GetImage("Dog3"),
                RaceTrackLength = distance,
                Location = new System.Drawing.Point(0, 0),
                StartPosition = 0
            });
            _racehoundList.Add(new Greyhound
            {
                Randomizer = random,
                GHImage = GetImage("Dog4"),
                RaceTrackLength = distance,
                Location = new System.Drawing.Point(0, 0),
                StartPosition = 0
            });
        }

        //Method to create the Bettors
        public void CreateBettors()
        {
            //Add 3 Bettors to the list
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
                
            _bettor.PlaceBet(int.Parse(BetAmount.Text), int.Parse((string)SelectDog.SelectedItem));

            if (_bettor.Name == "Joe")
            {
                JoesBetAmt.BorderThickness = new Thickness(0, 0, 0, 0);
                JoesBetAmt.Text = _bettor.Name + _bettor.UpdateLabels(null);
            }
            else if (_bettor.Name == "Bob")
            {
                BobsBetAmt.BorderThickness = new Thickness(0, 0, 0, 0);
                BobsBetAmt.Text = _bettor.Name + _bettor.UpdateLabels(null);
            }
            else
            {
                AnnasBetAmt.BorderThickness = new Thickness(0, 0, 0, 0);
                AnnasBetAmt.Text = _bettor.Name + _bettor.UpdateLabels(null);
            }
        }

        //Method that will be executed on click of Start button
        private async void OnStartRace(object sender, RoutedEventArgs e)
        {

            //Introducing Timer
            Timer timer = new Timer();
            timer.Start();

            int winner = 0;

            while (winner == 0)
            {
                for (int i = 0; i < _racehoundList.Count; i++)
                {
                    if (_racehoundList[i].Run())
                    {
                        winner = i + 1;
                        break;
                    }
                }
                await Task.Delay(1000);
            }

            WinnerDog.Text = "Dog #" + winner + " wins! ";

            for (int i = 0; i < _bettorList.Count; i++)
            {
                _bettorList[i].Collect(winner);
                _bettorList[i].ClearBet();
            }

            //After the winner is decided, the system will wait for 10 seconds and then initialize the form to start a new race
            await Task.Delay(10000);
            EndRace();
            timer.Stop();
        }

        private void EndRace()
        {
            //Resetting Amount Text Box to original values
            JoesBetAmt.BorderThickness = new Thickness(1, 1, 1, 1);
            JoesBetAmt.Text = "";
            JoesBetAmt.PlaceholderText = "Joe's Bet Amount";

            BobsBetAmt.BorderThickness = new Thickness(1, 1, 1, 1);
            BobsBetAmt.Text = "";
            BobsBetAmt.PlaceholderText = "Bob's Bet Amount";

            AnnasBetAmt.BorderThickness = new Thickness(1, 1, 1, 1);
            AnnasBetAmt.Text = "";
            AnnasBetAmt.PlaceholderText = "Anna's Bet Amount";

            //Sending Dogs to original position
            for (int i = 0; i < _racehoundList.Count; i++)
            {
                _racehoundList[i].TakeStartingPosition(_racehoundList[i].GHImage.Name);
            }

            WinnerDog.Text = "";
            BetAmount.Text = minBet.ToString();
            SelectDog.Items.Clear();
        }

        //This method checks if the Greyhound has reached the finish line
        public void OnRaceTimer(object sender, ElapsedEventArgs e)
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

        //This methods creates the Image at Runtime and display on the Grid.
        //The method also returns the image object 
        public Image GetImage(string imageName)
        {
            Image img = new Image();
            BitmapImage bitmapImage = new BitmapImage();

            //Setting the width and height of all images to a fixed value;
            img.Width = 120;
            img.Height = 108;

            //Setting the image source for each dog
            switch (imageName) 
            {
                case "Dog1":
                    //Defining Image Properties
                    img.Name = "Dog1";
                    bitmapImage.UriSource = new Uri("ms-appx:///Assets/GreyHound1.jpg");
                    img.Source = bitmapImage;
                    img.Margin = new Thickness(10,30,0,0);
                    img.HorizontalAlignment = HorizontalAlignment.Left;
                    img.VerticalAlignment = VerticalAlignment.Top;

                    //Adding the image object to the Grid Row
                    img.SetValue(Grid.RowProperty, 1);
                    ImageGrid.Children.Add(img);

                    break;

                case "Dog2":
                    //Defining Image Properties
                    img.Name = "Dog2";
                    bitmapImage.UriSource = new Uri("ms-appx:///Assets/GreyHound2.jpg");
                    img.Source = bitmapImage;
                    img.Margin = new Thickness(10,55,0,0);
                    img.HorizontalAlignment = HorizontalAlignment.Left;
                    img.VerticalAlignment = VerticalAlignment.Top;

                    //Adding the image object to the Grid Row
                    img.SetValue(Grid.RowProperty, 2);
                    ImageGrid.Children.Add(img);
                    break;

                case "Dog3":
                    //Defining Image Properties
                    img.Name = "Dog3";
                    bitmapImage.UriSource = new Uri("ms-appx:///Assets/GreyHound3.jpg");
                    img.Source = bitmapImage;
                    img.Margin = new Thickness(10, 50, 0, 0);
                    img.HorizontalAlignment = HorizontalAlignment.Left;
                    img.VerticalAlignment = VerticalAlignment.Top;

                    //Adding the image object to the Grid Row
                    img.SetValue(Grid.RowProperty, 3);
                    ImageGrid.Children.Add(img);
                    break;
                case "Dog4":
                    //Defining Image Properties
                    img.Name = "Dog4";
                    bitmapImage.UriSource = new Uri("ms-appx:///Assets/GreyHound4.jpg");
                    img.Source = bitmapImage;
                    img.Margin = new Thickness(10, 210, 0, 0);
                    img.HorizontalAlignment = HorizontalAlignment.Left;
                    img.VerticalAlignment = VerticalAlignment.Top;

                    //Adding the image object to the Grid Row
                    img.SetValue(Grid.RowProperty, 4);
                    ImageGrid.Children.Add(img);
                    break;
            }
            
            return img;
        }
    }
}
