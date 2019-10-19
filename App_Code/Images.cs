using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;
using System.Drawing;
using System.Drawing.Imaging;

namespace Adm
{
    namespace Tools
    {
        public class ImageTool
        {
            static public void SaveImage(string input, string output, float size, int quality)
            {
                Image img = Bitmap.FromFile(input);
                img = WidthResize(img, size);
                img = HeightResize(img, size);
                ChangeQuality(quality, img, output);
            }

            /// <summary>
            /// Изменяет качество изображения
            /// </summary>
            /// <param name="quality">Качество в процентах</param>
            /// <param name="image">Исходное изображение</param>
            /// <param name="path">Путь сохранения финального изображения</param>
            static public void ChangeQuality(int quality, Image image, string path)
            {
                ImageCodecInfo codec = null;
                EncoderParameter q = new EncoderParameter(Encoder.Quality, quality);
                ImageCodecInfo[] c = ImageCodecInfo.GetImageEncoders();
                EncoderParameters p = new EncoderParameters(1);
                p.Param[0] = q;
                string mime = System.Net.Mime.MediaTypeNames.Image.Jpeg;
                for (int i = 0; i < c.Length; i++)
                    if (c[i].MimeType == mime)
                    {
                        codec = c[i];
                        break;
                    }
                image.Save(path, codec, p);
                q.Dispose();
                p.Dispose();
            }
            public static string GetMime(ImageFormat format)
            {
                if (format == ImageFormat.Jpeg)
                    return System.Net.Mime.MediaTypeNames.Image.Jpeg;
                if (format == ImageFormat.Gif)
                    return System.Net.Mime.MediaTypeNames.Image.Gif;
                if (format == ImageFormat.Tiff)
                    return System.Net.Mime.MediaTypeNames.Image.Tiff;
                if (format == ImageFormat.Png)
                    return "image/png";
                if (format == ImageFormat.Bmp)
                    return "image/bmp";
                if (format == ImageFormat.Icon)
                    return "image/x-icon";
                return "image/bmp";
            }

            static public void ChangeQuality(int quality, string inpath, string outpath)
            {
                Image img = Bitmap.FromFile(inpath);
                ChangeQuality(quality, img, outpath);
            }

            static public Image WidthResize(Image sourceImage, float size)
            {
                float w = sourceImage.Width, h = sourceImage.Height;
                float k = h / w;

                if (size > w) size = w;

                int newW = Convert.ToInt32(size);
                int newH = Convert.ToInt32(newW * k);
                return ResizeImage(sourceImage, newW, newH);

            }
            static public Image HeightResize(Image sourceImage, float size)
            {
                float w = sourceImage.Width, h = sourceImage.Height;
                float k = w / h;

                if (size > h) size = h;

                int newH = Convert.ToInt32(size);
                int newW = Convert.ToInt32(newH * k);
                return ResizeImage(sourceImage, newW, newH);

            }
            static public Image SmartResize(Image sourceImage, int size)
            {
                float w = sourceImage.Width, h = sourceImage.Height;
                float k = w / h;
                int newW = size, newH = size;
                if (k > 1)
                    newH = Convert.ToInt32(size / k);
                else if (k < 1)
                    newW = Convert.ToInt32(size * k);
                return ResizeImage(sourceImage, newW, newH);

            }
            static public Image ResizeImage(Image sourceImage, int newWidth, int newHeight)
            {
                Image result = new Bitmap(newWidth, newHeight);
                Graphics g = Graphics.FromImage(result);
                g.DrawImage(sourceImage, 0, 0, newWidth, newHeight);
                return result;
            }
            static public Image GetImageFromURL(string URL)
            {
                Uri uri = new Uri(URL);
                return GetImageFromURL(uri);
            }

            static public Image GetImageFromURL(Uri url)
            {
                Image result;
                try
                {
                    Uri uri = url;
                    HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.CreateDefault(uri);
                    myHttpWebRequest.Method = "GET";
                    WebResponse response = myHttpWebRequest.GetResponse();
                    Stream readStream = response.GetResponseStream();
                    result = System.Drawing.Image.FromStream(readStream);
                }
                catch //(Exception ex)
                {
                    return null;
                }
                return result;
            }
        }
    }
}