using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Models.Cuong
{
    public class Transaction
    {
        private int _payer;
        private int _payee;
        private decimal _total;
        private DateTime _createdAt;
        public Transaction(int payer, int payee, decimal total, DateTime createdAt)
        {
            _payer = payer;
            _payee = payee;
            _total = total;
            _createdAt = createdAt;
        }

        public int Payer { get => _payer; set => _payer = value; }
        public int Payee { get => _payee; set => _payee = value; }
        public decimal Total { get => _total; set => _total = value; }
        public DateTime CreatedAt { get => _createdAt; set => _createdAt = value; }
    }
}
