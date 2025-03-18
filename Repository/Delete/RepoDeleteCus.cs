using iBanking.Data;
using iBanking.Interfaces.Delete;
using iBanking.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Repository.Delete
{
    public class RepoDeleteCus : IDeleteCustomer
    {
        private readonly iBankContext _context;
        private readonly ILogger<RepoDeleteCus> _logger;
        public RepoDeleteCus(iBankContext context,ILogger<RepoDeleteCus> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Boolean> Delete(Customer customer)
        {
            if (customer == null)
            {
                _logger.LogWarning("Xoa mot khach hang rong");
                return false;
            }
            try
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(DbUpdateException ex)
            {
                _logger.LogError(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return false;
        }
        public async Task<Boolean> DeleteByIdCus(Guid idCus)
        {
            //if(idCus == null)
            //{
            //    _logger.LogWarning("Id rong");
            //    return false;
            //}
            try
            {
                int affectedRows = await _context.Customers.Where(c => c.idCus == idCus)
                    .ExecuteDeleteAsync();
                if(affectedRows > 0)
                {
                    _logger.LogInformation($"Da xoa {affectedRows} khach hang co ID {idCus}");
                    return true;
                }
                _logger.LogWarning($"Khong tim thay khach hang co ID {idCus}");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return false;
        }
    }
}
