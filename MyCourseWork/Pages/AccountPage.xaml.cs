using MyCourseWork.Entities;
using MyCourseWork.Services;

namespace MyCourseWork.Pages;

public partial class AccountPage : ContentPage
{
    string name = null;
    string tempCost = null;
    string category = null;
    string tempAmount = null;
    string nameAccount = null;
    Account account;
    List<string> accountsNames;

    public void CreateListAccountsNames(List<string> accountsNames)
    {
        foreach (Account account in App.User.GetListAccounts())
        {
            accountsNames.Add(account.Name);
        }
    }
    public AccountPage()
    {
        InitializeComponent();
    }

    private void AccountName_TextChanged(object sender, TextChangedEventArgs e)
    {
        name = AccountName.Text;
    }
    private void AccountName_TextCompleted(object sender, EventArgs e)
    {
        name = AccountName.Text;
    }
    private void AccountAmount_TextChanged(object sender, TextChangedEventArgs e)
    {
        tempCost = AccountAmount.Text;
    }
    private void AccountAmount_TextCompleted(object sender, EventArgs e)
    {
        tempCost = AccountAmount.Text;
    }
    private void OnPickerSelectedIndexChangedAccountCategory(object sender, EventArgs e)
    {
        var picker = sender as Picker;
        category = picker.SelectedItem.ToString();
    }
    private async void OnClickedAddAccount(object sender, EventArgs e)
    {

        if (CheckCorrect.MonetaryTurnover(tempCost) && CheckCorrect.NameCorrect(name))
        {
            double cost = Convert.ToDouble(tempCost);

            App.User.GetListAccounts().Add(new Account(name, cost, DateTime.Now, category));
        }
        else
        {
            await App.Current.MainPage.DisplayAlert("Alert", "Incorrect data intoduction", "OK");
        }
    }

    private void Amount_TextChanged(object sender, TextChangedEventArgs e)
    {
        tempAmount = AmountOfReplenisment.Text;
    }
    private void Amount_TextCompleted(object sender, EventArgs e)
    {
        tempAmount = AmountOfReplenisment.Text;
    }
    private void OnPickerSelectedIndexChangedAccountSelection(object sender, EventArgs e)
    {
        CreateListAccountsNames(accountsNames = new List<string>());

        var picker = sender as Picker;

        account = App.User.GetListAccounts().FirstOrDefault(acc => acc.Name.Equals(picker.SelectedItem.ToString()));
        nameAccount = picker.SelectedItem.ToString();
        AccountView.ItemsSource = account.ToString();
    }
    private async void OnClickedReplenishAccount(object sender, EventArgs e)
    {
        if (CheckCorrect.MonetaryTurnover(tempAmount) && CheckCorrect.NameCorrect(nameAccount) && CheckCorrect.DeposeRange(account, Convert.ToDouble(tempAmount)) && (Convert.ToDouble(tempAmount) <= App.User.wallet.WalletBalance))
        {
            double cost = Convert.ToDouble(tempAmount);

            account.CurrentCost = WalletOperations.AccountReplenishment(account, cost);
            App.User.wallet.WalletBalance = WalletOperations.BalanceLoss(App.User, cost);
            App.User.GetListExpenses().Add(new Expense(name, cost, DateTime.Now, account.Category));

            if(account.Cost == account.CurrentCost)
            {
                App.User.PayDeleteAccount(account);
            }
        }
        else
        {
            await App.Current.MainPage.DisplayAlert("Alert", "Incorrect data intoduction", "OK");
        }
    }

    private void OnPageLoad(object sender, EventArgs e)
    {
        AccountCategory.ItemsSource = App.categories;
        AccountCategory.ItemsSource = AccountCategory.GetItemsAsArray();

        AccountSelection.ItemsSource = accountsNames;
        AccountSelection.ItemsSource = AccountSelection.GetItemsAsArray();

        AccountCategory.SelectedItem = App.categories[0];
    }
}