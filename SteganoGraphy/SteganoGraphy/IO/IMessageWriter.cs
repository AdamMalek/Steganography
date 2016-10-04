using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteganoGraphy.IO
{
    interface IMessageWriter
    {
        byte[] WriteMessage(byte[] image, byte[] message);
        Task<byte[]> WriteMessageAsync(byte[] image, byte[] message);
        byte[] WriteMessage(byte[] image, string message);
        Bitmap WriteMessage(Bitmap img, string message);
        Task<byte[]> WriteMessageAsync(byte[] image, string message);
    }
}
