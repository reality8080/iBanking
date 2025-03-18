using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Update
{
    public interface IUpdateBankAcc
    {
        public Task<Boolean> Update(Guid idCus,BankAcc newBankAcc);
        public Task<Boolean> UpdateByIdCus(Guid idAcc, BankAcc newBankAcc);
    }
}
