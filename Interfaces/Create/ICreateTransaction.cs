using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace iBanking.Interfaces.Write
{
    public interface ICreateTransaction
    {
        public Task<Boolean> AddTransaction(Transaction transaction);
    }
}
