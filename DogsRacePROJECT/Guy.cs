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
        public string Name; // Guy name
        public Bet MyBet;   // Instance of the bet class, it allows to storage bet value
        public int Cash;    // Amount of money
        //GUI controls
        public RadioButton MyRadioButton; 
        public Label MyLabel;


        public void UpdateLabels() // Simply updating guys labels
        {
            MyRadioButton.Text = Name + " ma " + Cash + " zł.";
        }
        public void ClearBet() //setting guy bet to null after run
        {
            MyBet = null;
            MyLabel.Text = Name + " nie zawarł zakładu";
        }
        public bool PlaceBet(int Amount, int DogToWin) //Allows our guy object to place bet, information about bet will be storaged in bet object. For current bet is being created new object
        {
            this.MyBet = new Bet() { Amount = Amount, DogRunner = DogToWin, Bettor = this };

            if (this.Cash >= Amount)
            {
                return true;
            }
            else
            {
                MessageBox.Show(Name + " nie ma wystarczającej ilości pieniędzy, aby obstawić");
                this.MyBet = null;
                return false;
            }
        }
        public void Collect(int Winner) //If object guy got referencje to object bet, it will add or subtract from his amount of cash
        {
            if (MyBet != null)
            {
                Cash = Cash + MyBet.PayOut(Winner); //Adding or substracting bet amount, clearing bet object and updating information
                ClearBet();
                UpdateLabels();
            }
        }
    }
}
