using MyCourseWork.Entities;
using MyCourseWork.Pages;

namespace MyCourseWork.Views;

public partial class ReplenishView : ContentPage
{
    string tempCost = null;
	public ReplenishView()
	{
		InitializeComponent();
	}

    private void Replenish_TextChanged(object sender, TextChangedEventArgs e)
    {
        tempCost = Replenish.Text;
    }
    private void Replenish_TextCompleted(object sender, EventArgs e)
    {
        tempCost = Replenish.Text;
    }

    private async void OnClickedReplenish_(object sender, EventArgs e)
    {
        if (CheckCorrect.MonetaryTurnover(tempCost))
        {
            double cost = Convert.ToDouble(tempCost);

            App.User.wallet.WalletBalance = WalletOperations.BalanceReplenishment(App.User, cost);
            // MyMainPage ---- Balance.Text = App.User.wallet.WalletBalance.ToString();
        }
        else
        {
            await App.Current.MainPage.DisplayAlert("Alert", "Incorrect data intoduction", "OK");
        }
    }

    private async void OnClickedBack(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(MyMainPage)}", true);
        Replenish.Text = string.Empty;
    }
}