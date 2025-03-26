using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace iBanking.Interfaces.Repo.Create
{
    public interface IRCreaTrans
    {
        public Task<bool> AddTransaction(Transactions transaction);
    }
}
