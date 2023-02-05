using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    public class Wages : Employee
    {
        private double rate;
        private double hours;

        public Wages()
        {
        }

        public Wages(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours) : base(id, name, address, phone, sin, dob, dept)
        {
            this.Rate = rate;
            this.Hours = hours;
        }

        public double Rate { get => rate; set => rate = value; }
        public double Hours { get => hours; set => hours = value; }

        public double getPay()
        {
            double pay = Rate * Hours;
            if (Hours > 40)
            {
                pay += (Hours - 40) * Rate * 0.5;
            }
            return pay;
        }

        public override string ToString()
        {
            return base.ToString() + "Pay: " + getPay();
        }
    }


}
