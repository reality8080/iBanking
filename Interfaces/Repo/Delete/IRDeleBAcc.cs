using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Repo.Delete
{
    public interface IRDeleBAcc
    {
        public Task<bool> DeleteByIdAcc(Guid idAcc);
    }
}
