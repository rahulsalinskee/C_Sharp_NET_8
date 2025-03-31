using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S
{
    //Violating Single Responsibility Principle
    public class ViolatingSingleResponsibilityPrinciple
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }

        // This class has too many responsibilities

        public void SaveToDatabase()
        {
            // Code to save employee to database
            Console.WriteLine($"Saving {Name} to database");
        }

        public void GeneratePayslip()
        {
            // Code to generate a payslip
            Console.WriteLine($"Generating payslip for {Name}");
        }

        public void CalculateTax()
        {
            // Code to calculate tax
            Console.WriteLine($"Calculating tax for {Name}");
        }
    }
}
