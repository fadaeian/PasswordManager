using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Base.Helpers
{
    public static class EncryptHelper
    {
        private static readonly string Salt = "S@ltMDevel0per";

        public static string PasswordHash(string password)
        {
            var provider = MD5.Create();
            byte[] bytes = provider.ComputeHash(Encoding.UTF32.GetBytes(Salt + password));
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }

        public static string Encrypt(string decrypted)
        {
            byte[] data = Encoding.UTF32.GetBytes(decrypted);
            var md5 = new MD5CryptoServiceProvider();
            var tripleDEC = new TripleDESCryptoServiceProvider
            {
                Key = md5.ComputeHash(Encoding.UTF32.GetBytes(Salt)),
                Mode = CipherMode.ECB
            };
            ICryptoTransform transform = tripleDEC.CreateEncryptor();
            var result = transform.TransformFinalBlock(data, 0, data.Length);
            return Base64UrlEncoder.Encode(result);
        }

        public static string Decrypt(string encrypted)
        {
            byte[] data = Base64UrlEncoder.DecodeBytes(encrypted);
            var md5 = new MD5CryptoServiceProvider();
            var tripleDEC = new TripleDESCryptoServiceProvider
            {
                Key = md5.ComputeHash(Encoding.UTF32.GetBytes(Salt)),
                Mode = CipherMode.ECB
            };
            tripleDEC.Key = md5.ComputeHash(Encoding.UTF32.GetBytes(Salt));
            tripleDEC.Mode = CipherMode.ECB;
            ICryptoTransform transform = tripleDEC.CreateDecryptor();
            var result = transform.TransformFinalBlock(data, 0, data.Length);
            return Encoding.UTF32.GetString(result);
        }
    }
}
