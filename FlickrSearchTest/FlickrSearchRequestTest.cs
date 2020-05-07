using FlickrSearch;
using FlickrSearch.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickrSearchTest
{
    [TestFixture]
   public class FlickrSearchRequestTest
    {
        [Test]
        public void GetFormatAsStringDefaultTest()
        {
            FlickrSearchRequest request = new FlickrSearchRequest();
            string format = request.GetFormatAsString();

            Assert.AreEqual(Constants.JSON, format);
        }

        [Test]
        public void GetFormatAsStringRestTest()
        {
            FlickrSearchRequest request = new FlickrSearchRequest();
            request.Format = eSupportedFormat.REST;
            string format = request.GetFormatAsString();

            Assert.AreEqual(Constants.REST, format);
        }

        [Test]
        public void GetFormatAsStringJsonTest()
        {
            FlickrSearchRequest request = new FlickrSearchRequest();
            request.Format = eSupportedFormat.JSON;
            string format = request.GetFormatAsString();

            Assert.AreEqual(Constants.JSON, format);
        }
    }
}
