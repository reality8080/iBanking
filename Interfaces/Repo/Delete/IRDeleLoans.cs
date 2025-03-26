using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Repo.Delete
{
    public interface IRDeleLoans
    {
        public Task<bool> DeleteByIdLoans(Guid idLoan);

    }
}
