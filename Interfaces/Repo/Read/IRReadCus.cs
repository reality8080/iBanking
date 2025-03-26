using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Repo.Read
{
    public interface IRReadCus
    {
        public Task<IEnumerable<Customer>> GetAll();
        public Task<Customer?> GetById(Guid idCus);
    }
}
