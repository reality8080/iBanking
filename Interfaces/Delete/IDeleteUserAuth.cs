using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Delete
{
    public interface IDeleteUserAuth
    {
        public Task<Boolean> Delete(UserAuth userAuth);
        public Task<Boolean> DeleteByIdUserAuth(Guid idUserAuth);

    }
}
