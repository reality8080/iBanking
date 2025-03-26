using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Repo.Read
{
    public interface IRReadBCard
    {
        public Task<IEnumerable<BankCard>> GetAll();
        public Task<BankCard?> GetByIdCard(Guid idCard);
        public Task<IEnumerable<BankCard>> GetByIdAcc(Guid idAcc);
    }
}
