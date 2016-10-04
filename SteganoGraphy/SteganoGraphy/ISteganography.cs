using SteganoGraphy.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteganoGraphy
{
    public interface ISteganography
    {
        int LoadImage(string path);
        void SaveImage(string path);
        void WriteMessage(string message, bool encrypt = false);
        void WriteMessageAsync(string message, bool encrypt = false);
        string ReadMessage(string path, bool decrypt = false);
        Task<string> ReadMessageAsync(string path, bool decrypt = false);
        byte[] GetImage();
        IEncryptor Encryption { get; set; }
    }
}
