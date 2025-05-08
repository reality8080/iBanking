using iBanking.Models.Cuong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Repo
{
    public interface IRepoEmployee
    {
        public Task<bool> createEmployee(Employee e);
        public Task<IEnumerable<Employee>> readAllEmployee();
        public Task<Employee> readEmployeeById(int id);
        public Task<Employee> readEmployeeByEmployeename(string name, string email, int? idManager);
        public Task<bool> update(int id, Employee e);
        public Task<bool> delete(Employee e);
    }
}
