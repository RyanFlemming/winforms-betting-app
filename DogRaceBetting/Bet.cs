using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DogRaceBetting
{
    public class Bet
    {
        public int Amount;
        public int Dog;
        public Guy Bettor;

        public string GetDescription()
        {
            string description = string.Format("{0} bet {1} on dog #{2}", Bettor.Name, Amount, Dog);
            return description;
        }
    }
}
