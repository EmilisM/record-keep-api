using System;

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

        public int RecordTypeId { get; set; }
        public RecordType RecordType { get; set; }

        public int CollectionId { get; set; }
        public Collection Collection { get; set; }

        public int OwnerId { get; set; }
        public UserData Owner { get; set; }
    }
}