using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCourseWork_InTheConsole.Services
{
    public class Income : ICheque
    {
        public Income(string? name, double cost, DateTime time)
        {
            Name = name;
            Cost = cost;
            Time = time;
        }

        public Income() { }
        public string Name { get; set; }
        public double Cost { get; set; }
        public DateTime Time { get; set; }

        public override string ToString()
        {
            return $"********** Income name: {Name}, income size: {Cost}, income time: {Time} **********";
        }
    }
}
