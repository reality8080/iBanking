using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iBanking.NewModels
{
    public class Deposit
    {
        public int User { get; set; }
        public int Cashier { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Total { get; set; }
        public Deposit()
        {
            this.User = 0;
            this.Cashier = 0;
            this.Total = 0;
            this.CreatedAt = DateTime.Now;
        }
    }
}