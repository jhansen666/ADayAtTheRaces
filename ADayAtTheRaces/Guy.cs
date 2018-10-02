using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADayAtTheRaces
{
    public class Guy
    {
        public string Name;
        public Bet MyBet = null;
        public int Cash;
        public RadioButton MyRadioButton;
        public Label MyLabel;

        public void UpdateLabels()
        {
            if(MyBet != null)
            {
                MyLabel.Text = Name + " bets " + MyBet.Amount + " bucks on dog #" + MyBet.Dog;
            }

            MyRadioButton.Text = Name + " has " + Cash + " bucks.";

        }
        
        public bool PlaceBet(int BetAmount, int DogToWin)
        {
            if(Cash >= BetAmount && (MyBet == null || MyBet.Amount == 0))
            {
                Cash -= BetAmount;
                MyBet = new Bet(BetAmount, DogToWin, this);
                UpdateLabels();
                return true;    
            }
            else
            {
                return false;
            }
        }

        // resets the bet to 0
        public void ClearBet()
        {
            MyBet.Amount = 0;
            UpdateLabels();
        }

        public void Collect(int Winner)
        {
            Cash += MyBet.PayOut(Winner);
            MyBet.ClearBet();
            UpdateLabels();
        }
    }
}
