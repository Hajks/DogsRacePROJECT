using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DogsRacePROJECT
{
    public partial class Form1 : Form
    {
        Dog[] dogs = new Dog[4]; //Creating array with 4 dogs 
        Guy[] guys = new Guy[3]; //Creating array with 3 guys
        Random Randomizer = new Random(); //Creating new object Random which will storage random number between 1-6.


        public Form1()
        {
            InitializeComponent();
            DogCreator(0, pictureBox1);
            DogCreator(1, pictureBox2);
            DogCreator(2, pictureBox3);
            DogCreator(3, pictureBox4);
            GuyCreator(0, "Arek", 100, arekRadioButton, arekLabel);
            GuyCreator(1, "Jacek", 100, jacekRadioButton, jacekLabel);
            GuyCreator(2, "Patryk", 100, patrykRadioButton, patrykLabel);

        }
        public void DogCreator(int index, PictureBox dogNumber) //method which create dogs with suitable fields 
        {
            if (dogs[index] == null)
            {
                dogs[index] = new Dog();
                dogs[index].MyPictureBox = dogNumber;
                dogs[index].StartingPosition = dogNumber.Left;
                dogs[index].RacetrackLength = racetrackPictureBox.Width - dogNumber.Width;
                dogs[index].MyRandom = Randomizer;                             
            }
        }
        private void GuyCreator(int index, string name, int cash, RadioButton guyRadioButton, Label guyLabel) //same as above but for guys
        {

            if (guys[index] == null)
            {
                guys[index] = new Guy();
                guys[index].Name = name;
                guys[index].Cash = cash;
                guys[index].MyRadioButton = guyRadioButton;
                guys[index].MyLabel = guyLabel;
                guys[index].UpdateLabels();                
            }
        }

        public void betButton_Click(object sender, EventArgs e)
        {
            {
           
                if (arekRadioButton.Checked == true) // if radiobutton is checked the right guy will bet
                {
                    guys[0].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value); 
                }
                if (jacekRadioButton.Checked == true)
                {
                    guys[1].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value);
                }
                if (patrykRadioButton.Checked == true)
                {
                    guys[2].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value);
                }
                for (int i = 0; i < 3; i++)
                {
                    guys[i].UpdateLabels(); // after clicking betButton all of labes will be updated, if guy made bet it should creat new Bet object, so we check it. If there bet object != null then update description Labels
                    if (guys[i].MyBet != null)
                    {
                        guys[i].MyLabel.Text = guys[i].MyBet.GetDescription();
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e) // Timer which let dogs run
        {
            for (int i = 0; i < 4; i++)
            {
            if(dogs[i] != null)
                {
                    int Winner = i + 1;
                    dogs[i].Run();
                    if(dogs[i].Run() == true) // If one of dogs finished race, we gonna get information about it. 
                    {
                        timer1.Stop();
                        MessageBox.Show("Wygrał pies z numerem " + (i+1));
                        groupBox1.Enabled = true;
                        for (int b = 0; b < 3; b++)
                        {
                            guys[b].Collect(i+1); //Winners take their moneys
                            guys[b].ClearBet(); //All bet objects will be cleared
                        }
                        for (int c = 0; c < 4; c++)
                        {
                            dogs[c].TakeStartingPosition(); //Set up dogs again
                        }
                    }
                }
            }
        }
         
        private void startButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                if(guys[i].MyBet == null) // If any bets objects left, clear it.
                {
                    guys[i].ClearBet();
                }
            }
            groupBox1.Enabled = false; //While race is on, betting is not allowed.
            timer1.Start();
        }
        private void timer2_Tick(object sender, EventArgs e) //Actually i could include it in timer1 but wanted to have those things separeted.
        {
            if (arekRadioButton.Checked == true)
                {
                    label1.Text = "Arek";
                }
            if (jacekRadioButton.Checked == true)
            {
                label1.Text = "Jacek";
            }
            if (patrykRadioButton.Checked == true)
            {
                label1.Text = "Patryk";
            }

        }
    }
}
