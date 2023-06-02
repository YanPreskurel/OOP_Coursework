using MyCourseWork.Services;

namespace MyCourseWork.Entities
{
    public class CheckCorrect
    {
        static public int UserId { get; set; } = 1;
        
        static public bool MonetaryTurnover(string number)
        {
            bool result = double.TryParse(number, out var temp);

            if (result)
            {
                if (temp > 0)
                {
                    return true;
                }
            }
            return false;
        }
     
        static public bool VerifyUserCorrect(List<User> _users, string login, string password) 
        { 
            foreach (var user in _users) 
            {
                if(user.Login == login && user.Password == password)
                {                   
                    UserId = user.Id;

                    return true;
                }
            }
            return false;
        }
        public static bool FindAccount(List<Account> accounts, string name)
        {
            if(accounts.Count == 0)
            {
                return false;
            }
            else
            {
                foreach (var account in accounts)
                {
                    if (account.Name == name)
                    {
                        return true;
                    }             
                }
                return false;
            }
        }

        public static bool FindPayment(List<Payment> payments, string name)
        {
            if (payments.Count == 0)
            {
                return false;
            }
            else
            {
                foreach (var payment in payments)
                {
                    if (payment.Name == name)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        static public bool DeposeRange(Account account, double cost)
        {
            if(account.Cost - account.CurrentCost >= cost)
            {
                return true;
            }
            return false;
        }
    }
}
