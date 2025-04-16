using iBanking.Interfaces.Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iBanking.Models
{
    public class BankAcc
    {
        public BankAcc(string idCus, string typeAcc, string accNum)
        {
            this.idCus = idCus;
            this.typeAcc = typeAcc;
            this.accNum = accNum;
        }


        [Key]
        public string idAcc { get; set; } = String.Empty; // Khóa chính

        [Required]
        public string idCus { get; set; }

        [Required, MaxLength(20)]
        public string accNum { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string? typeAcc { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal currBalance { get; set; }

        [Required]
        public DateTime openDate { get; set; } = DateTime.UtcNow;

        // Quan hệ với Customer
        public Customer? Customer { get; set; }

        // Quan hệ với các bảng khác
        public ICollection<Transactions>? Transactions { get; set; }
        public ICollection<BankCard>? BankCards { get; set; }
        public ICollection<Loans>? Loans { get; set; }
    }
}
