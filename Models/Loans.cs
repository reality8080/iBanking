using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iBanking.Models
{
    public class Loans
    {
        public Loans(Guid idAcc, decimal money, decimal percentage, int term, string? status)
        {
            this.idAcc = idAcc;
            this.money = money;
            this.percentage = percentage;
            this.term = term;
            this.status = status;
        }

        [Key]
        public Guid idLoan { get; set; } = Guid.NewGuid(); // Khóa chính

        [Required]
        public Guid idAcc { get; set; }

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal money { get; set; }

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal percentage { get; set; }

        [Required]
        public int term { get; set; }

        [Required, MaxLength(100)]
        public string? status { get; set; } = string.Empty;

        // Quan hệ với bankAcc
        public BankAcc? BankAcc { get; set; }
    }
}
