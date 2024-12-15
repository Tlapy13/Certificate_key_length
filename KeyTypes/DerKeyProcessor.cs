using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificate_key_length.KeyTypes
{
    public class DerKeyProcessor : IKeyProcessor
    {
        public string FormatName => "DER";

        public int GetKeyLength(string keyContent)
        {
            byte[] derBytes = Convert.FromBase64String(keyContent);
            var keyParameter = PublicKeyFactory.CreateKey(derBytes);

            if (keyParameter is RsaKeyParameters rsaKey)
            {
                return rsaKey.Modulus.BitLength;
            }

            throw new InvalidOperationException("Invalid DER RSA key.");
        }
    }
}
