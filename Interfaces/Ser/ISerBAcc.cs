using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Ser
{
    public interface ISerBAcc
    {
        public Task<bool> CreaBAcc(BankAcc ba);
    }
}
