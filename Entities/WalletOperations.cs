using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using MyCourseWork_InTheConsole.Services;



namespace MyCourseWork_InTheConsole.Entities
{
    static public class WalletOperations
    {
        static public double CurrencyConverter(User _user, string currencyTranslate)
        {
            double dollar = 2.9;
            double euro = 3.2;
            double ruble = 0.027;

            switch (currencyTranslate) // во что хочу перевести
            {
                case "BYN":
                    if(_user.wallet.CurrentCurrencyExchangeRate == "$")
                    {
                        return _user.wallet.WalletBalance * dollar;
                    }
                    else if(_user.wallet.CurrentCurrencyExchangeRate == "€")
                    {
                        return _user.wallet.WalletBalance * euro;
                    }
                    else if(_user.wallet.CurrentCurrencyExchangeRate == "RUB")
                    {
                        return _user.wallet.WalletBalance * ruble;
                    }
                    return _user.wallet.WalletBalance;

                case "$":
                    if (_user.wallet.CurrentCurrencyExchangeRate == "BYN")
                    {
                        return _user.wallet.WalletBalance / dollar;
                    }
                    else if (_user.wallet.CurrentCurrencyExchangeRate == "€")
                    {
                        return _user.wallet.WalletBalance * euro / dollar;
                    }
                    else if (_user.wallet.CurrentCurrencyExchangeRate == "RUB")
                    {
                        return _user.wallet.WalletBalance * ruble / dollar;
                    }
                    return _user.wallet.WalletBalance;

                case "€":
                    if (_user.wallet.CurrentCurrencyExchangeRate == "$")
                    {
                        return _user.wallet.WalletBalance * dollar / euro;
                    }
                    else if (_user.wallet.CurrentCurrencyExchangeRate == "BYN")
                    {
                        return _user.wallet.WalletBalance / euro;
                    }
                    else if (_user.wallet.CurrentCurrencyExchangeRate == "RUB")
                    {
                        return _user.wallet.WalletBalance * ruble / euro;
                    }
                    return _user.wallet.WalletBalance;

                case "RUB":
                    if (_user.wallet.CurrentCurrencyExchangeRate == "$")
                    {
                        return _user.wallet.WalletBalance * dollar / ruble;
                    }
                    else if (_user.wallet.CurrentCurrencyExchangeRate == "€")
                    {
                        return _user.wallet.WalletBalance * euro / ruble;
                    }
                    else if (_user.wallet.CurrentCurrencyExchangeRate == "BYN")
                    {
                        return _user.wallet.WalletBalance / ruble;
                    }
                    return _user.wallet.WalletBalance;

                default:
                    return _user.wallet.WalletBalance;
            }                                                             
        }

        static public double BalanceReplenishment(User _user, double amountOfReplenishment)
        {
            return _user.wallet.WalletBalance + amountOfReplenishment; // возвращаю сумму после поплнения кошелька, нужно приравнять к общей сумме денег на кошельке
        } 
     
        static public double BalanceLoss(User _user, double amountOfLoss)
        {
            return _user.wallet.WalletBalance - amountOfLoss; // возвращаю сумму после убытка кошелька, нужно приравнять к общей сумме денег на кошельке
        }
       
        static public double CountingSpentMoney(List<Expense> _expenses)
        {
            double AmountOfSpentMoney = 0;

            foreach (var expense in _expenses)
            {
                AmountOfSpentMoney += expense.Cost;
            }
            return AmountOfSpentMoney;
        }

        static public double CountingEarnedMoney(List<Income> _incomes)
        {
            double AmountOfEarnedMoney = 0;

            foreach (var income in _incomes)
            {
                AmountOfEarnedMoney += income.Cost;
            }
            return AmountOfEarnedMoney;
        }
    }
}
