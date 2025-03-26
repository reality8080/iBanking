using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Repo.Update
{
    public interface IRUpdaBCard
    {
        public Task<bool> Update(Guid idCard,BankCard newBankCard);
        public Task<bool> UpdateByIdAcc(Guid idAcc, BankCard newBankCard);
    }
}
