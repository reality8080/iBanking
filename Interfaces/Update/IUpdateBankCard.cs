using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Update
{
    public interface IUpdateBankCard
    {
        public Task<Boolean> Update(Guid idCard,BankCard newBankCard);
        public Task<Boolean> UpdateByIdAcc(Guid idAcc, BankCard newBankCard);
    }
}
