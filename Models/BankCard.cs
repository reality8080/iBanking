using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Models
{
    public class BankCard
    {
        public BankCard(Guid idAcc, string? typeCard, string? numberCard, DateTime expiredCard, string? statusCard)
        {
            this.idAcc = idAcc;
            this.typeCard = typeCard;
            this.numberCard = numberCard;
            this.expiredCard = expiredCard;
            this.statusCard = statusCard;
        }

        [Key]
        public Guid idCard { get; set; }
        [Required]
        public Guid idAcc { get; set; }
        [Required, MaxLength(100)]
        public string? typeCard { get; set; } = string.Empty;
        [Required, MaxLength(20)]
        public string? numberCard { get; set; } = string.Empty;
        [Required]
        public DateTime expiredCard { get; set; }
        [Required, MaxLength(100)]
        public string? statusCard { get; set; } = string.Empty;

        public BankAcc? BankAccs { get; set; }

    }
}
