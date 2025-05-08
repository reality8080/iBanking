using iBanking.NewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Repo
{
    public interface IRepoUser
    {
        //CRUD
        public Task<bool> createUser(User u);
        public Task<IEnumerable<User>> readAllUser();
        public Task<User> readUserById(int id);
        public Task<User> readUserByUsername(string username);
        public Task<bool> update(int id,User u);
        public Task<bool> delete(User u);
    }
}
