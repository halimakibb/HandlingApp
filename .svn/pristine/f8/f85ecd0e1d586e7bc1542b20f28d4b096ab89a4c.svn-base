using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FrancoHandling_Lib
{
    public class Encryption
    {
        private const string _EncryptionKey = "EncryptionKey";
        private const string _EncryptionIV = "EncryptionIV";

        public static string EncryptionKey
        {
            get { return ConfigurationManager.AppSettings[_EncryptionKey]; }
        }

        public static string EncryptionIV
        {
            get { return ConfigurationManager.AppSettings[_EncryptionIV]; }
        }


        /// <summary>
        /// Encryption Parameter Value
        /// </summary>
        /// <param name="prm_text_to_encrypt"></param>
        /// <returns></returns>
        public static string Encrypt(string prm_text_to_encrypt)
        {
            string sToEncrypt = prm_text_to_encrypt;
            RijndaelManaged myRijndael = new RijndaelManaged();
            myRijndael.Padding = PaddingMode.Zeros;
            myRijndael.Mode = CipherMode.CBC;
            myRijndael.KeySize = 256;
            myRijndael.BlockSize = 256;
            byte[] encrypted;
            byte[] toEncrypt;
            byte[] key;
            byte[] IV;


            key = System.Text.Encoding.ASCII.GetBytes(EncryptionKey);
            IV = System.Text.Encoding.ASCII.GetBytes(EncryptionIV);
            ICryptoTransform encryptor = myRijndael.CreateEncryptor(key, IV);

            MemoryStream msEncrypt = new MemoryStream();
            CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
            toEncrypt = System.Text.Encoding.ASCII.GetBytes(sToEncrypt);
            csEncrypt.Write(toEncrypt, 0, toEncrypt.Length);
            csEncrypt.FlushFinalBlock();
            encrypted = msEncrypt.ToArray();

            return Convert.ToBase64String(encrypted);
        }

        /// <summary>
        /// Decryption Parameter Value
        /// </summary>
        /// <param name="prm_text_to_decrypt"></param>
        /// <returns></returns>
        public static string Decrypt(string prm_text_to_decrypt)
        {
            RijndaelManaged myRijndael = new RijndaelManaged();
            myRijndael.Padding = PaddingMode.Zeros;
            myRijndael.Mode = CipherMode.CBC;
            myRijndael.KeySize = 256;
            myRijndael.BlockSize = 256;

            byte[] key;
            byte[] IV;

            key = System.Text.Encoding.ASCII.GetBytes(EncryptionKey);
            IV = System.Text.Encoding.ASCII.GetBytes(EncryptionIV);
            ICryptoTransform decryptor = myRijndael.CreateDecryptor(key, IV);
            byte[] sEncrypted = Convert.FromBase64String(prm_text_to_decrypt);
            byte[] fromEncrypt = Convert.FromBase64String(prm_text_to_decrypt);
            MemoryStream msDecrypt = new MemoryStream(sEncrypted);
            CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
            csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);
            string result = ASCIIEncoding.ASCII.GetString(fromEncrypt).Replace("\0", "").TrimEnd();
            return result;
        }

    }
}
