using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Repo.Create
{
    public interface IRCreaBAcc
    {
        public Task<bool> AddBankAcc(BankAcc bankAcc);
    }
}
