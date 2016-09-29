using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace C3R.CommonUtils
{
    public static class HashUtil
    {
        public static byte[] ToSHA(byte[] input)
        {
            byte[] cipher = null;
            var sha1 = SHA1.Create();
            cipher = sha1.ComputeHash(input);
            return cipher;
        }

        public static string ToSHA(string utf8Str)
        {
            var bytes = Encoding.UTF8.GetBytes(utf8Str);
            var cipher = ToSHA(bytes);
            return cipher.ToHexString();
        }

        public static string ToSaltedSHA(string utf8Str, string salt)
        {
            var salted = $"{utf8Str}-{salt}";
            return ToSHA(salted);
        }
    }
}
