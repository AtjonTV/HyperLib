using System;
using System.IO;
using System.Security.Cryptography;

namespace HyperLib
{
    public class EasyCrypt
    {
        public EasyCrypt()
        {

        }

        public static string GetSHA256Hash(byte[] tohash)
        {
            SHA256 sha = SHA256.Create();
            byte[] cache = sha.ComputeHash(tohash);
            return Convert.ToBase64String(cache);
        }

        public static string GetSHA256Hash(Stream tohash)
        {
            SHA256 sha = SHA256.Create();
            byte[] cache = sha.ComputeHash(tohash);
            return Convert.ToBase64String(cache);
        }
    }
}
