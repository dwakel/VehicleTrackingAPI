using HashidsNet;
using System;
using System.Linq;

namespace Gps.Core.Services
{
    public static class IDService
    {
        private static readonly IHashids Hashids = new Hashids("B5i+$lb)B<uJkV'f-.zK}T4>U0#21", 10, "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ123456789");

        public static string Encode(string prefix, long id)
        {
            var encoded = Hashids.EncodeLong(id);
            if (string.IsNullOrWhiteSpace(encoded))
            {
                throw new Exception("Encoded ID should not be empty");
            }

            return $"{prefix}_{encoded}";
        }

        public static long? Decode(string encoded)
        {
            if (string.IsNullOrWhiteSpace(encoded))
            {
                return null;
            }

            var id = encoded.Split('_').Last();
            var decoded = Hashids.DecodeLong(id).FirstOrDefault();

            return decoded != 0 ? decoded : (long?)null;
        }
    }
}