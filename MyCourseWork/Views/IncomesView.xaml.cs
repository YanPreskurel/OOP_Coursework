using MyCourseWork.Entities;
using MyCourseWork.Pages;
using MyCourseWork.Services;

namespace MyCourseWork.Views;

public partial class IncomesView : ContentPage
{
    string name = null;
    string tempCost = null;
    DatabaseService databaseService;

    public IncomesView(DatabaseService databaseService)
	{
		InitializeComponent();

        this.databaseService = databaseService;
	}

    private void IncomeName_TextChanged(object sender, TextChangedEventArgs e)
    {
        name = IncomeName.Text;
    }

    private void IncomeName_TextCompleted(object sender, EventArgs e)
    {
        name = IncomeName.Text;
    }

    private void IncomeAmount_TextChanged(object sender, TextChangedEventArgs e)
    {
        tempCost = IncomeAmount.Text;
    }

    private void IncomeAmount_TextCompleted(object sender, EventArgs e)
    {
        tempCost = IncomeAmount.Text;
    }

    private async void OnClickedAddIncome(object sender, EventArgs e)
    {
        if (CheckCorrect.MonetaryTurnover(tempCost) && CheckCorrect.NameCorrect(name))
        {
            double cost = Convert.ToDouble(tempCost);

            App.User.GetListIncomes().Add(new Income(name, cost, DateTime.Now));
            App.User.wallet.WalletBalance = WalletOperations.BalanceReplenishment(App.User, cost);
            App.User.wallet.EarnedMoney = WalletOperations.CountingEarnedMoney(App.User.GetListIncomes());

            await databaseService.UpdateUserAsync(App.User);

            MessagingCenter.Send<IncomesView>(this, "Added Income");
        }
        else
        {
            await App.Current.MainPage.DisplayAlert("Alert", "Incorrect data intoduction", "OK");
        }
    }

    private async void OnClickedBack(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(MyMainPage)}", true);
        IncomeName.Text = string.Empty;
        IncomeAmount.Text = string.Empty;
    }
}