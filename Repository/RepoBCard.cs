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
    public class RepoBCard : IRepoBCard
    {
        private readonly iBankContext _context;
        private readonly ILogger<RepoBCard> _logger;
        public RepoBCard(iBankContext _context, ILogger<RepoBCard> _logger)
        {
            this._context = _context ?? throw new ArgumentNullException(nameof(_context));
            this._logger = _logger ?? throw new ArgumentNullException(nameof(_logger));
        }

        public async Task<bool> AddBankCard(BankCard bankCard)
        {
            if(bankCard == null)
            {
                _logger.LogWarning("Du lieu the khong dung");
                return false;
            }
            try
            {
                await _context.BankCards.AddAsync(bankCard);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Da them the moi voi ID: {bankCard.idCard}");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return false;
        }

        public async Task<bool> DeleteByIdCard(Guid idCard)
        {
            if (idCard==Guid.Empty)
            {
                _logger.LogWarning("Du lieu the khong dung");
                return false;
            }
            try
            {
                var card = await _context.BankCards.FirstOrDefaultAsync(bc=>bc.idCard ==idCard);
                if(card == null)
                {
                    _logger.LogWarning("Khong tim thay the");
                    return false;
                }
                _context.BankCards.Remove(card);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Da xoa the voi ID: {idCard}");
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<IEnumerable<BankCard>> GetAll()
        {
            try
            {
                if(!await _context.BankCards.AnyAsync())
                {
                    _logger.LogWarning("Khong co the nao trong database");
                    return Enumerable.Empty<BankCard>();
                }
                var cards = await _context.BankCards.ToListAsync();
                _logger.LogInformation("Lay danh sach the thanh cong");
                return cards;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Enumerable.Empty<BankCard>();
            }
        }

        public async Task<IEnumerable<BankCard>> GetByIdAcc(Guid idAcc)
        {
            if(idAcc == Guid.Empty)
            {
                _logger.LogWarning("Du lieu the khong dung");
                return Enumerable.Empty<BankCard>();
            }
            try
            {
                var bCards=await _context.BankCards.Where(x => x.idAcc == idAcc).ToListAsync();
                if (!bCards.Any())
                {
                    _logger.LogWarning("Khong tim cac thay the");
                    return Enumerable.Empty<BankCard>();
                }
                _logger.LogInformation($"Tim thay {bCards.Count} the");
                return bCards;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return Enumerable.Empty<BankCard>();
            }
        }

        public async Task<BankCard?> GetByIdCard(Guid idCard)
        {
            if (idCard == Guid.Empty) {
                _logger.LogWarning("Du lieu the khong dung");
                return null;
            }
            try
            {
                var card = await _context.BankCards.FirstOrDefaultAsync(bc=>bc.idCard==idCard);
                if (card == null)
                {
                    _logger.LogWarning("Khong tim thay the");
                    return null;
                }
                _logger.LogInformation($"Tim thay the voi ID: {idCard}");
                return card;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<bool> Update(Guid idCard, BankCard newBankCard)
        {
            if(idCard == Guid.Empty || newBankCard.idCard == Guid.Empty)
            {
                _logger.LogWarning("Du lieu the khong dung");
                return false;
            }
            try
            {
                var card = await _context.BankCards.FindAsync(idCard);
                if (card == null)
                {
                    _logger.LogWarning("Khong tim thay the");
                    return false;
                }
                //card.idAcc = newBankCard.idAcc != Guid.Empty ? newBankCard.idAcc : card.idAcc;
                //card.idCard = newBankCard.idCard != Guid.Empty ? newBankCard.idCard : card.idCard;
                card.typeCard = newBankCard.typeCard ?? card.typeCard;
                card.numberCard = newBankCard.numberCard ?? card.numberCard;
                card.expiredCard = newBankCard.expiredCard != DateTime.MinValue ? newBankCard.expiredCard:card.expiredCard;
                card.statusCard = newBankCard.statusCard ?? card.statusCard;
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Da cap nhat the voi ID: {idCard}");
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateByIdAcc(Guid idAcc, BankCard newBankCard)
        {
            if (idAcc == Guid.Empty || newBankCard == null)
            {
                _logger.LogWarning("Id tai khoan khong ton tai");
                return false;
            }
            try
            {
                var cards = await _context.BankCards.Where(x => x.idAcc == idAcc).ToListAsync();
                if (!cards.Any())
                {
                    _logger.LogWarning("Khong tim thay the");
                    return false;
                }
                foreach (var item in cards)
                {
                    item.typeCard = newBankCard.typeCard ?? item.typeCard;
                    item.numberCard = newBankCard.numberCard ?? item.numberCard;
                    item.expiredCard = newBankCard.expiredCard != DateTime.MinValue ? newBankCard.expiredCard : item.expiredCard;
                    item.statusCard = newBankCard.statusCard ?? item.statusCard;
                }
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Da cap nhat the cho tai khoan voi ID: {idAcc}");
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
