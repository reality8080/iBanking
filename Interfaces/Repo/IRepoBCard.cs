using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Repo
{
    public interface IRepoBCard
    {
        public Task<bool> AddBankCard(BankCard bankCard);
        public Task<bool> DeleteByIdCard(Guid idCard);
        public Task<IEnumerable<BankCard>> GetAll();
        public Task<BankCard?> GetByIdCard(Guid idCard);
        public Task<IEnumerable<BankCard>> GetByIdAcc(Guid idAcc);
        public Task<bool> Update(Guid idCard, BankCard newBankCard);
        public Task<bool> UpdateByIdAcc(Guid idAcc, BankCard newBankCard);
    }
}
