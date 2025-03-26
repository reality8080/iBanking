using iBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Interfaces.Repo.Create
{
    public interface IRCreaLoans
    {
        public Task<bool> AddLoans(Loans loans);
    }
}
