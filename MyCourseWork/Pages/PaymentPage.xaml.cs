using MyCourseWork.Entities;
using MyCourseWork.Services;

namespace MyCourseWork.Pages;

public partial class PaymentPage : ContentPage
{
	public PaymentPage()
	{
		InitializeComponent();
	}

    private void OnClickedAddPayment(object sender, EventArgs e)
    {
        // add processing adding payments 

        string name = "";
        string tempCost= "";
        string category = "";

        if (CheckCorrect.MonetaryTurnover(tempCost))
        {
            double cost = Convert.ToDouble(tempCost);
            DateTime dateTime = DateTime.Now;

            App.User.GetListPayments().Add(new Payment(name, cost, dateTime, category));
        }
        else
        {
           // try again
        }
    }
}