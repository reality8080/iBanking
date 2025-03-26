using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Repo.Read
{
    public interface IRReadLoans
    {
        public Task<IEnumerable<Loans>> GetAll();
        public Task<Loans?> GetById(Guid idLoans);
        public Task<IEnumerable<Loans>> GetByIdAcc(Guid idAcc);
    }
}
