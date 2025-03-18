using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Update
{
    public  interface IUpdateCustomer
    {
        public Task<Boolean> Update(Guid idCus, Customer customer);

    }
}
