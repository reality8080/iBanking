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
    public class RepoLoans : IRepoLoans
    {
        public readonly iBankContext _context;
        public readonly ILogger<RepoLoans> _logger;
        public RepoLoans(iBankContext _context, ILogger<RepoLoans> _logger)
        {
            this._context = _context ?? throw new ArgumentNullException(nameof(_context));
            this._logger = _logger ?? throw new ArgumentNullException(nameof(_logger));
        }

        public async Task<bool> AddLoans(Loans loans)
        {
            if(loans.idLoan == Guid.Empty)
            {
                _logger.LogWarning("Du lieu khoan vay khong dung");
                return false;
            }
            try
            {
                await _context.Loans.AddAsync(loans);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Da them khoan vay moi voi ID: {loans.idLoan}");
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteByIdLoans(Guid idLoan)
        {
            if(idLoan == Guid.Empty)
            {
                _logger.LogWarning("Du lieu khoan vay khong dung");
                return false;
            }
            try
            {
                var card = await _context.Loans.FirstOrDefaultAsync(bc => bc.idLoan == idLoan);
                if (card == null)
                {
                    _logger.LogWarning("Khong tim thay khoan vay");
                    return false;
                }
                _context.Loans.Remove(card);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Da xoa khoan vay voi ID: {idLoan}");
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<IEnumerable<Loans>> GetAll()
        {
            try
            {
                if(!await _context.Loans.AnyAsync())
                {
                    _logger.LogWarning("Khong co khoan vay nao");
                    return Enumerable.Empty<Loans>();
                }
                var loans = await _context.Loans.ToListAsync();
                return loans;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Enumerable.Empty<Loans>();
            }
        }

        public async Task<Loans?> GetById(Guid idLoans)
        {
            if(idLoans == Guid.Empty)
            {
                _logger.LogWarning("Du lieu khoan vay khong dung");
                return null;
            }
            try
            {
                var loans = await _context.Loans.FirstOrDefaultAsync(l=>l.idLoan==idLoans);
                if(loans == null)
                {
                    _logger.LogWarning("Khong tim thay khoan vay");
                    return null;
                }
                return loans;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<IEnumerable<Loans>> GetByIdAcc(Guid idAcc)
        {
            if(idAcc == Guid.Empty)
            {
                _logger.LogWarning("Du lieu khoan vay khong dung");
                return Enumerable.Empty<Loans>();
            }
            try
            {
                var loans = await _context.Loans.Where(l => l.idAcc == idAcc).ToListAsync();
                if(!loans.Any())
                {
                    _logger.LogWarning("Khong tim thay khoan vay");
                    return Enumerable.Empty<Loans>();
                }
                _logger.LogInformation("Lay danh sach khoan vay thanh cong");
                return loans;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return Enumerable.Empty<Loans>();
            }
        }

        public async Task<bool> Update(Guid idLoans, Loans newLoans)
        {
            if(idLoans == Guid.Empty || newLoans.idLoan == Guid.Empty)
            {
                _logger.LogWarning("Du lieu khoan vay khong dung");
                return false;
            }
            try
            {
                var loans= await _context.Loans.FindAsync(idLoans);
                if (loans == null)
                {
                    _logger.LogWarning("Khong tim thay khoan vay");
                    return false;
                }
                loans.idAcc = newLoans.idAcc != Guid.Empty ? newLoans.idAcc : loans.idAcc;
                //loans.idLoan = newLoans.idLoan != Guid.Empty ? newLoans.idLoan : loans.idLoan;
                loans.money = newLoans.money != 0 ? newLoans.money : loans.money;
                loans.percentage = newLoans.percentage != 0 ? newLoans.percentage : loans.percentage;
                loans.term = newLoans.term != 0 ? newLoans.term : loans.term;
                loans.status = newLoans.status ?? loans.status;
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Da cap nhat khoan vay voi ID: {idLoans}");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        //public async Task<bool> UpdateByIdAcc(Guid idAcc, Loans newLoans)
        //{
        //    if (idAcc == Guid.Empty || newLoans.idAcc == Guid.Empty)
        //    {
        //        _logger.LogWarning("Du lieu khoan vay khong dung");
        //        return false;
        //    }
        //    try
        //    {
        //        var loans = await _context.Loans.Where(l => l.idAcc == idAcc).ToListAsync();
        //        if (!loans.Any())
        //        {
        //            _logger.LogWarning("Khong tim thay khoan vay");
        //            return false;
        //        }
        //        foreach (var loan in loans)
        //        {
        //            loan.idAcc = newLoans.idAcc != Guid.Empty ? newLoans.idAcc : loan.idAcc;
        //            //loan.idLoan = newLoans.idLoan != Guid.Empty ? newLoans.idLoan : loan.idLoan;
        //            loan.money = newLoans.money != 0 ? newLoans.money : loan.money;
        //            loan.percentage = newLoans.percentage != 0 ? newLoans.percentage : loan.percentage;
        //            loan.term = newLoans.term != 0 ? newLoans.term : loan.term;
        //            loan.status = newLoans.status ?? loan.status;
        //        }
        //        await _context.SaveChangesAsync();
        //        _logger.LogInformation($"Da cap nhat khoan vay voi ID: {idAcc}");
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message);
        //        return false;
        //    }
        //}
    }
}
