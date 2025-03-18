using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Write
{
    public interface ICreateCustomer
    {
        public Task<Boolean> AddCustomer(Customer customer);
    }
}
