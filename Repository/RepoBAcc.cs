using iBanking.Data;
using iBanking.Interfaces.Repo;
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
    public class RepoBAcc : IRepoBAcc
    {
        private readonly iBankContext _context;
        private readonly ILogger<RepoBAcc> _logger;

        public RepoBAcc(iBankContext context, ILogger<RepoBAcc> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> AddBankAcc(BankAcc bankAcc)
        {
            if (bankAcc == null)
            {
                _logger.LogWarning("Them mot tai khoan rong");
                return false;
            }
            try
            {
                await _context.BankAccs.AddAsync(bankAcc);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Da them tai khoan moi voi ID: {bankAcc.idAcc}");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteByIdAcc(Guid idAcc)
        {
            if(idAcc == Guid.Empty)
            {
                _logger.LogWarning("Du lieu tai khoan khong dung");
                return false;
            }
            try
            {
                var acc=await _context.BankAccs.FindAsync(idAcc);
                if (acc == null)
                {
                    _logger.LogWarning("Khong tim thay tai khoan");
                    return false;
                }
                _context.BankAccs.Remove(acc);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Xoa tai khoan thanh cong");
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return false;
        }

        public async Task<IEnumerable<BankAcc>> GetAll()
        {
            try
            {
                if (!await _context.BankAccs.AnyAsync())
                {
                    _logger.LogWarning("Khong co tai khoan nao");
                    return Enumerable.Empty<BankAcc>();
                }
                var BAccs = await _context.BankAccs.AsNoTracking().ToListAsync();
                _logger.LogInformation($"Lay danh sach {BAccs.Count} tai khoan thanh cong");
                return BAccs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return Enumerable.Empty<BankAcc>();
        }

        public async Task<BankAcc?> GetByIdAcc(Guid idAcc)
        {
            if (idAcc == Guid.Empty)
            {
                _logger.LogWarning("Id tai khoan khong ton tai");
                return null;
            }
            try
            {
                var bacc = await _context.BankAccs
                    .FindAsync(idAcc);
                if (bacc == null)
                {
                    _logger.LogWarning($"Tai khoan voi ID {idAcc} khong ton tai");
                    return null;
                }
                else
                {
                    _logger.LogInformation("Tai khoan ton tai");
                }
                return bacc;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }

        }

        public async Task<bool> Update(Guid idBAcc, BankAcc newBankAcc)
        {
            if (idBAcc == Guid.Empty ||newBankAcc==null)
            {
                _logger.LogWarning("Id tai khoan khong ton tai");
                return false;
            }
            try
            {
                var acc=await _context.BankAccs.FindAsync(idBAcc);
                if (acc == null)
                {
                    _logger.LogWarning($"Tai khoan voi ID {idBAcc} khong ton tai");
                    return false;
                }
                acc.accNum = newBankAcc.accNum != string.Empty ? newBankAcc.accNum : acc.accNum;
                acc.typeAcc = newBankAcc.typeAcc ?? acc.typeAcc;
                acc.currBalance = newBankAcc.currBalance !=0?newBankAcc.currBalance:acc.currBalance;
                acc.openDate = newBankAcc.openDate !=DateTime.MinValue ? newBankAcc.openDate:acc.openDate;

                await _context.SaveChangesAsync();
                _logger.LogInformation("Cap nhat tai khoan thanh cong");
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateByIdCus(Guid idCus, BankAcc newBankAcc)
        {
            if (idCus == Guid.Empty || newBankAcc == null)
            {
                _logger.LogWarning("Id tai khoan khong ton tai");
                return false;
            }
            try
            {
                var acc = await _context.BankAccs.FirstOrDefaultAsync(s=>s.idCus==idCus);
                if (acc == null || newBankAcc == null)
                {
                    _logger.LogWarning("Tai khoan khong ton tai");
                    return false;
                }
                acc.accNum = newBankAcc.accNum != string.Empty ? newBankAcc.accNum: acc.accNum;
                acc.typeAcc = newBankAcc.typeAcc ?? acc.typeAcc;
                acc.currBalance = newBankAcc.currBalance != 0 ? newBankAcc.currBalance : acc.currBalance;
                acc.openDate = newBankAcc.openDate != DateTime.MinValue ? newBankAcc.openDate : acc.openDate;
                await _context.SaveChangesAsync();
                _logger.LogInformation("Cap nhat tai khoan thanh cong");
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
