using Firebase.Auth;
using MyCourseWork.Services;



namespace MyCourseWork;

public partial class App : Application
{
    public static Entities.User User;
    private string webApiKey = "AIzaSyBw1KwO850Rv3txzjkJA56j1U2EAZOhp58";
    public static string Token;
    public static FirebaseAuthProvider authProvider;
    public static DatabaseService firebase;
    public App()
	{
        authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
        firebase = new DatabaseService();

        InitializeComponent();

		MainPage = new AppShell();
    }

}
