using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteganoGraphy.Encryption
{
    public interface IEncryptor
    {
        void SetEncryptionKeys(dynamic keys);
        void SetDecryptionKeys(dynamic keys);

        string Encrypt(string message);
        string Encrypt(byte[] message);
        byte[] EncryptToBytes(string message);
        byte[] EncryptToBytes(byte[] message);
        string Decrypt(string message);
        string Decrypt(byte[] message);
        byte[] DecryptToBytes(string message);
        byte[] DecryptToBytes(byte[] message);

        Task<string> EncryptAsync(string message);
        Task<string> EncryptAsync(byte[] message);
        Task<byte[]> EncryptToBytesAsync(string message);
        Task<byte[]> EncryptToBytesAsync(byte[] message);
        Task<string> DecryptAsync(string message);
        Task<string> DecryptAsync(byte[] message);
        Task<byte[]> DecryptToBytesAsync(string message);
        Task<byte[]> DecryptToBytesAsync(byte[] message);
    }
}
