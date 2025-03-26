using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Repo.Read
{
    public interface IRReadTrans
    {
        //public Task<bool> Get(Transactions transactions);
        public Task<IEnumerable<Transactions>> GetAll();
        public Task<Transactions?> GetById(Guid idTransaction);
        public Task<IEnumerable<Transactions>> GetByIdAcc(Guid idAcc);
    }
}
