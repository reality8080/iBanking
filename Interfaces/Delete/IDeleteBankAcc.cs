using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Delete
{
    public interface IDeleteBankAcc
    {
        public Task<Boolean> Delete(BankAcc bankAcc);
        public Task<Boolean> DeleteByIdAcc(Guid idAcc);
    }
}
