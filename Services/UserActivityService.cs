﻿using System;
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
            var storedAction = await _databaseContext.UserActivityActions.FirstOrDefaultAsync(u => u.Name == action);

            if (storedAction == null)
            {
                throw new Exception(
                    "Database missing required activity action configurations or provided action is missing");
            }

            var userActivity = new UserActivity
            {
                OwnerId = userId,
                CollectionId = collectionId,
                RecordId = recordId,
                Record = record,
                Collection = collection,
                Action = storedAction,
                Timestamp = DateTime.UtcNow
            };

            await _databaseContext.UserActivities.AddAsync(userActivity);

            await _databaseContext.SaveChangesAsync();
        }
    }
}