using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Repo
{
    public interface IRepoUserAuth
    {
        public Task<bool> AddUA(UserAuth userAuth);
        public Task<bool> Delete(UserAuth userAuth);
        public Task<bool> DeleteByIdUserAuth(Guid idUserAuth);
        public Task<IEnumerable<UserAuth>> GetByIdAcc(Guid idAcc);
        public Task<IEnumerable<UserAuth>> GetAll();
        public Task<UserAuth?> GetByIdUser(Guid idUserAuth);
        public Task<bool> Update(Guid idUserAuth, UserAuth newUserAuth);

    }
}
