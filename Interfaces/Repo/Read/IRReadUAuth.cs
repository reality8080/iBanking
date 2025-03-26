using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Repo.Read
{
    public interface IRReadUAuth
    {
        //public Task<bool> isUserAuth(UserAuth userAuth);
        public Task<IEnumerable<UserAuth>> GetByIdAcc(Guid idAcc);
        public Task<IEnumerable<UserAuth>> GetAll();
        public Task<UserAuth?> GetByIdUser(Guid idUserAuth);
    }
}
