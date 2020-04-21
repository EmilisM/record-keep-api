using System.Collections.Generic;
using Newtonsoft.Json;

namespace record_keep_api.DBO
{
    public partial class Image
    {
        public int Id { get; set; }
        public string Data { get; set; }

        public int CreatorId { get; set; }
        [JsonIgnore] public UserData Creator { get; set; }

        [JsonIgnore] public ICollection<UserData> ProfileImages { get; set; }
    }
}