using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Repo
{
    public interface IRepoCus
    {
        public Task<bool> AddCustomer(Customer customer);
        public Task<bool> Delete(Customer customer);
        public Task<bool> DeleteByIdCus(Guid idCus);
        public Task<IEnumerable<Customer>> GetAll();
        public Task<Customer?> GetById(Guid idCus);
        public Task<bool> Update(Guid idCus, Customer customer);
    }
}
