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
using System.Transactions;

namespace iBanking.Repository
{
    public class RepoTransHistory:IRepoTransHistory
    {
        public readonly iBankContext _context;
        public readonly ILogger<RepoTransHistory> _logger;
        public RepoTransHistory(iBankContext _context, ILogger<RepoTransHistory> _logger)
        {
            this._context = _context ?? throw new ArgumentNullException(nameof(_context));
            this._logger = _logger ?? throw new ArgumentNullException(nameof(_logger));
        }

        public async Task<bool> AddTransaction(Transactions transaction)
        {
            if (transaction.idTransaction == Guid.Empty)
            {
                _logger.LogWarning("Du lieu khoan vay khong dung");
                return false;
            }
            try
            {
                await _context.Transactions.AddAsync(transaction);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Da them lich su moi voi ID: {transaction.idTransaction}");
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteByIdTransaction(Guid idTransaction)
        {
            if(idTransaction == Guid.Empty)
            {
                _logger.LogWarning("Du lieu lich su khong dung");
                return false;
            }
            try
            {
                var trans = await _context.Transactions.FirstOrDefaultAsync(t=>t.idTransaction == idTransaction);
                if (trans == null)
                {
                    _logger.LogWarning("Khong tim thay lich su");
                    return false;
                }
                _context.Transactions.Remove(trans);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Da xoa lich su voi ID: {idTransaction}");
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<IEnumerable<Transactions>> GetAll()
        {
            try
            {
                if(! await _context.Transactions.AnyAsync())
                {
                    _logger.LogWarning("Khong co lich su giao dich");
                    return Enumerable.Empty<Transactions>();
                }
                var trans = await _context.Transactions.ToListAsync();
                return trans;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return Enumerable.Empty<Transactions>();
            }
        }

        public async Task<Transactions?> GetById(Guid idTransaction)
        {
            if(idTransaction == Guid.Empty)
            {
                _logger.LogWarning("Du lieu lich su khong dung");
                return null;
            }
            try
            {
                var trans = await _context.Transactions.FirstOrDefaultAsync(t => t.idTransaction == idTransaction);
                if(trans == null)
                {
                    _logger.LogWarning("Khong tim thay lich su");
                    return null;
                }
                return trans;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<IEnumerable<Transactions>> GetByIdAcc(Guid idAcc)
        {
            if (idAcc == Guid.Empty)
            {
                _logger.LogWarning("Du lieu lich su khong dung");
                return Enumerable.Empty<Transactions>();
            }
            try
            {
                var trans = await _context.Transactions.Where(l => l.idAcc == idAcc).ToListAsync();
                if (!trans.Any())
                {
                    _logger.LogWarning("Khong tim thay lich su");
                    return Enumerable.Empty<Transactions>();
                }
                _logger.LogInformation("Lay danh sach lich su thanh cong");
                return trans;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Enumerable.Empty<Transactions>();
            }
        }

        public async Task<bool> Update(Guid idTrans, Transactions newTransac)
        {
            if (idTrans == Guid.Empty || newTransac.idAcc == Guid.Empty)
            {
                _logger.LogWarning("Du lieu lich su khong dung");
                return false;
            }
            try
            {
                var trans = await _context.Transactions.FindAsync(idTrans);
                if (trans == null)
                {
                    _logger.LogWarning("Khong tim thay lich su");
                    return false;
                }
                trans.idAcc = newTransac.idAcc != Guid.Empty ? newTransac.idAcc : trans.idAcc;
                //loans.idLoan = newLoans.idLoan != Guid.Empty ? newLoans.idLoan : loans.idLoan;
                trans.typeTrans = newTransac.typeTrans ?? trans.typeTrans;
                trans.money = newTransac.money !=0 ? trans.money: trans.money;
                trans.time = newTransac?.time ?? trans.time;
                trans.status=newTransac?.status ?? trans.status;
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Da cap nhat lich su voi ID: {idTrans}");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        //public async Task<bool> UpdateByIdAcc(Guid idAcc, Transactions newTransac)
        //{
        //    if (idAcc == Guid.Empty || newTransac.idAcc == Guid.Empty)
        //    {
        //        _logger.LogWarning("Du lieu khoan vay khong dung");
        //        return false;
        //    }
        //    try
        //    {
        //        var trans = await _context.Transactions.Where(t => t.idAcc == idAcc).ToListAsync();
        //        if (!trans.Any())
        //        {
        //            _logger.LogWarning("Khong tim thay khoan vay");
        //            return false;
        //        }
        //        foreach(var tran in trans)
        //        {
        //            tran.idAcc = newTransac.idAcc != Guid.Empty ? newTransac.idAcc : tran.idAcc;
        //            //loans.idLoan = newLoans.idLoan != Guid.Empty ? newLoans.idLoan : loans.idLoan;
        //            tran.typeTrans = newTransac.typeTrans ?? tran.typeTrans;
        //            tran.money = newTransac?.money ?? tran.money;
        //            tran.time = newTransac?.time ?? tran.time;
        //            tran.status = newTransac?.status ?? tran.status;
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
