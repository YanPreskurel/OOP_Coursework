
namespace MyCourseWork.Pages;

public partial class StatisticsPage : ContentPage
{
    string category = null;
	public StatisticsPage()
	{
		InitializeComponent();
	}

    private void OnPickerSelectedIndexChangedCategorySelection(object sender, EventArgs e)
    {
        var picker = sender as Picker;
        category = picker.SelectedItem.ToString();
        CategotyInformation.Text = StatisticsOperations.calculate(category);
    }

    private void OnPageLoad(object sender, EventArgs e)
    {
        CategotySelection.ItemsSource = App.categories;
        CategotySelection.ItemsSource = CategotySelection.GetItemsAsArray();

        SpentMoney.Text = App.User.wallet.SpentMoney.ToString("0.##");
        EarnedMoney.Text = App.User.wallet.EarnedMoney.ToString("0.##");
        CurrentCurrencyExchangeRate.Text = App.User.wallet.CurrentCurrencyExchangeRate;
    }
}


public static class StatisticsOperations
{
    public static double sum = 0;
    public static string sumString;
    public static double percent = 0;
    public static string percentString;
    public static string calculate(string category_)
    {
        foreach(var item in App.User.GetListExpenses())
        { 
            if(item.Name == category_)
            {
                sum += item.Cost;
            }
        }
        sumString = sum.ToString("0.##");
        percent = sum * 100 /  App.User.wallet.SpentMoney;
        percentString = percent.ToString("0.##");

        return $"Spent on category - {sumString} {App.User.wallet.CurrentCurrencyExchangeRate}\nPercentage of total consumption - {percentString} %";
    }

}
