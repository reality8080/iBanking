using iBanking.Data;
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
    public class RepoUserAuth : IRCreaUAuth, IRReadUAuth, IRUpdaUAuth, IRDeleUAuth
    {
        private readonly iBankContext _context;
        private readonly ILogger<RepoUserAuth> _logger;
        public RepoUserAuth(iBankContext _context, ILogger<RepoUserAuth> _logger)
        {
            this._context = _context ?? throw new ArgumentNullException(nameof(_context));
            this._logger = _logger ?? throw new ArgumentNullException(nameof(_logger));
        }

        public async Task<bool> AddUA(UserAuth userAuth)
        {
            if (userAuth.idUserAuth == Guid.Empty)
            {
                _logger.LogWarning("Du lieu khoan vay khong dung");
                return false;
            }
            try
            {
                await _context.UserAuths.AddAsync(userAuth);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Da them lich su moi voi ID: {userAuth.idUserAuth}");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> Delete(UserAuth userAuth)
        {
            if (userAuth==null )
            {
                _logger.LogWarning("Du lieu dang nhap khong dung");
                return false;
            }
            try
            {
                var user = await _context.UserAuths.FirstOrDefaultAsync(u => u.idUserAuth == userAuth.idUserAuth);
                if (user == null)
                {
                    _logger.LogWarning("Khong tim thay lich su");
                    return false;
                }
                _context.UserAuths.Remove(user);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Da xoa lich su voi ID: {userAuth.idUserAuth}");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteByIdUserAuth(Guid idUserAuth)
        {
            if (idUserAuth == Guid.Empty)
            {
                _logger.LogWarning("Du lieu lich su khong dung");
                return false;
            }
            try
            {
                var user = await _context.UserAuths.FirstOrDefaultAsync(u => u.idUserAuth == idUserAuth);
                if (user == null)
                {
                    _logger.LogWarning("Khong tim thay lich su dang nhap");
                    return false;
                }
                _context.UserAuths.Remove(user);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Da xoa lich su dang nhap voi ID: {idUserAuth}");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<IEnumerable<UserAuth>> GetAll()
        {
            try
            {
                if (!await _context.UserAuths.AnyAsync())
                {
                    _logger.LogWarning("Khong co lich su giao dich");
                    return Enumerable.Empty<UserAuth>();
                }
                var users = await _context.UserAuths.ToListAsync();
                return users;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Enumerable.Empty<UserAuth>();
            }
        }

        public async Task<IEnumerable<UserAuth>> GetByIdAcc(Guid idAcc)
        {
            if (idAcc == Guid.Empty)
            {
                _logger.LogWarning("Du lieu lich su khong dung");
                return Enumerable.Empty<UserAuth>();
            }
            try
            {
                var trans = await _context.UserAuths.Where(u => u.idAcc == idAcc).ToListAsync();
                if (trans == null)
                {
                    _logger.LogWarning("Khong tim thay lich su");
                    return Enumerable.Empty<UserAuth>();
                }
                return trans;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Enumerable.Empty<UserAuth>();
            }
        }

        public async Task<UserAuth?> GetByIdUser(Guid idUserAuth)
        {
            if (idUserAuth == Guid.Empty)
            {
                _logger.LogWarning("Du lieu lich su khong dung");
                return null;
            }
            try
            {
                var trans = await _context.UserAuths.FirstOrDefaultAsync(u => u.idUserAuth == idUserAuth);
                if (trans == null)
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

        public async Task<bool> Update(Guid idUserAuth, UserAuth newUserAuth)
        {
            if (idUserAuth == Guid.Empty)
            {
                _logger.LogWarning("Du lieu lich su khong dung");
                return false;
            }
            try
            {
                var user = await _context.UserAuths.FirstOrDefaultAsync(u => u.idUserAuth == idUserAuth);
                if (user == null)
                {
                    _logger.LogWarning("Khong tim thay lich su");
                    return false;
                }
                user.idUserAuth = newUserAuth.idUserAuth != Guid.Empty ? newUserAuth.idUserAuth : user.idUserAuth;
                user.idAcc = newUserAuth.idAcc!=Guid.Empty ? newUserAuth.idAcc : user.idAcc;
                user.username = !string.IsNullOrEmpty(newUserAuth.username) ? newUserAuth.username : user.username;
                user.password = !string.IsNullOrEmpty(newUserAuth.password) ? newUserAuth.password : user.password;
                user.typeAuth = !string.IsNullOrEmpty(newUserAuth.typeAuth) ? newUserAuth.typeAuth : user.typeAuth;
                //_context.UserAuths.Update(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        //public Task<bool> UpdateByIdAcc(Guid idAcc, UserAuth newUserAuth)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
