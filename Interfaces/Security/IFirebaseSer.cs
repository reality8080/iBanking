using iBanking.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Security
{
    public interface IFirebaseSer
    {
        public Task<string> SignUpAsync(string username, string password, string email);
        public Task<string> LogInAsync(string username, string password);
        public Task<string> LogInWithEmailAsync(string email, string password);
        public Task sendEmailVerificationsAsync(string idToken);
        public Task<bool> isEmailVerificationsAsync(string idToken);
        public Task<string> signInWithGGAsync(string idToken);
        public Task<Customer> getCusInfoAsync(string idToken);
    }
}
