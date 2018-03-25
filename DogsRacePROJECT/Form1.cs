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
        Dog[] dogs = new Dog[4];
        Guy[] guys = new Guy[3];
        Random Randomizer = new Random();
        Bet MyBet = new Bet();

        public Form1()
        {
            InitializeComponent();
            DogCreator(0, pictureBox1);
            DogCreator(1, pictureBox2);
            DogCreator(2, pictureBox3);
            DogCreator(3, pictureBox4);
            GuyCreator(0, "Arek", 100, arekRadioButton, label1, arekTextBox);
            GuyCreator(1, "Jacek", 100, jacekRadioButton, label1, jacekTextBox);
            GuyCreator(2, "Patryk", 100, patrykRadioButton, label1, patrykTextBox);


        }
        public void DogCreator(int index, PictureBox dogNumber)
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
        private void GuyCreator(int index, string name, int cash, RadioButton guyRadioButton, Label guyLabel, TextBox guyTextBox) //betMissing ??
        {

            if (guys[index] == null)
            {
                guys[index] = new Guy();
                guys[index].Name = name;
                guys[index].Cash = cash;
                guys[index].MyRadioButton = guyRadioButton;
                guys[index].MyLabel = guyLabel;
                guys[index].MyTextBox = guyTextBox;
                guys[index].MyBet = new Bet();
                guys[index].UpdateLabels();
            }
        }

        public void betButton_Click(object sender, EventArgs e)
        {
            if (arekRadioButton.Checked == true)
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
                guys[i].UpdateLabels();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
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

            for (int i = 0; i < 4; i++)
            {
            if(dogs[i] != null)
                {
                    dogs[i].Run();
                    if(dogs[i].Run() == true)
                    {
                        timer1.Stop();
                        MessageBox.Show("Wygrał pies z numerem " + (i+1));
                    }
                }
            }
        }
         
        private void startButton_Click(object sender, EventArgs e)
        {
            timer1.Start();


        }
    }
}
