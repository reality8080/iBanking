using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace iBanking.Interfaces.Update
{
    public interface IUpdateTransaction
    {
        public Task<Boolean> Update(Guid idTrans,Transaction newTransac);
        public Task<Boolean> UpdateByIdAcc(Guid idAcc, Transaction newTransac);

    }
}
