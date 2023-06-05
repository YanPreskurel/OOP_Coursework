using MyCourseWork.Entities;
using MyCourseWork.Pages;
using MyCourseWork.Services;
using System.Xml;

namespace MyCourseWork;

public partial class MainPage : ContentPage
{
    public string UserLogin;
    public string UserPassword;
    DatabaseService databaseService;

    public MainPage(DatabaseService databaseService)
    {
        this.databaseService = databaseService;
        UserLogin = "admin@admin.com";
        UserPassword = "123123";

        InitializeComponent();
    }
    void Login_TextChanged(object sender, TextChangedEventArgs e)
    {
        UserLogin = Login.Text;
    }
    void Password_TextChanged(object sender, TextChangedEventArgs e)
    {
        UserPassword = Password.Text;
    }

    private void Login_TextCompleted(object sender, EventArgs e)
    {
        UserLogin = Login.Text;
    } 
    private void Password_TextCompleted(object sender, EventArgs e)
    {
        UserPassword = Password.Text;
    }

    private async void OnSignInClicked(object sender, EventArgs e)
    {
        //await Shell.Current.GoToAsync($"//{nameof(MyMainPage)}", true);
        try
        {
            //IsBusy = true;
            //var auth = await App.authProvider.SignInWithEmailAndPasswordAsync(UserLogin, UserPassword);
            //App.Token = auth.FirebaseToken;
            //App.User = await this.databaseService.GetUserAsync(auth.User.LocalId);
            await Shell.Current.GoToAsync($"//{nameof(MyMainPage)}", true);
        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
        }
        finally
        {
            //IsBusy = false;
        }
    } 
    private async void OnSignUpClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(MyMainPage)}", true);
        //try
        //{
        //    IsBusy = true;
        //    var auth = await App.authProvider.CreateUserWithEmailAndPasswordAsync(UserLogin, UserPassword);
        //    string token = auth.FirebaseToken;

        //    if (token != null)
        //    {
        //        await App.Current.MainPage.DisplayAlert("Success!", "User Registered successfully", "OK");
        //    }

        //    var auth1 = await App.authProvider.SignInWithEmailAndPasswordAsync(UserLogin, UserPassword);
        //    App.Token = auth1.FirebaseToken;

        //    App.User = new Entities.User()
        //    {
        //        Id = (int)Convert.ToUInt32(auth1.User.LocalId),
        //        Login = UserLogin,
        //        Password = UserPassword,
        //    };
        //    await databaseService.AddUserAsync(App.User);
        //    await Shell.Current.GoToAsync($"//{nameof(MyMainPage)}", true);
        //}
        //catch (Exception ex)
        //{
        //    await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
        //}
        //finally
        //{
        //    IsBusy = false;
        //}
    }
}
