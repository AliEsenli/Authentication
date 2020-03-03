﻿using Authentication.Domain.Entity;
using Authentication.Domain.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Domain.Repository.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public List<User> GetUsers(long userid, string username, string name, string surname, string email);

        public Task<User> ValidateUser(string username, string password = "");
    }
}
