using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iBanking.Models
{
    public class Customer
    {
        [Key]
        public Guid idCus { get; set; } = Guid.NewGuid(); // Định nghĩa khóa chính

        [Required, MaxLength(10)]
        public string? cccd { get; set; } = string.Empty;

        [Required,MaxLength(100)]
        public string name { get; set; } = string.Empty;

        [Required]
        public DateTime birth { get; set; }

        [Required, MaxLength(100)]
        public string address { get; set; } = string.Empty;

        [Required,MaxLength(10)]
        public string phone { get; set; } = string.Empty; // Có thể null

        [Required, MaxLength(255),EmailAddress]
        public string email { get; set; } = string.Empty;

        // Quan hệ 1-n với bankAcc
        public ICollection<BankAcc> BankAccs { get; set; } = null!;
    }
}
