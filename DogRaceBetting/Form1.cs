using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DogRaceBetting
{
    public partial class Form1 : Form
    {
        private List<Guy> guys = new List<Guy>();
        private List<Dog> dogs = new List<Dog>();
        private Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            guys.Add(new Guy { Name = "Joe", Cash = 50, MyRadioButton = this.joeRadioButton, MyLabel = this.joeBetLabel });
            guys.Add(new Guy { Name = "Bob", Cash = 75, MyRadioButton = this.bobRadioButton, MyLabel = this.bobBetLabel });
            guys.Add(new Guy { Name = "Al", Cash = 45, MyRadioButton = this.alRadioButton, MyLabel = this.alBetLabel });

            dogs.Add(new Dog { MyPictureBox = dog1, RacetrackLength = raceTrack.Width - dog1.Width, Randomizer = random});
            dogs.Add(new Dog { MyPictureBox = dog2, RacetrackLength = raceTrack.Width - dog2.Width, Randomizer = random });
            dogs.Add(new Dog { MyPictureBox = dog3, RacetrackLength = raceTrack.Width - dog3.Width, Randomizer = random});
            dogs.Add(new Dog { MyPictureBox = dog4, RacetrackLength = raceTrack.Width - dog4.Width, Randomizer = random});

            foreach (Guy guy in guys) // Clear bets after each race
            {
                guy.ClearBet();
            }
            this.minBetLabel.Text = "Minimum bet is " + betAmount.Minimum.ToString("c", CultureInfo.CreateSpecificCulture("en-AU"));
        }

        private void placeBet_Click(object sender, EventArgs e)
        {
            foreach (Guy guy in guys)
            {
                if (guy.MyRadioButton.Checked)
                {
                    if (guy.PlaceBet((int)betAmount.Value, (int)dogSelection.Value))
                    {
                        guy.MyLabel.Text = guy.MyBet.GetDescription();
                    }
                    else
                    {
                        MessageBox.Show(guy.Name + " doesn't have sufficient funds! :(");
                    }
                }
            }
        }

        private void startRace_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Dog dog in dogs)
            {
                if (dog.Run())
                {
                    timer1.Stop();
                    int winner = dogs.IndexOf(dog) + 1;
                    MessageBox.Show(String.Format("Dog #{0} won it all!", winner), "Winner", MessageBoxButtons.OK);

                    foreach (Guy guy in guys)
                    {
                        guy.Collect(winner);
                        guy.UpdateLabels();
                    }

                    foreach (Dog tiredDog in dogs)
                    {
                        tiredDog.TakeStartingPosition();
                    }
                }
            }
        }
    }
}
