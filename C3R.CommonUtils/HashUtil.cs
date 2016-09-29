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
        /// <summary>
        /// Generates SHA1 hash of given byte array input
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static byte[] ToSHA(byte[] input)
        {
            byte[] cipher = null;
            var sha1 = SHA1.Create();
            cipher = sha1.ComputeHash(input);
            return cipher;
        }

        /// <summary>
        /// Generates SHA1 hash from UTF8 string
        /// </summary>
        /// <param name="utf8Str"></param>
        /// <returns></returns>
        public static string ToSHA(string utf8Str)
        {
            var bytes = Encoding.UTF8.GetBytes(utf8Str);
            var cipher = ToSHA(bytes);
            return cipher.ToHexString();
        }

        /// <summary>
        /// Generates SHA1 hash from UTF8 string with salt
        /// </summary>
        /// <param name="utf8Str"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static string ToSaltedSHA(string utf8Str, string salt)
        {
            var salted = $"{utf8Str}-{salt}";
            return ToSHA(salted);
        }
    }
}
