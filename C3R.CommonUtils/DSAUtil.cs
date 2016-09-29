using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace C3R.CommonUtils
{
    public static class DSAUtil
    {
        /// <summary>
        /// <para>
        /// Generates DSA Key from given input (XML data of DSA key)
        /// </para>
        /// <para>
        /// If input is null, a new random DSA key will be created
        /// </para>
        /// </summary>
        /// <param name="input">XML data of DSA key</param>
        /// <returns></returns>
        public static DSA GetDSAKey(string input = null)
        {
            var dsa = DSA.Create();
            if (!string.IsNullOrWhiteSpace(input)) dsa.FromXmlString(input);
            return dsa;
        }

        /// <summary>
        /// Signs input data with given dsa key. DSA key must be private key
        /// </summary>
        /// <param name="dsa">Private key</param>
        /// <param name="input">data</param>
        /// <returns></returns>
        public static byte[] Sign(DSA dsa, byte[] input)
        {
            var sha = HashUtil.ToSHA(input);
            var sig = dsa.CreateSignature(sha);
            return sig;
        }

        /// <summary>
        /// Verify input data and signature with given dsa key, DSA should be public key only
        /// </summary>
        /// <param name="dsa">Public key</param>
        /// <param name="input">data</param>
        /// <param name="sig">signature</param>
        /// <returns></returns>
        public static bool Verify(DSA dsa, byte[] input, byte[] sig)
        {
            var sha1 = HashUtil.ToSHA(input);
            return dsa.VerifySignature(sha1, sig);
        }
    }
}
