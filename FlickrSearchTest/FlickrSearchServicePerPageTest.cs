using FlickrSearch;
using FlickrSearch.Controller;
using FlickrSearch.Model;
using NUnit.Framework;
using System;


namespace FlickrSearchTest
{
    [TestFixture]
    public class FlickrSearchServicePerPageTest
    {
        private FlickrSearchRequest _request = null;
        private IService _service = null;

        [Test]
        public void GetResponsePerPageTest([Values(0)]int input)
        {
            _request = new FlickrSearchRequest();
            _request.Text = "nature";
            _service = new FlickrSearchService(_request);

            var responseTask = _service.GetServiceResponse();

            responseTask.Wait();

            Assert.IsNotNull(responseTask.Result);

            Assert.AreEqual(Constants.SEARCH_OK, responseTask.Result.stat);

            Assert.IsNotNull(responseTask.Result.photos);

            Assert.AreEqual(100, responseTask.Result.photos.perpage);
        }

        [Test]
        public void GetResponsePerPageLimitTest([Values(10, 20, 50, 150, 95, 499, 350, 198, 500)]int input)
        {
            _request = new FlickrSearchRequest();
            _request.Text = "nature";
            _request.PerPage = (Int16)input;
            _service = new FlickrSearchService(_request);

            var responseTask = _service.GetServiceResponse();

            responseTask.Wait();

            Assert.IsNotNull(responseTask.Result);

            Assert.AreEqual(Constants.SEARCH_OK, responseTask.Result.stat);

            Assert.IsNotNull(responseTask.Result.photos);

            Assert.AreEqual(input, responseTask.Result.photos.perpage);
        }
    }
}
