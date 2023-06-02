using MyCourseWork.Entities;
using MyCourseWork.Services;
using MyCourseWork.Views;
using Firebase.Auth;


namespace MyCourseWork.Pages;

public partial class MyMainPage : ContentPage
{
	public MyMainPage()
	{
		InitializeComponent();
	}
    private void OnClickedConverter(object sender, EventArgs e)
    {
        Button button = sender as Button;

        if (button.Text == "BYN")
        {
            button.Text = "$";
        }
        else if (button.Text == "$")
        {
            button.Text = "EURO";
        }
        else if (button.Text == "EURO")
        {
            button.Text = "RUB";
        }
        else if (button.Text == "RUB")
        {
            button.Text = "BYN";
        }      

        App.User.wallet.WalletBalance = WalletOperations.CurrencyConverter(App.User, button.Text);
        App.User.wallet.EarnedMoney = WalletOperations.ConversionOfErnedAndSpentMoney(App.User, button.Text, App.User.wallet.EarnedMoney);
        App.User.wallet.SpentMoney = WalletOperations.ConversionOfErnedAndSpentMoney(App.User, button.Text, App.User.wallet.SpentMoney);
        App.User.wallet.CurrentCurrencyExchangeRate = button.Text;

        Balance.Text = App.User.wallet.WalletBalance.ToString();
    }
    private async void OnClickedReplenish(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(ReplenishView)}", true);
        //App.User.wallet
        // add processing replenish

        //string tempCost = "";

        //if (CheckCorrect.MonetaryTurnover(tempCost))
        //{
        //    double cost = Convert.ToDouble(tempCost);

        //    user.wallet.WalletBalance = WalletOperations.BalanceReplenishment(user, cost);
        //    Balance.Text = user.wallet.WalletBalance.ToString();
        //}
        //else
        //{
        //    // try again
        //}
    }

    private async void OnClickedBudget(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(BudgetView)}", true);
    }
    private async void OnClickedIncomes(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(IncomesView)}", true);
        // add processing adding incomes windows

        //string name = "";
        //string tempCost = "";

        //if (CheckCorrect.MonetaryTurnover(tempCost))
        //{
        //    double cost = Convert.ToDouble(tempCost);
        //    DateTime dateTime = DateTime.Now;

        //    user.GetListIncomes().Add(new Income(name, cost, dateTime));

        //    user.wallet.WalletBalance = WalletOperations.BalanceReplenishment(user, cost);
        //    user.wallet.EarnedMoney = WalletOperations.CountingEarnedMoney(MyProgram.GetListUsers()[userId - 1].GetListIncomes());
        //}
        //else
        //{
        //    // try again
        //}
    }

    private async void OnClickedExpenses(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(ExpensesView)}", true);
        // add processing adding expenses windows

        //string name = "";
        //string tempCost = "";
        //string category = "";

        //if (CheckCorrect.MonetaryTurnover(tempCost))
        //{
        //    double cost = Convert.ToDouble(tempCost);
        //    DateTime dateTime = DateTime.Now;

        //    if (cost > user.wallet.WalletBalance)
        //    {
        //        // try again
        //    }

        //    user.GetListExpenses().Add(new Expense(name, cost, dateTime, category));
        //    user.wallet.WalletBalance = WalletOperations.BalanceLoss(user, cost);
        //    user.wallet.SpentMoney = WalletOperations.CountingSpentMoney(user.GetListExpenses());
        //}
        //else
        //{
        //    // try again
        //}
    }
}