﻿using NovinBar.Domain.OperationResults;
using NovinBar.Domain.Users;
using NovinBar.Domain.Users.IUserRepositorys;
using NovinBar.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovinBar.Infrastructure.Users.Files
{
    public class UserEntityFramwork : IUser
    {
        public string _ConnectionString { get; set; }
        public UserEntityFramwork(string connectionString)
        {
            _ConnectionString = connectionString;
        }
        public async Task<OperationResult> InsertAsync(User user)
        {
            try
            {
                DbContextEF db = new DbContextEF(_ConnectionString);
                db.User.Add(user);
                await db.SaveChangesAsync();
                return new OperationResult
                {
                    Success = true
                };
            }
            catch (Exception)
            {
                return new OperationResult
                {
                    Success = false
                };
            }
            
        }

        public OperationResult<List<User>> Select(string SearchUserName = "")
        {
            try
            {
                DbContextEF db = new DbContextEF(_ConnectionString);
                var query = db.User.Where(p => p.UserName.Contains(SearchUserName))
                    .OrderBy(p => p.LastName).ThenBy(p => p.FirstName).ToList();
                return new OperationResult<List<User>>
                {
                    Data = query,
                    Success = true
                };
            }
            catch (Exception)
            {
                return new OperationResult<List<User>>
                {
                    Success = false
                };
            }
            
        }

        public async Task<OperationResult> UpdateAsync(User user)
        {
            try
            {
                DbContextEF db = new DbContextEF(_ConnectionString);
                var query = db.User.Where(p => p.UserName == user.UserName).Single();
                query.UpdateUser(user.FirstName, user.LastName, user.PassWord, user.PhoneNumber);
                await db.SaveChangesAsync();
                return new OperationResult 
                { Success = true };
            }
            catch (Exception)
            {
                return new OperationResult
                { Success = false };
            }
        }

        public async Task<OperationResult> DeleteAsync(string userName)
        {
            try
            {
                DbContextEF db = new DbContextEF(_ConnectionString);
                var query = db.User.Where(p => p.UserName == userName).Single();
                query.Delete();
                await db.SaveChangesAsync();
                return new OperationResult
                { Success = true };
            }
            catch (Exception)
            {
                return new OperationResult
                { Success = false };
            }
        }

        public async Task<OperationResult> RecoveryAsync(string userName)
        {
            try
            {
                DbContextEF db = new DbContextEF(_ConnectionString);
                var query = db.User.Where(p => p.UserName == userName).Single();
                query.Recovery();
                await db.SaveChangesAsync();
                return new OperationResult
                { Success = true };
            }
            catch (Exception)
            {
                return new OperationResult
                { Success = false };
            }
        }
    }
}
