using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace SessionManagement_Partee
{
    public class TextEncryption
    {
        private static SHA256Managed url = new SHA256Managed();
        private static byte[] _key = url.ComputeHash(Encoding.ASCII.GetBytes(HttpContext.Current.Session["SecretSalt"].ToString()));
        private static byte[] _iv = Encoding.ASCII.GetBytes("QU4nT0m/*4s5h013");
        private static AesCng SymmetricKey = new AesCng()
        {
            Key = _key,
            IV = _iv,
            KeySize = 256,
            BlockSize = 128,
            Mode = CipherMode.CBC,
        };
        public static RNGCryptoServiceProvider random = new RNGCryptoServiceProvider();
        public string RemoveSpace(string text)
        {
            text = text.Replace(" ", "+");
            int mod4 = text.Length % 4;
            if (mod4 > 0)
            {
                text += new string('=', 4 - mod4);
            }
            return text;
        }
        public string Encrypt(string _text)
        {
            string salt = HttpContext.Current.Session["SecretSalt"].ToString();
            if (string.IsNullOrEmpty(_text))
            {
                return string.Empty;
            }
            {
                using (var transform = SymmetricKey.CreateEncryptor(_key, _iv))
                {
                    var inputBytes = Encoding.UTF8.GetBytes(_text + salt);
                    var encryptedBytes = transform.TransformFinalBlock(inputBytes, 0, inputBytes.Length);
                    return Convert.ToBase64String(encryptedBytes);
                }
            }
        }
        public string Decrypt(string _text)
        {
            if (string.IsNullOrEmpty(_text))
            {
                return string.Empty;
            }
            {
                using (var transform = SymmetricKey.CreateDecryptor(_key, _iv))
                {
                    var _inputBytes = Convert.FromBase64String(_text);
                    var _textBytes = transform.TransformFinalBlock(_inputBytes, 0, _inputBytes.Length);
                    return Encoding.UTF8.GetString(_textBytes);
                }
            }
        }

    }
}