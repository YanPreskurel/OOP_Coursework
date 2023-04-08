using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCourseWork_InTheConsole.Entities
{
    public class Wallet
    {
        public Wallet() { }

        public double WalletBalance { get; set; } = 0;
        public double SpentMoney { get; set; } = 0;
        public string CurrentCurrencyExchangeRate { get; set; } = "BYN";      
    }
}
