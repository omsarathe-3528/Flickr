using FlickrSearch;
using FlickrSearch.Controller;
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
    public class FlickrSearchServiceTextTest
    {
        private FlickrSearchRequest _request = null;
        private IService _service = null;


        [Test]
        public void GetResponseValidTextTest()
        {
            _request = new FlickrSearchRequest();
            _request.Text = "nature";
            _service = new FlickrSearchService(_request);

            var responseTask = _service.GetServiceResponse();

            responseTask.Wait();

            Assert.IsNotNull(responseTask.Result);

            Assert.AreEqual(Constants.SEARCH_OK, responseTask.Result.stat);

            Assert.IsNotNull(responseTask.Result.photos);
        }

        [Test]
        public void GetResponseBlankTextTest()
        {
            _request = new FlickrSearchRequest();
            _request.Text = "";
            _service = new FlickrSearchService(_request);

            var responseTask = _service.GetServiceResponse();

            responseTask.Wait();

            Assert.IsNotNull(responseTask.Result);

            Assert.AreEqual(Constants.SEARCH_FAIL, responseTask.Result.stat);
        }

        [Test]
        public void GetResponseTextNoResultTest()
        {
            _request = new FlickrSearchRequest();
            _request.Text = "dsdsfsdfsdfsf";
            _service = new FlickrSearchService(_request);

            var responseTask = _service.GetServiceResponse();

            responseTask.Wait();

            Assert.IsNotNull(responseTask.Result);

            Assert.AreEqual(Constants.SEARCH_OK, responseTask.Result.stat);

            Assert.AreEqual(0, responseTask.Result.photos.total);
        }
    }
}
