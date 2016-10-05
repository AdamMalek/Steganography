using SteganoGraphy.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SteganoGraphy.IO
{
    public class LeastByteWriter : IMessageWriter
    {
        public byte[] WriteMessage(byte[] image, byte[] message)
        {
            if (image.Length <= message.Length) throw new MessageTooLongException();

            byte[] result = new byte[image.Length];
            Array.Copy(image, result, image.Length);

            //byte[] xxx = new byte[] { 237, 4, 45, 155 };
            //char x = (char)(((xxx[0] & 3) << 6) | ((xxx[1] & 3) << 4) |
            //    ((xxx[2] & 3) << 2) | ((xxx[3] & 3)));

            //Console.Write("1 " + x);
            //char inject = 'U';
            //for (int i = 0; i < 4; i++)
            //{
            //    xxx[i] = (byte)(((xxx[i] >> 2) << 2) |
            //    ((inject >> ((3 - i) * 2))) & 3);
            //}
            //char y = (char)(((xxx[0] & 3) << 6) | ((xxx[1] & 3) << 4) |
            //    ((xxx[2] & 3) << 2) | ((xxx[3] & 3)));

            //Console.Write(" 2 " + y);


            int character = 0;
            for (int i = 0; i < result.Length; i += 4)
            {
                if (character >= message.Length) break;
                for (int j = 0; j < 4; j++)
                {
                    result[j + i] = (byte)(((result[j + i] >> 2) << 2) |
                    ((message[character] >> ((3 - i) * 2))) & 3);
                }
                character++;
            }

            return result;
        }

        public Bitmap WriteMessage(Bitmap img, string message)
        {
            var msg = Encoding.UTF8.GetBytes(message);
            if (msg.Length == 0 || msg.Last() != 0)
            {
                var msg2 = msg.ToList();
                msg2.Add(0);
                msg = msg2.ToArray();
            }
            var pixelCount = msg.Length * 4;
            var width = img.Width;

            int character = 0;
            for (int i = 0; i < pixelCount; i += 4)
            {
                if (character >= msg.Length) break;
                for (int j = 0; j < 4; j++)
                {
                    var pixel = img.GetPixel((j+i) % width, (j+i) / width);
                    var pixelR = (byte)(((pixel.R >> 2) << 2) |
                    ((msg[character] >> ((3 - j) * 2))) & 3);
                    Color color = Color.FromArgb(pixel.A, pixelR, pixel.G, pixel.B);
                    img.SetPixel((j + i) % width, (j + i) / width,color);
                }
                character++;
            }
            return img;
        }

        public byte[] WriteMessage(byte[] image, string message)
        {
            return WriteMessage(image, Encoding.UTF8.GetBytes(message));
        }

        public Task<byte[]> WriteMessageAsync(byte[] image, string message)
        {
            Task<byte[]> task = new Task<byte[]>(() => WriteMessage(image, message));
            task.Start();
            return task;
        }

        public Task<byte[]> WriteMessageAsync(byte[] image, byte[] message)
        {
            Task<byte[]> task = new Task<byte[]>(() => WriteMessage(image, message));
            task.Start();
            return task;
        }
    }
}
