using iBanking.Interfaces.Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iBanking.Models
{
    public class BankAcc
    {
        //private readonly IRepoBAcc _rBAcc;
        // khoi tao ban dau
        public BankAcc(Guid idCus, string typeAcc, string accNum)
        {
            this.idCus = idCus;
            this.typeAcc = typeAcc;
            //this._rBAcc = _repoBAcc ?? throw new ArgumentNullException(nameof(_repoBAcc));
            this.accNum = accNum;
        }
        //Cap nhat du lieu
        //public BankAcc(string accNum, string typeAcc, decimal currBalance, DateTime openDate)
        //{
        //    this.accNum = accNum;
        //    this.typeAcc = typeAcc;
        //    this.currBalance = currBalance;
        //    this.openDate = openDate;
        //}

        [Key]
        public Guid idAcc { get; set; } = Guid.NewGuid(); // Khóa chính

        [Required]
        public Guid idCus { get; set; }

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
        public ICollection<UserAuth>? UserAuths { get; set; }
    }
}
