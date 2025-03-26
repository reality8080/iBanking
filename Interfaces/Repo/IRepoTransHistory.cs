using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Repo
{
    public interface IRepoTransHistory
    {
        public Task<bool> AddTransaction(Transactions transaction);
        public Task<bool> DeleteByIdTransaction(Guid idTransaction);
        public Task<IEnumerable<Transactions>> GetAll();
        public Task<Transactions?> GetById(Guid idTransaction);
        public Task<IEnumerable<Transactions>> GetByIdAcc(Guid idAcc);
        public Task<bool> Update(Guid idTrans, Transactions newTransac);

    }
}
