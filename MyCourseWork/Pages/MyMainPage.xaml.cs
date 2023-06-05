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

        Balance.Text = App.User.wallet.WalletBalance.ToString("0.##");
    }
    private async void OnClickedReplenish(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(ReplenishView)}", true);
    }
    private async void OnClickedBudget(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(BudgetView)}", true);
    }
    private async void OnClickedIncomes(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(IncomesView)}", true);     
    }
    private async void OnClickedExpenses(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(ExpensesView)}", true);       
    }

    private void OnPageLoad(object sender, EventArgs e)
    {
        Balance.Text = App.User.wallet.WalletBalance.ToString("0.##");
    }
}