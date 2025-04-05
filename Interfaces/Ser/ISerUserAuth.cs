using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Ser
{
    public interface ISerUserAuth
    {
        public string randomNumBAcc();
        public Task<bool> addUaBaCr(string username,string password, string typeAuth);
        public Task<bool> CheckPass(string username, string password);
    }
}
