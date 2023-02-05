using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    public class Employee
    {
        private string id;
        private string name;
        private string address;
        private string phone;
        private long sin;
        private string dob;
        private string dept;

        public Employee()
        {
        }

        public Employee(string id, string name, string address, string phone, long sin, string dob, string dept)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.Phone = phone;
            this.Sin = sin;
            this.Dob = dob;
            this.Dept = dept;
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }
        public long Sin { get => sin; set => sin = value; }
        public string Dob { get => dob; set => dob = value; }
        public string Dept { get => dept; set => dept = value; }

        public override string ToString()
        {
            return ("Id: " + id + " Name: " + name + " Address: " + address + " Phone: " + phone + " Sin: " + sin + " DOB: " + dob + " Department: " + dept);
        }

    }
}
