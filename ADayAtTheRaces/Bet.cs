using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADayAtTheRaces
{
    public class Bet
    {
        public int Amount;
        public int Dog;
        public Guy Bettor;

        public Bet(int amount, int dog, Guy bettor)
        {
            Amount = amount;
            Dog = dog;
            Bettor = bettor;
        }
        public string GetDescription()
        {
            if(Amount == 0)
            {
                return Bettor.Name + " hasn't placed a bet yet";
            }
            else
            {
                return Bettor.Name + " bets " + Amount + " on dog #" + Dog;
            }
        }

        public void ClearBet()
        {
            Amount = 0;
        }

        public int PayOut(int Winner)
        {
            if(Dog == Winner)
            {
                return Amount*2;
            }
            else
            {
                return -Amount;
            }
            
        }
    }
}
