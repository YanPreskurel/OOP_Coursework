using Firebase.Auth;
using MyCourseWork.Entities;
using MyCourseWork.Services;
using System.Collections.ObjectModel;

namespace MyCourseWork.Pages;

public partial class PaymentPage : ContentPage
{
    string name = null;
    string tempCost = null;
    string category = null;
    string namePayment = null;
    Payment payment;
    DatabaseService databaseService;

    public ObservableCollection<string> paymentsNames { get; set; }=new ObservableCollection<string>();

    public void CreateListPaymentsNames()
    {
        foreach (Payment payment in App.User.GetListPayments())
        {
            paymentsNames.Add(payment.Name);
        }
    }

    public PaymentPage(DatabaseService databaseService)
	{
        CreateListPaymentsNames();
        InitializeComponent();
        BindingContext = this;
        this.databaseService = databaseService;
    }

    private void PaymentName_TextChanged(object sender, TextChangedEventArgs e)
    {
        name = PaymentName.Text;
    }
    private void PaymentName_TextCompleted(object sender, EventArgs e)
    {
        name = PaymentName.Text;
    }
    private void PaymentAmount_TextChanged(object sender, TextChangedEventArgs e)
    {
        tempCost = PaymentAmount.Text;
    }
    private void PaymentAmount_TextCompleted(object sender, EventArgs e)
    {
        tempCost = PaymentAmount.Text;
    }
    private void OnPickerSelectedIndexChangedPaymentCategory(object sender, EventArgs e)
    {
        var picker = sender as Picker;
        category = picker.SelectedItem.ToString();
    }
    private async void OnClickedAddPayment(object sender, EventArgs e)
    {
        if (CheckCorrect.MonetaryTurnover(tempCost) && CheckCorrect.NameCorrect(name))
        {
            double cost = Convert.ToDouble(tempCost);

            App.User.GetListPayments().Add(new Payment(name, cost, DateTime.Now, category));
            paymentsNames.Add(name);

            await databaseService.UpdateUserAsync(App.User);

        }
        else
        {
            await App.Current.MainPage.DisplayAlert("Alert", "Incorrect data intoduction", "OK");
        }
    }


    private void OnPickerSelectedIndexChangedPaymentSelection(object sender, EventArgs e)
    {
        var picker = sender as Picker;

        payment = App.User.GetListPayments().FirstOrDefault(pay => pay.Name.Equals(picker.SelectedItem.ToString()));
        namePayment = picker.SelectedItem.ToString();
        PaymentView.Text = payment.ToString();
    }

    private async void OnClickedPayAndDeletePayment(object sender, EventArgs e)
    {
        if (CheckCorrect.NameCorrect(namePayment) && payment.Cost <= App.User.wallet.WalletBalance)
        {
            App.User.wallet.WalletBalance = WalletOperations.BalanceLoss(App.User, payment.Cost);
            App.User.GetListExpenses().Add(new Expense(payment.Name, payment.Cost, DateTime.Now, payment.Category));
            App.User.PayDeletePayment(payment);

            PaymentView.Text = string.Empty;

            await databaseService.UpdateUserAsync(App.User);
        }
        else
        {
            await App.Current.MainPage.DisplayAlert("Alert", "Incorrect data intoduction", "OK");
        }
    }

    private void OnPageLoad(object sender, EventArgs e)
    {
        PaymentCategory.ItemsSource = App.categories;
        PaymentCategory.ItemsSource = PaymentCategory.GetItemsAsArray();

        PaymentCategory.SelectedItem = App.categories[0];
    }
}