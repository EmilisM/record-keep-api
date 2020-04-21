using System;
using System.Collections.Generic;

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

        public UserData Owner { get; set; }
        public ICollection<CollectionRecords> CollectionRecordsCollection { get; set; }
        public ICollection<CollectionRecords> CollectionRecordsRecord { get; set; }
    }
}