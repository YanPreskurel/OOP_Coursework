
using MyCourseWork.Pages;

namespace MyCourseWork.Views;

public partial class BudgetView : ContentPage
{
	public BudgetView()
	{
		InitializeComponent();
	}

    private async void OnClickedBack(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(MyMainPage)}", true);
    }

    private void OnPageLoad(object sender, EventArgs e)
    {
        IncomesView.ItemsSource = App.User.GetListIncomes();
        ExpensesView.ItemsSource = App.User.GetListExpenses();
    }
}