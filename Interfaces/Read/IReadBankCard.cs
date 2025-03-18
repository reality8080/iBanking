using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Read
{
    public interface IReadBankCard
    {
        public Task<IEnumerable<BankCard>> Get(BankCard bankCard);
        public Task<IEnumerable<BankCard>> GetAll();
        public Task<Boolean> GetByIdCard(Guid idCard);
        public Task<IEnumerable<BankCard>> GetByIdAcc(Guid idAcc);
    }
}
