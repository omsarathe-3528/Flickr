using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickrSearch.Model
{
    public class FlickrSearchRequest
    {
        public string ApiKey { get; set; }
        public string UserId { get; set; }
        public string Tags { get; set; }
        public string TagMode { get; set; }
        public string Text { get; set; }
        public DateTime MinUploadDate { get; set; }
        public DateTime MaxUploaddate { get; set; }
        public DateTime MinTokenDate { get; set; }
        public DateTime MaxTokenDate { get; set; }
        public string License { get; set; }
        public string Sort { get; set; }
        public ePrivacyFilter PrivacyFilter { get; set; }
        public string BoundingBox { get; set; }
        public eAccuracy Accuracy { get; set; }
        public eSafeSearchSettings SafeSearch { get; set; }
        public eContentTypes ContentTypes { get; set; }
        public string MachineTags { get; set; }
        public string MachineTagMode { get; set; }
        public string GroupId { get; set; }
        public string Contacts { get; set; }
        public eSupportedFormat Format { get; set; }
        public Int32 WoeId { get; set; }
        public string PlaceId { get; set; }
        public eMediaTypes Media { get; set; }
        public bool HasGeo { get; set; }
        public eGeoContext GeoContext { get; set; }
        public double Lattitude { get; set; }
        public double Longitude { get; set; }
        public UInt16 Radius { get; set; }
        public string RadiusUnits { get; set; }
        public bool IsCommon { get; set; }
        public bool InGallary { get; set; }
        public bool IsGetty { get; set; }
        public List<eExtraInformation> Extras { get; set; }
        public Int16 PerPage { get; set; }
        public Int16 Page {get; set;}

        public Uri URI
        {
            get
            {
                return new Uri(getUrl());
            }
        }

        public string GetFormatAsString()
        {
            string retValue = Constants.JSON;
            switch (Format)
            {
                case eSupportedFormat.REST:
                    retValue = Constants.REST;
                    break;
                case eSupportedFormat.JSON:
                default:
                    retValue = Constants.JSON;
                    break;
            }
            return retValue;
        }

        private string getUrl()
        {
            string api_key = (string.IsNullOrEmpty(ApiKey) ? Constants.API_KEY : ApiKey);
            string url = string.Format(Constants.BASE_URI + Constants.PHOTO_SEARCH_URI, Constants.SEARCH_METHOD_NAME, api_key, GetFormatAsString());
            url += (Format == eSupportedFormat.JSON) ? "&nojsoncallback=1" : string.Empty;
            url += string.IsNullOrEmpty(Text) ? string.Empty : "&text=" + Text;
            url += string.IsNullOrEmpty(Tags) ? string.Empty : "&tags=" + Tags;
            url += (PerPage == 0 )? string.Empty : "&per_page=" + PerPage;

            return url;
        }
    }
}
