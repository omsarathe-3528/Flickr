using NUnit.Framework;
using System;
using FlickrSearch.Controller;

namespace FlickrSearchTest
{
    [TestFixture]
    public class HttpResponseTest
    {
        [Test]
        public void GetAsyncWhenInvalidURL()
        {
            Uri input = new Uri(@"https://www.flickr.com/services/rest/?method=flickr.photos.search.invalid");
            IResponse httpResponse = new HttpResponse();

            var response = httpResponse.GetAsync(input);

            response.Wait();

            string res = response.Result;
            Assert.IsNotNull(res);
        }

        [Test]
        public void GetAsyncWhenValidURL()
        {
            Uri input = new Uri(@"https://www.flickr.com/services/rest/?method=flickr.photos.search&api_key=68181930883570499963da0414e39476&format=rest&auth_token=72157714190839907-fe7108c66ee0b1f0&api_sig=f28a734328646b64c5c30872bab6ab38");
            IResponse httpResponse = new HttpResponse();

            var response = httpResponse.GetAsync(input);

            response.Wait();

            string res = response.Result;
            Assert.IsNotNull(res);
        }

        [Test]
        public void GetAsyncWhenUriIsNull()
        {
            IResponse httpResponse = new HttpResponse();

            var response = httpResponse.GetAsync(null);

            response.Wait();

            string res = response.Result;
            Assert.IsNull(res);
        }
    }
}
