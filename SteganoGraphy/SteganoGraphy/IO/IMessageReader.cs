using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteganoGraphy.IO
{
    public interface IMessageReader
    {
        byte[] GetMessageBytes(byte[] image);
        Task<byte[]> GetMessageBytesAsync(byte[] image);
        string GetMessage(byte[] image);
        string GetMessage(Bitmap img);
        Task<string> GetMessageAsync(byte[] image);
    }
}
