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
    public class SerCustomer : ISerCustomer
    {
        private readonly IRepoCus _cus;
        private readonly ILogger<SerCustomer> _logger;

        public SerCustomer(IRepoCus _cus, ILogger<SerCustomer> _logger)
        {
            this._cus = _cus ?? throw new ArgumentNullException(nameof(_cus));
            this._logger = _logger ?? throw new ArgumentNullException(nameof(_logger));
        }

        public async Task<bool> CreaCus()
        {
            try
            {
                Customer cus = new Customer();
                if (cus == null)
                {
                    _logger.LogWarning("Tai nguoi dung that bai");
                    return false;
                }
                bool checkCrCus = await _cus.AddCustomer(cus);
                if (!checkCrCus)
                {
                    _logger.LogWarning("Nguoi dung bi loi khi dua du lieu vao");
                    return false;
                }
                _logger.LogInformation("Tao Tai khoan thanh cong");
                return true;
            }
            catch
            (Exception ex)
            {
                _logger.LogError($"Tai nguoi dung that bai: {ex}");
                return false;
            }
        }
    }
}
