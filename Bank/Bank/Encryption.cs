using System;
using System.Security.Cryptography;
using System.Text;

namespace Bank
{
    class Encryption
    {        
        public static String Encrypt(String message, String key)
        {
            Byte[] keyBytes = Encoding.Default.GetBytes(key);
            Byte[] messageBytes = Encoding.Default.GetBytes(message);

            EncryptDecrypt(messageBytes, keyBytes);
            return Convert.ToBase64String(messageBytes);
        }

        public static String Decrypt(String message, String key)
        {
            Byte[] keyBytes = Encoding.Default.GetBytes(key);
            Byte[] messageBytes = Convert.FromBase64String(message);

            EncryptDecrypt(messageBytes, keyBytes);
            return Encoding.Default.GetString(messageBytes);
        }
        private static void EncryptDecrypt(Byte[] message, Byte[] Keys)
        {
            for (Int32 i = 0; i < message.Length - 1; i++)
            {
                message[i] ^= Keys[i % Keys.Length];
            }
        }

        // Generate the key of the encryption in given length
        public static string GenerateKey(int  Textlength)
        {
            StringBuilder sb = new StringBuilder();
            Random random = new Random();
            int i = 0;
            while( i< Textlength)
            {
                sb.Append(random.Next(1,10));
                i++;
            }
                       
            return sb.ToString();
        }

        //Computes SHA256 Hash
        private static byte[] GetHash(string inputString)
        {   
            HashAlgorithm algorithm = SHA256.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
    }
}
