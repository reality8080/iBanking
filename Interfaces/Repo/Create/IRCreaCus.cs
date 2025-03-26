using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Repo.Create
{
    public interface IRCreaCus
    {
        public Task<bool> AddCustomer(Customer customer);
    }
}
