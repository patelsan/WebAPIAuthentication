using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using WebAPIAuthenitication.Security;
using System.Net;

namespace WebAPIAuthentication.UnitTests
{
    [TestClass]
    public class TokenTests
    {
        [TestMethod]
        public void FindCertificate()
        {
            CryptographyHelper cryptographyHelper = new CryptographyHelper();
            X509Certificate2 certificate = cryptographyHelper.GetX509Certificate("CN=WebAPI-Token");

            Assert.IsNotNull(certificate);
        }

        [TestMethod]
        public void EncryptAndDecrypt()
        {
            CryptographyHelper cryptographyHelper = new CryptographyHelper();
            X509Certificate2 certificate = cryptographyHelper.GetX509Certificate("CN=WebAPI-Token");
            string plainToken = "UserId: Ninja, IP: 127.0.0.1";

            string encrypted = cryptographyHelper.Encrypt(certificate, plainToken);
            string decrypted = cryptographyHelper.Decrypt(certificate, encrypted);

            Assert.AreEqual(plainToken, decrypted);
        }

        [TestMethod]
        public void CreateToken()
        {
            Token token = new Token("peter",  "127.0.0.1");
            string encrypted = token.Encrypt();

            Token recreatedToken = Token.Decrypt(encrypted);

            Assert.AreEqual(token.UserId, recreatedToken.UserId);
            Assert.AreEqual(token.IP, recreatedToken.IP);

        }
    }
}
