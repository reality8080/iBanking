using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Delete
{
    public interface IDeleteLoans
    {
        public Task<Boolean> Delete(Loans loans);
        public Task<Boolean> DeleteByIdLoans(Guid idLoan);

    }
}
