using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificate_key_length.KeyTypes
{
    public class PemKeyProcessor : IKeyProcessor
    {
        public string FormatName => "PEM";

        public int GetKeyLength(string keyContent)
        {
            using (var reader = new StringReader(keyContent))
            {
                var pemReader = new PemReader(reader);
                var keyObject = pemReader.ReadObject();

                if (keyObject is RsaKeyParameters rsaKey)
                {
                    return rsaKey.Modulus.BitLength;
                }

                throw new InvalidOperationException("Invalid PEM RSA key.");
            }
        }
    }
}
