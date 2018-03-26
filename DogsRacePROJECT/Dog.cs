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
        public int StartingPosition; //Place where dog should start
        public int RacetrackLength; // How long racetrack is
        public PictureBox MyPictureBox = null; //Setting object picturebox to null
        public int Location = 0; // Current location
        public Random MyRandom; // Random which be used to move dogs
        public bool Run() // Moving dogs on racetrackPictureBox 
        {
            Location = Location + MyRandom.Next(1, 6); //Random number from 1 to 6 which be added to MyPictureBox.Left location
            MyPictureBox.Left = Location;
            if (MyPictureBox.Left >= MyPictureBox.Parent.Width - MyPictureBox.Width) //if dog reached finishing-line return true, else return false
            {
                return true;
            }
            else
            {
                return false;
            }          
        }
        public void TakeStartingPosition() // method used to set up dogs on the starting line
        {
            Location = 0;
            MyPictureBox.Left = Location;
        }
    }
}
