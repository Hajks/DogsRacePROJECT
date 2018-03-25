using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DogsRacePROJECT
{
    public class Dog
    {
        public int StartingPosition;
        public int RacetrackLength;
        public PictureBox MyPictureBox = null;
        public int Location = 0;
        public Random MyRandom;

        public bool Run()
        {
            Location = Location + MyRandom.Next(1, 4);
            MyPictureBox.Left = Location;
            if (MyPictureBox.Left >= MyPictureBox.Parent.Width - MyPictureBox.Width)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public void TakeStartingPosition()
        {
            Location = 0;
        }
    }
}
