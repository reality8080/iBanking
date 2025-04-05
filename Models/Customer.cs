using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iBanking.Models
{
    public class Customer
    {
        public Customer()
        {
        }

        //public Customer(string? cccd, string name, DateTime birth, string address, string phone, string email)
        //{
        //    this.cccd = cccd;
        //    this.name = name;
        //    this.birth = birth;
        //    this.address = address;
        //    this.phone = phone;
        //    this.email = email;
        //}

        [Key]
        public Guid idCus { get; set; } = Guid.NewGuid(); // Định nghĩa khóa chính

        [MaxLength(10)]
        public string? cccd { get; set; } = string.Empty;

        [MaxLength(100)]
        public string name { get; set; } = string.Empty;

        public DateTime birth { get; set; }

        [MaxLength(100)]
        public string address { get; set; } = string.Empty;

        [MaxLength(10)]
        public string phone { get; set; } = string.Empty; // Có thể null

        [MaxLength(255),EmailAddress]
        public string email { get; set; } = string.Empty;

        // Quan hệ 1-n với bankAcc
        public ICollection<BankAcc> BankAccs { get; set; } = null!;
    }
}
