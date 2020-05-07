using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using record_keep_api.DBO;
using record_keep_api.Models.UserActivity;

namespace record_keep_api.Services
{
    public class UserActivityService : IUserActivityService
    {
        private readonly DatabaseContext _databaseContext;

        public UserActivityService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task CreateActivityAsync(UserActivityActionName action, int userId, Collection collection = null,
            int? collectionId = null,
            Record record = null,
            int? recordId = null)
        {
            var storedAction = await _databaseContext.UserActivityActions.FirstAsync(u => u.Name == action);

            var userActivity = new UserActivity
            {
                OwnerId = userId,
                CollectionId = collectionId,
                RecordId = recordId,
                Record = record,
                Collection = collection,
                Action = storedAction,
                TimeStamp = DateTime.UtcNow
            };

            await _databaseContext.UserActivities.AddAsync(userActivity);

            await _databaseContext.SaveChangesAsync();
        }
    }
}