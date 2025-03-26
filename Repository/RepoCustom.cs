using iBanking.Data;
using iBanking.Interfaces.Repo;
using iBanking.Interfaces.Repo.Create;
using iBanking.Interfaces.Repo.Delete;
using iBanking.Interfaces.Repo.Read;
using iBanking.Interfaces.Repo.Update;
using iBanking.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Repository
{
    public class RepoCustom : IRepoCus
    {
        private readonly iBankContext _context;
        private readonly ILogger<RepoCustom> _logger;

        public RepoCustom(iBankContext _context, ILogger<RepoCustom> _logger)
        {
            this._context = _context ?? throw new ArgumentNullException(nameof(_context));
            this._logger = _logger ?? throw new ArgumentNullException(nameof(_logger));
        }

        public async Task<bool> AddCustomer(Customer customer)
        {
            if (customer == null)
            {
                _logger.LogWarning("Them mot khach hang rong");
                return false;
            }
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await _context.Customers.AddAsync(customer);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex.Message);
            }
            return false;
        }

        public async Task<bool> Delete(Customer customer)
        {
            if (customer == null)
            {
                _logger.LogWarning("Du lieu rong");
                return false;
            }
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var acc = await _context.Customers.FindAsync(customer.idCus);
                if (acc == null)
                {
                    _logger.LogWarning("Khong tim thay khach hang");
                    return false;
                }
                _context.Customers.Remove(acc);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                _logger.LogInformation($"Da xoa khach hang{customer.idCus}");
                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex.Message);
            }
            return false;
        }

        public async Task<bool> DeleteByIdCus(Guid idCus)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var cus = await _context.Customers.FindAsync(idCus);
                if (cus == null)
                {
                    _logger.LogWarning("Khong tim thay khach hang");
                    return false;
                }
                _context.Customers.Remove(cus);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                _logger.LogWarning($"Da xoa khach hang co ID {idCus}");
                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex.Message);
            }
            return false;
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
            if (idCus == Guid.Empty)
            {
                _logger.LogError("IdCus is empty");
                return null;
            }
            try
            {
                var cus = await _context.Customers
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
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<bool> Update(Guid idCus, Customer customer)
        {
            if (idCus == Guid.Empty)
            {
                _logger.LogWarning("Id khach hang rong");
                return false;
            }
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var cus = await _context.Customers.FindAsync(idCus);
                if (cus == null)
                {
                    _logger.LogWarning("Khong tim thay khach hang");
                    return false;
                }
                
                //cus.cccd=customer.cccd ?? cus.cccd;
                //cus.name = customer.name ?? cus.name;
                //cus.birth = customer.birth!=DateTime.MinValue ? customer.birth:cus.birth;
                //cus.address = customer.address ?? cus.address;
                //cus.phone = customer.phone ?? cus.phone;
                //cus.email = customer.email ?? cus.email;
                _context.Entry(cus).CurrentValues.SetValues(customer);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                _logger.LogInformation("Cap nhat khach hang thanh cong");
                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
