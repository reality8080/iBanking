using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Read
{
    public interface IReadBankAcc
    {
        public Task<IEnumerable<BankAcc>> GetAll();
        public Task<BankAcc> Get(BankAcc bankAcc);
        public Task<BankAcc> GetByIdAcc(Guid idAcc);

    }
}
