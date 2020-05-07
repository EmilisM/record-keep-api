using System.Collections.Generic;
using Newtonsoft.Json;
using record_keep_api.Models.UserActivity;

namespace record_keep_api.DBO
{
    public class UserActivityAction
    {
        public int Id { get; set; }

        public UserActivityActionName Name { get; set; }

        [JsonIgnore] public ICollection<UserActivity> Activities { get; set; }
    }
}