using iBanking.Data;
using iBanking.Interfaces.Read;
using iBanking.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Repository.Read
{
    public class RepoReadCus : IReadCustomer
    {
        private readonly iBankContext _context;
        private readonly ILogger<RepoReadCus> _logger;
        public RepoReadCus(iBankContext context,ILogger<RepoReadCus> logger)
        {
            _context = context ??throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            try
            {
                var cuss = await _context.Customers.AsNoTracking().ToListAsync();
                _logger.LogInformation("Get all customers");
                return cuss;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Enumerable.Empty<Customer>();
            }
        }

        public async Task<Customer?> GetById(Guid idCus)
        {
            if(idCus == Guid.Empty)
            {
                _logger.LogError("IdCus is empty");
                return null;
            }
            try
            {
                var cus = await _context.Customers.AsNoTracking()
                    .FirstOrDefaultAsync(s => s.idCus == idCus);
                if (cus == null)
                {
                    _logger.LogError("Customer not found");
                    return null;
                }
                else
                {
                    _logger.LogInformation("Customer found");
                }
                return cus;
            }
            catch(Exception ex) 
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
    }
}
