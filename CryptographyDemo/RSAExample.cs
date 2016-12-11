#region

using System;
using System.Security.Cryptography;
using System.Text;

#endregion

namespace CryptographyDemo {
    public class RSAExample {
        public static void Run() {
            Console.WriteLine("================================================");
            string sourceData = "Here is some data to encrypt!(RSA)";
            var encryptData = Encrypt(sourceData);
            var decryptData = Decrypt(encryptData);
            Console.WriteLine("Original:\n{0}", sourceData);
            Console.WriteLine("Encrypted:\n{0}", encryptData);
            Console.WriteLine("Decrypted:\n{0}", decryptData);
        }

        public static string Encrypt(string sourceData) {
            var rsa = 1;
            var cspParms = new CspParameters(rsa);
            cspParms.Flags = CspProviderFlags.UseUserProtectedKey;
            cspParms.KeyContainerName = "MyKeys";
            var algorithm = new RSACryptoServiceProvider(cspParms);
            var sourceBytes = new UnicodeEncoding().GetBytes(sourceData);
            return Convert.ToBase64String(algorithm.Encrypt(sourceBytes, true));
        }


        public static string Decrypt(string encryptData) {
            var encryptBytes = Convert.FromBase64String(encryptData);
            var rsa = 1;
            var cspParms = new CspParameters(rsa);
            cspParms.Flags = CspProviderFlags.UseUserProtectedKey;
            cspParms.KeyContainerName = "MyKeys";
            var algorithm = new RSACryptoServiceProvider(cspParms);
            var decryptBytes = algorithm.Decrypt(encryptBytes, true);
            return new UnicodeEncoding().GetString(decryptBytes);
        }
    }
}