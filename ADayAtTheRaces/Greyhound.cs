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
        public PictureBox MyPictureBox;
        public int Location = 0;
        public Random Randomizer;

        public bool Run()
        {
            return true;
        }

        public void TakeStartingPosition()
        {
            Location = 0;
            MyPictureBox.Left = 0;
        }
    }
}
