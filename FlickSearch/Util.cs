using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace FlickrSearch
{
    public class Util
    {
        /*
         * Function to download flickr image from the given url
         */
        public static Image DownloadImageFromUrl(string imageUrl)
        {
            Image image = null;

            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(imageUrl);
                webRequest.AllowWriteStreamBuffering = true;
                webRequest.Timeout = 30000;

                WebResponse webResponse = webRequest.GetResponse();

                Stream stream = webResponse.GetResponseStream();

                image = Image.FromStream(stream);

                webResponse.Close();
            }
            catch
            {
                return null;
            }

            return image;
        }

        /*
        * Function to resize the image to max width and height by maitaining its aspect ratio
        */
        public static Image ResizeImage(Image img, int maxWidth, int maxHeight)
        {
            Image newImage = null;
            if (img != null && (maxHeight != 0 && maxWidth != 0))
            {
                var ratioX = (double)maxWidth / img.Width;
                var ratioY = (double)maxHeight / img.Height;
                var ratio = Math.Min(ratioX, ratioY);

                var newWidth = (int)(img.Width * ratio);
                var newHeight = (int)(img.Height * ratio);

                newImage = new Bitmap(newWidth, newHeight);

                using (var graphics = Graphics.FromImage(newImage))
                    graphics.DrawImage(img, 0, 0, newWidth, newHeight);
            }

            return newImage;
        }
    }
}
