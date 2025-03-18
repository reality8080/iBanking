using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Models
{
    public class UserAuth
    {
        [Key]
        public Guid idUserAuth { get; set; } = Guid.NewGuid();
        [Required]
        public Guid idAcc { get; set; }
        [Required, MaxLength(100)]
        public string? username { get; set; } = string.Empty;
        [Required, MaxLength(100)]
        public string? password { get; set; } = string.Empty;
        [Required, MaxLength(100)]
        public string? typeAuth { get; set; } = string.Empty;
        public BankAcc? BankAcc { get; set; } 
    }
}
