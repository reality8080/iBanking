using iBanking.Interfaces.Repo;
using iBanking.Interfaces.Ser;
using iBanking.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Service
{
    public class SerBAcc : ISerBAcc
    {
        private readonly IRepoBAcc _bankAcc;
        private readonly ILogger<SerBAcc> _logger;
        public SerBAcc(IRepoBAcc _bankAcc, ILogger<SerBAcc> _logger)
        {
            this._bankAcc = _bankAcc ?? throw new ArgumentNullException(nameof(_bankAcc));
            this._logger = _logger ?? throw new ArgumentNullException(nameof(_logger));
        }
        public async Task<bool> CreaBAcc(BankAcc ba)
        {
            if (ba == null)
            {
                _logger.LogWarning("Them tai khoan ngan hang khong dung");
                return false;
            }
            try
            {
                bool checkCrBA = await _bankAcc.AddBankAcc(ba);
                if (!checkCrBA)
                {
                    _logger.LogWarning("Khong the tao ban ghi");
                    return false;
                }
                _logger.LogInformation("Tao tai khoan thanh cong");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return false;
            }
        }
    }
}
