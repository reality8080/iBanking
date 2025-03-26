using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Repo.Update
{
    public interface IRUpdaBAcc
    {
        public Task<bool> Update(Guid idBAcc, BankAcc newBankAcc);
        public Task<bool> UpdateByIdCus(Guid idCus, BankAcc newBankAcc);
    }
}
