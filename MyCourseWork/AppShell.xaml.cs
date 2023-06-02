using MyCourseWork.Views;

namespace MyCourseWork;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(ReplenishView), typeof(ReplenishView));
        Routing.RegisterRoute(nameof(BudgetView), typeof(BudgetView));
        Routing.RegisterRoute(nameof(IncomesView), typeof(IncomesView));
        Routing.RegisterRoute(nameof(ExpensesView), typeof(ExpensesView));
    }
}
