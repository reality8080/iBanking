using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Update
{
    public interface IUpdateUserAuth
    {
        public Task<Boolean> Update(Guid idUserAuth, UserAuth newUserAuth);
        public Task<Boolean> UpdateByIdAcc(Guid idAcc, UserAuth newUserAuth);

    }
}
