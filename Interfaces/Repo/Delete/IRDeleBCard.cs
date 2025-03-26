using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Repo.Delete
{
    public interface IRDeleBCard
    {
        public Task<bool> DeleteByIdCard(Guid idCard);

    }
}
