using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificate_key_length.KeyTypes
{
    using System;
    using System.IO;
    using System.Text;
    using Org.BouncyCastle.Crypto.Parameters;
    using Org.BouncyCastle.Math;

    public class OpenSshKeyProcessor : IKeyProcessor
    {
        public string FormatName => "OpenSSH";

        public int GetKeyLength(string keyContent)
        {
            if (string.IsNullOrWhiteSpace(keyContent))
                throw new ArgumentException("Key content cannot be null or empty.", nameof(keyContent));

            string[] parts = keyContent.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Sanity checks:
            if (parts.Length < 2)
                throw new FormatException("Invalid OpenSSH RSA public key format. Expected at least two space-separated parts.");

            if (!parts[0].StartsWith("ssh-rsa", StringComparison.Ordinal) && !parts[0].Equals("ssh-rsa", StringComparison.Ordinal))
                throw new FormatException("Key content does not start with 'ssh-rsa'.");

            string base64Data = parts[1];
            string base64Clean = base64Data
.Replace("\r", "")
.Replace("\n", "");

            byte[] decodedBytes;
            try
            {
                decodedBytes = Convert.FromBase64String(base64Clean);
            }
            catch (FormatException ex)
            {
                throw new FormatException("Invalid Base64-encoded data in OpenSSH RSA public key.", ex);
            }

            int offset = 0;
            string keyType = ReadLengthPrefixedString(decodedBytes, ref offset);
            if (keyType != "ssh-rsa")
                throw new FormatException($"Unexpected key type: {keyType}. Expected 'ssh-rsa'.");

            byte[] exponentBytes = ReadLengthPrefixedBytes(decodedBytes, ref offset);
            byte[] modulusBytes = ReadLengthPrefixedBytes(decodedBytes, ref offset);

            BigInteger modulus = new BigInteger(1, modulusBytes);
            int bitLength = modulus.BitLength;

            return bitLength;
        }

        /// <summary>
        /// Reads a 4-byte big-endian length from the buffer, then reads that many bytes as a UTF-8 string.
        /// </summary>
        private static string ReadLengthPrefixedString(byte[] data, ref int offset)
        {
            int length = ReadUInt32BigEndian(data, ref offset);
            if (length < 0 || offset + length > data.Length)
                throw new FormatException("Invalid length while reading length-prefixed string.");

            string result = Encoding.UTF8.GetString(data, offset, length);
            offset += length;
            return result;
        }

        /// <summary>
        /// Reads a 4-byte big-endian length, then reads that many bytes from the buffer.
        /// </summary>
        private static byte[] ReadLengthPrefixedBytes(byte[] data, ref int offset)
        {
            int length = ReadUInt32BigEndian(data, ref offset);
            if (length < 0 || offset + length > data.Length)
                throw new FormatException("Invalid length while reading length-prefixed bytes.");

            byte[] result = new byte[length];
            Buffer.BlockCopy(data, offset, result, 0, length);
            offset += length;
            return result;
        }

        /// <summary>
        /// Reads a 4-byte big-endian integer from the buffer and advances the offset.
        /// </summary>
        private static int ReadUInt32BigEndian(byte[] data, ref int offset)
        {
            if (offset + 4 > data.Length)
                throw new FormatException("Not enough data to read uint32.");

            // Big-endian to int
            int value = (data[offset] << 24) |
                        (data[offset + 1] << 16) |
                        (data[offset + 2] << 8) |
                        (data[offset + 3]);
            offset += 4;
            return value;
        }
    }
}