using MyCourseWork.Entities;
using MyCourseWork.Pages;
using MyCourseWork.Services;
using MyCourseWork.Views;

namespace MyCourseWork;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddTransient<MainPage>();
		builder.Services.AddTransient<MyMainPage>();
		builder.Services.AddTransient<AccountPage>();
		builder.Services.AddTransient<PaymentPage>();
		builder.Services.AddTransient<StatisticsPage>();

        builder.Services.AddTransient<ReplenishView>();
        builder.Services.AddTransient<BudgetView>();
        builder.Services.AddTransient<IncomesView>();
        builder.Services.AddTransient<ExpensesView>();

        builder.Services.AddSingleton<DatabaseService>();

        return builder.Build();
	}
}