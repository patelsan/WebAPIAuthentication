using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;

namespace WebAPIAuthenitication.Security
{
    public class CryptographyHelper
    {
        public X509Certificate2 GetX509Certificate(string subjectName)
        {
            X509Store certificateStore = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            certificateStore.Open(OpenFlags.ReadOnly);
            X509Certificate2 certificate;

            try
            {
                certificate = certificateStore.Certificates.OfType<X509Certificate2>().
                                                                FirstOrDefault(cert => cert.SubjectName.Name.Equals(subjectName, StringComparison.OrdinalIgnoreCase));
            }
            finally
            {
                certificateStore.Close();
            }

            if (certificate == null)
                throw new Exception(String.Format("Certificate '{0}' not found.", subjectName));

            return certificate;
        }

        public string Encrypt(X509Certificate2 certificate, string plainToken)
        {
            RSACryptoServiceProvider cryptoProvidor = (RSACryptoServiceProvider)certificate.PublicKey.Key;
            byte[] encryptedTokenBytes = cryptoProvidor.Encrypt(Encoding.UTF8.GetBytes(plainToken), true);
            return Convert.ToBase64String(encryptedTokenBytes);
        }

        public string Decrypt(X509Certificate2 certificate, string encryptedToken)
        {
            RSACryptoServiceProvider cryptoProvidor = (RSACryptoServiceProvider)certificate.PrivateKey;
            byte[] decryptedTokenBytes = cryptoProvidor.Decrypt(Convert.FromBase64String(encryptedToken), true);

            return Encoding.UTF8.GetString(decryptedTokenBytes);
        }
    }
}