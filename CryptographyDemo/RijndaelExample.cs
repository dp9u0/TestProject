#region

using System;
using System.IO;
using System.Security.Cryptography;

#endregion

namespace CryptographyDemo {
    public class RijndaelExample {
        public static void Run() {
            try {
                Console.WriteLine("================================================");

                string original = "Here is some data to encrypt!(RijndaelExample)";

                // Create a new instance of the RijndaelManaged
                // class.  This generates a new key and initialization 
                // vector (IV).
                using (RijndaelManaged myRijndael = new RijndaelManaged()) {
                    myRijndael.GenerateKey();
                    myRijndael.GenerateIV();
                    // Encrypt the string to an array of bytes.
                    byte[] encrypted = EncryptStringToBytes(original, myRijndael.Key, myRijndael.IV);

                    // Decrypt the bytes to a string.
                    string roundtrip = DecryptStringFromBytes(encrypted, myRijndael.Key, myRijndael.IV);

                    //Display the original data and the decrypted data.
                    Console.WriteLine("Original:\n{0}", original);
                    Console.WriteLine("Encrypted:\n{0}", Convert.ToBase64String(encrypted));
                    Console.WriteLine("Decrypted:\n{0}", roundtrip);
                }
            } catch (Exception e) {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }

        public static byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV) {
            // Check arguments.
            if ((plainText == null) || (plainText.Length <= 0))
                throw new ArgumentNullException("plainText");
            if ((Key == null) || (Key.Length <= 0))
                throw new ArgumentNullException("Key");
            if ((IV == null) || (IV.Length <= 0))
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            // Create an RijndaelManaged object
            // with the specified key and IV.
            using (RijndaelManaged rijAlg = new RijndaelManaged()) {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream()) {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)) {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt)) {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }


            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        public static string DecryptStringFromBytes(byte[] cipherText, byte[] Key, byte[] IV) {
            // Check arguments.
            if ((cipherText == null) || (cipherText.Length <= 0))
                throw new ArgumentNullException("cipherText");
            if ((Key == null) || (Key.Length <= 0))
                throw new ArgumentNullException("Key");
            if ((IV == null) || (IV.Length <= 0))
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an RijndaelManaged object
            // with the specified key and IV.
            using (RijndaelManaged rijAlg = new RijndaelManaged()) {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText)) {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)) {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt)) {
                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }
    }
}