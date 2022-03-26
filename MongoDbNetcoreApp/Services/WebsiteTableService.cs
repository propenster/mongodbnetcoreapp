using AutoMapper;
using MongoDB.Driver;
using MongoDbNetcoreApp.Data;
using MongoDbNetcoreApp.Dtos;
using MongoDbNetcoreApp.Helpers;
using MongoDbNetcoreApp.Interfaces;
using MongoDbNetcoreApp.Models;
using System;
using System.Net;
using System.Threading.Tasks;

namespace MongoDbNetcoreApp.Services
{
    public class WebsiteTableService : IWebsiteTableService
    {
        private readonly IMongoCollection<WebsiteTable> _websiteTables;
        private readonly IMapper _mapper;

        public WebsiteTableService(IDbClient dbClient)
        {
            _websiteTables = dbClient.GetWebsiteTablesCollection();
        }
        public async Task<GenericResponse<WebsiteTable>> InsertWebsiteTable(WebsiteTableDto websiteTable)
        {
            try
            {
                var newWebsiteTable = _mapper.Map<WebsiteTable>(websiteTable);
                await _websiteTables.InsertOneAsync(newWebsiteTable);

                return new GenericResponse<WebsiteTable>
                {
                    Data = newWebsiteTable,
                    Message = "New website table created successfully",
                    Success = true,
                    StatusCode = HttpStatusCode.OK
                };


            }
            catch (Exception ex)
            {

                return new GenericResponse<WebsiteTable>
                {
                    Data = null,
                    Message = ex.Message,
                    Success = false,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }
    }
}
