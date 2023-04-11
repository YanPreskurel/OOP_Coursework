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
        //static public bool SignIn_SignUp(string? selectNumber)
        //{
        //    if (selectNumber == "1" || selectNumber == "2")
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //static public bool MenuNumber(string? selectNumber)
        //{
        //    if (selectNumber == "1" || selectNumber == "2" || selectNumber == "3" || selectNumber == "4" || selectNumber == "5" || selectNumber == "6" || selectNumber == "7" || selectNumber == "8" || selectNumber == "9" || selectNumber == "10" || selectNumber == "11" || selectNumber == "12" || selectNumber == "13" || selectNumber == "14")
        //    {
        //        return true;
        //    }
        //    return false;
        //}

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
    }
}
