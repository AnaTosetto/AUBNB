using System;
using System.Security.Cryptography;

namespace AUBNB.Infra.Security
{
    public class Encrypter : IEncrypter
    {
        private static readonly int saltSize = 40;
        private static readonly int DeriveBytesIterationsCount = 10000;

        public string GetSalt(string value)
        {
            var saltBytes = new byte[saltSize];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(saltBytes);

            return Convert.ToBase64String(saltBytes);
        }

        public string GetHash(string value, string salt)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(value, GetBytes(salt), DeriveBytesIterationsCount);

            return Convert.ToBase64String(pbkdf2.GetBytes(saltSize));
        }

        private static byte[] GetBytes(string value)
        {
            var bytes = new byte[value.Length + sizeof(char)];
            Buffer.BlockCopy(value.ToCharArray(), 0, bytes, 0, bytes.Length);

            return bytes;
        }
    }
}