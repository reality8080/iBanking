using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Repo.Update
{
    public  interface IRUpdaCus
    {
        public Task<bool> Update(Guid idCus, Customer customer);

    }
}
