using MyCourseWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCourseWork.Services
{
    public class Payment : ICheque
    {
        public Payment(string name, double cost, DateTime time, string category)
        {
            Name = name;
            Cost = cost;
            Time = time;
            Category = category;
        }
        public Payment() { }
        public string Name { get; set; }
        public double Cost { get; set; }
        public DateTime Time { get; set; }
        public string Category { get; set; }

        public override string ToString()
        {
            return $"********** Payment name: {Name}, size: {Cost:0.##}, time: {Time}, category: {Category} **********";
        }
    }
}
