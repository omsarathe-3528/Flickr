using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FlickrSearch
{
    public class Constants
    {
        public const string PHOTO_URL = @"http://farm{0}.staticflickr.com/{1}/{2}_{3}_n.jpg";
        public const string LOG_FILE_NAME = "FlickrApp.log";
        public const string JSON = "json";
        public const string REST = "rest";
        public const string SEARCH_METHOD_NAME = "flickr.photos.search";
        public const string API_KEY = @"82379657b2ca36ab1a472c9428b53df6";
        public const string BASE_URI = @"https://api.flickr.com/services/rest/";
        public const string PHOTO_SEARCH_URI = @"?method={0}&api_key={1}&format={2}";
        public const string SEARCH_FAIL = "fail";
        public const string SEARCH_OK = "ok";
        public const UInt16 IMAGE_RESIZE_WIDTH = 150;
        public const UInt16 IMAGE_RESIZE_HEIGHT = 125;
    }

    public enum eSupportedFormat
    {
        JSON,
        REST
    }

    public enum ePrivacyFilter
    {
        PublicPhotos = 1,
        PrivatePhotosVisibleToFriends,
        PrivatePhotosVisibleToFamily,
        PrivatePhotosVisibleToFriendAndFamily,
        CompletelyPrivatePhotos
    }

    public enum eAccuracy
    {
        World = 1,
        Country = 3,
        Region = 6,
        City = 11,
        Street = 16
    }

    public enum eSafeSearchSettings
    {
        Safe = 1,
        Moderate,
        Restricted
    }

    public enum eContentTypes
    {
        Photos = 1,
        Screenshots,
        Other,
        PhotosAndScreenshots,
        ScreenshotsAndOther,
        PhotosAndOthers,
        PhotosScreenshotsAndOther
    }

    public enum eMediaTypes
    {
        All,
        Photos,
        Videos
    }

    public enum eGeoContext
    {
        NotDefined,
        Indoors,
        Outdoors
    }

    public enum eExtraInformation
    {
        Description,
        License,
        DateUpload,
        DateTaken,
        OwnerName,
        IconServer,
        OriginalFormat,
        LastUpdate,
        Geo,
        Tags,
        MachineTags,
        oDims,
        Views,
        Media,
        PathAlias,
        URLsq,
        URLt,
        URLs,
        URLq,
        URLm,
        URLn,
        URLz,
        URLc,
        URLl,
        URLo
    }
}
