using Certificate_key_length;
using Certificate_key_length.KeyTypes;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        try
        {
            // PEM Example
            string pemKey = KeyProvider.GetPemPublicKey();
            var pemProcessor = KeyProcessorManager.GetProcessor("PEM");
            Console.WriteLine($"Format: {pemProcessor.FormatName}, Key Length: {pemProcessor.GetKeyLength(pemKey)} bits");

            // OpenSSH Example
            string sshKey = KeyProvider.GetOpenSshKey();
            var sshProcessor = KeyProcessorManager.GetProcessor("OpenSSH");

            Console.WriteLine($"Format: {sshProcessor.FormatName}, Key Length: {sshProcessor.GetKeyLength(sshKey)} bits");

            // DER Example
            string derKey = KeyProvider.GetDerEncodedKey();
            var derProcessor = KeyProcessorManager.GetProcessor("DER");
            Console.WriteLine($"Format: {derProcessor.FormatName}, Key Length: {derProcessor.GetKeyLength(derKey)} bits");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.ReadLine();
    }
}