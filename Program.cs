using MyCourseWork_InTheConsole.Entities;
using MyCourseWork_InTheConsole.Services;


namespace MyCourseWork_InTheConsole
{
    public class Program
    {
        public static void Main()
        {
            List<User> users = new List<User>();
            DateTime dateTime = DateTime.Now;

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
                                              "6. Просмотр баланса кошелька\n" +
                                              "7. Просмотр кол-ва потраченных денег\n" +
                                              "8. Конвертация баланса кошелька\n" +
                                              "9. Просмотр списка доходов\n" +
                                              "10. Просмотр списка расходов\n" +
                                              "11. Просмотр списка счетов\n" +
                                              "12. Просмотр уведомлений\n" +
                                              "13. Пополнить счёт\n" +
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

                                        users[userId - 1].GetListIncomes().Add(new Income(name1, cost1, dateTime));
                                        users[userId - 1].wallet.WalletBalance += cost1;

                                        Console.WriteLine("Your income has been successfully added\n");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error, try again\n");
                                        break;
                                    }
                                    
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

                                        if (cost2 > users[userId - 1].wallet.WalletBalance)
                                        {
                                            Console.WriteLine("Error, try again\n");
                                            break;
                                        }

                                        users[userId - 1].GetListExpenses().Add(new Expense(name2, cost2, dateTime, category2));
                                        users[userId - 1].wallet.WalletBalance -= cost2;

                                        Console.WriteLine("Your expense has been successfully added\n");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error, try again\n");
                                        break;
                                    }

                                    // добавление расхода реализовано

                                case "3":
                                    break;
                                case "4":
                                    break;
                                case "5":
                                    break;
                                case "6":
                                    break;
                                case "7":
                                    break;
                                case "8":
                                    break;
                                case "9":
                                    break;
                                case "10":
                                    break;
                                case "11":
                                    break;
                                case "12":
                                    break;
                                case "13":
                                    break;
                                case "14": // выход на начальную страницу сделан
                                    buttonExit = true;
                                    break;

                                default:
                                    Console.WriteLine("Error, try again\n");
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
  