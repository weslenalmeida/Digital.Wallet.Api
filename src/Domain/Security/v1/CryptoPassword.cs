using CrossCutting.Configuration;
using System.Text;

namespace Domain.Security.v1
{
    public static class CryptoPassword
    {
        public static string Encode(string password)
        {
            byte[] unhashedBytes = Encoding.Unicode.GetBytes(string.Concat(AppSettings.SaltConfiguration.Salt, password));
            var sha256 = new System.Security.Cryptography.SHA256Managed();
            byte[] hashedBytes = sha256.ComputeHash(unhashedBytes);
            return Convert.ToBase64String(hashedBytes);
        }
    }
}
