using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FlickrSearch.Controller
{
    public class HttpResponse : IResponse
    {
        public Task<string> GetAsync(Uri uri)
        {
            return  GetHttpResponse(uri);
        }

        /*
         * Call the web service and get the response as string
         */
        private async Task<string> GetHttpResponse(Uri uri)
        {
            string result = null;
            if (uri != null)
            {
                try
                {
                    HttpClient client = new HttpClient();
                    result = await client.GetStringAsync(uri.ToString());
                }
                catch (Exception ex)
                {
                    Logger.WriteLog("Exception in function GetHttpResponse");
                    Logger.WriteLog(ex.Message);
                    Logger.WriteLog("URI " + uri.ToString());
                }
            }

            return result;
        }
    }
}
