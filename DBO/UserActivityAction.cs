using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using record_keep_api.Models.UserActivity;

namespace record_keep_api.DBO
{
    public class UserActivityAction
    {
        public int Id { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public UserActivityActionName Name { get; set; }

        [JsonIgnore] public ICollection<UserActivity> Activities { get; set; }
    }
}