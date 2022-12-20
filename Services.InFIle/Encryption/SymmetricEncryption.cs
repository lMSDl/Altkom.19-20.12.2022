using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Services.InFile.Encryption
{
    public class SymmetricEncryption
    {
        private byte[] _salt;
        public SymmetricEncryption(string salt)
        {
            _salt = Encoding.Unicode.GetBytes(salt);
        }
        private AesManaged _algorithm = new AesManaged();


        public byte[] Encrypt(string stringToEncrypt, string password)
        {
            return Encrypt(Encoding.Unicode.GetBytes(stringToEncrypt), password);
        }

        public byte[] Encrypt(byte[] bytesToEncrypt, string password)
        {
            var passwordHash = GenerateHash(password);
            var key = GenerateKey(passwordHash);
            var iv = GenerateIV(passwordHash);

            var encryptor = _algorithm.CreateEncryptor(key, iv);
            return Transform(encryptor, bytesToEncrypt);
        }

        private byte[] Transform(ICryptoTransform encryptor, byte[] bytesToEncrypt)
        {
            using (var memoryStream = new MemoryStream())
            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
            {
                cryptoStream.Write(bytesToEncrypt, 0, bytesToEncrypt.Length);
                cryptoStream.FlushFinalBlock();

                return memoryStream.ToArray();
            }
        }


        private byte[] GenerateIV(Rfc2898DeriveBytes passwordHash)
        {
            return passwordHash.GetBytes(_algorithm.BlockSize / 8);
        }
        private byte[] GenerateKey(Rfc2898DeriveBytes passwordHash)
        {
            return passwordHash.GetBytes(_algorithm.KeySize / 8);
        }
        private Rfc2898DeriveBytes GenerateHash(string password)
        {
            return new Rfc2898DeriveBytes(password, _salt);
        }
    }
}
