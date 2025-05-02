using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iBanking.NewModels
{
    public class Employee : Person
    {
        public decimal Salary { get; set; }
        public int ManagerId { get; set; }
        public Employee()
        {
            this.Salary = 0;
            this.ManagerId = 0;
        }
        public override string ToString()
        {
            return this.Name;
        }
    }
}