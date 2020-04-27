using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace record_keep_api.DBO
{
    public sealed partial class UserData
    {
        [JsonIgnore] public int Id { get; set; }

        public string Email { get; set; }
        public string DisplayName { get; set; }
        [JsonIgnore] public string PasswordHash { get; set; }
        [JsonIgnore] public string PasswordSalt { get; set; }
        public DateTime CreationDate { get; set; }

        [JsonIgnore] public int? ProfileImageId { get; set; }
        public Image ProfileImage { get; set; }

        [JsonIgnore] public ICollection<Image> CreatedImages { get; set; }
        [JsonIgnore] public ICollection<Record> Records { get; set; }
    }
}