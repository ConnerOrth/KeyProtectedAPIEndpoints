using System;
using System.Security.Cryptography;
using System.Threading;

namespace KeyProtectedAPIEndpoints.Helpers
{
    public sealed class APIKeyGenerator
    {
        private const string Chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        private static readonly ThreadLocal<char[]> charBufferThreadLocal = new ThreadLocal<char[]>(() => new char[32]);

        static APIKeyGenerator() { }
        private APIKeyGenerator() { }
        public static APIKeyGenerator Instance { get; } = new APIKeyGenerator();
        public string Next => GetAPIKey();
        private static string GetAPIKey()
        {
            char[] buffer = charBufferThreadLocal.Value;

            byte[] data = new byte[32 * 4];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }
            for (int i = 0; i < 32; i++)
            {
                var rnd = BitConverter.ToUInt32(data, i * 4);
                var idx = rnd % Chars.Length;
                buffer[i] = Chars[(int)idx];
            }
            return new string(buffer, 0, buffer.Length);
        }
    }
}
