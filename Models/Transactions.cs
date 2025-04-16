using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Models
{
    public class Transactions
    {
        public Transactions(string idAcc, string? typeTrans, double money, DateTime time, string? status)
        {
            this.idAcc = idAcc;
            this.typeTrans = typeTrans;
            this.money = money;
            this.time = time;
            this.status = status;
        }

        [Key]
        public string idTransaction { get; set; } = String.Empty;
        [Required]
        public string idAcc { get; set; }
        [Required, MaxLength(100)]
        public string? typeTrans { get; set; } = string.Empty;
        [Required]
        public double money { get; set; }
        [Required]
        public DateTime time { get; set; }
        [Required, MaxLength(100)]
        public string? status { get; set; } = string.Empty;

        public BankAcc BankAcc { get; set; } = null!;
    }
}
