using NUnit.Framework;
using FlickrSearch.Model;
using FlickrSearch.Controller;
using FlickrSearch;

namespace FlickrSearchTest
{
    [TestFixture]
    public class FlickrSearchServiceTagTest
    {
        private FlickrSearchRequest _request = null;
        private IService _service = null;
        [Test]
        public void GetResponseFailTest()
        {
            _request = new FlickrSearchRequest();
            _service = new FlickrSearchService(_request);

            var responseTask = _service.GetServiceResponse();

            responseTask.Wait();

            Assert.IsNotNull(responseTask.Result);

            Assert.AreEqual(Constants.SEARCH_FAIL, responseTask.Result.stat);
        }

        [Test]
        public void GetResponseValidTagTest()
        {
            _request = new FlickrSearchRequest();
            _request.Tags = "nature";
            _service = new FlickrSearchService(_request);

            var responseTask = _service.GetServiceResponse();

            responseTask.Wait();

            Assert.IsNotNull(responseTask.Result);

            Assert.AreEqual(Constants.SEARCH_OK, responseTask.Result.stat);

            Assert.IsNotNull(responseTask.Result.photos);
        }

        [Test]
        public void GetResponseBlankTagTest()
        {
            _request = new FlickrSearchRequest();
            _request.Tags = "";
            _service = new FlickrSearchService(_request);

            var responseTask = _service.GetServiceResponse();

            responseTask.Wait();

            Assert.IsNotNull(responseTask.Result);

            Assert.AreEqual(Constants.SEARCH_FAIL, responseTask.Result.stat);
        }

        [Test]
        public void GetResponseTagNoResultTest()
        {
            _request = new FlickrSearchRequest();
            _request.Tags = "sdfsdfsdfsdfsfsds";
            _service = new FlickrSearchService(_request);

            var responseTask = _service.GetServiceResponse();

            responseTask.Wait();

            Assert.IsNotNull(responseTask.Result);

            Assert.AreEqual(Constants.SEARCH_OK, responseTask.Result.stat);

            Assert.AreEqual(0, responseTask.Result.photos.total);
        }


        [Test]
        public void GetResponseNullTest()
        {
            _request = null;
            _service = new FlickrSearchService(_request);

            var responseTask = _service.GetServiceResponse();

            responseTask.Wait();

            Assert.IsNull(responseTask.Result);
        }
    }
}
