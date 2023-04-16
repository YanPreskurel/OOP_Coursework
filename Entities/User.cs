using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCourseWork_InTheConsole.Services;

namespace MyCourseWork_InTheConsole.Entities
{
    public class User
    {
        public User(int id, string? name, string? login, string? password)
        {
            Id = id;
            Name = name;
            Login = login;
            Password = password;
        }
        public User()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public Wallet wallet = new();


        private List<Income> incomes = new();

        private List<Expense> expenses = new();

        private List<Account> accounts = new();

        private List<Notification> notifications = new();


        public List<Income> GetListIncomes()
        {
            return incomes;
        }

        public List<Expense> GetListExpenses()
        {
            return expenses;
        }
        public List<Account> GetListAccounts()
        {
            return accounts;
        }
        public List<Notification> GetListNotifications()
        {
            return notifications;
        }
        public void PayDeleteNotification(Notification notification)
        {
            notifications.Remove(notification);
        }
    }
}
