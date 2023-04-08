using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCourseWork_InTheConsole.Entities
{
    public class CheckCorrect
    {

        static public bool SignIn_SignUp(string? selectNumber)
        {
            if (selectNumber == "1" || selectNumber == "2")
            {
                return true;
            }
            return false;
        }
    }
}
