using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCourseWork.Interfaces;

namespace MyCourseWork.Services
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
            return $"********** Account size: {CurrentCost}/{Cost}**********\n********** Account time: {Time}**********\n********** Account category: {Category} **********";
        }
    }
}
