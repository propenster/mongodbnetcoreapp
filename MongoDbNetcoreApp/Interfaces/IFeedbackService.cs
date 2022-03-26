using MongoDbNetcoreApp.Dtos;
using MongoDbNetcoreApp.Helpers;
using MongoDbNetcoreApp.Models;
using System.Threading.Tasks;

namespace MongoDbNetcoreApp.Interfaces
{
    public interface IFeedbackService
    {
        Task<GenericResponse<Feedback>> InsertFeedback(FeedbackDto feedback);
    }
}
