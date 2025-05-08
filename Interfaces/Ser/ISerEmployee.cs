using iBanking.Models.Cuong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Ser
{
    public interface ISerEmployee
    {
        public Task<bool> createEm(string username, string password, string email, int? manager);
        public Task<Employee?> CheckEmailAndEmployeeName(string username, string email,int? idManager);
        public Task<bool> CheckPass(string id, string password);
        public string randomNumBAcc();
    }
}
