using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Proyecto_Joyeria.Core
{
    class Utils
    {
        public static byte[] ConvertBitmapImageToByteArray(BitmapImage image)
        {
            byte[] data;
            try
            {
                BitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image));
                using (MemoryStream ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    data = ms.ToArray();
                }
            }
            catch
            {
                data = null;
            }
            return data;
        }

        public static BitmapImage ConvertByteArrayToBitmapImage(Byte[] bytes)
        {
            BitmapImage image = new BitmapImage();
            try
            {
                var stream = new MemoryStream(bytes);
                stream.Seek(0, SeekOrigin.Begin);
                image.BeginInit();
                image.StreamSource = stream;
                image.EndInit();
            }
            catch
            {
                image = null;
            }
            return image;
        }

        public static bool ByteArrayCompare(byte[] a1, byte[] a2)
        {
            if (a1 != null && a2 != null)
            {
                if (a1.Length != a2.Length)
                    return false;

                for (int i = 0; i < a1.Length; i++)
                    if (a1[i] != a2[i])
                        return false;

                return true;
            }
            else
            {
                if (a1 == null && a2 == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
    }
}
