using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCourseWork_InTheConsole.Services
{
    public class Account : ICheque
    {
        public Account(string name, double cost, DateTime time, string category)
        {
            Name = name;
            Cost = cost;
            Time = time;
            Category = category;
        }

        public Account() { }
        public string Name { get; set; }
        public double Cost { get; set; }
        public double CurrentCost { get; set; }
        public DateTime Time { get; set; } // время создания счета 
        public string Category { get; set; }

        public override string ToString()
        {
            return $"********** Account name: {Name}, account size: {CurrentCost}/{Cost}, account time: {Time}, account category: {Category} **********";
        }
    }
}
