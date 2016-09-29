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
        public static DSA GetDSAKey(string input = null)
        {
            var dsa = DSA.Create();
            if (!string.IsNullOrWhiteSpace(input)) dsa.FromXmlString(input);
            return dsa;
        }

        public static byte[] Sign(DSA dsa, byte[] input)
        {
            var sha = HashUtil.ToSHA(input);
            var sig = dsa.CreateSignature(sha);
            return sig;
        }

        public static bool Verify(DSA dsa, byte[] input, byte[] sig)
        {
            var sha1 = HashUtil.ToSHA(input);
            return dsa.VerifySignature(sha1, sig);
        }
    }
}
