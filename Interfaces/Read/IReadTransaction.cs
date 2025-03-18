using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Read
{
    public interface IReadTransaction
    {
        public Task<Boolean> Get(Transactions transactions);
        public Task<IEnumerable<Transactions>> GetAll();
        public Task<IEnumerable<Transactions>> GetById(Guid idTransaction);
        public Task<IEnumerable<Transactions>> GetByIdAcc(Guid idAcc);
    }
}
