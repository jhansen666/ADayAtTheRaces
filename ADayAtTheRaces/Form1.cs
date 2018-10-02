using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADayAtTheRaces
{
    public partial class Form1 : Form
    {
        Greyhound[] GreyhoundArray = new Greyhound[4];
        Guy[] GuyArray = new Guy[3];
        int GuyNumber = 0;
        public Random MyRandomizer = new Random();
        public Form1()
        {
            InitializeComponent();
            // initializing greyhound and dog objects
            GreyhoundArray[0] = new Greyhound()
            {
                MyPictureBox = dog0PicBox,
                StartingPosition = dog0PicBox.Left,
                RacetrackLength = racetrackPicBox.Width - dog0PicBox.Width,
                Randomizer = MyRandomizer
            };
            GreyhoundArray[1] = new Greyhound()
            {
                MyPictureBox = dog1PicBox,
                StartingPosition = dog1PicBox.Left,
                RacetrackLength = racetrackPicBox.Width - dog1PicBox.Width,
                Randomizer = MyRandomizer
            };
            GreyhoundArray[2] = new Greyhound()
            {
                MyPictureBox = dog2PicBox,
                StartingPosition = dog2PicBox.Left,
                RacetrackLength = racetrackPicBox.Width - dog2PicBox.Width,
                Randomizer = MyRandomizer
            };
            GreyhoundArray[3] = new Greyhound()
            {
                MyPictureBox = dog3PicBox,
                StartingPosition = dog3PicBox.Left,
                RacetrackLength = racetrackPicBox.Width - dog3PicBox.Width,
                Randomizer = MyRandomizer
            };
            GuyArray[0] = new Guy()
            {
                Name = "Joe",
                Cash = 50,
                MyRadioButton = joeRadioButton,
                MyLabel = joeBetLabel
            };
            GuyArray[1] = new Guy()
            {
                Name = "Bob",
                Cash = 50,
                MyRadioButton = bobRadioButton,
                MyLabel = bobBetLabel
            };
            GuyArray[2] = new Guy()
            {
                Name = "Al",
                Cash = 50,
                MyRadioButton = alRadioButton,
                MyLabel = alBetLabel
            };
            GuyArray[0].UpdateLabels();
            GuyArray[1].UpdateLabels();
            GuyArray[2].UpdateLabels();
        }

        private void joeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            GuyNumber = 0;
            nameLabel.Text = "Joe";
        }

        private void bobRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            GuyNumber = 1;
            nameLabel.Text = "Bob";
        }

        private void AlRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            GuyNumber = 2;
            nameLabel.Text = "Al";
        }

        private void betsButton_Click(object sender, EventArgs e)
        {
            // placing bet on the chosen guys behalf
            GuyArray[GuyNumber].PlaceBet((int)betAmountUD.Value, (int)dogNumberUD.Value);
        }

        private void startRaceButton_Click(object sender, EventArgs e)
        {
            if(GuyArray[0].MyBet != null && GuyArray[1].MyBet != null && GuyArray[2].MyBet != null)
            {
                bool RaceStopped = false;
                int WinningDog = 0;
                while (RaceStopped == false)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (GreyhoundArray[i].Run() == true)
                        {
                            RaceStopped = true;
                            WinningDog = i + 1;
                        }
                    }
                }
                // collect the money
                foreach (Guy guy in GuyArray)
                {
                    guy.Collect(WinningDog);
                    guy.MyBet.GetDescription();
                }
                // return dogs back to the starting position
                foreach (Greyhound dog in GreyhoundArray)
                {
                    dog.TakeStartingPosition();
                }
            }
            else
            {
                MessageBox.Show("Not all initial bets have been placed yet.", "Info");
            }   
        }
    }
}
