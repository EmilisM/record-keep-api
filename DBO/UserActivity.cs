using System;
using Newtonsoft.Json;

namespace record_keep_api.DBO
{
    public class UserActivity
    {
        public int Id { get; set; }

        public DateTime Timestamp { get; set; }

        [JsonIgnore] public int OwnerId { get; set; }
        [JsonIgnore] public UserData Owner { get; set; }

        [JsonIgnore] public int ActionId { get; set; }
        public UserActivityAction Action { get; set; }

        [JsonIgnore] public int? CollectionId { get; set; }
        public Collection Collection { get; set; }

        [JsonIgnore] public int? RecordId { get; set; }
        public Record Record { get; set; }
    }
}