using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Repo.Update
{
    public interface IRUpdaUAuth
    {
        public Task<bool> Update(Guid idUserAuth, UserAuth newUserAuth);
        //public Task<bool> UpdateByIdAcc(Guid idAcc, UserAuth newUserAuth);

    }
}
