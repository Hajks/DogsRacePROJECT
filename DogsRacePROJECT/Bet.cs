using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DogsRacePROJECT
{
    public class Bet
    {
        public int Amount; //bet amount
        public int DogRunner; //which number of dog
        public Guy Bettor;  //Reference to guy object
        public string GetDescription()
        {

            if (Bettor.Cash >= Amount) // if bettor got enough cash to bet then it will return information that his bet is set up
            {
                return Bettor.Name + " stawia " + Amount + " zł, na charata z numerem " + DogRunner; 
            }
            else
            {
                return Bettor.Name + " nie zawarł zakładu.";
            }
        }
        public int PayOut(int Winner) //if bettor has seleted dog which won then it will return him his bet multiplied by 2, otherwise he will lose money which he put
        {
            if (Winner == DogRunner)
            {
                return Amount;
            }
            else
            {
                return -Amount;
            }
        }
    }
}
