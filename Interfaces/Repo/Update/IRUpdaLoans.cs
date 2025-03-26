using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Repo.Update
{
    public interface IRUpdaLoans
    {
        public Task<bool> Update(Guid idLoans,Loans newLoans);
        //public Task<bool> UpdateByIdAcc(Guid idAcc, Loans newLoans);
    }
}
