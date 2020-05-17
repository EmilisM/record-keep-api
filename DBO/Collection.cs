using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace record_keep_api.DBO
{
    public class Collection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }

        public int OwnerId { get; set; }
        [JsonIgnore] public UserData Owner { get; set; }

        [JsonIgnore] public int? ImageId { get; set; }
        public Image Image { get; set; }

        [JsonIgnore] public ICollection<Record> Records { get; set; }

        [JsonIgnore] public ICollection<UserActivity> Activities { get; set; }
    }
}