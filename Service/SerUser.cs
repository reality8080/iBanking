using iBanking.Interfaces.Repo;
using iBanking.Interfaces.Ser;
using iBanking.NewModels;
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
                MessageBox.Show("Username or email is null or empty");
                return null;
            }

            try
            {
                var checkUser = await _repoUser.readUserByUsername(username);
                if (checkUser == null)
                {
                    _logger.LogError($"Username {username}, {email} does not exist");
                    MessageBox.Show($"Username {username}, {email} does not exist");
                    return null;
                }
                _logger.LogInformation($"Username found - {username} - {email}");
                return checkUser;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error checking username and email");
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public async Task<bool> CheckPass(string id, string password)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(password))
            {
                _logger.LogError($"ID: {id} or password: {password} is null or empty");
                MessageBox.Show($"ID: {id} or password: {password} is null or empty");
                return false;
            }
            try
            {
                var checkUser = await _repoUser.readUserById(Convert.ToInt32(id));
                if (checkUser == null)
                {
                    _logger.LogError("ID does not exist");
                    MessageBox.Show("ID does not exist");
                    return false;
                }
                if (checkUser.Password != password)
                {
                    _logger.LogError("Password is incorrect");
                    MessageBox.Show("Password is incorrect");
                    return false;
                }
                _logger.LogInformation("Password is correct");
                MessageBox.Show("Password is correct");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking password");
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public async Task<bool> createUser(string username, string password, string email)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
            {
                _logger.LogError($"Username: {username}, password: {password} or email: {email} is null or empty");
                MessageBox.Show("Username, password or email is null or empty");
                return false;
            }

            try
            {
                User u = new User(username, password, email);

                if (u == null)
                {
                    _logger.LogError($"Username:  {username}, password:  {password}  or email: {email} is null or empty ");
                    MessageBox.Show("Username:  {username}, password:  {password}  or email: {email} is null or empty:");
                    return false;
                }
                var createed = await _repoUser.createUser(u);
                if (createed == false)
                {
                     _logger.LogError("User not found");
                    return false;
                }
                _logger.LogInformation($"User:{username} created successfully");
                MessageBox.Show("User created successfully");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating user");
                MessageBox.Show(ex.Message);
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
