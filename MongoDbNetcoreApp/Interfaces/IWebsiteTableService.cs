using MongoDbNetcoreApp.Dtos;
using MongoDbNetcoreApp.Helpers;
using MongoDbNetcoreApp.Models;
using System.Threading.Tasks;

namespace MongoDbNetcoreApp.Interfaces
{
    public interface IWebsiteTableService
    {
        Task<GenericResponse<WebsiteTable>> InsertWebsiteTable(WebsiteTableDto websiteTable);
    }
}
