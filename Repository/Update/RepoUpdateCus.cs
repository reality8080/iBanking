using iBanking.Data;
using iBanking.Interfaces.Update;
using iBanking.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Repository.Update
{
    public class RepoUpdateCus : IUpdateCustomer
    {
        private readonly iBankContext _iBankContext;
        private readonly ILogger<RepoUpdateCus> _logger;
        public RepoUpdateCus(iBankContext context, ILogger<RepoUpdateCus> logger)
        {
            _iBankContext = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Update(Guid idCus, Customer customer)
        {
            if (idCus == Guid.Empty)
            {
                _logger.LogWarning("Id khach hang rong");
                return false;
            }
            try
            {
                var cus = await _iBankContext.Customers.AsNoTracking()
                    .FirstOrDefaultAsync(c => c.idCus == idCus);
                if(cus == null)
                {
                    _logger.LogWarning("Khong tim thay khach hang");
                    return false;
                }
                cus.cccd = customer.cccd;
                cus.name = customer.name;
                cus.birth = customer.birth;
                cus.address = customer.address;
                cus.phone = customer.phone;
                cus.email = customer.email;
                await _iBankContext.SaveChangesAsync();
                _logger.LogInformation("Cap nhat khach hang thanh cong");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
