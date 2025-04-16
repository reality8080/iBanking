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

        public Customer(string email, string username, string password, string? cccd, string name, DateTime birth, string address, string phone)
        {
            this.username = username;
            this.email = email;
            this.password = password;
            this.cccd = cccd;
            this.name = name;
            this.birth = birth;
            this.address = address;
            this.phone = phone;
        }

        public Customer(string email,string username,string password)
        {
            this.email = email;
            this.username = username;
            this.password = password;
        }

        [Key]
        public string idCus { get; set; } = string.Empty; // Định nghĩa khóa chính

        [MaxLength(10)]
        public string? cccd { get; set; } = string.Empty;

        [MaxLength(100)]
        public string username { get; set; }=string.Empty;

        [MaxLength(100)]
        public string password {  get; set; } = string.Empty;

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
