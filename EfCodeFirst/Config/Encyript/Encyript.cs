using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace EfCodeFirst.Config.Encyript
{
    public class Encyript : IEncyript
    {
        private readonly IDataProtectionProvider _dataProtectionProvider;

        public Encyript(IDataProtectionProvider dataProtectionProvider)
        {
            _dataProtectionProvider = dataProtectionProvider;
        }

        public string Decyription(string text, string key)
        {
            var protector = _dataProtectionProvider.CreateProtector(key);
            return protector.Protect(text);
        }

        public string Encyription(string cipherText, string key)
        {
            var protector = _dataProtectionProvider.CreateProtector(key);
            return protector.Unprotect(cipherText);
        }
    }
}
