using System.Collections.Generic;
using Newtonsoft.Json;

namespace record_keep_api.DBO
{
    public partial class Image
    {
        public Image()
        {
            Users = new HashSet<UserData>();
        }

        [JsonIgnore] public int Id { get; set; }
        public string Url { get; set; }

        [JsonIgnore] public ICollection<UserData> Users { get; set; }
    }
}