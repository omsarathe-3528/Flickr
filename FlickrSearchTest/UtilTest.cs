using FlickrSearch;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Resources;

namespace FlickrSearchTest
{
    [TestFixture]
    public class UtilTest
    {
        [Test]
        public void ResizeImageNullTest()
        {
            Image imgObj = Util.ResizeImage(null, 200, 150);

            Assert.IsNull(imgObj);
        }

        [Test]
        public void ResizeImageTest()
        {
            Image imgObj = new Bitmap(Resource.TestImage);
            Image img = Util.ResizeImage(imgObj, 200, 150);

            Assert.IsNotNull(img);
            Assert.AreNotEqual(0, imgObj.Width);
            Assert.AreNotEqual(0, imgObj.Width);
        }

        [Test]
        public void ResizeImageHeightWidthTest()
        {
            int x = 200;
            int y = 150;

            Image imgObj = new Bitmap(Resource.TestImage);
            Image newImage = Util.ResizeImage(imgObj, x, y);

            Assert.IsNotNull(newImage);
            Assert.LessOrEqual(newImage.Width, x);
            Assert.LessOrEqual(newImage.Height, y);
        }

        [Test]
        public void ResizeImageNoHeightWidthTest()
        {
            int x = 0;
            int y = 0;

            Image imgObj = new Bitmap(Resource.TestImage);
            Image newImage = Util.ResizeImage(imgObj, x, y);

            Assert.IsNull(newImage);
        }


        [Test]
        public void DownloadImageFromUrlInvalidURLTest(
            [Values(null,
            @"http://testWrongurl.com/img")] string input)
        {
            var img = Util.DownloadImageFromUrl(input);

            Assert.IsNull(img);
        }

        [Test]
        public void DownloadImageFromUrlTest()
        {
            var img = Util.DownloadImageFromUrl( @"http://farm66.staticflickr.com/65535/49849667543_b5df36c823_n.jpg");

            Assert.IsNotNull(img);
            Assert.IsInstanceOf(typeof(Image), img);
        }
    }
}
