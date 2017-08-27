using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace HyperLib.Cryptography
{
    public class EasyHash
    {
        public EasyHash()
        {

        }

		public static string GetSHA1Hash(byte[] tohash)
		{
			SHA1 sha = SHA1.Create();
			byte[] cache = sha.ComputeHash(tohash);
			return Convert.ToBase64String(cache);
		}

		public static string GetSHA1Hash(Stream tohash)
		{
			SHA1 sha = SHA1.Create();
			byte[] cache = sha.ComputeHash(tohash);
			return Convert.ToBase64String(cache);
		}

        public static string GetSHA1Hash(string tohash)
        {
            SHA1 sha = SHA1.Create();
            byte[] cache = sha.ComputeHash(Encoding.Unicode.GetBytes(tohash));
            return Convert.ToBase64String(cache);
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

        public static string GetSHA256Hash(string tohash)
        {
            SHA256 sha = SHA256.Create();
            byte[] cache = sha.ComputeHash(Encoding.Unicode.GetBytes(tohash));
            return Convert.ToBase64String(cache);
        }

        public static string GetSHA384Hash(byte[] tohash)
		{
			SHA384 sha = SHA384.Create();
			byte[] cache = sha.ComputeHash(tohash);
			return Convert.ToBase64String(cache);
		}

		public static string GetSHA384Hash(Stream tohash)
		{
			SHA384 sha = SHA384.Create();
			byte[] cache = sha.ComputeHash(tohash);
			return Convert.ToBase64String(cache);
		}

        public static string GetSHA384Hash(string tohash)
        {
            SHA384 sha = SHA384.Create();
            byte[] cache = sha.ComputeHash(Encoding.Unicode.GetBytes(tohash));
            return Convert.ToBase64String(cache);
        }

        public static string GetSHA512Hash(byte[] tohash)
		{
			SHA512 sha = SHA512.Create();
			byte[] cache = sha.ComputeHash(tohash);
			return Convert.ToBase64String(cache);
		}

		public static string GetSHA512Hash(Stream tohash)
		{
			SHA512 sha = SHA512.Create();
			byte[] cache = sha.ComputeHash(tohash);
			return Convert.ToBase64String(cache);
		}

        public static string GetSHA512Hash(string tohash)
        {
            SHA512 sha = SHA512.Create();
            byte[] cache = sha.ComputeHash(Encoding.Unicode.GetBytes(tohash));
            return Convert.ToBase64String(cache);
        }
    }
}
