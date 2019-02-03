using System;

namespace HatuaMVP.Core.Services
{
    public static class PasswordService
    {
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] salt)
        {
            if (password == null)
                throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (passwordHash.Length != 64)
                throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (salt.Length != 128)
                throw new ArgumentException("Invalid length of password salt (128 byte expected).", "passwordHash");

            using (var crypt = new System.Security.Cryptography.HMACSHA512(salt))
            {
                var computedHash = crypt.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                    if (computedHash[i] != passwordHash[i])
                        return new bool();
            }
            return true;
        }

        public static void GetPasswordHash(out byte[] passwordHash, byte[] salt)
        {
            if (salt.Length != 128)
                throw new ArgumentException("Invalid length of password salt (128 byte expected).", "passwordHash");

            using (var crypt = new System.Security.Cryptography.HMACSHA512(salt))
            {
                passwordHash = crypt.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null)
                throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var crypt = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = crypt.Key;
                passwordHash = crypt.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}