using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADayAtTheRaces
{
    public class Greyhound
    {
        public int StartingPosition;
        public int RacetrackLength;
        public PictureBox MyPictureBox = null;
        public int Location = 0;
        public Random Randomizer;

        public bool Run()
        {
            Location += Randomizer.Next(1, 4);
            MyPictureBox.Left = StartingPosition + Location;
            // determine wether the greyhound has won the race or not
            if (MyPictureBox.Right == MyPictureBox.Parent.Right)
            {
                return true;
            }
            else
            {
                return false;
            }            
        }
        // reset the greyhounds position
        public void TakeStartingPosition()
        {
            Location = 0;
            MyPictureBox.Left = StartingPosition;
        }
    }
}
