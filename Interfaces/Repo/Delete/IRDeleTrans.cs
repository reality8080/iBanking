using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace iBanking.Interfaces.Repo.Delete
{
    public interface IRDeleTrans
    {
        //public Task<bool> Delete(Transaction transaction);
        public Task<bool> DeleteByIdTransaction(Guid idTransaction);

    }
}
