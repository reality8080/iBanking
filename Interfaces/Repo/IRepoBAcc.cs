using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Repo
{
    public interface IRepoBAcc
    {
        public Task<bool> AddBankAcc(BankAcc bankAcc);
        public Task<bool> DeleteByIdAcc(Guid idAcc);
        public Task<IEnumerable<BankAcc>> GetAll();
        public Task<BankAcc?> GetByIdAcc(Guid idAcc);
        public Task<bool> Update(Guid idBAcc, BankAcc newBankAcc);
        public Task<bool> UpdateByIdCus(Guid idCus, BankAcc newBankAcc);
    }
}
