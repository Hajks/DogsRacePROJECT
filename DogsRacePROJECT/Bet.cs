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
        public int Amount;
        public int Dog;
        public Guy Bettor;



        public string GetDescription()
        {

            if (this.Bettor.MyBet.Amount != 0)
            {
                return Bettor.Name + " stawia " + Amount + " zł, na charata z numerem " + Dog;
            }
            else
            {
                return Bettor.Name + " nie zawarł zakładu.";
            }
        }
        
    }
}
