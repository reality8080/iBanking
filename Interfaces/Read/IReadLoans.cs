using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Read
{
    public interface IReadLoans
    {
        public Task<Boolean> Get(Loans loans);
        public Task<IEnumerable<Loans>> GetAll();
        public Task<IEnumerable<Loans>> GetById(Guid idLoans);
        public Task<IEnumerable<Loans>> GetByIdAcc(Guid idAcc);
    }
}
