using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Models.Cuong
{
    public class Deposit
    {
        private int _idUser;
        private int _cashier;
        private decimal _amount;
        private DateTime _createdAt;
        public Deposit(int idUser, int cashier, decimal amount, DateTime createdAt)
        {
            _idUser = idUser;
            _cashier = cashier;
            _amount = amount;
            _createdAt = createdAt;
        }

        public int IdUser { get => _idUser; set => _idUser = value; }
        public int Cashier { get => _cashier; set => _cashier = value; }
        public decimal Amount { get => _amount; set => _amount = value; }
        public DateTime CreatedAt { get => _createdAt; set => _createdAt = value; }
    }
}
