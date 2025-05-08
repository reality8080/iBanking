using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace iBanking.NewModels
{
    public class Employee : Person
    {
        public decimal Salary { get; set; }
        public int? ManagerId { get; set; }
        public Employee()
        {
            this.Salary = 0;
            this.ManagerId = 0;
        }

        public Employee(int id, string username, string password, decimal salary, string email, DateTime createdAt, int? manager):
            base( id,  username,  password,   email,  createdAt)
        {
            //_id = id;
            //_username = username;
            this.Salary = salary;
            //_password = password;
            //_email = email;
            //_createdAt = createdAt;
            this.ManagerId = manager;
        }

        public Employee(string username, string password, string email, DateTime createdAt, int? manager) : base( username, password, email)
        {
            //_username = username;
            //_password = password;
            //_email = email;
            //_createdAt = createdAt;
            this.ManagerId= manager;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}