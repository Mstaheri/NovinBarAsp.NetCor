﻿using NovinBar.Domain.OperationResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovinBar.Domain.Users.IUserRepositorys
{
    public interface IUser
    {
        public Task<OperationResult> InsertAsync(User user);
        public Task<OperationResult> UpdateAsync(User user);
        public Task<OperationResult> DeleteAsync(string userName);
        public Task<OperationResult> RecoveryAsync(string userName);
        public OperationResult<List<User>> Select(string searchUserName = "");
        public OperationResult<User> FindUserName(string UserName);
    }
}
