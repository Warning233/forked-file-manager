using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace File_Manager
{
    [Serializable]
    public class Users
    {
        private string encryptionKey = GenerateEncryptionKey(16);
        public string Name { get; set; }
        public string Password { get; set; }
        public Users() { }
        public Users(string username, string password) 
        {
            Name = username;
            Password = password;
        }

        [OnSerializing]
        internal void OnSerializing(StreamingContext context)
        {
            Name = EncryptString(Name, encryptionKey);
            Password = EncryptString(Password, encryptionKey);
        }

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            Name = DecryptString(Name, encryptionKey);
            Password = DecryptString(Password, encryptionKey);
        }

        private string EncryptString(string plainText, string key)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = new byte[16];

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        private string DecryptString(string cipherText, string key)
        {
            using (Aes aes = Aes.Create()) 
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = new byte[16];

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                byte[] cipherBytes = Convert.FromBase64String(cipherText);

                using (MemoryStream msDecrypt = new MemoryStream(cipherBytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

        private static string GenerateEncryptionKey(int lengthInBytes)
        {
            byte[] key = new byte[lengthInBytes];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(key);
            }
            return Convert.ToBase64String(key);
        }
    }
}
