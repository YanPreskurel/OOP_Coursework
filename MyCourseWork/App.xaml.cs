using Firebase.Auth;
using MyCourseWork.Pages;
using MyCourseWork.Services;
using MyCourseWork.Views;

namespace MyCourseWork;

public partial class App : Application
{
    public static Entities.User User;
    private string webApiKey = "AIzaSyBw1KwO850Rv3txzjkJA56j1U2EAZOhp58";
    public static string Token;
    public static FirebaseAuthProvider authProvider;
    public static DatabaseService firebase;
    public static List<string> categories;
    public App()
	{
        CreateListCategories(categories = new List<string>());
        authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
        firebase = new DatabaseService();
        User = new(1, "Yan", "123");

        InitializeComponent();

        //Routing.RegisterRoute("ReplenishView", typeof(ReplenishView));
        //Routing.RegisterRoute("BudgetView", typeof(BudgetView));
        //Routing.RegisterRoute("IncomesView", typeof(IncomesView));
        //Routing.RegisterRoute("ExpensesView", typeof(ExpensesView));

        MainPage = new AppShell();
    }
    public void CreateListCategories(List<string> categories)
    {
        categories.Add("Etc.");
        categories.Add("Transport");
        categories.Add("Food");
        categories.Add("Rest");
        categories.Add("Rent");
        categories.Add("Clothes");
        categories.Add("Travel");
    }
}
