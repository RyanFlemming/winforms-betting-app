using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DogRaceBetting
{
    public class Guy
    {
        public string Name;
        public Bet MyBet;
        public int Cash;
        // Control each guy's Radio Buttons & labels on form
        public RadioButton MyRadioButton;
        public Label MyLabel;

        public void UpdateLabels()
        {
            MyLabel.Text = string.Format("{0}", this.MyBet.Amount); // set label to = bet
            MyRadioButton.Text = string.Format("{0}", Cash); // update radio button to show cash
        }

        public void ClearBet()
        {
            this.MyLabel.Text = string.Format("{0} hasn't placed a bet", Name);
            this.MyRadioButton.Text = this.Name + " has " + this.Cash.ToString("c");
                //String.Format("{0} has {1:c}", Name, Cash);
        }

        public bool PlaceBet(int BetAmount, int DogToWin)
        {
            MyBet = new Bet { Amount = BetAmount, Dog = DogToWin, Bettor = this }; // Create bet object and store the amount
            return (this.Cash >= BetAmount); // return true if guy had enough money
        }

        public void Collect(int Winner)
        {
            if (this.MyBet != null && Winner == this.MyBet.Dog)
            {
                this.Cash += this.MyBet.Amount;
            }
            else
            {
                this.Cash -= this.MyBet.Amount;
            }
        }
    }
}
