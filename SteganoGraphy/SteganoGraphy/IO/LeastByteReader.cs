using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteganoGraphy.IO
{
    public class LeastByteReader : IMessageReader
    {
        public string GetMessage(byte[] image)
        {
            throw new NotImplementedException();
        }

        public string GetMessage(Bitmap bmp)
        {
            //var msg = Encoding.UTF8.GetBytes(message);
            //var pixelCount = msg.Length * 4;
            //var width = img.Width;

            //int character = 0;
            //for (int i = 0; i < pixelCount; i += 4)
            //{
            //    if (character >= message.Length) break;
            //    for (int j = 0; j < 4; j++)
            //    {
            //        var pixel = img.GetPixel((j + i) % width, (j + i) / width);
            //        var pixelR = (byte)(((pixel.R >> 2) << 2) |
            //        ((msg[character] >> ((3 - i) * 2))) & 3);
            //        Color color = Color.FromArgb(pixel.A, pixelR, pixel.G, pixel.B);
            //        img.SetPixel((j + i) % width, (j + i) / width, color);
            //    }
            //    character++;
            //}
            //return img;


            //char x = (char)(((xxx[0] & 3) << 6) | ((xxx[1] & 3) << 4) |
            //((xxx[2] & 3) << 2) | ((xxx[3] & 3)));
            var width = bmp.Width;
            StringBuilder sb = new StringBuilder();
            int i = 0;
            do
            {

                var pixel0 = bmp.GetPixel((0 + i) % width, (0 + i) / width);
                var pixel1 = bmp.GetPixel((1 + i) % width, (1 + i) / width);
                var pixel2 = bmp.GetPixel((2 + i) % width, (2 + i) / width);
                var pixel3 = bmp.GetPixel((3 + i) % width, (3 + i) / width);
                char x = (char)(((pixel0.R & 3) << 6) | ((pixel1.R & 3) << 4) |
                ((pixel2.R & 3) << 2) | ((pixel3.R & 3)));
                if (x != 0)
                    sb.Append(x);
                else break;
                i += 4;
            } while (i < bmp.Height * bmp.Width);
            return sb.ToString();

        }

        public Task<string> GetMessageAsync(byte[] image)
        {
            throw new NotImplementedException();
        }

        public byte[] GetMessageBytes(byte[] image)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> GetMessageBytesAsync(byte[] image)
        {
            throw new NotImplementedException();
        }
    }
}
