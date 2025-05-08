using iBanking.Interfaces.Repo;
using iBanking.Interfaces.Ser;
using iBanking.NewModels;
using iBanking.Repository.Cuong;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking.Service
{
    public class SerEmployee:ISerEmployee
    {
        private readonly IRepoEmployee _repoEmployee;
        private readonly ILogger<SerEmployee> _logger;

        public SerEmployee(IRepoEmployee _repoEmployee, ILogger<SerEmployee> _logger)
        {
            this._repoEmployee = _repoEmployee ?? throw new ArgumentNullException(nameof(_repoEmployee));
            this._logger = _logger ?? throw new ArgumentNullException(nameof(_logger));
        }

        //public async Task<Employee?> CheckEmailAndAdminName(string employeeName, string email)
        //{
        //    if (string.IsNullOrEmpty(employeeName) || string.IsNullOrEmpty(email))
        //    {
        //        _logger.LogError("Username or email is null or empty");
        //        MessageBox.Show("Username or email is null or empty");
        //        return null;
        //    }

        //    try
        //    {
        //        var checkEmployee = await _repoEmployee.readEmployeeByEmployeename(employeeName);
        //        if (checkEmployee == null)
        //        {
        //            _logger.LogError($"Username {employeeName}, {email} does not exist");
        //            MessageBox.Show($"Username {employeeName}, {email} does not exist");
        //            return null;
        //        }
        //        _logger.LogInformation($"Username found - {employeeName} - {email}");
        //        return checkEmployee;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, "Error checking username and email");
        //        MessageBox.Show(ex.Message);
        //        return null;
        //    }
        //}
        public async Task<Employee?> CheckEmailAndEmployeeName(string username, string email, int? idManager)
        {
            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(email))
            {
                return null;
            }
            try
            {
                var checkEmployee = await _repoEmployee.readEmployeeByEmployeename(username,email,idManager);
                if (checkEmployee == null)
                {
                    _logger.LogError($"The Employee: {username} not exists");
                    MessageBox.Show($"The Employee: {username} not exists", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }
                return checkEmployee;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error checking username and email");
                MessageBox.Show(ex.Message, "Error checking username and email");
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
                var checkUser = await _repoEmployee.readEmployeeById(Convert.ToInt32(id));
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
        public async Task<bool> createEm(string username, string password, string email, int? manager)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
            {
                _logger.LogError($"Username: {username}, password: {password} or email: {email} is null or empty");
                MessageBox.Show("Username, password or email is null or empty");
                return false;
            }

            try
            {
                Employee u = new Employee(username, password, email, DateTime.Now, manager);

                if (u == null)
                {
                    _logger.LogError($"Username:  {username}, password:  {password}  or email: {email} is null or empty ");
                    MessageBox.Show("Username:  {username}, password:  {password}  or email: {email} is null or empty:");
                    return false;
                }
                var createed = await _repoEmployee.createEmployee(u);
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
