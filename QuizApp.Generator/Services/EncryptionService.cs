using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace QuizApp.Generator.Services
{
    public static class EncryptionService
    {
        private static readonly string _keyString = Environment.GetEnvironmentVariable("ENCRYPTION_KEY");
        private static readonly string _ivString = Environment.GetEnvironmentVariable("ENCRYPTION_IV");

        private static readonly byte[] _key = Encoding.UTF8.GetBytes(_keyString);
        private static readonly byte[] _iv = Encoding.UTF8.GetBytes(_ivString);

        public static byte[] Encrypt(string plaintext)
        {
            using var aes = Aes.Create();
            aes.Key = _key;
            aes.IV = _iv;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            using var ms = new MemoryStream();
            using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
            using (var writer = new StreamWriter(cs))
            {
                writer.Write(plaintext);
            }

            return ms.ToArray();
        }

        public static string Decrypt(byte[] ciphertext)
        {
            using var aes = Aes.Create();
            aes.Key = _key;
            aes.IV = _iv;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            using var ms = new MemoryStream(ciphertext);
            using var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read);
            using var reader = new StreamReader(cs);
            return reader.ReadToEnd();
        }
    }
}
