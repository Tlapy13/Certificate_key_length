using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificate_key_length
{
    public static class KeyProvider
    {
        /// <summary>
        /// Returns a sample PEM-formatted RSA public key.
        /// </summary>
        public static string GetPemPublicKey()
        {
            return @"
-----BEGIN PUBLIC KEY-----
MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEApZ1tXiwcGXkQPgKXq5iN
YZzHry9Q3cPD1Fx05oibYVDKbQ9HZ0MTn+uEDnEnUXYnR1RULI35p3yZqJ/7/xrk
BZpQulx1WxEFvUnhngyCX/yU5KqPRa25e5UfI5uTyjdD3uH6yPcAfhv2SJsI7G2M
TTutduNaeEufb/Bpgpb5ufhsiipPa3ge/Qy6E0ZbL173X8InUdMr0IsEsHFK2f9J
pGM0Q5R9oOTaiw30ai3U5lSEaq4ik9h/lK0ax3EZYwH9bv/rkT317+VGWJsqDOlx
IMCPJS6qBR7g+OtVY4L1T9RKGNeourDb/BF6Z0UxcqdZQJOMUVDcGTjprPU3Yj6l
nwIDAQAB
-----END PUBLIC KEY-----
".Trim();
        }
        /// <summary>
        /// Returns a valid OpenSSH-formatted RSA public key.
        /// </summary>
        public static string GetOpenSshKey()
        {
            return @"ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQDttVfkKBuC9OCMxGqVQtpcjKW+kbR0J4DDIYtwIhZHQe2qronZT3BHyPaVSWknNUtgUqS8R2IaxrSeRnq4Hs0vZyZU8r61W/HtMVZ6NqqC0n6+ikS2VJjGjU+RznORz0hEYeYSGnQNYIHzVhKCGCWXbvpoy15vPvIXkcgJgYMQJji3c/UraHFUaN18wUYaQiVVHal8CSs3YE7sABX0JLSObEU4lBZ/MVRGywfHjVDt6yOG5c+u0G8LBY7Ct6PrNvDR7Q1Wbsil2LO2nER8tSEmtS2fb/agKMmvFD3XxxBEb0ZjSh6q8tcmYznSGL9G4XjQR7XygLtEl/PaRDwnAghJ tlapy@Super_PC";
        }

        /// <summary>
        /// Returns a Base64-encoded DER-formatted RSA public key.
        /// </summary>
        public static string GetDerEncodedKey()
        {
            return @"
MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEApZ1tXiwcGXkQPgKXq5iN
YZzHry9Q3cPD1Fx05oibYVDKbQ9HZ0MTn+uEDnEnUXYnR1RULI35p3yZqJ/7/xrk
BZpQulx1WxEFvUnhngyCX/yU5KqPRa25e5UfI5uTyjdD3uH6yPcAfhv2SJsI7G2M
TTutduNaeEufb/Bpgpb5ufhsiipPa3ge/Qy6E0ZbL173X8InUdMr0IsEsHFK2f9J
pGM0Q5R9oOTaiw30ai3U5lSEaq4ik9h/lK0ax3EZYwH9bv/rkT317+VGWJsqDOlx
IMCPJS6qBR7g+OtVY4L1T9RKGNeourDb/BF6Z0UxcqdZQJOMUVDcGTjprPU3Yj6l
nwIDAQAB
".Trim();
        }
    }

}
