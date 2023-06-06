using MyCourseWork.Entities;
using MyCourseWork.Pages;
using MyCourseWork.Services;

namespace MyCourseWork.Views;

public partial class ExpensesView : ContentPage
{
    string name = null;
    string tempCost = null;
    string category = null;
    DatabaseService databaseService;
    public ExpensesView(DatabaseService databaseService)
	{
        InitializeComponent();
        this.databaseService = databaseService;
    }

    private void ExpenseName_TextChanged(object sender, TextChangedEventArgs e)
    {
        name = ExpenseName.Text;
    }
    private void ExpenseName_TextCompleted(object sender, EventArgs e)
    {
        name = ExpenseName.Text;
    }
    private void ExpenseAmount_TextChanged(object sender, TextChangedEventArgs e)
    {
        tempCost = ExpenseAmount.Text;
    }
    private void ExpenseAmount_TextCompleted(object sender, EventArgs e)
    {
        tempCost = ExpenseAmount.Text;
    }

    private async void OnClickedAddExpense(object sender, EventArgs e)
    {
        if (CheckCorrect.MonetaryTurnover(tempCost) && CheckCorrect.NameCorrect(name) && (Convert.ToDouble(tempCost) <= App.User.wallet.WalletBalance))
        {
            double cost = Convert.ToDouble(tempCost);

            App.User.GetListExpenses().Add(new Expense(name, cost, DateTime.Now, category));
            App.User.wallet.WalletBalance = WalletOperations.BalanceLoss(App.User, cost);
            App.User.wallet.SpentMoney = WalletOperations.CountingSpentMoney(App.User.GetListExpenses());

            await databaseService.UpdateUserAsync(App.User);

            MessagingCenter.Send<ExpensesView>(this, "Added Expense");
        }
        else
        {
            await App.Current.MainPage.DisplayAlert("Alert", "Incorrect data intoduction", "OK");
        }
    }

    private async void OnClickedBack(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(MyMainPage)}", true);
        ExpenseName.Text = string.Empty;
        ExpenseAmount.Text = string.Empty;
        ExpenseCategory.SelectedItem = App.categories[0];
    }

    private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = sender as Picker;

        category = picker.SelectedItem.ToString();
    }
    private void OnPageLoad(object sender, EventArgs e)
    {
        ExpenseCategory.ItemsSource = App.categories;
        ExpenseCategory.ItemsSource = ExpenseCategory.GetItemsAsArray();
        ExpenseCategory.SelectedItem = App.categories[0];
    }
}