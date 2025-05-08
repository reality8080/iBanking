using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Models.Cuong
{
    public class Employee
    {
        private int _id;
        private string _username;
        private decimal _salary;
        private string _password;
        private string _email;
        private DateTime _createdAt;
        private int? _manager;

        public Employee(int id, string username, string password, decimal salary, string email, DateTime createdAt, int? manager)
        {
            _id = id;
            _username = username;
            _salary = salary;
            _password = password;
            _email = email;
            _createdAt = createdAt;
            this._manager = manager;
        }

        public Employee( string username, string password, string email, DateTime createdAt, int? manager)
        {
            _username = username;
            _password = password;
            _email = email;
            _createdAt = createdAt;
            _manager = manager;
        }

        public int Id { get => _id; set => _id = value; }
        public string Username { get => _username; set => _username = value; }
        public decimal Salary { get => _salary; set => _salary = value; }
        public string Password { get => _password; set => _password = value; }
        public string Email { get => _email; set => _email = value; }
        public DateTime CreatedAt { get => _createdAt; set => _createdAt = value; }
        public int? Manager { get => _manager; set => _manager = value; }
    }
}
