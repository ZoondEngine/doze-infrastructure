using System.Security.Cryptography;
using System.Text;

namespace Doze.Private
{
    public static class CryptObject
    {
        public static string ShaHash(string str)
            => Encoding.UTF8.GetString(new SHA1CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(str)));

        public static string MD5Hash(string str)
            => Encoding.UTF8.GetString(new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(str)));
    }
}
