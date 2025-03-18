using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Delete
{
    public interface IDeleteCustomer
    {
        public Task<Boolean> Delete(Customer customer);
        public Task<Boolean> DeleteByIdCus(Guid idCus);
    }
}
