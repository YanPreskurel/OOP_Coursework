using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCourseWork.Interfaces
{
    public interface ICheque
    {
        string Name { get; set; }
        double Cost { get; set; }
        DateTime Time { get; set; }
    }
}
