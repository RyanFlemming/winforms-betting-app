using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DogRaceBetting
{
    public class Dog
    {
        public const int StartingPosition = 0;
        public int RacetrackLength;
        public PictureBox MyPictureBox = null;
        public int Location = 0; // Current location on track
        public Random Randomizer;

        public bool Run()
        {
            Location = Randomizer.Next(1, 5); // Move dog 1 to 4 spaces at random
            MyPictureBox.Left += Location; // Update dog location

            return (MyPictureBox.Right >= RacetrackLength); // return true if I won
        }

        public void TakeStartingPosition() // Move dog to starting position and reset location
        {
            MyPictureBox.Left = StartingPosition;
            Location = 0;
        }
    }
}
