using MyCourseWork_InTheConsole.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCourseWork_InTheConsole.Entities
{
    public class CheckCorrect
    {
        static public int userId;
        
        static public bool MonetaryTurnover(string? number)
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
        static public void SetUserId(int _userId)
        {
            userId = _userId;
        }
     
        static public bool VerifyUserCorrect(List<User> _users, string? login, string? password) 
        { 
            foreach (var user in _users) 
            {
                if(user.Login == login && user.Password == password)
                {
                    userId = 1;
                    SetUserId(user.Id);
                    return true;
                }
            }
            return false;
        }
        public static bool FindAccount(List<Account> accounts, string? name)
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

        public static bool FindNotification(List<Notification> notifications, string? name)
        {
            if (notifications.Count == 0)
            {
                return false;
            }
            else
            {
                foreach (var notification in notifications)
                {
                    if (notification.Name == name)
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
