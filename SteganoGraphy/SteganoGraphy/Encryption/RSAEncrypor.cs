using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SteganoGraphy.Encryption
{
    public class RSAEncrypor : IEncryptor
    {
        private RSACryptoServiceProvider _rsa;
        public RSAEncrypor()
        {
            _rsa = new RSACryptoServiceProvider();
        }

        public void SetDecryptionKeys(object keys)
        {
            var keyD = BitConverter.GetBytes((keys as RSAKeySet).D);
            var currentParameters = _rsa.ExportParameters(true);
            currentParameters.D = keyD;
            _rsa.ImportParameters(currentParameters);
        }

        public void SetEncryptionKeys(object keys)
        {
            var keyE = BitConverter.GetBytes((keys as RSAKeySet).E);
            var keyN = BitConverter.GetBytes((keys as RSAKeySet).N);
            var currentParameters = _rsa.ExportParameters(true);
            currentParameters.Exponent = keyE;
            currentParameters.Modulus = keyN;
            _rsa.ImportParameters(currentParameters);
        }

        public byte[] DecryptToBytes(byte[] message)
        {
            return _rsa.EncryptValue(message);
        }

        public byte[] DecryptToBytes(string message)
        {
            var bytes = Encoding.Unicode.GetBytes(message);
            return DecryptToBytes(bytes);
        }

        public string Decrypt(byte[] message)
        {
            var decryptedBytes = DecryptToBytes(message);
            return Encoding.Unicode.GetString(decryptedBytes);
        }

        public string Decrypt(string message)
        {
            var bytes = Encoding.Unicode.GetBytes(message);
            return Decrypt(bytes);
        }

        public Task<string> DecryptAsync(byte[] message)
        {
            throw new NotImplementedException();
        }

        public Task<string> DecryptAsync(string message)
        {
            throw new NotImplementedException();
        }



        public Task<byte[]> DecryptToBytesAsync(byte[] message)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> DecryptToBytesAsync(string message)
        {
            throw new NotImplementedException();
        }

        public string Encrypt(byte[] message)
        {
            throw new NotImplementedException();
        }

        public string Encrypt(string message)
        {
            throw new NotImplementedException();
        }

        public Task<string> EncryptAsync(byte[] message)
        {
            throw new NotImplementedException();
        }

        public Task<string> EncryptAsync(string message)
        {
            throw new NotImplementedException();
        }

        public byte[] EncryptToBytes(byte[] message)
        {
            throw new NotImplementedException();
        }

        public byte[] EncryptToBytes(string message)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> EncryptToBytesAsync(byte[] message)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> EncryptToBytesAsync(string message)
        {
            throw new NotImplementedException();
        }
    }
}
