using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyCourseWork_InTheConsole.Entities
{
    public class Wallet
    {
        public Wallet() { }

        public double WalletBalance { get; set; } = 0;
        public double SpentMoney { get; set; } = 0;
        public double EarnedMoney { get; set; } = 0;
        public string CurrentCurrencyExchangeRate { get; set; } = "BYN";

        public override string ToString()
        {
            return $"********** Wallet balance: {WalletBalance} {CurrentCurrencyExchangeRate}, amount of money earned: {EarnedMoney} {CurrentCurrencyExchangeRate}, amount of money spent: {SpentMoney} {CurrentCurrencyExchangeRate}**********";
        }
    }
}
