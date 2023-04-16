using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCourseWork_InTheConsole.Services
{
    public class Expense : ICheque
    {
        public Expense(string? name, double cost, DateTime time, string? category)
        {
            Name = name;
            Cost = cost;
            Time = time;
            Category = category;
        }
        public Expense() { }

        public string Name { get; set; }
        public double Cost { get; set; }
        public DateTime Time { get; set; }
        public string Category { get; set; }

        public override string ToString()
        {
            return $"********** Expense name: {Name}, expense size: {Cost}, expense time: {Time}, expense category: {Category} **********";
        }
    }
}
