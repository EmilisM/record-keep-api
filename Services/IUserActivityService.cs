using System.Threading.Tasks;
using record_keep_api.DBO;
using record_keep_api.Models.UserActivity;

namespace record_keep_api.Services
{
    public interface IUserActivityService
    {
        Task CreateActivityAsync(UserActivityActionName action, int userId, Collection collection = null,
            int? collectionId = null,
            Record record = null,
            int? recordId = null);
    }
}