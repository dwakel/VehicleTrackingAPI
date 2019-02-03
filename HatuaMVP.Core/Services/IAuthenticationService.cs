using HatuaMVP.Core.Domain;
using HatuaMVP.Core.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatuaMVP.Core.Services
{
    public interface IAuthenticationService
    {
        Task<User> Authenticate(string username, string password);
    }

    public class AuthenticationService : IAuthenticationService
    {
        private HatuaContext _context;

        public AuthenticationService(HatuaContext context)
        {
            _context = context;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.Users.SingleOrDefault(x => x.Username == username);

            if (user == null)
                return null;

            if (!PasswordService.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return user;
        }
    }
}