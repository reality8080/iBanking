using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Repo.Delete
{
    public interface IRDeleUAuth
    {
        public Task<bool> Delete(UserAuth userAuth);
        public Task<bool> DeleteByIdUserAuth(Guid idUserAuth);

    }
}
