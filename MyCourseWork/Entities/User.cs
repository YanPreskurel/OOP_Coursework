using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCourseWork.Services;
using Newtonsoft.Json;

namespace MyCourseWork.Entities
{
    public class User
    {
        public User(int id, string login, string password)
        {
            Id = id;
            Login = login;
            Password = password;
        }
        public User()
        {
        }

        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "Login")]
        public string Login { get; set; }

        [JsonProperty(PropertyName = "Password")]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "wallet")]
        public Wallet wallet = new();

        [JsonProperty(PropertyName = "incomes")]
        private List<Income> incomes = new();
        [JsonProperty(PropertyName = "expenses")]
        private List<Expense> expenses = new();
        [JsonProperty(PropertyName = "accounts")]
        private List<Account> accounts = new();
        [JsonProperty(PropertyName = "payments")]
        private List<Payment> payments = new();


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
        public List<Payment> GetListPayments()
        {
            return payments;
        }
        public void PayDeletePayment(Payment payment)
        {
            payments.Remove(payment);
        }
        public void PayDeleteAccount(Account account)
        {
            accounts.Remove(account);
        }

    }
}
