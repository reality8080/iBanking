using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Delete
{
    public interface IDeleteBankCard
    {
        public Task<Boolean> Delete(BankCard bankCard);
        public Task<Boolean> DeleteByIdCard(Guid idCard);

    }
}
