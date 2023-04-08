using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCourseWork_InTheConsole.Services
{
    public class Notification : ICheque
    {
        public Notification(string name, double cost, DateTime time, string category)
        {
            Name = name;
            Cost = cost;
            Time = time;
            Category = category;
        }
        public Notification() { }
        public string Name { get; set; }
        public double Cost { get; set; }
        public DateTime Time { get; set; } // дата создания, надо будет добавить дату оплаты и считывать время, написать метод для отправки уведомления за какое-то время до оплаты
        public string Category { get; set; }

        public override string ToString()
        {
            return $"********** Notification name: {Name}, notification size: {Cost}, notification time: {Time}, notification category: {Category} **********";
        }

        //public void PayDeleteNotification(Expense _expenses) 
        //{

        //} // удаление уведомления со списка уведомлений и оплата тем самым занесение его в список расходов

        //public void AddPaidNotificationToExpenses(Expense _expenses) { } // метод добавления оплаченного уведомления в список доходов  

    }
}
