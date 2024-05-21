using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Security;

namespace ToolAccessLayer
{

    public class AesEncryption
    {
        /*

            private static readonly byte[] salt = new byte[] { 0x26, 0x19, 0x7A, 0x3E, 0xBC, 0x2F, 0xEE, 0xD9 };
            private const int iterations = 1000;

            public static string EncryptString(string plainText, string password)
            {
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                byte[] keyBytes = new Rfc2898DeriveBytes(password, salt, iterations).GetBytes(32);

                using (AesManaged aes = new AesManaged())
                {
                    aes.Key = keyBytes;
                    aes.IV = new byte[16];
                    aes.Mode = CipherMode.CBC;

                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(plainTextBytes, 0, plainTextBytes.Length);
                            cs.Close();
                        }

                        byte[] encryptedBytes = ms.ToArray();
                        return Convert.ToBase64String(encryptedBytes);
                    }
                }
            }

            public static string DecryptString(string encryptedText, string password)
            {
                byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
                byte[] keyBytes = new Rfc2898DeriveBytes(password, salt, iterations).GetBytes(32);

                using (AesManaged aes = new AesManaged())
                {
                    aes.Key = keyBytes;
                    aes.IV = new byte[16];
                    aes.Mode = CipherMode.CBC;

                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(encryptedBytes, 0, encryptedBytes.Length);
                            cs.Close();
                        }

                        byte[] decryptedBytes = ms.ToArray();
                        return Encoding.UTF8.GetString(decryptedBytes);
                    }
                }
            }
      */

        private static readonly byte[] salt = new byte[] { 0x26, 0x19, 0x7A, 0x3E, 0xBC, 0x2F, 0xEE, 0xD9 };
        private const int iterations = 1000;

        public static string EncryptString(string plainText, string password)
        {
            byte[] plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            using (Aes aesAlg = Aes.Create())
            {
                Rfc2898DeriveBytes keyDerivation = new Rfc2898DeriveBytes(password, salt, iterations);
                aesAlg.Key = keyDerivation.GetBytes(32);
                aesAlg.IV = new byte[16];

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aesAlg.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(plainTextBytes, 0, plainTextBytes.Length);
                    }

                    byte[] encryptedBytes = ms.ToArray();
                    return Convert.ToBase64String(encryptedBytes);
                }
            }
        }

        public static string DecryptString(string encryptedText, string password)
        {
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
            using (Aes aesAlg = Aes.Create())
            {
                Rfc2898DeriveBytes keyDerivation = new Rfc2898DeriveBytes(password, salt, iterations);
                aesAlg.Key = keyDerivation.GetBytes(32);
                aesAlg.IV = new byte[16];

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aesAlg.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(encryptedBytes, 0, encryptedBytes.Length);
                    }

                    byte[] decryptedBytes = ms.ToArray();
                    return System.Text.Encoding.UTF8.GetString(decryptedBytes);
                }
            }
        }
    }
}
