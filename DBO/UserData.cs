using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace record_keep_api.DBO
{
    public sealed partial class UserData
    {
        public UserData()
        {
            Collection = new HashSet<Collection>();
        }

        [JsonIgnore] public int Id { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
        [JsonIgnore] public string PasswordHash { get; set; }
        [JsonIgnore] public string PasswordSalt { get; set; }
        public DateTime CreationDate { get; set; }

        [JsonIgnore] public int? ImageId { get; set; }
        public Image Image { get; set; }

        [JsonIgnore] public ICollection<Collection> Collection { get; set; }
    }
}