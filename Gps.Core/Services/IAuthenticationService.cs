﻿using Gps.Core.Domain;
using Gps.Core.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gps.Core.Services
{
    public interface IAuthenticationService
    {
        Task<User> Authenticate(string username, string password);
    }

    public class AuthenticationService : IAuthenticationService
    {
        private GpsContext _context;

        public AuthenticationService(GpsContext context)
        {
            _context = context;
        }

        public async Task<User> Authenticate(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.Users.SingleOrDefault(x => x.Email == email);

            if (user == null)
                return null;

            if (!PasswordService.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return user;
        }
    }
}