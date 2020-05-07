using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickrSearch.Controller
{
    public interface IResponse
    {
        Task<string> GetAsync(Uri uri);
    }
}
