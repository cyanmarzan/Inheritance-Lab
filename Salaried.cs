using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    public class Salaried : Employee
    {
        private double salary;

        public Salaried()
        {
        }

        public Salaried(string id, string name, string address, string phone, long sin, string dob, string dept, double salary) : base(id, name, address, phone, sin, dob, dept)
        {
            this.Salary = salary;
        }

        public double Salary { get => salary; set => salary = value; }

        public double getPay()
        {
            return salary;
        }

        public override string ToString()
        {
            return base.ToString() + " Salary: " + salary;
        }

    }
}
