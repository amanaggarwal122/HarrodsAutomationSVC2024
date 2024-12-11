using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TAF_GenericUtility.Scripted.Security
{
    public class FileSecurity
    {
        private const ushort ITERATIONS = 40000;
        private const string saltString = "192837465";        
        private static byte[] SALT = Encoding.ASCII.GetBytes(saltString);
        private const string password = "KU/MrDnUlxdgWF3AHyXT+A==:VBoK8D81HW+nr/muOAvH5w==";
        private static byte[] CreateKey(string password, int keySize)
        {
            DeriveBytes derivedKey = new Rfc2898DeriveBytes(password, SALT, ITERATIONS);
            return derivedKey.GetBytes(keySize >> 3);
        }

        public static string Encrypt(string text)
        {
            byte[] encryptedData = null;
            byte[] data = Encoding.Default.GetBytes(text);

            using (AesCryptoServiceProvider provider = new AesCryptoServiceProvider())
            {
                provider.KeySize = 128;
                provider.GenerateIV();
                provider.Key = CreateKey(password, provider.KeySize);
                provider.Mode = CipherMode.CBC;
                provider.Padding = PaddingMode.PKCS7;

                using (MemoryStream memStream = new MemoryStream(data.Length))
                {
                    memStream.Write(provider.IV, 0, 16);
                    using (ICryptoTransform encryptor = provider.CreateEncryptor(provider.Key, provider.IV))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memStream, encryptor, CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(data, 0, data.Length);
                            cryptoStream.FlushFinalBlock();
                        }
                    }
                    encryptedData = memStream.ToArray();
                }
            } 
            return Encoding.Default.GetString(encryptedData);
        }

        public static string Decrypt(string text)
        {
            byte[] data = Encoding.Default.GetBytes(text);
            byte[] decryptedData = new byte[data.Length];

            using (AesCryptoServiceProvider provider = new AesCryptoServiceProvider())
            {
                provider.KeySize = 128;
                provider.Key = CreateKey(password, provider.KeySize);
                provider.Mode = CipherMode.CBC;
                provider.Padding = PaddingMode.PKCS7;
                using (MemoryStream memStream = new MemoryStream(data))
                {
                    byte[] iv = new byte[16];
                    memStream.Read(iv, 0, 16);
                    using (ICryptoTransform decryptor = provider.CreateDecryptor(provider.Key, iv))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memStream, decryptor, CryptoStreamMode.Read))
                        {
                            cryptoStream.Read(decryptedData, 0, decryptedData.Length);
                        }
                    }
                }
            }
            
            return Encoding.Default.GetString(decryptedData);
        }
    }
}