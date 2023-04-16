using MyCourseWork_InTheConsole.Entities;
using MyCourseWork_InTheConsole.Services;
using System.Security.Principal;
using System.Xml.Linq;


namespace MyCourseWork_InTheConsole
{
    public class Program
    {
        public static void Main()
        {
            List<User> users = new();          

            while (true)
            {
                //Console.Clear();
                Console.WriteLine("Choose:\n1. SIGN IN\n2. SIGN UP\n3. EXIT\n Answer: ");

                string? enter = Console.ReadLine();
                int userId;


                if (enter == "1")
                {
                    Console.WriteLine("***************** ENTRANCE *************** \nEnter login and password\n Login: ");
                    string? login = Console.ReadLine();
                    Console.WriteLine("Password: ");
                    string? password = Console.ReadLine();
                    Console.WriteLine();

                    if (CheckCorrect.VerifyUserCorrect(users, login, password))
                    {
                        Console.WriteLine("Successful entry attempt");
                        userId = CheckCorrect.userId;
                        var user = users.FirstOrDefault(u => u.Id == userId);

                        // дальнейшее развитие и вывод списка возможных команд
                        while (true)
                        {
                            bool buttonExit = false;

                            Console.WriteLine("\nSelect the command from the shown: ");
                            Console.WriteLine("1. Добавить доход\n" +
                                              "2. Добавить расход\n" +
                                              "3. Добавить счёт\n" +
                                              "4. Добавить уведомление \n" +
                                              "5. Пополнение баланса\n" +
                                              "6. Пополнение счёта\n" + 
                                              "7. Конвертация баланса кошелька\n" +   
                                              "8. Просмотр баланса кошелька\n" +
                                              "9. Просмотр списка доходов\n" +
                                              "10. Просмотр списка расходов\n" +
                                              "11. Просмотр списка счетов\n" +
                                              "12. Просмотр списка уведомлений\n" +
                                              "13. Оплата уведомлений\n" +
                                              "14. Выход");
                            string? nameOfCommand = Console.ReadLine();

                            switch (nameOfCommand)
                            {
                                case "1":

                                    Console.WriteLine("Введите наименование дохода: ");
                                    string? name1 = Console.ReadLine();

                                    Console.WriteLine("Введите сумму дохода: ");
                                    string? temp1 = Console.ReadLine();
                                    bool result1 = CheckCorrect.MonetaryTurnover(temp1);

                                    if (result1)
                                    {
                                        double cost1 = Convert.ToDouble(temp1);
                                        DateTime dateTime = DateTime.Now;

                                        user.GetListIncomes().Add(new Income(name1, cost1, dateTime));

                                        user.wallet.WalletBalance = WalletOperations.BalanceReplenishment(user, cost1);
                                        user.wallet.EarnedMoney = WalletOperations.CountingEarnedMoney(users[userId - 1].GetListIncomes());

                                        Console.WriteLine("Your income has been successfully added\n");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error, try again\n");
                                    }
                                    break;

                                // добавление дохода реализовано

                                case "2":
                                    Console.WriteLine("Введите наименование расхода: ");
                                    string? name2 = Console.ReadLine();

                                    Console.WriteLine("Введите сумму расхода: ");
                                    string? temp2 = Console.ReadLine();
                                    bool result2 = CheckCorrect.MonetaryTurnover(temp2);

                                    Console.WriteLine("Введите категорию расхода: ");
                                    string? category2 = Console.ReadLine();
                                    

                                    if (result2)
                                    {
                                        double cost2 = Convert.ToDouble(temp2);
                                        DateTime dateTime = DateTime.Now;

                                        if (cost2 > user.wallet.WalletBalance)
                                        {
                                            Console.WriteLine("Error, try again\n");
                                            break;
                                        }

                                        user.GetListExpenses().Add(new Expense(name2, cost2, dateTime, category2));

                                        user.wallet.WalletBalance = WalletOperations.BalanceLoss(user, cost2);                                     
                                        user.wallet.SpentMoney = WalletOperations.CountingSpentMoney(user.GetListExpenses());

                                        Console.WriteLine("Your expense has been successfully added\n");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error, try again\n");
                                    }
                                    break;

                                // добавление расхода реализовано

                                case "3":
                                    Console.WriteLine("Введите наименование счёта: ");
                                    string? name3 = Console.ReadLine();

                                    Console.WriteLine("Введите сумму желаемого накопления: ");
                                    string? temp3 = Console.ReadLine();
                                    bool result3 = CheckCorrect.MonetaryTurnover(temp3);

                                    Console.WriteLine("Введите категорию расхода: ");
                                    string? category3 = Console.ReadLine();


                                    if (result3)
                                    {
                                        double cost3 = Convert.ToDouble(temp3);
                                        DateTime dateTime = DateTime.Now;

                                        user.GetListAccounts().Add(new Account(name3, cost3, dateTime, category3));

                                        Console.WriteLine("Your account has been successfully added\n");
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nError, try again\n");
                                    }
                                    break;

                                // добавление счета реализовано

                                case "4":
                                    Console.WriteLine("Введите наименование уведомления: ");
                                    string? name4 = Console.ReadLine();

                                    Console.WriteLine("Введите нужную сумму для оплаты уведомления: ");
                                    string? temp4 = Console.ReadLine();
                                    bool result4 = CheckCorrect.MonetaryTurnover(temp4);

                                    Console.WriteLine("Введите категорию уведомления: ");
                                    string? category4 = Console.ReadLine();


                                    if (result4)
                                    {
                                        double cost4 = Convert.ToDouble(temp4);
                                        DateTime dateTime = DateTime.Now;

                                        user.GetListNotifications().Add(new Notification(name4, cost4, dateTime, category4));

                                        Console.WriteLine("Your notification has been successfully added\n");
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nError, try again\n");
                                    }
                                    break;

                                // добавление уыедомления реализовано

                                case "5":
                                    Console.WriteLine("Введите сумму на которую хотите пополнить баланс: ");
                                    string? temp5 = Console.ReadLine();
                                    bool result5 = CheckCorrect.MonetaryTurnover(temp5);

                                    if (result5)
                                    {
                                        double cost5 = Convert.ToDouble(temp5);

                                        user.wallet.WalletBalance = WalletOperations.BalanceReplenishment(user, cost5);

                                        Console.WriteLine("Money successfully credited\n");
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nError, try again\n");
                                    }
                                    break;
                                // пополнение баланса реализовано

                                case "6":

                                    Console.WriteLine();
                                    foreach (var account in users[userId - 1].GetListAccounts())
                                    {
                                        Console.WriteLine(account.ToString());
                                    }
                                    Console.WriteLine("\nВведите наименование счёта, который хотите пополнить: ");

                                    string? name6 = Console.ReadLine();

                                    if (CheckCorrect.FindAccount(user.GetListAccounts(), name6))
                                    {
                                        foreach (var account in user.GetListAccounts())
                                        {
                                            if (account.Name == name6)
                                            {
                                                Console.WriteLine($"You have selected this account, enter the amount you want to put on the account");
                                                Console.WriteLine(account.ToString());

                                                string? temp6 = Console.ReadLine();
                                                bool result6 = CheckCorrect.MonetaryTurnover(temp6);

                                                if (result6)
                                                {
                                                    double cost6 = Convert.ToDouble(temp6);
                                                    if (CheckCorrect.DeposeRange(account, cost6))
                                                    {
                                                        if (cost6 <= user.wallet.WalletBalance)
                                                        {
                                                            DateTime dateTime = DateTime.Now;

                                                            account.CurrentCost = WalletOperations.AccountReplenishment(account, cost6);
                                                            user.wallet.WalletBalance = WalletOperations.BalanceLoss(user, cost6);
                                                            user.GetListExpenses().Add(new Expense(name6, cost6, dateTime, "Fundraising"));
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("\nError, try again\n");
                                                            break;
                                                        }

                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("\nError, try again\n");
                                                        break;
                                                    }
                                                    // вызвать функцию проверки возможности совершения операции
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\nError, try again\n");
                                                    break;
                                                }

                                            }

                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nError, try again\n");
                                    }
                                    break;

                                // пополнение счёта реализовано

                                case "7":
                                    Console.WriteLine("\nSelect the currency you want to transfer money:  -  1. $  -  2. Euro  -  3.  RUB  -  4. BYN  -  : ");

                                    string? temp7 = Console.ReadLine();

                                    if (temp7 == "1")
                                    {
                                        temp7 = "$";
                                    }
                                    else if(temp7 == "2")
                                    {
                                        temp7 = "Euro";
                                    }
                                    else if(temp7 == "3")
                                    {
                                        temp7 = "RUB";
                                    }
                                    else if(temp7 == "4")
                                    {
                                        temp7 = "BYN";
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nError, try again\n");
                                        break;
                                    }

                                    user.wallet.WalletBalance = WalletOperations.CurrencyConverter(user, temp7);
                                    user.wallet.EarnedMoney = WalletOperations.ConversionOfErnedAndSpentMoney(user, temp7, user.wallet.EarnedMoney);
                                    user.wallet.SpentMoney = WalletOperations.ConversionOfErnedAndSpentMoney(user, temp7, user.wallet.SpentMoney);

                                    user.wallet.CurrentCurrencyExchangeRate = temp7;

                                    break;

                                    // конвертация в другую валюту реализована

                                case "8":
                                    Console.WriteLine("\n" + user.wallet.ToString() + "\n");
                                    break;

                                    // Просмотр баланса кошелька реализован

                                case "9":

                                    Console.WriteLine();
                                    foreach (var income in user.GetListIncomes())
                                    {
                                        Console.WriteLine(income.ToString());
                                    }
                                    break;

                                    // Просмотр списка доходов реализован

                                case "10":
                                    Console.WriteLine();
                                    foreach (var expense in user.GetListExpenses())
                                    {
                                        Console.WriteLine(expense.ToString());
                                    }
                                    break;

                                    // Просмотр списка расходов реализован

                                case "11":
                                    Console.WriteLine();
                                    foreach (var account in user.GetListAccounts())
                                    {
                                        Console.WriteLine(account.ToString());
                                    }
                                    break;

                                    // Просмотр списка счетов реализован

                                case "12":
                                    Console.WriteLine();
                                    foreach (var notification in user.GetListNotifications())
                                    {
                                        Console.WriteLine(notification.ToString());
                                    }
                                    break;

                                    // Просмотр списка уведомлений реализован
                                case "13":
                                    Console.WriteLine();
                                    foreach (var notification in user.GetListNotifications())
                                    {
                                        Console.WriteLine(notification.ToString());
                                    }

                                    Console.WriteLine("Введите наименование уведомления, которое хотите оплатить: ");

                                    string? name13 = Console.ReadLine();

                                    if (CheckCorrect.FindNotification(user.GetListNotifications(), name13))
                                    {

                                        var notification = user.GetListNotifications().FirstOrDefault(not => not.Name.Equals(name13));

                                        if (notification.Cost <= user.wallet.WalletBalance)
                                        {
                                            DateTime dateTime = DateTime.Now;

                                            user.wallet.WalletBalance = WalletOperations.BalanceLoss(user, notification.Cost);
                                            user.GetListExpenses().Add(new Expense(notification.Name, notification.Cost, dateTime, notification.Category));
                                            user.PayDeleteNotification(notification);

                                            Console.WriteLine("\nNotification successfully paid\n");
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nError, try again\n");
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nError, try again\n");
                                        break;
                                    }                                       
                                    break;

                                    // Оплата уведомления 

                                case "14": // выход на начальную страницу сделан
                                    buttonExit = true;
                                    break;

                                default:
                                    Console.WriteLine("\nError, try again\n");
                                    continue;
                            }
                            if (buttonExit)
                            {
                                break;
                            }
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("This user doesn't exist, try again");
                        continue;
                    }
                }
                else if (enter == "2")
                {
                    Console.WriteLine("***************** REGISTRATION *************** \nEnter your name, login and password\n Name: ");
                    string? name = Console.ReadLine();
                    Console.WriteLine(" Login: ");
                    string? login = Console.ReadLine();
                    Console.WriteLine(" Password: ");
                    string? password = Console.ReadLine();
                    Console.WriteLine();

                    users.Add(new User(users.Count + 1, name, login, password));
                }
                else if (enter == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("***************** ERROR ***************\n");
                    continue;
                    // Ошибка и переход к началу 
                }
            }

            /*
              User user = new();

            DateTime date = DateTime.Now;
            Income ncjnn = new Income("Work", 15, date);

            user.GetListIncomes().Add(ncjnn);     //добавление элемента списка
            user.GetListIncomes().Remove(ncjnn);  //удаление эелемента списка , когда буду через форейч перебирать с проверкой с ифом

            foreach (var item in user.GetListIncomes())
            {
                Console.WriteLine(item.ToString()); // вывод списка в консоль
            }
             */
        }
    }
}
  