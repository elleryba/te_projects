using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechElevator.Classes
{
    public class Company
    {
        public string Name { get; set; }
        public int NumberOfEmployees { get; set; }
        public decimal Revenue { get; set; }
        public decimal Expenses { get; set; }

        public string GetCompanySize()
        {
            if (this.NumberOfEmployees < 50)
            {
                return "small";
            }
            else if (this.NumberOfEmployees >= 50 && this.NumberOfEmployees <= 250)
            {
                return "medium";
            }
            else
            {
                return "large";
            }
        }

        public decimal GetProfit()
        {
            return this.Revenue - this.Expenses;
        }
    }
}
