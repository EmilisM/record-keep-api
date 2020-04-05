using System;
using System.Collections.Generic;

namespace record_keep_api.DBO
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public partial class Collection
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

        public virtual UserData Owner { get; set; }
        public virtual ICollection<CollectionRecords> CollectionRecordsCollection { get; set; }
        public virtual ICollection<CollectionRecords> CollectionRecordsRecord { get; set; }
    }
}