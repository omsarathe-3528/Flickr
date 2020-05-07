using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using FlickrSearch.Model;

namespace FlickrSearch.Controller
{
    public class FlickrSearchService : IService
    {
        private FlickrSearchRequest _request = null;
        private IResponse _httpResponse = null;
        public FlickrSearchService(FlickrSearchRequest request)
        {
            this._request = request;
            _httpResponse = new HttpResponse();
        }

        public async Task<FlickrSearchResponse> GetServiceResponse()
        {
            FlickrSearchResponse response = null;

            try
            {
                if (_httpResponse != null)
                {
                    var searchResults = await _httpResponse.GetAsync(_request.URI);

                    if (!string.IsNullOrEmpty(searchResults))
                    {
                        response = DeserializeResponse(searchResults);
                    }
                }
            }
            catch (Exception ex )
            {
                Logger.WriteLog("Exception in function GetServiceResponse");
                Logger.WriteLog(ex.Message);
            }
            return response;
        }

        /*
         * Deserialize the response received as JSON or XML
         */
        private FlickrSearchResponse DeserializeResponse(string responseString)
        {
            FlickrSearchResponse photoResults = null;
            try
            {
                if (_request.Format == eSupportedFormat.JSON)
                {
                    photoResults = JsonConvert.DeserializeObject<FlickrSearchResponse>(responseString);
                }
                else if (_request.Format == eSupportedFormat.REST)
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(FlickrSearchResponse));

                    using (var stringreader = new StringReader(responseString))
                    {
                        photoResults = (FlickrSearchResponse)serializer.Deserialize(stringreader);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Exception in function DeserializeResponse");
                Logger.WriteLog(ex.Message);
            }

            return photoResults;
        }
    }
}
