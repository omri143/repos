using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XorEncryptionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string toEncrypt = "541656541.17&EURO&";
            string key = GenerateKey(toEncrypt.Length);
            string encrypted = Encrypt(toEncrypt, key);
            string decrypted = Decrypt(encrypted, key);
            Validate(toEncrypt, key);
            Console.ReadKey();

        }
        public static void Validate(String message, String Key)
        {
            String encryption = Encrypt(message, Key);
            String decryption = Decrypt(encryption, Key);

            Console.WriteLine("=====================");
            Console.WriteLine("Test Result: {0}", message.Equals(decryption));
            Console.WriteLine("=====================");
            Console.WriteLine("message...: {0}", message);
            Console.WriteLine("encryption: {0}", encryption);
            Console.WriteLine("message...: {0}", decryption);
            Console.WriteLine("=====================");
            Console.WriteLine("");

        }

        private static void EncryptDecrypt(Byte[] message, Byte[] Keys)
        {
            for (Int32 i = 0; i < message.Length - 1; i++)
            {
                message[i] ^= Keys[i % Keys.Length];
            }
        }

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
        public static string GenerateKey(int length)
        {
            Random random = new Random();
            StringBuilder sb = new StringBuilder();
            int i = 0;
            while(i<=length)
            {
                sb.Append(random.Next(1, 10));
                i++;
            }
            return sb.ToString();
        }
    }
}
