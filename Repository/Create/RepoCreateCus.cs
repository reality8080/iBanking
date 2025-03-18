using iBanking.Data;
using iBanking.Interfaces.Write;
using iBanking.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Repository.Create
{
    public class RepoCreateCus : ICreateCustomer
    {
        private readonly iBankContext _context;
        private readonly ILogger<RepoCreateCus> _logger;

        public RepoCreateCus(iBankContext context, ILogger<RepoCreateCus> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            //là một cách bảo vệ class khỏi lỗi null của các tham số truyền vào.
            //✅ Tránh lỗi null khi khởi tạo Repository.
            //✅ Giúp lỗi rõ ràng hơn khi DI không truyền vào context hoặc logger.
            //✅ Dễ debug hơn → Nếu context bị null, lỗi sẽ báo ArgumentNullException: context thay vì NullReferenceException.
        }
        public async Task<bool> AddCustomer(Customer customer)
        {
            //Kiểm tra đầu vào customer
            if (customer == null)
            {
                _logger.LogWarning("Them mot khach hang rong");
                return false;
            }
            try
            {
                await _context.Customers.AddAsync(customer);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError( ex.Message);
            }
            catch (InvalidOperationException invOpEx)
            {
                _logger.LogError(invOpEx.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return false;
        }
    }
}
