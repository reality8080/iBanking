using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace iBanking.Interfaces.Delete
{
    public interface IDeleteTransaction
    {
        public Task<Boolean> Delete(Transaction transaction);
        public Task<Boolean> DeleteByIdTransaction(Guid idTransaction);

    }
}
