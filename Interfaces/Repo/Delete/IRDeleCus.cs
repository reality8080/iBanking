using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Repo.Delete
{
    public interface IRDeleCus
    {
        public Task<bool> Delete(Customer customer);
        public Task<bool> DeleteByIdCus(Guid idCus);
    }
}
