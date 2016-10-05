using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteganoGraphy.Encryption;
using System.IO;
using SteganoGraphy.Exceptions;
using SteganoGraphy.IO;
using System.Drawing;

namespace SteganoGraphy
{
    public class Steganography : ISteganography
    {
        private IMessageWriter _writer = new LeastByteWriter();
        private IMessageReader _reader = new LeastByteReader();
        public IEncryptor Encryption { get; set; }
        private byte[] loadedImage;
        private Bitmap img;
        public byte[] GetImage()
        {
            return loadedImage;
        }

        public int LoadImage(string path)
        {
            try
            {
                img = new Bitmap(path);
                return (img.Width * img.Height) / 4 - 50;
                loadedImage = File.ReadAllBytes(path);
                return loadedImage.Length;
            }
            catch (Exception)
            {
                throw new InvalidFileException();
            }
        }
        public void SaveImage(string path)
        {
            try
            {
                if (img == null && loadedImage == null) throw new NoFileLoadedException();
                //File.WriteAllBytes(path, loadedImage);
                img.Save(path,System.Drawing.Imaging.ImageFormat.Bmp);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string ReadMessage(string path, bool decrypt = false)
        {
            //var msg =  _reader.GetMessage(loadedImage);
            var msg = _reader.GetMessage(img);
            if (decrypt)
            {
                msg = Encryption.Decrypt(msg);
            }
            return msg;
        }


        public void WriteMessage(string message, bool encrypt = false)
        {
            if (encrypt)
            {
               message = Encryption.Encrypt(message);
            }
            //loadedImage = _writer.WriteMessage(loadedImage, message);
            img = _writer.WriteMessage(img, message);
        }

        public void WriteMessageAsync(string message, bool encrypt = false)
        {
            Task task = new Task(() => WriteMessage(message, encrypt));
            task.Start();
        }

        public Task<string> ReadMessageAsync(string path, bool decrypt = false)
        {
            Task<string> task = new Task<string>(()=> ReadMessage(path,decrypt));
            task.Start();
            return task;
        }
    }
}
