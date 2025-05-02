using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Models.Cuong
{
    public class User
    {
        private int _id;
        private string _username;
        private string _password;
        private Decimal _balance;
        private string _email;
        private DateTime _createdAt;

        public User(int id, string username, string password, decimal balance, string email, DateTime createdAt)
        {
            _id = id;
            _username = username;
            _password = password;
            _balance = balance;
            _email = email;
            _createdAt = createdAt;
        }

        public User( string username, string password, string email)
        {
            _username = username;
            _password = password;
            _email = email;
            _createdAt = DateTime.Now;
        }

        public int Id { get => _id; set => _id = value; }
        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public decimal Balance { get => _balance; set => _balance = value; }
        public string Email { get => _email; set => _email = value; }
        public DateTime CreatedAt { get => _createdAt; set => _createdAt = value; }
    }
}
