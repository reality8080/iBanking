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
        [Key]
        public Guid idTransaction { get; set; } = Guid.NewGuid();
        [Required]
        public Guid idAcc { get; set; }
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
