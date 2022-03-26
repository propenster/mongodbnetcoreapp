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
    public class FeedbackService : IFeedbackService
    {
        private readonly IMongoCollection<Feedback> _feedbacks;
        private readonly IMapper _mapper;
        public FeedbackService(IDbClient dbClient)
        {
            _feedbacks = dbClient.GetFeedbacksCollection();
        }

        public async Task<GenericResponse<Feedback>> InsertFeedback(FeedbackDto feedback)
        {
            try
            {
                var newFeedback = _mapper.Map<Feedback>(feedback);
                await _feedbacks.InsertOneAsync(newFeedback);

                return new GenericResponse<Feedback>
                {
                    Data = newFeedback,
                    Message = "Feedback created successfully",
                    Success = true,
                    StatusCode = HttpStatusCode.OK
                };


            }
            catch (Exception ex)
            {

                return new GenericResponse<Feedback>
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
