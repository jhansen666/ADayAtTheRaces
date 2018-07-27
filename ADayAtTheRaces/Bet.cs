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
        public Greyhound Dog;
        public Guy Bettor;

        public string GetDescription()
        {
            return "Placeholder";
        }

        public int PayOut(int Winner)
        {
            return 1;
        }
    }
}
