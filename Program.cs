using MyCourseWork_InTheConsole.Entities;
using MyCourseWork_InTheConsole.Services;


namespace MyCourseWork_InTheConsole
{
    public class Program
    {
        public static void Main()
        {
            //while(здесь булевая переменная)
            //{
            //   здесь работающая программа
            //}

            Console.WriteLine("Choose:\n1. SIGN IN\n2. SIGN UP");

            string? enter = Console.ReadLine();
            // Console.Clear();

            if (CheckCorrect.SignIn_SignUp(enter) && enter == "1")
            {
                Console.WriteLine("Вход");
                // Вход
            }
            else if (CheckCorrect.SignIn_SignUp(enter) && enter == "2")
            {
                Console.WriteLine("Регистрация");
                // Регистрация 
            }
            else
            {
                Console.WriteLine("Ошибка");
                // Ошибка и переход к началу 
            }

            
            User user = new();

            DateTime date = DateTime.Now;
            Income ncjnn = new Income("Work", 15, date);

            user.GetListIncomes().Add(ncjnn);     //добавление элемента списка
            user.GetListIncomes().Remove(ncjnn);  //удаление эелемента списка , когда буду через форейч перебирать с проверкой с ифом

            foreach (var item in user.GetListIncomes())
            {
                Console.WriteLine(item.ToString()); // вывод списка в консоль
            }

        }
    }
}