using iBanking.Interfaces.Repo;
using iBanking.Interfaces.Ser;
using iBanking.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Service
{
    public class SerUserAuth : ISerUserAuth
    {
        private readonly IRepoCus _cus;
        private readonly IRepoUserAuth _userAuth;
        private readonly IRepoBAcc _bankAcc;
        private readonly ILogger<SerUserAuth> logger;
        public SerUserAuth(IRepoCus _cus, IRepoUserAuth _userAuth, IRepoBAcc _bankAcc, ILogger<SerUserAuth> logger) 
        {
            this._cus = _cus ?? throw new ArgumentNullException(nameof(_cus));
            this._userAuth = _userAuth?? throw new ArgumentNullException(nameof(_userAuth));
            this._bankAcc = _bankAcc ?? throw new ArgumentNullException(nameof(_bankAcc));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> addUaBaCr(string username, string password, string typeAuth)
        {
            if(username == null || password == null || typeAuth == null)
            {
                logger.LogWarning("Them ban ghi phan quyen ko dung");
                return false;
            }
            try
            {
                Customer cus=new Customer();
                BankAcc bankAcc=new BankAcc(cus.idCus,typeAuth, randomNumBAcc());
                UserAuth ua= new UserAuth(bankAcc.idAcc,username,password,typeAuth);
                bool addCus= await _cus.AddCustomer(cus);
                bool addBA= await _bankAcc.AddBankAcc(bankAcc);
                bool addUA = await _userAuth.AddUA(ua);
                if (!addCus || !addBA || !addUA)
                {
                    logger.LogWarning("Tao tai khoan va ban ghi xac thuc ko hop le");
                    return false;
                }
                logger.LogInformation("Tao thanh cong");
                return true;
            }
            catch (Exception ex)
            {
                logger.LogWarning(ex.Message);
                return false;
            }
        }

        public async Task<bool> CheckPass(string username, string password)
        {
            if (username == null || password == null)
            {
                logger.LogWarning("Ten va mat khau bi trong");
                return false;
            }

            try
            {
                var checkPass = await _userAuth.GetByUserName(username);
                if (checkPass == null)
                {
                    logger.LogWarning("Ko co tai khoan");
                    return false;
                }
                else
                {
                    if (checkPass.password != password)
                    {
                        logger.LogWarning("Khong dung mat khau");
                        return false;
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message,ex);
                return false;
            }
        }
        public string randomNumBAcc()
        {
            var random = new Random();
            return random.Next(1000000000, int.MaxValue).ToString();
        }
    }
}
