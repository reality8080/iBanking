using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Update
{
    public interface IUpdateLoans
    {
        public Task<Boolean> Update(Guid idLoans,Loans newLoans);
        public Task<Boolean> UpdateByIdAcc(Guid idAcc, Loans newLoans);
    }
}
