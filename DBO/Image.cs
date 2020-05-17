using System.Collections.Generic;
using Newtonsoft.Json;

namespace record_keep_api.DBO
{
    public class Image
    {
        public int Id { get; set; }
        public string Data { get; set; }

        [JsonIgnore] public int CreatorId { get; set; }
        [JsonIgnore] public UserData Creator { get; set; }

        [JsonIgnore] public ICollection<UserData> Profiles { get; set; }
        [JsonIgnore] public ICollection<Collection> Collections { get; set; }
        [JsonIgnore] public ICollection<Record> Records { get; set; }
    }
}