using FlickrSearch.Model;
using System.Threading.Tasks;

namespace FlickrSearch.Controller
{
    public interface IService
    {
        Task<FlickrSearchResponse> GetServiceResponse();
    }
}
