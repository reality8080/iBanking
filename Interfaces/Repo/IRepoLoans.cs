using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Repo
{
    public interface IRepoLoans
    {
        public Task<bool> AddLoans(Loans loans);
        public Task<bool> DeleteByIdLoans(Guid idLoan);
        public Task<IEnumerable<Loans>> GetAll();
        public Task<Loans?> GetById(Guid idLoans);
        public Task<IEnumerable<Loans>> GetByIdAcc(Guid idAcc);
        public Task<bool> Update(Guid idLoans, Loans newLoans);
    }
}
