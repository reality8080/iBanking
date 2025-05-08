using iBanking.NewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Ser
{
    public interface ISerUser
    {
        public Task<bool> createUser(string username, string password, string email);
        public Task<User?> CheckEmailAndUserName(string username, string email);
        public Task<bool> CheckPass(string username,string password);
        public string randomNumBAcc();
    }
}
