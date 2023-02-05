using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;

namespace Lab_2
{
    public class Driver
    {
        static List<Employee> employees = new List<Employee>();
        static List<Employee> salaryEmployee = new List<Employee>();
        static List<Employee> wageEmployee = new List<Employee>();
        static List<Employee> partTimeEmployee = new List<Employee>();

        static void Main(string[] args)
        {
            GetEmployeeFromFile();
            double averagePay = GetAverageWeeklyPay();
            Console.WriteLine("The average weekly pay is: " + averagePay);
            GetHighestWage();
            GetLowestSalary();
            GetPercentageCategory();
            Console.ReadKey();
        }

        public static void GetEmployeeFromFile()
        {
            string path = "C:\\assignment\\textfiles\\employees.txt";
            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                string[] fields = line.Split(':');
                string id = fields[0];
                string name = fields[1];
                string address = fields[2];
                string phone = fields[3];
                long sin = long.Parse(fields[4]);
                string dob = fields[5];
                string dept = fields[6];

                Employee employee = new Employee(id, name, address, phone, sin, dob, dept);
                employees.Add(employee);

                if (id.StartsWith("0") || id.StartsWith("1") || id.StartsWith("2") || id.StartsWith("3") || id.StartsWith("4"))
                {
                    salaryEmployee.Add(employee);
                    double salary = double.Parse(fields[7]);
                    employees.Add(new Salaried(id, name, address, phone, sin, dob, dept, salary));
                }
                else if (id.StartsWith("5") || id.StartsWith("6") || id.StartsWith("7"))
                {
                    wageEmployee.Add(employee);
                    double rate = double.Parse(fields[7]);
                    double hours = double.Parse(fields[8]);
                    employees.Add(new Wages(id, name, address, phone, sin, dob, dept, rate, hours));
                }
                else if ((id.StartsWith("8") || id.StartsWith("9")))
                {
                    partTimeEmployee.Add(employee);
                    double rate = double.Parse(fields[7]);
                    double hours = double.Parse(fields[8]);
                    employees.Add(new PartTime(id, name, address, phone, sin, dob, dept, rate, hours));
                }
            }
        }

        public static double GetAverageWeeklyPay()
        {
            double salaryPay = 0;
            double wagePay = 0;
            double ptPay = 0;
            double averagePay = 0;

            foreach (Employee employee in employees)
            {
                if (employee is Salaried)
                {
                    salaryPay += ((Salaried)employee).getPay();
                }
                else if (employee is Wages)
                {
                    wagePay += ((Wages)employee).getPay();
                }
                else if (employee is PartTime)
                {
                    ptPay += ((PartTime)employee).getPay();
                }
            }

            double totalPay = salaryPay + wagePay + ptPay;
            averagePay = totalPay / 9;
            return averagePay ;
        }

        public static void GetHighestWage()
        {
            double highestWage = 0.00;
            string highestWageEmployee = "";

            foreach (Employee employee in employees)
            {
                if (employee is Wages)
                {
                    Wages wageEmployee = (Wages)employee;
                    if (wageEmployee.getPay() > highestWage)
                    {
                        highestWage = wageEmployee.getPay();
                        highestWageEmployee = employee.Name;
                    }
                }
            }

            Console.WriteLine("The wage employee with the highest pay is: " + highestWageEmployee + ", with a wage of: " + highestWage + "$");
        }
        public static void GetLowestSalary()
        {
            double lowestSalary = double.MaxValue;
            string lowestSalaryEmployee = "";

            foreach (Employee employee in employees)
            {
                if (employee is Salaried)
                {
                    Salaried salaryEmployee = (Salaried)employee;
                    if (salaryEmployee.getPay() < lowestSalary)
                    {
                        lowestSalary = salaryEmployee.getPay();
                        lowestSalaryEmployee = employee.Name;
                    }
                }
            }

            Console.WriteLine("The salary employee with the lowest pay is: " + lowestSalaryEmployee + ", with a wage of: " + lowestSalary + "$");

        }
        public static void GetPercentageCategory()
        {
            int salariedCount = salaryEmployee.Count;
            int wageCount = wageEmployee.Count;
            int partTimeCount = partTimeEmployee.Count;
            int totalCount = salariedCount + wageCount + partTimeCount;

            double salariedPercent = (double)salariedCount / totalCount * 100;
            double wagePercent = (double)wageCount / totalCount * 100;
            double partTimePercent = (double)partTimeCount / totalCount * 100;

            Console.WriteLine("Percentage of salaried employees: " + salariedPercent + "%");
            Console.WriteLine("Percentage of wage employees: " + wagePercent + "%");
            Console.WriteLine("Percentage of part-time employees: " + partTimePercent + "%");
        }
    }
}
