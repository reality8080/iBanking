using iBanking.Interfaces.Repo;
using iBanking.Interfaces.Ser;
using iBanking.Models.Cuong;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Service
{
    public class SerUser : ISerUser
    {
        private readonly IRepoUser _repoUser;
        private readonly ILogger<ISerUser> _logger;
        public SerUser( ILogger<SerUser>logger, IRepoUser repoUser)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repoUser = repoUser ?? throw new ArgumentNullException(nameof(repoUser));
        }
        public async Task<User?> CheckEmailAndUserName(string username, string email)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email))
            {
                _logger.LogError("Username or email is null or empty");
                return null;
            }

            try
            {
                var checkUser = await _repoUser.readUserByUsername(username);
                if (checkUser == null)
                {
                    _logger.LogError("Username does not exist");
                    return null;
                }
                _logger.LogInformation($"Username found - {username} - {email}");
                return checkUser;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking username and email");
                return null;
            }
        }

        public async Task<bool> CheckPass(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                _logger.LogError("Username or password is null or empty");
                return false;
            }
            try
            {
                var checkUser = await _repoUser.readUserByUsername(username);
                if (checkUser == null)
                {
                    _logger.LogError("Username does not exist");
                    return false;
                }
                if (checkUser.Password != password)
                {
                    _logger.LogError("Password is incorrect");
                    return false;
                }
                _logger.LogInformation("Password is correct");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking password");
                return false;
            }
        }

        public async Task<bool> createUser(string username, string password, string email)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
            {
                _logger.LogError("Username, password or email is null or empty");
                return false;
            }

            try
            {
                User u = new User(username, password, email);

                if (u == null)
                {
                    _logger.LogError("User is null");
                    return false;
                }
                var createed = await _repoUser.createUser(u);
                if (createed == false)
                {
                     _logger.LogError("User is null");
                    return false;
                }
                _logger.LogInformation("User created successfully");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating user");
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
