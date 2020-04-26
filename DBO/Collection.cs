using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace record_keep_api.DBO
{
    public sealed partial class Collection
    {
        public Collection()
        {
            CollectionRecordsCollection = new HashSet<CollectionRecords>();
            CollectionRecordsRecord = new HashSet<CollectionRecords>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }

        public int OwnerId { get; set; }

        [JsonIgnore] public UserData Owner { get; set; }

        [JsonIgnore] public int? ImageId { get; set; }
        public Image Image { get; set; }

        [JsonIgnore] public ICollection<CollectionRecords> CollectionRecordsCollection { get; set; }

        [JsonIgnore] public ICollection<CollectionRecords> CollectionRecordsRecord { get; set; }
    }
}