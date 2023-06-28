using System.Text;
using System;
namespace SM_AMS.Services.Security
{
    public class SMSecurity
    {
        // Function to encrypt the URL
        public static string EncryptUrl(string url)
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(url);
            string encryptedUrl = Convert.ToBase64String(plainBytes);
            return encryptedUrl;
        }
        // Function to decrypt the encrypted URL
        public static string DecryptUrl(string encryptedUrl)
        {
            byte[] encryptedBytes = Convert.FromBase64String(encryptedUrl);
            string decryptedUrl = Encoding.UTF8.GetString(encryptedBytes);
            return decryptedUrl;
        }

    }
}
