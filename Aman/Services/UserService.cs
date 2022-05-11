using Aman.Interfaces;
using Aman.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Aman.Services
{
    public class UserService: IUserInterface<User>
    {
        private User _user;
        public User User {
            get { return _user; }
            set { _user = value; }
        }

        public async Task<User> GetUserAsync(string id)
        {
            return await Task.FromResult(User); 
        }

        public async Task<User> SetUserAsync(User user)
        {
            User = user;
            return await Task.FromResult(User);
        }

    }
}
