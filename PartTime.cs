using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    public class PartTime : Employee
    {
        private double rate;
        private double hours;

        public PartTime()
        {
        }

        public PartTime(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours) : base(id, name, address, phone, sin, dob, dept)
        {
            this.Rate = rate;
            this.Hours = hours;
        }

        public double Rate { get => rate; set => rate = value; }
        public double Hours { get => hours; set => hours = value; }

        public double getPay()
        {
            return rate * hours;
        }

        public override string ToString()
        {
            return base.ToString() + "Rate: " + rate + " Hours: " + hours;
        }
    }
}
