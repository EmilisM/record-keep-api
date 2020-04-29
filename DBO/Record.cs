using System;
using Newtonsoft.Json;

namespace record_keep_api.DBO
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public partial class Record
    {
        public int Id { get; set; }
        public string Artist { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }

        public int CollectionId { get; set; }
        [JsonIgnore] public Collection Collection { get; set; }

        [JsonIgnore] public int OwnerId { get; set; }
        [JsonIgnore] public UserData Owner { get; set; }
    }
}