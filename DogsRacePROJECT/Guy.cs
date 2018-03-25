using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DogsRacePROJECT
{
    public class Guy
    {
        public string Name;
        public Bet MyBet;
        public int Cash;
        public RadioButton MyRadioButton;
        public Label MyLabel;
        public TextBox MyTextBox;



        public void UpdateLabels()
        {
            MyRadioButton.Text = Name + " ma " + Cash + " zł.";
            MyTextBox.Text = MyBet.GetDescription();
       }
        public void ClearBet()
        {
            MyBet = null;
        }
        public bool PlaceBet(int Amount, int DogToWin)
        {

            MyBet.Amount = Amount;
            MyBet.Dog = DogToWin;
            if (this.Cash > Amount)
            {
                MessageBox.Show("Działa");
                return true;
            }
            else
            {
                MessageBox.Show("Nie Działa");
                return false;
            }
        }
        /*public void Collect(int Winner) //ToDo
        {
            if (MyBet.Bettor )
            UpdateLabels();
        }
        */
    }

   
}
