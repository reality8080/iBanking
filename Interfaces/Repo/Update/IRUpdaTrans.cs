using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace iBanking.Interfaces.Repo.Update
{
    public interface IRUpdaTrans
    {
        public Task<bool> Update(Guid idTrans,Transactions newTransac);
        //public Task<bool> UpdateByIdAcc(Guid idAcc, Transactions newTransac);

    }
}
