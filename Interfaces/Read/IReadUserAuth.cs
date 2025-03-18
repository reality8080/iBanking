using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Read
{
    public interface IReadUserAuth
    {
        public Task<Boolean> isUserAuth(UserAuth userAuth);
        public Task<Boolean> isUserAuth(Guid idUserAuth);
        public Task<IEnumerable<UserAuth>> GetAll();
        public Task<IEnumerable<UserAuth>> GetByIdUser(Guid idUserAuth);
    }
}
